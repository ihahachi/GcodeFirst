using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GcodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void interface_list()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxInterfaces.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    string first = listBox1.Items[i].ToString();
                    string path = Application.StartupPath + @"\" + textBoxInterfaces.Text + "\\" + "I" + first + "Repository.cs";




                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            sw.WriteLine("using System.Threading.Tasks;");
                            sw.WriteLine("using " + textNamespace.Text + ";");
                            sw.WriteLine("");
                            sw.WriteLine("namespace " + textNamespace.Text + "." + textBoxInterfaces.Text);
                            sw.WriteLine("{");
                            sw.WriteLine("      public  interface I" + first + "Repository : IRepository<" + first + ">");
                            sw.WriteLine("      {");
                            sw.WriteLine("");
                            sw.WriteLine("      }");
                            sw.WriteLine("}");
                        }
                    }
                }
            }
            finally
            {

            }
        }

        private void Repository_list()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxRepositry.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    string first = listBox1.Items[i].ToString();
                    string path = Application.StartupPath + @"\" + textBoxRepositry.Text + "\\" + first + "Repository.cs";




                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            sw.WriteLine("using System.Threading.Tasks;");
                            sw.WriteLine("using " + textNamespace.Text + ";");
                            sw.WriteLine("");
                            sw.WriteLine("namespace " + textNamespace.Text + "." + textBoxRepositry.Text);
                            sw.WriteLine("{");
                            sw.WriteLine("      class " + first + textBoxRepositry.Text  + " : " + textBoxRepositry.Text  + "<" + first + ">, " + textBoxInterfaces.Text + ".I" + first + "Repository");
                            sw.WriteLine("      {");
                            sw.WriteLine("          public " + first + "Repository(" + textBoxDBContext.Text + " context) : base(context)");
                            sw.WriteLine("          {");
                            sw.WriteLine("          }");
                            sw.WriteLine("");
                            sw.WriteLine("          public " + textBoxDBContext.Text + " " + textBoxDBContext.Text + " { get { return Context as " + textBoxDBContext.Text + "; } }");
                            sw.WriteLine("      }");
                            sw.WriteLine("}");
                        }
                    }
                }
            }
            finally
            {

            }
        }

        private void Iunityofwork()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxUnityOfWork.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                string path3 = Application.StartupPath + @"\" + textBoxUnityOfWork.Text + "\\I" + textBoxUnityOfWork.Text + ".cs";



                if (File.Exists(path3) == false)
                {
                    using (StreamWriter sw = File.CreateText(path3))
                    {
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("using " + textNamespace.Text + "." + textBoxInterfaces.Text + ";");
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + textNamespace.Text);
                        sw.WriteLine("{");
                        sw.WriteLine("");
                        sw.WriteLine("  public interface I" + textBoxUnityOfWork.Text + " : IDisposable");
                        sw.WriteLine("  {");
                        for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                        {
                            string first = listBox1.Items[i].ToString();
                            sw.WriteLine("      I" + first + textBoxRepositry.Text + " " + first + " { get; }");
                        }
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("      int Complete();");
                        sw.WriteLine("  }");
                        sw.WriteLine("}");
                    }
                }



            }
            finally
            {

            }
        }

        private void Unityofwork()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxUnityOfWork.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                string path3 = Application.StartupPath + @"\" + textBoxUnityOfWork.Text + "\\" + textBoxUnityOfWork.Text + ".cs";



                if (File.Exists(path3) == false)
                {
                    using (StreamWriter sw = File.CreateText(path3))
                    {
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("using " + textNamespace.Text + "." + textBoxInterfaces.Text + ";");
                        sw.WriteLine("using " + textNamespace.Text + "." + textBoxRepositry.Text + ";");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + textNamespace.Text);
                        sw.WriteLine("{");
                        sw.WriteLine("");
                        sw.WriteLine("  public class " + textBoxUnityOfWork.Text  + " : I" + textBoxUnityOfWork.Text);
                        sw.WriteLine("  {");
                        sw.WriteLine("      protected readonly " + textBoxDBContext.Text + " _context;");
                        sw.WriteLine("");
                        sw.WriteLine("      public " + textBoxUnityOfWork.Text  + "(" + textBoxDBContext.Text + " Context)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          _context = Context;");
                        sw.WriteLine("");
                        for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                        {
                            string first = listBox1.Items[i].ToString();
                            sw.WriteLine("          " + first + " = new " + first + "Repository(Context);");
                        }
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                        {
                            string first = listBox1.Items[i].ToString();
                            sw.WriteLine("          public I" + first + "Repository " + first + " { get; private set; }");
                        }
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("        public int Complete()");
                        sw.WriteLine("        {");
                        sw.WriteLine("            return _context.SaveChanges();");
                        sw.WriteLine("        }");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("        public void Dispose()");
                        sw.WriteLine("        {");
                        sw.WriteLine("            _context.Dispose();");
                        sw.WriteLine("        }");
                        sw.WriteLine("  }");
                        sw.WriteLine("}");
                    }
                }



            }
            finally
            {

            }
        }

        private void IRepository()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxInterfaces.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                string path3 = Application.StartupPath + @"\" + textBoxInterfaces.Text + "\\I" + textBoxRepositry.Text + ".cs";



                if (File.Exists(path3) == false)
                {
                    using (StreamWriter sw = File.CreateText(path3))
                    {
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("using System.Linq.Expressions;");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + textNamespace.Text);
                        sw.WriteLine("{");
                        sw.WriteLine("");
                        sw.WriteLine("  public interface I" + textBoxRepositry.Text + "<TEntity> where TEntity : class");
                        sw.WriteLine("  {");
                        sw.WriteLine("      TEntity " + textFunctionGet.Text + "(int id);");
                        sw.WriteLine("      IEnumerable<TEntity> " + textFunctionGetAll.Text + "();");
                        sw.WriteLine("      IEnumerable<TEntity> " + textFunctionFind.Text + "(Expression<Func<TEntity, bool>> predicate);");
                        sw.WriteLine("");
                        sw.WriteLine("      void " + textFunctionAdd.Text + "(TEntity entity);");
                        sw.WriteLine("      void " + textFunctionAddRange.Text + "(IEnumerable<TEntity> entites);");
                        sw.WriteLine("      void " + textFunctionRemove.Text + "(TEntity entity);");
                        sw.WriteLine("      void " + textFunctionRemoveRange.Text + "(IEnumerable<TEntity> entites);");
                        sw.WriteLine("  }");
                        sw.WriteLine("}");
                    }
                }



            }
            finally
            {

            }
        }

        private void Repository()
        {
            try
            {
                string path2 = Application.StartupPath + @"\" + textBoxRepositry.Text + "\\";
                if (Directory.Exists(path2) == false)
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }

                string path3 = Application.StartupPath + @"\" + textBoxRepositry.Text + "\\" + textBoxRepositry.Text + ".cs";



                if (File.Exists(path3) == false)
                {
                    using (StreamWriter sw = File.CreateText(path3))
                    {
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("using System.Data.Entity;");
                        sw.WriteLine("using System.Linq.Expressions;");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + textNamespace.Text);
                        sw.WriteLine("{");
                        sw.WriteLine("");
                        sw.WriteLine("  public class " + textBoxRepositry.Text + "<TEntity> : I" + textBoxRepositry.Text + "<TEntity> where TEntity : class");
                        sw.WriteLine("  {");
                        sw.WriteLine("      protected readonly " + textBoxDBContext.Text + " _context;");
                        sw.WriteLine("");
                        sw.WriteLine("      public " + textBoxRepositry.Text + "(" + textBoxDBContext.Text + " Context)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          _context = Context;");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public void " + textFunctionAdd.Text + "(TEntity entity)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          Context.Set<TEntity>().Add(entity);");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public void " + textFunctionAddRange.Text + "(IEnumerable<TEntity> entites)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          Context.Set<TEntity>().AddRange(entites);");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public IEnumerable<TEntity> " + textFunctionFind.Text + "(Expression<Func<TEntity, bool>> predicate)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          return Context.Set<TEntity>().Where(predicate);");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public TEntity " + textFunctionGet.Text + "(int id)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          return Context.Set<TEntity>().Find(id);");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public IEnumerable<TEntity> " + textFunctionGetAll.Text + "()");
                        sw.WriteLine("      {");
                        sw.WriteLine("          return Context.Set<TEntity>().AsParallel().ToList();");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public void " + textFunctionRemove.Text + "(TEntity entity)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          Context.Set<TEntity>().Remove(entity);");
                        sw.WriteLine("      }");
                        sw.WriteLine("");
                        sw.WriteLine("      public void " + textFunctionRemoveRange.Text + "(IEnumerable<TEntity> entites)");
                        sw.WriteLine("      {");
                        sw.WriteLine("          Context.Set<TEntity>().RemoveRange(entites);");
                        sw.WriteLine("      }");
                        sw.WriteLine("  }");
                        sw.WriteLine("}");
                    }
                }



            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            interface_list();
            IRepository();
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Repository_list();
            Repository();
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Iunityofwork();
            this.Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Unityofwork();
            this.Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            interface_list();
            IRepository();
            Repository_list();
            Repository();
            Iunityofwork();
            Unityofwork();
            this.Cursor = Cursors.Default;
        }
    }
}
