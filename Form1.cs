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


        WebClient webss = new WebClient();
        public string JUSTLINK;
        public const string KEY = "";



        public string doGET(string URL)
        {
            string html = string.Empty;
            string url = URL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream)) { html = reader.ReadToEnd(); }
            return html;
        }
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
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                progressBar1.Show();
                progressBar1.Minimum = 1;
                progressBar1.Maximum = 20;
                progressBar1.Value = 1;
                progressBar1.Step = 1;
                string html = string.Empty;

                string user = textBox1.Text;
                progressBar1.PerformStep();
                string url = @"https://osu.ppy.sh/api/get_user?k=" + KEY + "&u=" + user;
                progressBar1.PerformStep();
                var JSONobj = new JavaScriptSerializer().Deserialize<List<osuUser.user>>(doGET(url));
                progressBar1.PerformStep();
                label5.Text = JSONobj[0].user_id + "    Username: " + JSONobj[0].username;
                progressBar1.PerformStep();
                label4.Text = JSONobj[0].pp_raw.ToString();
                progressBar1.PerformStep();
                label9.Text = JSONobj[0].level;
                progressBar1.PerformStep();
                label10.Text = JSONobj[0].pp_rank;
                progressBar1.PerformStep();
                label12.Text = JSONobj[0].pp_country_rank + " (" + JSONobj[0].country + ")";
                progressBar1.PerformStep();
                int howManyRanks;
                progressBar1.PerformStep();
                Int32.TryParse(textBox2.Text, out howManyRanks);
                progressBar1.PerformStep();
                int outss;
                Int32.TryParse(JSONobj[0].pp_country_rank, out outss);
                string nextPlayersID = getIDbyPos(outss - howManyRanks, JSONobj[0].country);
                string urls = @"https://osu.ppy.sh/api/get_user_best?k=" + KEY + "&u=" + nextPlayersID;
                var datUser = new JavaScriptSerializer().Deserialize<List<osuUser.beatmap>>(doGET(urls));
                string mapID = datUser[0].beatmap_id;
                progressBar1.PerformStep();


                string urlz = @"https://osu.ppy.sh/api/get_beatmaps?k=" + KEY + "&b=" + mapID;
                var datss = new JavaScriptSerializer().Deserialize<List<osuUser.beatset>>(doGET(urlz));

                progressBar1.PerformStep();
                linkLabel1.Text = "This is what you should play: " + datss[0].title + "  [" + datss[0].version + "]";
                JUSTLINK = "https://osu.ppy.sh/beatmapsets/" + datss[0].beatmapset_id;
                progressBar1.PerformStep();
                if (checkBox1.Checked)
                {
                    webss.DownloadFileCompleted += new AsyncCompletedEventHandler(isComplete);
                    Uri theLink = new Uri(JUSTLINK + "/download");
                    webss.DownloadDataAsync(theLink, "map.osz");
                }
                progressBar1.Value = progressBar1.Maximum;
                Thread.Sleep(2000);
                progressBar1.Hide();

            }
            //   string scorePage = doGET

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
            progressBar1.Hide();
        }
        public int getPage(int position)
        {
            position--;
            return (position / 50) + 1;
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        private string getIDbyPos(int pos, string country)
        {
            string src = doGET("https://old.ppy.sh/p/pp/?c=" + country + "&m=0&s=3&o=1&f=&page=" + getPage(pos));
            string findUser = getBetween(src, "<td><b>#" + pos + "</b></td>", "</tr>");
            findUser = getBetween(findUser, "<td>", "</td>");
            findUser = getBetween(findUser, "u/", "'");
            return findUser;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(JUSTLINK);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox2.Text))
                textBox2.Text = "0";
            int x; Int32.TryParse(textBox2.Text, out x);
            if (x > 3000)
                textBox2.Text = 3000.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                string message = "This is a BETA feature! Are you sure you want to use it?";
                string caption = "Warning!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                if (result == DialogResult.No)
                    checkBox1.Checked = false;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {


            using (var client = new WebClient())
            {
                client.DownloadFile("https://osu.ppy.sh/beatmapsets/104801/download", "map.osz");
            }


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