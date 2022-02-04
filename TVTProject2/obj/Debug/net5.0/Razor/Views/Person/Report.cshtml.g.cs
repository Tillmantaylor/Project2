#pragma checksum "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4175c04667f843ba4ff5770ee8dc2e608c6d1d6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_Report), @"mvc.1.0.view", @"/Views/Person/Report.cshtml")]
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
#line 1 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\_ViewImports.cshtml"
using TVTProject2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\_ViewImports.cshtml"
using TVTProject2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\_ViewImports.cshtml"
using TVTProject2.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4175c04667f843ba4ff5770ee8dc2e608c6d1d6b", @"/Views/Person/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd42b974b3aef47996020574de978bfa46fd9e97", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TVTProject2.Models.ViewModels.PersonReportVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
  
    ViewData["Title"] = "Report";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
 foreach(var person in Model.people)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h3>");
#nullable restore
#line 10 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
       Write(person.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <h4>Number of Project: ");
#nullable restore
#line 11 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
                          Write(person.Projects.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <h4>Total Hourly Rate: ");
#nullable restore
#line 12 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
                          Write(person.HourlyRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <div>\r\n");
#nullable restore
#line 14 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
             foreach(var project in person.Projects)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <span class=\"pr-2 border-right border-dark\">Project Name: ");
#nullable restore
#line 17 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
                                                                         Write(project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <span class=\"pr-2 border-right border-dark\">Project Role: ");
#nullable restore
#line 18 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
                                                                         Write(project.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <span>Hourly Rate: ");
#nullable restore
#line 19 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
                                  Write(project.HourlyRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n");
#nullable restore
#line 21 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Users\Jake\Source\Repos\Project2\TVTProject2\Views\Person\Report.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4175c04667f843ba4ff5770ee8dc2e608c6d1d6b6971", async() => {
                WriteLiteral("Back to Home Page");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TVTProject2.Models.ViewModels.PersonReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591