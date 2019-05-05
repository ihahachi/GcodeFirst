## About GcodeFirst

it is tool for generator code for Microsoft Entity Framework to support repository, unit of work patterns, multiple database.


## Why the UnitOfWork and Repository pattern?

he UnitOfWork and repository patterns are intended to act like a abstraction layer between business logic and data access layer.
This can help insulate your application from changes in the data store and can facilitate automated unit testing / test driven development.


<a href="https://imgur.com/4Q0GBl0"><img src="https://i.imgur.com/4Q0GBl0.png" title="source: imgur.com" /></a>

### Example generator code

#### DbContext:

```csharp
public class MyDbContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public MyDbContext(string nameOrConnectionString)
        : base(nameOrConnectionString)
    {
    }
}
```

#### The Generic Repository:

```csharp
public interface IRepository<T> where T : class
{
   IQueryable<T> Entities { get; }
   void Remove(T entity);
   void Add(T entity);
}
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly MyDbContext _dbContext;
    private IDbSet<T> _dbSet => _dbContext.Set<T>();
    public IQueryable<T> Entities => _dbSet;
    public GenericRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
}
```


#### The UnitOfWork

```csharp
public interface IUnitOfWork
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }

    /// <summary>
    /// Commits all changes
    /// </summary>
    void Commit();
    /// <summary>
    /// Discards all changes that has not been commited
    /// </summary>
    void RejectChanges();
    void Dispose();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _dbContext;
    #region Repositories
    public IRepository<Author> AuthorRepository => 
       new GenericRepository<Author>(_dbContext);
    public IRepository<Book> BookRepository => 
       new GenericRepository<Book>(_dbContext);
    #endregion
    public UnitOfWork(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Commit()
    {
        _dbContext.SaveChanges();
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }
    public void RejectChanges()
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries()
              .Where(e => e.State != EntityState.Unchanged))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.Reload();
                    break;
            }
        }
    }
}
```



### Usage

```csharp
var dbContext = new MyDbContext("{connectionString goes here}");
var unitOfWork = new UnitOfWork(dbContext);
```

#### Selecting some entities

```csharp
var books = unitOfWork.BookRepository.Entities
    .Where(n => n.Title == "Hello World");
var justOneBook = unitOfWork.BookRepository.Entities
    .First(n => n.ID == 1);
```

#### Create

```csharp
// Create
var author = new Author() { Name = "Kris" };
unitOfWork.AuthorRepository.Add(author);
unitOfWork.Commit(); // Save changes to database
```


#### Update

```csharp
// Update
var author = unitOfWork.AuthorRepository.Entities
    .First(n => n.Name == "Kris");
author.Name = "Dan";
unitOfWork.Commit(); // Save changes to database
```


#### Delete

```csharp
// Delete
var author = unitOfWork.AuthorRepository.Entities
    .First(n => n.Name == "Dan");
unitOfWork.AuthorRepository.Remove(author);
unitOfWork.Commit(); // Save changes to database
```


#### Reject Changes

```csharp
// Delete
var author = unitOfWork.AuthorRepository.Entities
    .First(n => n.Name == "Dan");
unitOfWork.AuthorRepository.Remove(author);
// Ops i don't want to do this
unitOfWork.RejectChanges(); // Reject all changes
```


## License

The GcodeFirst  is open-sourced software licensed under the [MIT license](http://opensource.org/licenses/MIT)
