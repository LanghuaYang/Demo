using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public delegate void writetextbox(string s);
        public void f(string s)
        {
        }
        public Form1()
        {
            InitializeComponent();
        }
        public void writetext1()
        { }
        public void writetext2()
        { }
        private void label1_Click(object sender, EventArgs e)
        {
            string s = "abc";
            string s1 = "bcd";
            string s2 = string.Format("{0}{1}{2}{3}",s,s1,"hello","heihei");
            string s3 = s ?? s1; // set s3 to s if s is not null
            writetextbox wtb = new writetextbox(f);
            wtb.Invoke("1");//equals to wtb(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 非泛型数组
            ArrayList arraylist = new ArrayList();

            // 泛型数组
            List<int> genericlist = new List<int>();
            IEnumerable
        }
    }
}
