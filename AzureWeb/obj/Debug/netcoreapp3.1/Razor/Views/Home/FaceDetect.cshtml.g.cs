#pragma checksum "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\FaceDetect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06c838becdde615f34da02d760d66cbed2f9768e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FaceDetect), @"mvc.1.0.view", @"/Views/Home/FaceDetect.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\_ViewImports.cshtml"
using AzureWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\_ViewImports.cshtml"
using AzureWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06c838becdde615f34da02d760d66cbed2f9768e", @"/Views/Home/FaceDetect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30ffd0d1b8307535ea63b2b122398e28a4e732e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FaceDetect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\FaceDetect.cshtml"
  
    ViewData["Title"] = "FaceDetect";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>FaceDetect</h1>


<label><span>請輸入網址:</span></label>
<input class=""form-control"" id=""faceUrl"" value=""https://i.ytimg.com/vi/3tyNQmhcDN4/maxresdefault.jpg"" />

        <div class=""card mb-3"" style=""max-width: 540px;"">
            <div class=""row g-0"">
                <div class=""col-md-4"">
                    <img id=""face"" class=""img-thumbnail w-100"" src=""https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOVcUZxwN0Qvm80RC8pocds1_XNxs-1cWawQ&usqp=CAU""  alt=""..."">
                </div>
                <div class=""col-md-8"">
                    <div class=""card-body"">
                        <h5 class=""card-title"">Card title</h5>
                        <p class=""card-text"">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                        <p class=""card-text""><small class=""text-muted"">Last updated 3 mins ago</small></p>
                    </div>
                </div>
            </div>
     ");
            WriteLiteral(@"   </div>
  
    
<button class=""btn-outline-primary"" onclick=""faceDetect()"">Detect</button>
<div class=""form-group"">
    <img class=""img-thumbnail"" id=""face"" src=""https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOVcUZxwN0Qvm80RC8pocds1_XNxs-1cWawQ&usqp=CAU"" />
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function faceDetect() {
            $(""#face"").attr(""src"", $(""#faceUrl"").val());
     
        var params = {
            // Request parameters
            ""returnFaceId"": ""true"",
            ""returnFaceLandmarks"": ""false"",
            ""returnFaceAttributes"": ""age, gender, emotion"",
            ""recognitionModel"": ""recognition_04"",
            ""returnRecognitionModel"": ""false"",
            ""detectionModel"": ""detection_01"",
            ""faceIdTimeToLive"": ""86400"",
        };

        var data = {
            url: $(""#faceUrl"").val()
        };


        $.ajax({
            url: ""https://msit143000face.cognitiveservices.azure.com/face/v1.0/detect?"" + $.param(params),
            beforeSend: function (xhrObj) {
                // Request headers
                xhrObj.setRequestHeader(""Content-Type"", ""application/json"");
                xhrObj.setRequestHeader(""Ocp-Apim-Subscription-Key"", ""3176efd4c2014aa7903981e7d0c143b6"");
            },
            type: ""POS");
                WriteLiteral(@"T"",
            // Request body
            data: JSON.stringify(data),
        })
            .done(function (data) {
                //    alert(JSON.stringify(data));
                var gender = data[0][""faceAttributes""][""gender""];
                var age = data[0][""faceAttributes""][""age""];
                var emotion = data[0][""faceAttributes""][""emotion""];
                var MaxEmotion = 0;
                var MaxEmotionName = """";
                $.each(emotion, function (name, value) {
                    if (value > MaxEmotion) {
                        MaxEmotion = value;
                        MaxEmotionName = name;
                    }
                });
                alert(`性別:${gender},年齡:${age}, 情緒: ${MaxEmotionName}, 情緒指數: ${(MaxEmotion * 100).toFixed(2)} %`);
                }).fail(function (err) {
                    alert(err.responseText);
                });
        }

    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
