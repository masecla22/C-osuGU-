﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;








namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string JUSTLINK;
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
        public const string KEY = "wednesdaymydudes";
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
                string html = string.Empty;
                string user = textBox1.Text;
                string url = @"https://osu.ppy.sh/api/get_user?k=" + KEY + "&u=" + user;
                var JSONobj = new JavaScriptSerializer().Deserialize<List<osuUser.user>>(doGET(url));
                label5.Text = JSONobj[0].user_id + "    Username: " + JSONobj[0].username;
                label4.Text = JSONobj[0].pp_raw.ToString();
                label9.Text = JSONobj[0].level;
                label10.Text = JSONobj[0].pp_rank;
                label12.Text = JSONobj[0].pp_country_rank + " (" + JSONobj[0].country + ")";


                int outss;
                Int32.TryParse(JSONobj[0].pp_country_rank, out outss);
                string nextPlayersID = getIDbyPos(outss - 4, JSONobj[0].country);
                string urls = @"https://osu.ppy.sh/api/get_user_best?k=" + KEY + "&u=" + nextPlayersID;
                var datUser = new JavaScriptSerializer().Deserialize<List<osuUser.beatmap>>(doGET(urls));
                string mapID = datUser[0].beatmap_id;



                string urlz = @"https://osu.ppy.sh/api/get_beatmaps?k=" + KEY + "&b=" + mapID;
                var datss = new JavaScriptSerializer().Deserialize<List<osuUser.beatset>>(doGET(urlz));

                linkLabel1.Text = "This is what you should play: " + datss[0].title + "  [" + datss[0].version + "]";
                JUSTLINK = "https://osu.ppy.sh/beatmapsets/" + datss[0].beatmapset_id;


            }
            //   string scorePage = doGET

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