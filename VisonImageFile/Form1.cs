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

namespace VisonImageFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] ImageData = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                ImageData = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("尚未選擇欲分析的圖片");
            }
            else
            {
                //preview
                HttpClient client = new HttpClient();
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


                //============================================ 改傳2進位內容
                JObject data = new JObject { ["url"] = txtFileName.Text };
                string json = JsonConvert.SerializeObject(data);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage jsonResponse = await client.PostAsync(uri, stringContent);
                jsonResponse.EnsureSuccessStatusCode();
                string result = await jsonResponse.Content.ReadAsStringAsync();

                //============================================


                //MessageBox.Show(result);
                dynamic description = JsonConvert.DeserializeObject(result);

                JObject ImageContent = description as JObject;
                string Text = Convert.ToString(ImageContent["description"]["captions"][0]["text"]);
                float Confidence = Convert.ToSingle(ImageContent["description"]["captions"][0]["confidence"]);
                MessageBox.Show($"圖片內容:{Text}, 信心指數:{Confidence * 100:n2}%");
            }
        }


    }
}
