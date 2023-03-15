
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using bookApp.Models;
using bookApp.Models.ViewModels;

namespace bookApp.Infrastructure {
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PaginationHelper : TagHelper {

        private IUrlHelperFactory uhf;
        public PaginationHelper(IUrlHelperFactory temp) { uhf = temp; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PagesInfoModel pageModel { get; set; }
        public string pageAction { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho) {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("ul");
            final.Attributes["class"] = "pagination";

            for (int i = 1; i <= pageModel.totalPages; i++) {
                TagBuilder tbLI = new TagBuilder("li");
                TagBuilder tbA = new TagBuilder("a");

                if (i == pageModel.currentPage) {
                    tbLI.Attributes["class"] = "page-item active";
                }
                else {
                    tbLI.Attributes["class"] = "page-item";
                }
                tbLI.Attributes["id"] = pageAction.ToString();
                tbA.Attributes["href"] = uh.Action(pageAction, new { pageNum = i });
                tbA.Attributes["class"] = "page-link";
                tbA.InnerHtml.Append(i.ToString());

                tbLI.InnerHtml.AppendHtml(tbA);
                final.InnerHtml.AppendHtml(tbLI);
            }
            tho.Content.AppendHtml(final);
        }
    }
}
