using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace invertMD5HashCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string binaryString ="";
            string reversedBinaryString = "";
            string tempHolder = "";
            string invertedMD5Hash = "";
            foreach(char c in richTextBox1.Text)
            {
                binaryString += Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4,'0');
            }
            richTextBox2.Text = binaryString;

            foreach(char c in binaryString)
            {
                switch(c)
                {
                    case '0': reversedBinaryString += '1'; break;
                    case '1': reversedBinaryString += '0'; break;
                }
                
            }
            richTextBox3.Text = reversedBinaryString;

            //tempHolder = reversedBinaryString[0].ToString();

            List<string> splittedBinary = new List<string>();

            

            int counter = 1;

            splittedBinary.Add(reversedBinaryString.Substring(0, 4));

            foreach (char c in reversedBinaryString)
            {
                if(counter % 4 == 0)
                {
                    try
                    {
                        splittedBinary.Add(reversedBinaryString.Substring(counter, 4));
                    }
                    catch
                    {

                    }
                    
                }
                counter++;
            }

            for (int i=0; i < splittedBinary.Count; i++)
            {
                invertedMD5Hash += Convert.ToString(Convert.ToInt32(splittedBinary[i], 2), 16);
            }
            richTextBox4.Text = invertedMD5Hash;
        }
    }
}
