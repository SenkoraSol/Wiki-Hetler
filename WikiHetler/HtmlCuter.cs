using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki_Hitler
{
    static class HtmlCuter
    {

        static public IEnumerable<string> AngleSharpParse(string Html)
        {

            List<string> hrefTags = new List<string>();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(Html);
            //var betterDocument = document.GetElementById("bodyContent");

            foreach (IElement Testdocument in document.QuerySelectorAll("p"))
            {
                foreach (IElement element in Testdocument.QuerySelectorAll("a"))
                {
                    if (element.GetAttribute("title") != "" && element.GetAttribute("title") != null)
                    {

                        hrefTags.Add(element.GetAttribute("title"));
                    }
                }
            }

            return hrefTags;
        }
    }
}
