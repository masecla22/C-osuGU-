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
    public partial class UserControl1 : UserControl
    {

        WebClient webss = new WebClient();
        public string JUSTLINK;
        public const string KEY = "f1b362fdd7062aed3f8e5fd48a5316a49875b504";

        public UserControl1()
        {
            InitializeComponent();
        }
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
        private string getIDbyPos(int pos, string country)
        {
            string src = doGET("https://old.ppy.sh/p/pp/?c=" + country + "&m=0&s=3&o=1&f=&page=" + getPage(pos));
            string findUser = getBetween(src, "<td><b>#" + pos + "</b></td>", "</tr>");
            findUser = getBetween(findUser, "<td>", "</td>");
            findUser = getBetween(findUser, "u/", "'");
            return findUser;
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
        private void mapFind_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                string html = string.Empty;
                string user = textBox1.Text;
                string url = @"https://osu.ppy.sh/api/get_user?k=" + KEY + "&u=" + user;
                var JSONobj = new JavaScriptSerializer().Deserialize<List<osuUser.user>>(doGET(url));
                int outss;
                Int32.TryParse(JSONobj[0].pp_country_rank, out outss);
                string nextPlayersID = getIDbyPos(outss - 4, JSONobj[0].country);
                string urls = @"https://osu.ppy.sh/api/get_user_best?k=" + KEY + "&u=" + nextPlayersID;
                var datUser = new JavaScriptSerializer().Deserialize<List<osuUser.beatmap>>(doGET(urls));
                string mapID = datUser[0].beatmap_id;
                string urlz = @"https://osu.ppy.sh/api/get_beatmaps?k=" + KEY + "&b=" + mapID;
                var datss = new JavaScriptSerializer().Deserialize<List<osuUser.beatset>>(doGET(urlz));
                mapName.Text = "Map name: "  + datss[0].title;
                difficultyName.Text ="Difficulty: "+ datss[0].version;
                JUSTLINK = "https://osu.ppy.sh/beatmapsets/" + datss[0].beatmapset_id;
                mapInfo.Show();

            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            mapInfo.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(JUSTLINK);
        }
    }
}
//            if (String.IsNullOrEmpty(textBox2.Text))
//textBox2.Text = "0";
 //           int x; Int32.TryParse(textBox2.Text, out x);
  //          if (x > 3000)
   //             textBox2.Text = 3000.ToString();
