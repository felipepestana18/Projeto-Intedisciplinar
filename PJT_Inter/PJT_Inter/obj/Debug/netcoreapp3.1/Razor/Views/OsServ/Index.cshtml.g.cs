#pragma checksum "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2477ecb60a63347d52fdab9e8f8c46896c8ecd15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OsServ_Index), @"mvc.1.0.view", @"/Views/OsServ/Index.cshtml")]
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
#line 1 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\_ViewImports.cshtml"
using PJT_Inter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\_ViewImports.cshtml"
using PJT_Inter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2477ecb60a63347d52fdab9e8f8c46896c8ecd15", @"/Views/OsServ/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37880ce461336e9aaf543db08add0c48ede4994e", @"/Views/_ViewImports.cshtml")]
    public class Views_OsServ_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OsServ>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OsServ", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">
                Lista de Serviços da Ordem de Serviço
                    <a class=""btn btn-primary"" style=""float: right""");
            BeginWriteAttribute("href", " href=\"", 281, "\"", 317, 2);
            WriteAttributeValue("", 288, "/OsServ/Create/", 288, 15, true);
#nullable restore
#line 7 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
WriteAttributeValue("", 303, ViewBag.id_Os, 303, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Adicionar</a>\r\n     \r\n            </h6>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2477ecb60a63347d52fdab9e8f8c46896c8ecd154873", async() => {
                WriteLiteral(@"
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col"">Serviço</th>
                        <th scope=""col"">Status</th>
                        <th scope=""col"">Editar</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 21 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
                     foreach (var oss in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
#nullable restore
#line 24 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
                                       Write(oss.NomeServico);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th scope=\"row\">");
#nullable restore
#line 25 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
                                       Write(oss.statusNome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th>\r\n");
                WriteLiteral("\r\n                                <a class=\"btn btn-info btn-circle btn-sm\"");
                BeginWriteAttribute("href", " href=\"", 1226, "\"", 1281, 4);
                WriteAttributeValue("", 1233, "/OsServ/Update/?P1=", 1233, 19, true);
#nullable restore
#line 29 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
WriteAttributeValue("", 1252, oss.Os_Id, 1252, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1262, "&P2=", 1262, 4, true);
#nullable restore
#line 29 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
WriteAttributeValue("", 1266, oss.Servico_Id, 1266, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fas fa-info-circle\"></i>\r\n                                </a>\r\n                            </th>\r\n                        </tr>    \r\n");
#nullable restore
#line 34 "D:\Users\HankZ\Projetos C#\PJT_Inter\PJT_Inter\Views\OsServ\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    \r\n                </tbody>\r\n            </table>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n<a class=\"btn btn-primary\" href=\"/OrdemServico/Index\">Voltar</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OsServ>> Html { get; private set; }
    }
}
#pragma warning restore 1591