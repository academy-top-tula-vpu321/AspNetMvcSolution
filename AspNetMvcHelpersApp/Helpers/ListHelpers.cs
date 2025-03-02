using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace AspNetMvcHelpersApp.Helpers
{
    public static class ListHelpers
    {
        public static HtmlString CreateUList(this IHtmlHelper htmlHelper, 
                                            string[] items)
        {
            string list = $"<ul class='list-group'>";

            foreach (string item in items)
                list += $"<li class='list-group-item'>{item}</li>";

            list += "</ul>";

            return new HtmlString(list);
        }

        public static HtmlString CreateOList(this IHtmlHelper htmlHelper,
                                            string[] items)
        {
            TagBuilder ol = new TagBuilder("ol");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.Attributes.Add("class", "list-group-item");
                li.InnerHtml.Append(item);
                ol.InnerHtml.AppendHtml(li);
            }
            ol.Attributes.Add("class", "list-group");

            using StringWriter writerHtml = new();
            ol.WriteTo(writerHtml, HtmlEncoder.Default);
            return new HtmlString(writerHtml.ToString());
        }
    }
}
