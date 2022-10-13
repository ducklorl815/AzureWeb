#pragma checksum "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\ImageDetectContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0ea9db90137e54e5ffbaa9f5714817b8636bbc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ImageDetectContent), @"mvc.1.0.view", @"/Views/Home/ImageDetectContent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0ea9db90137e54e5ffbaa9f5714817b8636bbc7", @"/Views/Home/ImageDetectContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30ffd0d1b8307535ea63b2b122398e28a4e732e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ImageDetectContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\ImageDetectContent.cshtml"
  
    ViewData["Title"] = "ImageDetect";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ImageDetect</h1>\r\n\r\n<label><span>請選取圖形檔案</span></label>\r\n<input class=\"form-control\" id=\"imageFile\" type=\"file\" />\r\n\r\n");
            WriteLiteral("\r\n\r\n<button class=\"btn-outline-primary\" onclick=\"imageDetect()\">Detect</button>\r\n<div class=\"form-group\">\r\n    <img class=\"img-thumbnail\" id=\"image\"");
            BeginWriteAttribute("src", " src=\"", 985, "\"", 991, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var imageBuffer;
        document.querySelector(""#imageFile"").addEventListener(""change"", function () {
            var reader = new FileReader();
            reader.onload = function () {
                imageBuffer = this.result;
                var blob = new Blob([imageBuffer], { type: ""image/jpg"" });
                var urlCreator = window.URL || window.webkitURL;
                var imageUrl = urlCreator.createObjectURL(blob);
                $(""#image"").attr(""src"", imageUrl);
            };
            reader.readAsArrayBuffer(this.files[0]);
        })




        function imageDetect() {
            //====================
            $(""#image"").attr(""src"", $(""#imageUrl"").val());
            //====================
        var params = {
            // Request parameters
            ""visualFeatures"":""Description"",
            //queryString[""details""] = ""{string}"";
            ""language"": ""en"",
            ""model-version"":""latest"",
        };

        ");
                WriteLiteral(@"$.ajax({
            url: ""https://msit14306p2.cognitiveservices.azure.com/vision/v3.2/analyze?"" + $.param(params),
            beforeSend: function (xhrObj) {
                // Request headers
                xhrObj.setRequestHeader(""Content-Type"", ""application/octet-stream"");
                xhrObj.setRequestHeader(""Ocp-Apim-Subscription-Key"", ""b2cfc22bd8b24b8cb15a8c5906c5ed96"");
            },
            type: ""POST"",
            processData:false,
            // Request body
            data: imageBuffer,
        })
            .done(function (data) {
                //    alert(JSON.stringify(data));
                var text = data[""description""][""captions""][0][""text""];
                var confidence = data[""description""][""captions""][0][""confidence""];
                alert(`內容:${text}, 信心指數: ${(confidence * 100).toFixed(2)} %`);
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