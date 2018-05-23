using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Threading;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private FormWindowState m_WindowState = FormWindowState.Normal;
        private Rectangle m_FormSizeAndLocation = Rectangle.Empty;
        private void ChangeWindowState(FormWindowState p_NewState)
        {
            this.WindowState = FormWindowState.Normal;
            switch (p_NewState)
            {
                case FormWindowState.Maximized:
                    // if in normal mode we remind window size and location
                    if (m_WindowState == FormWindowState.Normal)
                    {
                        m_FormSizeAndLocation.Location = this.Location;
                        m_FormSizeAndLocation.Size = this.Size;
                    }
                    // make our form to be borderless in Maximized mode
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    // calculate the window dimensions manually to prevent overlap the taskbar
                    this.Size = SystemInformation.WorkingArea.Size;
                    this.Location = SystemInformation.WorkingArea.Location;
                    break;
                case FormWindowState.Minimized:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case FormWindowState.Normal:
                    // make our form Sizeable by code
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    // Return to previous state values for window ocation & size
                    this.Location = m_FormSizeAndLocation.Location;
                    this.Size = m_FormSizeAndLocation.Size;
                    break;
            }
            // to remind our last WindowState mode applied
            m_WindowState = p_NewState;
        }
        public int contor = 1;
        public void setActiveP(Panel which)
        {
            which.Show();
            which.BackColor = Color.FromArgb(205, 0, 205);
        }
        public void setInactiveP(Panel which)
        {
            which.Hide();
        }
        private bool m_MousePressed = false;
        private int m_oldX, m_oldY;
        void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Point TS = this.PointToScreen(e.Location);
            m_oldX = TS.X;
            m_oldY = TS.Y;
            m_MousePressed = true;
        }
        void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            m_MousePressed = false;
        }
        void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            // if not maximized we can move our form
            if (m_MousePressed == true && m_WindowState != FormWindowState.Maximized)
            {
                Point TS = this.PointToScreen(e.Location);

                this.Location = new Point(this.Location.X + (TS.X - m_oldX),
                                          this.Location.Y + (TS.Y - m_oldY));
                m_oldX = TS.X;
                m_oldY = TS.Y;
            }
        }
        public Form1()
        {
            InitializeComponent();
            panel3.MouseDown += new MouseEventHandler(panel3_MouseDown);
            panel3.MouseMove += new MouseEventHandler(panel3_MouseMove);
            panel3.MouseUp += new MouseEventHandler(panel3_MouseUp);
            setActiveP(panel1);
            setInactiveP(panel11);
            userControl31.Visible = false;
            userControl41.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        public void isComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("hello");
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
            string newHtml = String.Empty;
            int compareCount = 0;
            for (int i = 0; i < HTML.Length; i++)
            {
                compareCount += boolToInt(HTML[i] == '>' || HTML[i] == '<');
                if (compareCount % 2 == 0 && (HTML[i] != '<' && HTML[i] != '>'))
                    newHtml += HTML[i];
            }
            return newHtml;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            setActiveP(panel1);
            setInactiveP(panel7);
            setInactiveP(panel11);
            userControl11.Visible = true;
            userControl31.Visible = false;
            userControl41.Visible = false;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setActiveP(panel11);
            setInactiveP(panel1);
            setInactiveP(panel7);
            userControl11.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            setActiveP(panel7);
            setInactiveP(panel1);
            setInactiveP(panel11);
            userControl11.Visible = false;
            userControl31.Visible = true;
            userControl41.Visible = false;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://patreon.com/Quintickle");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Quintickle");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCfr2K-Dsz_lL_U0f010JWJA");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (contor % 2 == 1)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            contor++;
        }
    }
}

namespace osuUser
{
    public class user
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string count300 { get; set; }
        public string count100 { get; set; }
        public string count50 { get; set; }
        public string playcount { get; set; }
        public string ranked_score { get; set; }
        public string total_score { get; set; }
        public string pp_rank { get; set; }
        public string level { get; set; }
        public string pp_raw { get; set; }
        public string accuracy { get; set; }
        public string count_rank_ss { get; set; }
        public string count_rank_ssh { get; set; }
        public string count_rank_s { get; set; }
        public string count_rank_sh { get; set; }
        public string count_rank_a { get; set; }
        public string country { get; set; }
        public string pp_country_rank { get; set; }
        public object[] events { get; set; }
    }

    public class beatmap
    {
        public string beatmap_id { get; set; }
        public string score { get; set; }
        public string maxcombo { get; set; }
        public string count50 { get; set; }
        public string count100 { get; set; }
        public string count300 { get; set; }
        public string countmiss { get; set; }
        public string countkatu { get; set; }
        public string countgeki { get; set; }
        public string perfect { get; set; }
        public string enabled_mods { get; set; }
        public string user_id { get; set; }
        public string date { get; set; }
        public string rank { get; set; }
        public string pp { get; set; }
    }


    public class beatset
    {
        public string approved { get; set; }
        public string approved_date { get; set; }
        public string last_update { get; set; }
        public string artist { get; set; }
        public string beatmap_id { get; set; }
        public string beatmapset_id { get; set; }
        public string bpm { get; set; }
        public string creator { get; set; }
        public string difficultyrating { get; set; }
        public string diff_size { get; set; }
        public string diff_overall { get; set; }
        public string diff_approach { get; set; }
        public string diff_drain { get; set; }
        public string hit_length { get; set; }
        public string source { get; set; }
        public string genre_id { get; set; }
        public string language_id { get; set; }
        public string title { get; set; }
        public string total_length { get; set; }
        public string version { get; set; }
        public string file_md5 { get; set; }
        public string mode { get; set; }
        public string tags { get; set; }
        public string favourite_count { get; set; }
        public string playcount { get; set; }
        public string passcount { get; set; }
        public string max_combo { get; set; }
    }



}