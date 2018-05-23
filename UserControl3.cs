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
    public partial class UserControl3 : UserControl
    {
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
        public const string KEY = "f1b362fdd7062aed3f8e5fd48a5316a49875b504";
        public UserControl3()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                string link = @"https://osu.ppy.sh/api/get_user?k="+KEY+"&u="+textBox1.Text;
               var json = new JavaScriptSerializer().Deserialize<List<osuUser.user>>(doGET(link));
                label2.Text = "Username: " + json[0].username+"   ID: "+json[0].user_id;
                label3.Text = "Rank: " + json[0].pp_rank + "  Local Rank: " + json[0].pp_country_rank + " (" + json[0].country + ")";
                label4.Text = "Level: " + json[0].level+"    PP: "+json[0].pp_raw;
                label5.Text = "Ranked Score/Total Score:  " + json[0].ranked_score + "/" + json[0].total_score;
                label6.Text = "Hits of 300: "+json[0].count300+"  100: "+ json[0].count100+" 50: "+ json[0].count50;
                label7.Text = "Playcount: "+ json[0].playcount+"   Silver SS: "+ json[0].count_rank_ssh+"  Silver S: "+json[0].count_rank_sh+" SS: "+json[0].count_rank_ss + " S: " + json[0].count_rank_s + " A: " + json[0].count_rank_a;
                panel1.Visible = true;
            }
        }
    }
}
