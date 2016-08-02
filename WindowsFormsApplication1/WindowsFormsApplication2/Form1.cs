using System;
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
        CheckAccount acc;
        public Form1()
        {
            InitializeComponent();
            acc = new CheckAccount();
            acc.Balance = 1000.0;
            this.balance.Text = acc.Balance.ToString();
            acc[10] = new Person("langhua"); //using indexer
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            acc.withdraw(Double.Parse(this.amount.Text));
            this.balance.Text = acc[10].Name;//using indexer
            this.balance.Text = acc.Balance.ToString();
        }
    }
}
