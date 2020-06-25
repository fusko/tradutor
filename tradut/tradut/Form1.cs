using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace tradut
{
    public partial class Form1 : Form
    {
        // public Class1 tradutor;
        private Tradutor tradutor;
        public Form1()
        {
            InitializeComponent();
            tradutor = new Tradutor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text= tradutor.Traduzir(textBox1.Text);            
            
        



        }

        static string[] Quebra(string texto)
        {
            
            return texto.Split('\r');
        }


       

        public string tiraComments()
        {
            var regex = new Regex(@"\/\/\s(.*)", RegexOptions.IgnoreCase);
            string result = regex.Replace(textBox1.Text,"");
            return result;
        }
    }

   
}
