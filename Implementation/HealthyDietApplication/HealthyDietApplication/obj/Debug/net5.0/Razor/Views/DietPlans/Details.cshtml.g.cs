#pragma checksum "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "627594193c2ee496006c3bb5b1517a083e319f68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DietPlans_Details), @"mvc.1.0.view", @"/Views/DietPlans/Details.cshtml")]
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
#line 1 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\_ViewImports.cshtml"
using HealthyDietApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\_ViewImports.cshtml"
using HealthyDietApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"627594193c2ee496006c3bb5b1517a083e319f68", @"/Views/DietPlans/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96e469806999e97b05bd2812591a098ee701a452", @"/Views/_ViewImports.cshtml")]
    public class Views_DietPlans_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HealthyDiet.Domain.Domain.Diet>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/fontawesome/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/fontawesome/css/fontawesome.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/fontawesome/css/fontawesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DietPlans", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChooseDietForUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
  
    ViewData["Title"] = "Diet Plan - " + Model.Name;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--    Font Awesome CSS Import   -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "627594193c2ee496006c3bb5b1517a083e319f686982", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "627594193c2ee496006c3bb5b1517a083e319f688097", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "627594193c2ee496006c3bb5b1517a083e319f689212", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<!--    Main Part   -->

<div class=""container my-5 mx-auto"">
    <div class=""row mx-5"">
        <div class=""col-12 mx-4 portfolio-item"">
            <div class=""card h-100"">
                <a href=""#"">
                    <img class=""card-img-top""");
            BeginWriteAttribute("src", " src=\"", 663, "\"", 686, 1);
#nullable restore
#line 20 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
WriteAttributeValue("", 669, Model.PictureURL, 669, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         style=\"height: 550px;\" />\r\n                </a>\r\n                <div class=\"card-body\">\r\n                    <h1 class=\"card-title text-center\">\r\n                        ");
#nullable restore
#line 25 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                    <p class=\"card-text text-center mt-3 bg-white\">");
#nullable restore
#line 27 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                              Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <div class=\"row text-white\">\r\n                        <div class=\"col\">\r\n                            <div class=\"mt-1 mb-5 text-center\" style=\"font-size: 50px;\">\r\n");
#nullable restore
#line 31 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                  
                                    double average = 0.0;
                                    double avgInt = 0.0;
                                    if (Model.Diets != null && Model.Diets.Count != 0)
                                    {
                                        foreach (var userDiets in Model.Diets)
                                        {
                                            average += userDiets.Rating;
                                        }

                                        average /= Model.Diets.Count;
                                        average = Math.Round(average, 2);

                                        avgInt = (int)average;
                                    }

                                    for (int i = 0; i < avgInt; i++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fa fa-star checked\" style=\"color: orange;\"></span>\r\n");
#nullable restore
#line 50 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                    }
                                    for (int i = 0; i < 5 - avgInt; i++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fa fa-star text-dark\"></span>\r\n");
#nullable restore
#line 54 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <br />\r\n                                    <h2 class=\"text-center text-dark lead\">Average Rating: ");
#nullable restore
#line 56 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                      Write(average);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
            WriteLiteral("                            </div>\r\n                            <div class=\"row text-dark mt-3\">\r\n");
#nullable restore
#line 60 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                  
                                    int counter = 1;
                                    double sumCalories = 0;
                                    foreach (var day in Model.Days)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""col-4"">
                                            <div class=""card mb-3"">
                                                                                <div class=""card-header"" style=""background-color: #e1e1e1;"">
                                                                                    <b class=""lead"">Day ");
#nullable restore
#line 68 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                                   Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                                                                                </div>\r\n                                                <div class=\"card-body\">\r\n                                                    <ul class=\"list-group text-dark\">\r\n");
#nullable restore
#line 72 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                         foreach (var victual in day.Victuals)
                                                        {
                                                            var calories = victual.Victual.NumberCalories * victual.Quantity;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <li class=\"list-group-item d-flex justify-content-between align-items-center\">\r\n                                                                ");
#nullable restore
#line 77 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                           Write(victual.Victual.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                <span class=\"badge badge-info badge-pill text-right\">x ");
#nullable restore
#line 78 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                                                  Write(victual.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 78 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                                                                      Write(calories);

#line default
#line hidden
#nullable disable
            WriteLiteral(" kcal</span>\r\n                                                            </li>\r\n");
#nullable restore
#line 80 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"

                                                            sumCalories += calories;
                                                            
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </ul>\r\n");
#nullable restore
#line 85 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                      
                                                        counter++;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </div>\r\n                                                <div class=\"card-footer text-right\">\r\n                                                    <b class=\"lead\">");
#nullable restore
#line 90 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                               Write(sumCalories);

#line default
#line hidden
#nullable disable
            WriteLiteral(" kcal</b> \r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 94 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"

                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                    </div>

                    <div class=""row mb-1 mt-3"">
                        <div class=""col-12"">
                            <div class=""card my-4"">
                                <div class=""card-body text-dark"">
                                    <p class=""mb-1 lead""><b>Length:</b> ");
#nullable restore
#line 105 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                   Write(Model.LengthDays);

#line default
#line hidden
#nullable disable
            WriteLiteral(" days</p>\r\n                                    <hr class=\"text-secondary my-2\" />\r\n                                    <p class=\"my-1 lead\"><b>Weight Loss approx:</b> ");
#nullable restore
#line 107 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                               Write(Model.WeightLoss);

#line default
#line hidden
#nullable disable
            WriteLiteral(" kg</p>\r\n                                    <hr class=\"text-secondary my-2\" />\r\n                                    <p class=\"my-1 lead\"><b>Times chosen:</b> ");
#nullable restore
#line 109 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                         Write(Model.Diets.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" times</p>\r\n                                    <hr class=\"text-secondary my-2\" />\r\n                                    <p class=\"mt-1 lead\"><b>Intensity:</b> ");
#nullable restore
#line 111 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                      Write(Model.Intensity);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"row\">\r\n");
#nullable restore
#line 118 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                         if (User.Identity.IsAuthenticated)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-6"">
                            <button type=""button"" class=""btn btn-block btn-primary"" data-toggle=""modal"" data-target=""#exampleModalCenter"">Choose Diet</button>

                            <!-- Modal -->
                            <div class=""modal fade"" id=""exampleModalCenter"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
                                <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                                    <div class=""modal-content"">
                                        <div class=""modal-header"">
                                            <h5 class=""modal-title"" id=""exampleModalLongTitle"">Choose ");
#nullable restore
#line 128 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" as Active</h5>
                                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                <span aria-hidden=""true"">&times;</span>
                                            </button>
                                        </div>
                                        <div class=""modal-body"">
                                            Are you sure you want to choose this diet as your current active? You previous chosen diet is going to be stored as finished.
                                        </div>
                                        <div class=""modal-footer"">
                                            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cancel</button>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "627594193c2ee496006c3bb5b1517a083e319f6825232", async() => {
                WriteLiteral("Save Changes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-dietPlanId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 138 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                                                                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dietPlanId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-dietPlanId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dietPlanId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <div class=""col-6"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "627594193c2ee496006c3bb5b1517a083e319f6828125", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 148 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
                        } else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-12\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "627594193c2ee496006c3bb5b1517a083e319f6829980", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 153 "C:\Users\Nick\Documents\GitHub\Healthy_Diet\Implementation\HealthyDietApplication\HealthyDietApplication\Views\DietPlans\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HealthyDiet.Domain.Domain.Diet> Html { get; private set; }
    }
}
#pragma warning restore 1591
