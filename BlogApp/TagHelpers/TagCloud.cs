using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.TagHelpers
{
    [HtmlTargetElement("tag-cloud", Attributes = "name")]
    public class CommentBoxTagHelper : TagHelper
    {

        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.Content.AppendHtml($"<div class='ui labeled button' tabindex='0'><ul><li><button class='btn btn-lg'>{Name}</button></li></ul></div>");

            base.Process(context, output);
        }
    }
}