using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure
{
    //Specifiy what kind of html element we are accessing and with what attribute: 
    [HtmlTargetElement("div", Attributes = "page-blah")]
    public class PaginationTagHelper : TagHelper
    {
        //Goal: Dynamically create page links
        private IUrlHelperFactory uhf;
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        // create an html attribute that allows it to be dynamic...I think
        [HtmlAttributeNotBound]

        public ViewContext vc { get; set; }

        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }
        //added from chapter 7
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageBlah.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pagenum = i });

                // added this from chapter 7 to use the boostrap classes
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBlah.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }


                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);

        }


    }
}
