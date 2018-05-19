using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pp = textBox2.Text;
            string username = textBox1.Text;
            bool isUsername = false;
            try { Int32.Parse(username); isUsername = false; } catch (FormatException) { isUsername = true; } //decide whether it is a username or an id!
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string isPP = textBox2.Text;
            for (int i = 0; i < isPP.Length; i++)
            {
                if (!isNumber(isPP[i]))
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                }
            }
            int x = 0;
            Int32.TryParse(isPP, out x);
            if (x > 10000)
            {
                textBox2.Text = "9999";
            }
        }
        private bool isNumber(char a)
        {
            if (a == '0' || a == '1' || a == '2' || a == '3' || a == '4' || a == '5' || a == '6' || a == '7' || a == '8' || a == '9') { return true; }
            else { return false; }

        }
        private int boolToInt(bool x)
        {
            if (x == false)
                return 0;
            else
                return 1;
        }
        private string stripTags(string HTML)
        {
            string newHtml=String.Empty;
            int compareCount = 0;
            for(int i=0;i<HTML.Length;i++)
            {
                compareCount += boolToInt(HTML[i] == '>' || HTML[i] == '<');
                if (compareCount % 2 == 0 && (HTML[i] != '<' && HTML[i] != '>')) 
                    newHtml += HTML[i];
            }
            return newHtml;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string html = string.Empty;
            string url = "https://osu.ppy.sh/users/7177173";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Console.WriteLine(stripTags(html));
        }
    }
}
