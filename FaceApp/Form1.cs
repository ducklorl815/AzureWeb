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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FaceApp
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
                MessageBox.Show("OK~");
            }
            else
            {
                HttpClient client = new HttpClient();
                using (HttpResponseMessage Response = await client.GetAsync(txtUrl.Text))
                {
                    Response.EnsureSuccessStatusCode();
                    using (Stream imgStream = await Response.Content.ReadAsStreamAsync())
                    {
                        pictureBox1.Image = Image.FromStream(imgStream);
                    }
                    client = new HttpClient();
                    var queryString = HttpUtility.ParseQueryString(string.Empty);

                    // Request headers
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "3176efd4c2014aa7903981e7d0c143b6");

                    // Request parameters
                    queryString["returnFaceId"] = "true";
                    queryString["returnFaceLandmarks"] = "false"; //五官位置
                    queryString["returnFaceAttributes"] = "age, gender, emotion"; //偵測條件
                    queryString["recognitionModel"] = "recognition_04"; //辨識模型
                    queryString["returnRecognitionModel"] = "false";
                    queryString["detectionModel"] = "detection_01"; //偵測模型
                    queryString["faceIdTimeToLive"] = "86400"; //86400>>一天
                    var uri = "https://msit143000face.cognitiveservices.azure.com/face/v1.0/detect?" + queryString;

                    JObject data = new JObject { ["url"] = txtUrl.Text };
                    string json = JsonConvert.SerializeObject(data);
                    StringContent stringContent = new StringContent(json, Encoding.UTF8,"application/json");
                    HttpResponseMessage jsonResponse = await client.PostAsync(uri, stringContent);
                    jsonResponse.EnsureSuccessStatusCode();
                    string result = await jsonResponse.Content.ReadAsStringAsync();
                    //MessageBox.Show(result);
                    dynamic faces = JsonConvert.DeserializeObject(result);
                    foreach (var item in faces)
                    {
                        JObject face = item as JObject; 
                        int age = Convert.ToInt32(face["faceAttributes"]["age"]); 
                        string gender = Convert.ToString(face["faceAttributes"]["gender"]);
                        JObject emotion = JObject.Parse(Convert.ToString(face["faceAttributes"]["emotion"]));

                        float MaxEmotion = 0;
                        string MaxEmotionName = "";

                        foreach (JProperty prop in emotion.Properties())
                        {
                            float PropertyValue = float.Parse(Convert.ToString(emotion[prop.Name]));
                            if (PropertyValue > MaxEmotion)
                            {
                                MaxEmotion=PropertyValue;
                                MaxEmotionName = prop.Name;
                            }
                        }
                        MessageBox.Show($"性別:{gender}\n年齡:{age}\n情緒:{MaxEmotionName}\n信心指數:{MaxEmotion * 100:n2}%");
                    }

                }
            }
        }
    }
}
