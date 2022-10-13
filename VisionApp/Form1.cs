using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace VisionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                MessageBox.Show("請輸入圖片網址");
            }
            else
            {
                //preview
                HttpClient client = new HttpClient();
                using (HttpResponseMessage Response = await client.GetAsync(txtUrl.Text))
                {
                    Response.EnsureSuccessStatusCode();
                    using (Stream imgStream = await Response.Content.ReadAsStreamAsync())
                    {
                        pictureBox1.Image = Image.FromStream(imgStream);
                    }
                }

                //detect
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b2cfc22bd8b24b8cb15a8c5906c5ed96");
                //3176efd4c2014aa7903981e7d0c143b6

                 // Request parameters
                 queryString["visualFeatures"] = "Description"; //描述
                //queryString["details"] = "{string}";
                queryString["language"] = "en";
                queryString["model-version"] = "latest";
                var uri = "https://msit14306p2.cognitiveservices.azure.com/vision/v3.2/analyze?" + queryString;
                //14300vision
                JObject data = new JObject { ["url"] = txtUrl.Text };
                string json = JsonConvert.SerializeObject(data);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage jsonResponse = await client.PostAsync(uri, stringContent);
                jsonResponse.EnsureSuccessStatusCode();
                string result = await jsonResponse.Content.ReadAsStringAsync();
                //MessageBox.Show(result);


                dynamic description = JsonConvert.DeserializeObject(result);

                JObject ImageContent = description as JObject;
                string Text = Convert.ToString(ImageContent["description"]["captions"][0]["text"]);
                float Confidence = Convert.ToSingle(ImageContent["description"]["captions"][0]["confidence"]);
                MessageBox.Show($"圖片內容:{Text}, 信心指數:{Confidence*100:n2}%");





            }
        }
    }
}
