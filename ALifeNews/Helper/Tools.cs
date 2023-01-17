using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ALifeNews.Helper
{
    public class Tools
    {
        public static string ConvertToHtml(string text)
        {
            string html = text;

            string pattern;

            pattern = "(\\[b\\])(.*?)(\\[/b\\])";
            html = Regex.Replace(html, pattern, "<b>$2</b>");

            pattern = "(\\[u\\])(.*?)(\\[/u\\])";
            html = Regex.Replace(html, pattern, "<u>$2</u>");

            pattern = "(\\[a\\])(.*?)(\\[/a\\]\\[n\\])(.*?)(\\[/n\\])";
            html = Regex.Replace(html, pattern, "<a href='$2' target='_blank'>$4</a>");

            pattern = "(\\[e\\])(.*?)(\\[/e\\]\\[n\\])(.*?)(\\[/n\\])";
            html = Regex.Replace(html, pattern, "<a href='mailto:$2' target='_blank'>$4</a>");

            pattern = "(\\[a\\])(.*?)(\\[/a\\])";
            html = Regex.Replace(html, pattern, "<a href='$2' target='_blank'>$2</a>");

            pattern = "(\\[e\\])(.*?)(\\[/e\\])";
            html = Regex.Replace(html, pattern, "<a href='mailto:$2' target='_blank'>$2</a>");

            //Noncapturing Groups
            //The following grouping construct does not capture the substring that is matched by a subexpression:
            //(?: subexpression)

            pattern = @"(\[i\])(?:\[w\:(\d+)\])(?:\[h\:(\d+)\])(?:\[alt\:(.+)\])(.*?)(\[/i\])";
            html = Regex.Replace(html, pattern, "<img src='$5' width='$2' height='$3' alt='$4'>");

            pattern = @"(\[br\])";
            html = Regex.Replace(html, pattern, "<br>");

            html = html.Replace("\n", "\n<br/>");

            return (html);
        }

        public static string AddBoldUnderLine(string text)
        {
            string html = "<b><u>" + text + "</u></b>";
            return (html);
        }
    }
}