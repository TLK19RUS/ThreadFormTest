using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Class1 cl1 = null;
        Class1 cl2 = null;

        public void set_text(String text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    textBox1.Text += text + "\r\n";
                }));
            }
            else
            {
                textBox1.Text += text + "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cl1 = new Class1("Поток 1", 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cl1 != null)
            {
                cl1.stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cl2 = new Class1("Поток 2", 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cl2 != null)
            {
                cl2.stop();
            }
        }
    }
}
