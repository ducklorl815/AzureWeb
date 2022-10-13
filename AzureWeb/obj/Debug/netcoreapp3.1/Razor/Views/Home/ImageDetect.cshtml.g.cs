#pragma checksum "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\ImageDetect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b57d788aa9741dc9460603339b54a5cb926a5bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ImageDetect), @"mvc.1.0.view", @"/Views/Home/ImageDetect.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b57d788aa9741dc9460603339b54a5cb926a5bc", @"/Views/Home/ImageDetect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30ffd0d1b8307535ea63b2b122398e28a4e732e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ImageDetect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Student\Documents\AzureWeb\AzureWeb\Views\Home\ImageDetect.cshtml"
  
    ViewData["Title"] = "ImageDetect";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>ImageDetect</h1>

<label><span>請輸入網址:</span></label>
<input class=""form-control"" id=""imageUrl"" value=""https://a-z-animals.com/media/2021/12/How-Long-Do-Lions-Live-header.jpg"" />

<div class=""card mb-3"" style=""max-width: 540px;"">
    <div class=""row g-0"">
        <div class=""col-md-4"">
            <img id=""image"" class=""img-thumbnail w-100"" src=""https://a-z-animals.com/media/2021/12/How-Long-Do-Lions-Live-header.jpg"" alt=""..."">
        </div>
        <div class=""col-md-8"">
            <div class=""card-body"">
                <h5 class=""card-title"">Card title</h5>
                <p class=""card-text"">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                <p class=""card-text""><small class=""text-muted"">Last updated 3 mins ago</small></p>
            </div>
        </div>
    </div>
</div>


<button class=""btn-outline-primary"" onclick=""faceDetect()"">Detect</button>
<div class=""form-group"">
    ");
            WriteLiteral("<img class=\"img-thumbnail\" id=\"image\" src=\"https://static.theprint.in/wp-content/uploads/2021/04/yawning-lion.jpg?compress=true&quality=80&w=376&dpr=2.6\" />\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function faceDetect() {
            $(""#face"").attr(""src"", $(""#faceUrl"").val());

        var params = {
            // Request parameters
            ""visualFeatures"":""Description"",
            //queryString[""details""] = ""{string}"";
            ""language"": ""en"",
            ""model-version"":""latest"",
        };

        var data = {
            url: $(""#imageUrl"").val()
        };


        $.ajax({
            url: ""https://msit14306p2.cognitiveservices.azure.com/vision/v3.2/analyze?"" + $.param(params),
            beforeSend: function (xhrObj) {
                // Request headers
                xhrObj.setRequestHeader(""Content-Type"", ""application/json"");
                xhrObj.setRequestHeader(""Ocp-Apim-Subscription-Key"", ""b2cfc22bd8b24b8cb15a8c5906c5ed96"");
            },
            type: ""POST"",
            // Request body
            data: JSON.stringify(data),
        })
            .done(function (data) {
                //    alert(JSON.stringify(d");
                WriteLiteral(@"ata));
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