using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ALifeNews.Helper
{
    public class StudyPlan
    {

        public static string GetHtmlByIssueNum(int issueNum, Constants.LanguageType languageType)
        {
            if (issueNum < -1) return ("");
            string[] contents = bookContents.Split('\n');
            //if ((issueNum * 7) > contents.Length) return ("");
            if (issueNum == -1 || issueNum == 0) issueNum = 1;

            string html = "";
            string pattern, urlPart;
            pattern = "chineses\\=(.*?)\\&chap";

            for (int i=0; i<7; i++)
            {
                string line = contents[((issueNum - 1) * 7 + i) % contents.Length];
                string[] parts = line.Split('\t');
                if (languageType == Constants.LanguageType.Chinese)
                {
                    urlPart = parts[2];
                    Regex r = new Regex(pattern);
                    Match m = r.Match(urlPart);
                    if (m.Success)
                    {
                        string chChap = m.Groups[1].Value;
                        //Encode Chinese characters 
                        urlPart = urlPart.Replace(chChap, HttpUtility.UrlEncode(chChap));
                    }
                    html += parts[0] + " " + parts[1] + " <a href='" + urlPart + "' target='_blank'>link</a><br>\n";
                }
                else
                {
                    string engWebUrl = "https://www.biblegateway.com/passage/?search=";
                    string engQueryPostfix = "&version=NIV";
                    string engFinalUrl = engWebUrl + HttpUtility.UrlEncode(parts[4]) + engQueryPostfix;
                    
                    html += parts[3] + " " + parts[4] + " <a href='" + engFinalUrl + "' target='_blank'>link</a><br>\n";
                }
                
            }
            return (html);
        }

        static string bookContents = @"1/1	太 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=1	1/1	Matthew 1
1/2	太 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=2	1/2	Matthew 2
1/3	太 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=3	1/3	Matthew 3
1/4	太 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=4	1/4	Matthew 4
1/5	太 5:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=5&sec=1-20	1/5	Matthew 5:1-20
1/6	太 5:21-48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=5&sec=21-48	1/6	Matthew 5:21-48
1/7	太 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=6	1/7	Matthew 6
1/8	太 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=7	1/8	Matthew 7
1/9	太 8:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=8&sec=1-22	1/9	Matthew 8:1-22
1/10	太 8:23-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=8&sec=23-34	1/10	Matthew 8:23-34
1/11	太 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=9	1/11	Matthew 9
1/12	太 10:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=10&sec=1-20	1/12	Matthew 10:1-20
1/13	太 10:21-42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=10&sec=21-42	1/13	Matthew 10:21-42
1/14	太 11:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=11&sec=1-19	1/14	Matthew 11:1-19
1/15	太 11:20-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=11&sec=20-30	1/15	Matthew 11:20-30
1/16	太 12:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=12&sec=1-21	1/16	Matthew 12:1-21
1/17	太 12:22-50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=12&sec=22-50	1/17	Matthew 12:22-50
1/18	太 13:1-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=13&sec=1-35	1/18	Matthew 13:1-35
1/19	太 13:36-58	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=13&sec=36-58	1/19	Matthew 13:36-58
1/20	太 14:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=14&sec=1-21	1/20	Matthew 14:1-21
1/21	太 14:22-36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=14&sec=22-36	1/21	Matthew 14:22-36
1/22	太 15:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=15&sec=1-20	1/22	Matthew 15:1-20
1/23	太 15:21-39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=15&sec=21-39	1/23	Matthew 15:21-39
1/24	太 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=16	1/24	Matthew 16
1/25	太 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=17	1/25	Matthew 17
1/26	太 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=18	1/26	Matthew 18
1/27	太 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=19	1/27	Matthew 19
1/28	太 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=20	1/28	Matthew 20
1/29	太 21:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=21&sec=1-22	1/29	Matthew 21:1-22
1/30	太 21:23-46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=21&sec=23-46	1/30	Matthew 21:23-46
1/31	太 22:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=22&sec=1-22	1/31	Matthew 22:1-22
2/1	太 22:23-46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=22&sec=23-46	2/1	Matthew 22:23-46
2/2	太 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=23	2/2	Matthew 23
2/3	太 24:1-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=24&sec=1-35	2/3	Matthew 24:1-35
2/4	太 24:36-51	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=24&sec=36-51	2/4	Matthew 24:36-51
2/5	太 25:1-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=25&sec=1-30	2/5	Matthew 25:1-30
2/6	太 25:31-46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=25&sec=31-46	2/6	Matthew 25:31-46
2/7	太 26:1-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=26&sec=1-35	2/7	Matthew 26:1-35
2/8	太 26:36-56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=26&sec=36-56	2/8	Matthew 26:36-56
2/9	太 26:57-75	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=26&sec=57-75	2/9	Matthew 26:57-75
2/10	太 27:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=27&sec=1-26	2/10	Matthew 27:1-26
2/11	太 27:27-44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=27&sec=27-44	2/11	Matthew 27:27-44
2/12	太 27:45-66	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=27&sec=45-66	2/12	Matthew 27:45-66
2/13	太 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=太&chap=28	2/13	Matthew 28
2/14	可 1:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=1&sec=1-20	2/14	Mark 1:1-20
2/15	可 1:21-45	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=1&sec=21-45	2/15	Mark 1:21-45
2/16	可 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=2	2/16	Mark 2
2/17	可 3:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=3&sec=1-19	2/17	Mark 3:1-19
2/18	可 3:20-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=3&sec=20-35	2/18	Mark 3:20-35
2/19	可 4:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=4&sec=1-20	2/19	Mark 4:1-20
2/20	可 4:21-41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=4&sec=21-41	2/20	Mark 4:21-41
2/21	可 5:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=5&sec=1-20	2/21	Mark 5:1-20
2/22	可 5:21-43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=5&sec=21-43	2/22	Mark 5:21-43
2/23	可 6:1-29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=6&sec=1-29	2/23	Mark 6:1-29
2/24	可 6:30-56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=6&sec=30-56	2/24	Mark 6:30-56
2/25	可 7:1-23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=7&sec=1-23	2/25	Mark 7:1-23
2/26	可 7:24-37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=7&sec=24-37	2/26	Mark 7:24-37
2/27	可 8:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=8&sec=1-21	2/27	Mark 8:1-21
2/28	可 8:22-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=8&sec=22-38	2/28	Mark 8:22-38
3/1	可 9:1-32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=9&sec=1-32	3/1	Mark 9:1-32
3/2	可 9:33-50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=9&sec=33-50	3/2	Mark 9:33-50
3/3	可 10:1-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=10&sec=1-31	3/3	Mark 10:1-31
3/4	可 10:32-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=10&sec=32-52	3/4	Mark 10:32-52
3/5	可 11:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=11&sec=1-19	3/5	Mark 11:1-19
3/6	可 11:20-33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=11&sec=20-33	3/6	Mark 11:20-33
3/7	可 12:1-27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=12&sec=1-27	3/7	Mark 12:1-27
3/8	可 12:28-44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=12&sec=28-44	3/8	Mark 12:28-44
3/9	可 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=13	3/9	Mark 13
3/10	可 14:1-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=14&sec=1-31	3/10	Mark 14:1-31
3/11	可 14:32-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=14&sec=32-52	3/11	Mark 14:32-52
3/12	可 14:53-72	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=14&sec=53-72	3/12	Mark 14:53-72
3/13	可 15:1-32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=15&sec=1-32	3/13	Mark 15:1-32
3/14	可 15:33-47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=15&sec=33-47	3/14	Mark 15:33-47
3/15	可 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=可&chap=16	3/15	Mark 16
3/16	路 1:1-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=1&sec=1-38	3/16	Luke 1:1-38
3/17	路 1:39-66	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=1&sec=39-66	3/17	Luke 1:39-66
3/18	路 1:67-80	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=1&sec=67-80	3/18	Luke 1:67-80
3/19	路 2:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=2&sec=1-20	3/19	Luke 2:1-20
3/20	路 2:21-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=2&sec=21-52	3/20	Luke 2:21-52
3/21	路 3:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=3&sec=1-20	3/21	Luke 3:1-20
3/22	路 3:21-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=3&sec=21-38	3/22	Luke 3:21-38
3/23	路 4:1-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=4&sec=1-30	3/23	Luke 4:1-30
3/24	路 4:31-44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=4&sec=31-44	3/24	Luke 4:31-44
3/25	路 5:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=5&sec=1-26	3/25	Luke 5:1-26
3/26	路 5:27-39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=5&sec=27-39	3/26	Luke 5:27-39
3/27	路 6:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=6&sec=1-26	3/27	Luke 6:1-26
3/28	路 6:27-49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=6&sec=27-49	3/28	Luke 6:27-49
3/29	路 7:1-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=7&sec=1-35	3/29	Luke 7:1-35
3/30	路 7:36-50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=7&sec=36-50	3/30	Luke 7:36-50
3/31	路 8:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=8&sec=1-25	3/31	Luke 8:1-25
4/1	路 8:26-56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=8&sec=26-56	4/1	Luke 8:26-56
4/2	路 9:1-36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=9&sec=1-36	4/2	Luke 9:1-36
4/3	路 9:37-62	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=9&sec=37-62	4/3	Luke 9:37-62
4/4	路 10:1-24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=10&sec=1-24	4/4	Luke 10:1-24
4/5	路 10:25-42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=10&sec=25-42	4/5	Luke 10:25-42
4/6	路 11:1-28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=11&sec=1-28	4/6	Luke 11:1-28
4/7	路 11:29-54	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=11&sec=29-54	4/7	Luke 11:29-54
4/8	路 12:1-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=12&sec=1-34	4/8	Luke 12:1-34
4/9	路 12:35-59	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=12&sec=35-59	4/9	Luke 12:35-59
4/10	路 13:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=13&sec=1-17	4/10	Luke 13:1-17
4/11	路 13:18-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=13&sec=18-35	4/11	Luke 13:18-35
4/12	路 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=14	4/12	Luke 14
4/13	路 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=15	4/13	Luke 15
4/14	路 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=16	4/14	Luke 16
4/15	路 17:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=17&sec=1-19	4/15	Luke 17:1-19
4/16	路 17:20-37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=17&sec=20-37	4/16	Luke 17:20-37
4/17	路 18:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=18&sec=1-17	4/17	Luke 18:1-17
4/18	路 18:18-43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=18&sec=18-43	4/18	Luke 18:18-43
4/19	路 19:1-27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=19&sec=1-27	4/19	Luke 19:1-27
4/20	路 19:28-48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=19&sec=28-48	4/20	Luke 19:28-48
4/21	路 20:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=20&sec=1-26	4/21	Luke 20:1-26
4/22	路 20:27-47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=20&sec=27-47	4/22	Luke 20:27-47
4/23	路 21:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=21&sec=1-19	4/23	Luke 21:1-19
4/24	路 21:20-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=21&sec=20-38	4/24	Luke 21:20-38
4/25	路 22:1-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=22&sec=1-38	4/25	Luke 22:1-38
4/26	路 22:39-53	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=22&sec=39-53	4/26	Luke 22:39-53
4/27	路 22:54-71	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=22&sec=54-71	4/27	Luke 22:54-71
4/28	路 23:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=23&sec=1-25	4/28	Luke 23:1-25
4/29	路 23:26-56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=23&sec=26-56	4/29	Luke 23:26-56
4/30	路 24:1-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=24&sec=1-35	4/30	Luke 24:1-35
5/1	路 24:36-53	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=路&chap=24&sec=36-53	5/1	Luke 24:36-53
5/2	約 1:1-28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=1&sec=1-28	5/2	John 1:1-28
5/3	約 1:29-51	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=1&sec=29-51	5/3	John 1:29-51
5/4	約 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=2	5/4	John 2
5/5	約 3:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=3&sec=1-21	5/5	John 3:1-21
5/6	約 3:22-36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=3&sec=22-36	5/6	John 3:22-36
5/7	約 4:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=4&sec=1-26	5/7	John 4:1-26
5/8	約 4:27-54	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=4&sec=27-54	5/8	John 4:27-54
5/9	約 5:1-15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=5&sec=1-15	5/9	John 5:1-15
5/10	約 5:16-47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=5&sec=16-47	5/10	John 5:16-47
5/11	約 6:1-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=6&sec=1-40	5/11	John 6:1-40
5/12	約 6:41-71	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=6&sec=41-71	5/12	John 6:41-71
5/13	約 7:1-24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=7&sec=1-24	5/13	John 7:1-24
5/14	約 7:25-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=7&sec=25-52	5/14	John 7:25-52
5/15	約 8:1-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=8&sec=1-30	5/15	John 8:1-30
5/16	約 8:31-59	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=8&sec=31-59	5/16	John 8:31-59
5/17	約 9:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=9&sec=1-25	5/17	John 9:1-25
5/18	約 9:26-41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=9&sec=26-41	5/18	John 9:26-41
5/19	約 10:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=10&sec=1-21	5/19	John 10:1-21
5/20	約 10:22-42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=10&sec=22-42	5/20	John 10:22-42
5/21	約 11:1-37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=11&sec=1-37	5/21	John 11:1-37
5/22	約 11:38-57	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=11&sec=38-57	5/22	John 11:38-57
5/23	約 12:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=12&sec=1-19	5/23	John 12:1-19
5/24	約 12:20-36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=12&sec=20-36	5/24	John 12:20-36
5/25	約 12:37-50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=12&sec=37-50	5/25	John 12:37-50
5/26	約 13:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=13&sec=1-17	5/26	John 13:1-17
5/27	約 13:18-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=13&sec=18-38	5/27	John 13:18-38
5/28	約 14:1-14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=14&sec=1-14	5/28	John 14:1-14
5/29	約 14:15-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=14&sec=15-31	5/29	John 14:15-31
5/30	約 15:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=15&sec=1-17	5/30	John 15:1-17
5/31	約 15:18-16:4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=15&sec=18&chap2=16&sec2=4	5/31	John 15:18-16:4
6/1	約 16:5-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=16&sec=5-16	6/1	John 16:5-16
6/2	約 16:17-33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=16&sec=17-33	6/2	John 16:17-33
6/3	約 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=17	6/3	John 17
6/4	約 18:1-27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=18&sec=1-27	6/4	John 18:1-27
6/5	約 18:28-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=18&sec=28-40	6/5	John 18:28-40
6/6	約 19:1-27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=19&sec=1-27	6/6	John 19:1-27
6/7	約 19:28-42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=19&sec=28-42	6/7	John 19:28-42
6/8	約 20:1-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=20&sec=1-18	6/8	John 20:1-18
6/9	約 20:19-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=20&sec=19-31	6/9	John 20:19-31
6/10	約 21:1-14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=21&sec=1-14	6/10	John 21:1-14
6/11	約 21:15-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約&chap=21&sec=15-25	6/11	John 21:15-25
6/12	徒 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=1	6/12	Acts 1
6/13	徒 2:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=2&sec=1-21	6/13	Acts 2:1-21
6/14	徒 2:22-47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=2&sec=22-47	6/14	Acts 2:22-47
6/15	徒 3:1-10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=3&sec=1-10	6/15	Acts 3:1-10
6/16	徒 3:11-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=3&sec=11-26	6/16	Acts 3:11-26
6/17	徒 4:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=4&sec=1-22	6/17	Acts 4:1-22
6/18	徒 4:23-37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=4&sec=23-37	6/18	Acts 4:23-37
6/19	徒 5:1-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=5&sec=1-16	6/19	Acts 5:1-16
6/20	徒 5:17-42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=5&sec=17-42	6/20	Acts 5:17-42
6/21	徒 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=6	6/21	Acts 6
6/22	徒 7:1-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=7&sec=1-38	6/22	Acts 7:1-38
6/23	徒 7:39-60	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=7&sec=39-60	6/23	Acts 7:39-60
6/24	徒 8:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=8&sec=1-25	6/24	Acts 8:1-25
6/25	徒 8:26-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=8&sec=26-40	6/25	Acts 8:26-40
6/26	徒 9:1-19a	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=9&sec=1-19a	6/26	Acts 9:1-19a
6/27	徒 9:19b-43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=9&sec=19b-43	6/27	Acts 9:19b-43
6/28	徒 10:1-23a	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=10&sec=1-23a	6/28	Acts 10:1-23a
6/29	徒 10:23b-48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=10&sec=23b-48	6/29	Acts 10:23b-48
6/30	徒 11:1-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=11&sec=1-18	6/30	Acts 11:1-18
7/1	徒 11:19-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=11&sec=19-30	7/1	Acts 11:19-30
7/2	徒 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=12	7/2	Acts 12
7/3	徒 13:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=13&sec=1-25	7/3	Acts 13:1-25
7/4	徒 13:26-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=13&sec=26-52	7/4	Acts 13:26-52
7/5	徒 14:1-20a	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=14&sec=1-20a	7/5	Acts 14:1-20a
7/6	徒 14:20b-28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=14&sec=20b-28	7/6	Acts 14:20b-28
7/7	徒 15:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=15&sec=1-21	7/7	Acts 15:1-21
7/8	徒 15:22-41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=15&sec=22-41	7/8	Acts 15:22-41
7/9	徒 16:1-15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=16&sec=1-15	7/9	Acts 16:1-15
7/10	徒 16:16-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=16&sec=16-40	7/10	Acts 16:16-40
7/11	徒 17:1-15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=17&sec=1-15	7/11	Acts 17:1-15
7/12	徒 17:16-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=17&sec=16-34	7/12	Acts 17:16-34
7/13	徒 18:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=18&sec=1-17	7/13	Acts 18:1-17
7/14	徒 18:18-28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=18&sec=18-28	7/14	Acts 18:18-28
7/15	徒 19:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=19&sec=1-22	7/15	Acts 19:1-22
7/16	徒 19:23-41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=19&sec=23-41	7/16	Acts 19:23-41
7/17	徒 20:1-12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=20&sec=1-12	7/17	Acts 20:1-12
7/18	徒 20:13-38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=20&sec=13-38	7/18	Acts 20:13-38
7/19	徒 21:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=21&sec=1-26	7/19	Acts 21:1-26
7/20	徒 21:27-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=21&sec=27-40	7/20	Acts 21:27-40
7/21	徒 22:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=22&sec=1-21	7/21	Acts 22:1-21
7/22	徒 22:22-23:11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=22&sec=22&chap2=23&sec2=11	7/22	Acts 22:22-23:11
7/23	徒 23:12-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=23&sec=12-35	7/23	Acts 23:12-35
7/24	徒 24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=24	7/24	Acts 24
7/25	徒 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=25	7/25	Acts 25
7/26	徒 26:1-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=26&sec=1-18	7/26	Acts 26:1-18
7/27	徒 26:19-32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=26&sec=19-32	7/27	Acts 26:19-32
7/28	徒 27:1-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=27&sec=1-26	7/28	Acts 27:1-26
7/29	徒 27:27-44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=27&sec=27-44	7/29	Acts 27:27-44
7/30	徒 28:1-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=28&sec=1-16	7/30	Acts 28:1-16
7/31	徒 28:17-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=徒&chap=28&sec=17-31	7/31	Acts 28:17-31
8/1	羅 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=1	8/1	Romans 1
8/2	羅 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=2	8/2	Romans 2
8/3	羅 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=3	8/3	Romans 3
8/4	羅 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=4	8/4	Romans 4
8/5	羅 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=5	8/5	Romans 5
8/6	羅 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=6	8/6	Romans 6
8/7	羅 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=7	8/7	Romans 7
8/8	羅 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=8	8/8	Romans 8
8/9	羅 9:1-29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=9&sec=1-29	8/9	Romans 9:1-29
8/10	羅 9:30-10:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=9&sec=30&chap2=10&sec2=21	8/10	Romans 9:30-10:21
8/11	羅 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=11	8/11	Romans 11
8/12	羅 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=12	8/12	Romans 12
8/13	羅 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=13	8/13	Romans 13
8/14	羅 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=14	8/14	Romans 14
8/15	羅 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=15	8/15	Romans 15
8/16	羅 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=羅&chap=16	8/16	Romans 16
8/17	林前 1:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=1&sec=1-17	8/17	1 Corinthians 1:1-17
8/18	林前 1:18-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=1&sec=18-31	8/18	1 Corinthians 1:18-31
8/19	林前 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=2	8/19	1 Corinthians 2
8/20	林前 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=3	8/20	1 Corinthians 3
8/21	林前 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=4	8/21	1 Corinthians 4
8/22	林前 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=5	8/22	1 Corinthians 5
8/23	林前 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=6	8/23	1 Corinthians 6
8/24	林前 7:1-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=7&sec=1-16	8/24	1 Corinthians 7:1-16
8/25	林前 7:17-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=7&sec=17-40	8/25	1 Corinthians 7:17-40
8/26	林前 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=8	8/26	1 Corinthians 8
8/27	林前 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=9	8/27	1 Corinthians 9
8/28	林前 10:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=10&sec=1-22	8/28	1 Corinthians 10:1-22
8/29	林前 10:23-11:1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=10&sec=23&chap2=11&sec2=1	8/29	1 Corinthians 10:23-11:1
8/30	林前 11:2-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=11&sec=2-16	8/30	1 Corinthians 11:2-16
8/31	林前 11:17-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=11&sec=17-34	8/31	1 Corinthians 11:17-34
9/1	林前 12:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=12&sec=1-11	9/1	1 Corinthians 12:1-11
9/2	林前 12:12-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=12&sec=12-31	9/2	1 Corinthians 12:12-31
9/3	林前 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=13	9/3	1 Corinthians 13
9/4	林前 14:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=14&sec=1-25	9/4	1 Corinthians 14:1-25
9/5	林前 14:26-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=14&sec=26-40	9/5	1 Corinthians 14:26-40
9/6	林前 15:1-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=15&sec=1-34	9/6	1 Corinthians 15:1-34
9/7	林前 15:35-58	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=15&sec=35-58	9/7	1 Corinthians 15:35-58
9/8	林前 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林前&chap=16	9/8	1 Corinthians 16
9/9	林後 1:1-2:4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=1&sec=1&chap2=2&sec2=4	9/9	2 Corinthians 1:1-2:4
9/10	林後 2:5-3:6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=2&sec=5&chap2=3&sec2=6	9/10	2 Corinthians 2:5-3:6
9/11	林後 3:7-4:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=3&sec=7&chap2=4&sec2=18	9/11	2 Corinthians 3:7-4:18
9/12	林後 5:1-6:2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=5&sec=1&chap2=6&sec2=2	9/12	2 Corinthians 5:1-6:2
9/13	林後 6:3-7:1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=6&sec=3&chap2=7&sec2=1	9/13	2 Corinthians 6:3-7:1
9/14	林後 7:2-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=7&sec=2-16	9/14	2 Corinthians 7:2-16
9/15	林後 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=8	9/15	2 Corinthians 8
9/16	林後 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=9	9/16	2 Corinthians 9
9/17	林後 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=10	9/17	2 Corinthians 10
9/18	林後 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=11	9/18	2 Corinthians 11
9/19	林後 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=12	9/19	2 Corinthians 12
9/20	林後 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=林後&chap=13	9/20	2 Corinthians 13
9/21	加 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=1	9/21	Galatians 1
9/22	加 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=2	9/22	Galatians 2
9/23	加 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=3	9/23	Galatians 3
9/24	加 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=4	9/24	Galatians 4
9/25	加 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=5	9/25	Galatians 5
9/26	加 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=加&chap=6	9/26	Galatians 6
9/27	弗 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=1	9/27	Ephesians 1
9/28	弗 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=2	9/28	Ephesians 2
9/29	弗 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=3	9/29	Ephesians 3
9/30	弗 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=4	9/30	Ephesians 4
10/1	弗 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=5	10/1	Ephesians 5
10/2	弗 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=弗&chap=6	10/2	Ephesians 6
10/3	腓 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=腓&chap=1	10/3	Philippians 1
10/4	腓 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=腓&chap=2	10/4	Philippians 2
10/5	腓 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=腓&chap=3	10/5	Philippians 3
10/6	腓 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=腓&chap=4	10/6	Philippians 4
10/7	西 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=西&chap=1	10/7	Colossians 1
10/8	西 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=西&chap=2	10/8	Colossians 2
10/9	西 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=西&chap=3	10/9	Colossians 3
10/10	西 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=西&chap=4	10/10	Colossians 4
10/11	帖前 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖前&chap=1	10/11	1 Thessalonians 1
10/12	帖前 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖前&chap=2	10/12	1 Thessalonians 2
10/13	帖前 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖前&chap=3	10/13	1 Thessalonians 3
10/14	帖前 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖前&chap=4	10/14	1 Thessalonians 4
10/15	帖前 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖前&chap=5	10/15	1 Thessalonians 5
10/16	帖後 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖後&chap=1	10/16	2 Thessalonians 1
10/17	帖後 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖後&chap=2	10/17	2 Thessalonians 2
10/18	帖後 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=帖後&chap=3	10/18	2 Thessalonians 3
10/19	提前 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=1	10/19	1 Timothy 1
10/20	提前 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=2	10/20	1 Timothy 2
10/21	提前 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=3	10/21	1 Timothy 3
10/22	提前 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=4	10/22	1 Timothy 4
10/23	提前 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=5	10/23	1 Timothy 5
10/24	提前 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提前&chap=6	10/24	1 Timothy 6
10/25	提後 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提後&chap=1	10/25	2 Timothy 1
10/26	提後 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提後&chap=2	10/26	2 Timothy 2
10/27	提後 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提後&chap=3	10/27	2 Timothy 3
10/28	提後 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=提後&chap=4	10/28	2 Timothy 4
10/29	多 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=多&chap=1	10/29	Titus 1
10/30	多 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=多&chap=2	10/30	Titus 2
10/31	多 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=多&chap=3	10/31	Titus 3
11/1	門 1:1-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=門&chap=1&sec=1-25	11/1	Philemon 1:1-25
11/2	來 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=1	11/2	Hebrews 1
11/3	來 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=2	11/3	Hebrews 2
11/4	來 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=3	11/4	Hebrews 3
11/5	來 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=4	11/5	Hebrews 4
11/6	來 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=5	11/6	Hebrews 5
11/7	來 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=6	11/7	Hebrews 6
11/8	來 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=7	11/8	Hebrews 7
11/9	來 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=8	11/9	Hebrews 8
11/10	來 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=9	11/10	Hebrews 9
11/11	來 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=10	11/11	Hebrews 10
11/12	來 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=11	11/12	Hebrews 11
11/13	來 12:1-13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=12&sec=1-13	11/13	Hebrews 12:1-13
11/14	來 12:14-29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=12&sec=14-29	11/14	Hebrews 12:14-29
11/15	來 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=來&chap=13	11/15	Hebrews 13
11/16	雅 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=雅&chap=1	11/16	James 1
11/17	雅 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=雅&chap=2	11/17	James 2
11/18	雅 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=雅&chap=3	11/18	James 3
11/19	雅 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=雅&chap=4	11/19	James 4
11/20	雅 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=雅&chap=5	11/20	James 5
11/21	彼前 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼前&chap=1	11/21	1 Peter 1
11/22	彼前 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼前&chap=2	11/22	1 Peter 2
11/23	彼前 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼前&chap=3	11/23	1 Peter 3
11/24	彼前 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼前&chap=4	11/24	1 Peter 4
11/25	彼前 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼前&chap=5	11/25	1 Peter 5
11/26	彼後 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼後&chap=1	11/26	2 Peter 1
11/27	彼後 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼後&chap=2	11/27	2 Peter 2
11/28	彼後 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彼後&chap=3	11/28	2 Peter 3
11/29	約一 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約一&chap=1	11/29	1 John 1
11/30	約一 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約一&chap=2	11/30	1 John 2
12/1	約一 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約一&chap=3	12/1	1 John 3
12/2	約一 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約一&chap=4	12/2	1 John 4
12/3	約一 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約一&chap=5	12/3	1 John 5
12/4	約二 1:1-13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約二&chap=1&sec=1-13	12/4	2 John 1:1-13
12/5	約三 1:1-15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=約三&chap=1&sec=1-15	12/5	3 John 1:1-15
12/6	猶 1:1-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=猶&chap=1&sec=1-16	12/6	Jude 1:1-16
12/7	猶 1:17-25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=猶&chap=1&sec=17-25	12/7	Jude 1:17-25
12/8	啟 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=1	12/8	Revelation 1
12/9	啟 2:1-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=2&sec=1-17	12/9	Revelation 2:1-17
12/10	啟 2:18-29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=2&sec=18-29	12/10	Revelation 2:18-29
12/11	啟 3:1-13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=3&sec=1-13	12/11	Revelation 3:1-13
12/12	啟 3:14-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=3&sec=14-22	12/12	Revelation 3:14-22
12/13	啟 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=4	12/13	Revelation 4
12/14	啟 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=5	12/14	Revelation 5
12/15	啟 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=6	12/15	Revelation 6
12/16	啟 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=7	12/16	Revelation 7
12/17	啟 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=8	12/17	Revelation 8
12/18	啟 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=9	12/18	Revelation 9
12/19	啟 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=10	12/19	Revelation 10
12/20	啟 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=11	12/20	Revelation 11
12/21	啟 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=12	12/21	Revelation 12
12/22	啟 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=13	12/22	Revelation 13
12/23	啟 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=14	12/23	Revelation 14
12/24	啟 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=15	12/24	Revelation 15
12/25	啟 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=16	12/25	Revelation 16
12/26	啟 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=17	12/26	Revelation 17
12/27	啟 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=18	12/27	Revelation 18
12/28	啟 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=19	12/28	Revelation 19
12/29	啟 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=20	12/29	Revelation 20
12/30	啟 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=21	12/30	Revelation 21
12/31	啟 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=啟&chap=22	12/31	Revelation 22
1/1	創 1:1-2:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=1&sec=1&chap2=2&sec2=25	1/1	Genesis 1:1-2:25
1/2	創 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=3	1/2	Genesis 3
1/3	創 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=4	1/3	Genesis 4
1/4	創 5:1-6:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=5&sec=1&chap2=6&sec2=22	1/4	Genesis 5:1-6:22
1/5	創 7:1-8:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=7&sec=1&chap2=8&sec2=22	1/5	Genesis 7:1-8:22
1/6	創 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=9	1/6	Genesis 9
1/7	創 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=10	1/7	Genesis 10
1/8	創 11:1-12:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=11&sec=1&chap2=12&sec2=20	1/8	Genesis 11:1-12:20
1/9	創 13:1-14:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=13&sec=1&chap2=14&sec2=24	1/9	Genesis 13:1-14:24
1/10	創 15:1-16:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=15&sec=1&chap2=16&sec2=16	1/10	Genesis 15:1-16:16
1/11	創 17:1-18:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=17&sec=1&chap2=18&sec2=33	1/11	Genesis 17:1-18:33
1/12	創 19:1-20:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=19&sec=1&chap2=20&sec2=18	1/12	Genesis 19:1-20:18
1/13	創 21:1-22:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=21&sec=1&chap2=22&sec2=24	1/13	Genesis 21:1-22:24
1/14	創 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=23	1/14	Genesis 23
1/15	創 24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=24	1/15	Genesis 24
1/16	創 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=25	1/16	Genesis 25
1/17	創 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=26	1/17	Genesis 26
1/18	創 27:1-28:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=27&sec=1&chap2=28&sec2=22	1/18	Genesis 27:1-28:22
1/19	創 29:1-30:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=29&sec=1&chap2=30&sec2=43	1/19	Genesis 29:1-30:43
1/20	創 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=31	1/20	Genesis 31
1/21	創 32:1-33:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=32&sec=1&chap2=33&sec2=20	1/21	Genesis 32:1-33:20
1/22	創 34:1-35:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=34&sec=1&chap2=35&sec2=29	1/22	Genesis 34:1-35:29
1/23	創 36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=36	1/23	Genesis 36
1/24	創 37:1-38:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=37&sec=1&chap2=38&sec2=30	1/24	Genesis 37:1-38:30
1/25	創 39:1-40:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=39&sec=1&chap2=40&sec2=23	1/25	Genesis 39:1-40:23
1/26	創 41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=41	1/26	Genesis 41
1/27	創 42:1-43:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=42&sec=1&chap2=43&sec2=34	1/27	Genesis 42:1-43:34
1/28	創 44:1-45:28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=44&sec=1&chap2=45&sec2=28	1/28	Genesis 44:1-45:28
1/29	創 46:1-47:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=46&sec=1&chap2=47&sec2=31	1/29	Genesis 46:1-47:31
1/30	創 48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=48	1/30	Genesis 48
1/31	創 49:1-50:26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=創&chap=49&sec=1&chap2=50&sec2=26	1/31	Genesis 49:1-50:26
2/1	出 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=1	2/1	Exodus 1
2/2	出 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=2	2/2	Exodus 2
2/3	出 3:1-4:3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=3&sec=1&chap2=4&sec2=3	2/3	Exodus 3:1-4:3
2/4	出 5:1-6:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=5&sec=1&chap2=6&sec2=30	2/4	Exodus 5:1-6:30
2/5	出 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=7	2/5	Exodus 7
2/6	出 8:1-9:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=8&sec=1&chap2=9&sec2=35	2/6	Exodus 8:1-9:35
2/7	出 10:1-11:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=10&sec=1&chap2=11&sec2=10	2/7	Exodus 10:1-11:10
2/8	出 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=12	2/8	Exodus 12
2/9	出 13:1-14:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=13&sec=1&chap2=14&sec2=31	2/9	Exodus 13:1-14:31
2/10	出 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=15	2/10	Exodus 15
2/11	出 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=16	2/11	Exodus 16
2/12	出 17:1-18:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=17&sec=1&chap2=18&sec2=27	2/12	Exodus 17:1-18:27
2/13	出 19:1-20:26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=19&sec=1&chap2=20&sec2=26	2/13	Exodus 19:1-20:26
2/14	出 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=21	2/14	Exodus 21
2/15	出 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=22	2/15	Exodus 22
2/16	出 23:1-24:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=23&sec=1&chap2=24&sec2=18	2/16	Exodus 23:1-24:18
2/17	出 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=25	2/17	Exodus 25
2/18	出 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=26	2/18	Exodus 26
2/19	出 27:1-28:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=27&sec=1&chap2=28&sec2=43	2/19	Exodus 27:1-28:43
2/20	出 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=29	2/20	Exodus 29
2/21	出 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=30	2/21	Exodus 30
2/22	出 31:1-32:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=31&sec=1&chap2=32&sec2=35	2/22	Exodus 31:1-32:35
2/23	出 33:1-34:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=33&sec=1&chap2=34&sec2=35	2/23	Exodus 33:1-34:35
2/24	出 35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=35	2/24	Exodus 35
2/25	出 36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=36	2/25	Exodus 36
2/26	出 37:1-38:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=37&sec=1&chap2=38&sec2=31	2/26	Exodus 37:1-38:31
2/27	出 39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=39	2/27	Exodus 39
2/28	出 40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=出&chap=40	2/28	Exodus 40
3/1	利 1:1-2:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=1&sec=1&chap2=2&sec2=16	3/1	Leviticus 1:1-2:16
3/2	利 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=3	3/2	Leviticus 3
3/3	利 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=4	3/3	Leviticus 4
3/4	利 5:1-6:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=5&sec=1&chap2=6&sec2=30	3/4	Leviticus 5:1-6:30
3/5	利 7:1-8:36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=7&sec=1&chap2=8&sec2=36	3/5	Leviticus 7:1-8:36
3/6	利 9:1-10:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=9&sec=1&chap2=10&sec2=20	3/6	Leviticus 9:1-10:20
3/7	利 11:1-12:8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=11&sec=1&chap2=12&sec2=8	3/7	Leviticus 11:1-12:8
3/8	利 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=13	3/8	Leviticus 13
3/9	利 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=14	3/9	Leviticus 14
3/10	利 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=15	3/10	Leviticus 15
3/11	利 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=16	3/11	Leviticus 16
3/12	利 17:1-18:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=17&sec=1&chap2=18&sec2=30	3/12	Leviticus 17:1-18:30
3/13	利 19:1-20:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=19&sec=1&chap2=20&sec2=27	3/13	Leviticus 19:1-20:27
3/14	利 21:1-22:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=21&sec=1&chap2=22&sec2=33	3/14	Leviticus 21:1-22:33
3/15	利 23:1-24:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=23&sec=1&chap2=24&sec2=23	3/15	Leviticus 23:1-24:23
3/16	利 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=25	3/16	Leviticus 25
3/17	利 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=26	3/17	Leviticus 26
3/18	利 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=利&chap=27	3/18	Leviticus 27
3/19	民 1:1-2:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=1&sec=1&chap2=2&sec2=34	3/19	Numbers 1:1-2:34
3/20	民 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=3	3/20	Numbers 3
3/21	民 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=4	3/21	Numbers 4
3/22	民 5:1-6:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=5&sec=1&chap2=6&sec2=27	3/22	Numbers 5:1-6:27
3/23	民 7:1-8:26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=7&sec=1&chap2=8&sec2=26	3/23	Numbers 7:1-8:26
3/24	民 9:1-10:36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=9&sec=1&chap2=10&sec2=36	3/24	Numbers 9:1-10:36
3/25	民 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=11	3/25	Numbers 11
3/26	民 12:1-13:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=12&sec=1&chap2=13&sec2=33	3/26	Numbers 12:1-13:33
3/27	民 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=14	3/27	Numbers 14
3/28	民 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=15	3/28	Numbers 15
3/29	民 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=16	3/29	Numbers 16
3/30	民 17:1-18:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=17&sec=1&chap2=18&sec2=32	3/30	Numbers 17:1-18:32
3/31	民 19:1-20:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=19&sec=1&chap2=20&sec2=29	3/31	Numbers 19:1-20:29
4/1	民 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=21	4/1	Numbers 21
4/2	民 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=22	4/2	Numbers 22
4/3	民 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=23	4/3	Numbers 23
4/4	民 24:1-25:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=24&sec=1&chap2=25&sec2=18	4/4	Numbers 24:1-25:18
4/5	民 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=26	4/5	Numbers 26
4/6	民 27:1-28:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=27&sec=1&chap2=28&sec2=31	4/6	Numbers 27:1-28:31
4/7	民 29:1-30:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=29&sec=1&chap2=30&sec2=16	4/7	Numbers 29:1-30:16
4/8	民 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=31	4/8	Numbers 31
4/9	民 32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=32	4/9	Numbers 32
4/10	民 33:1-34:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=33&sec=1&chap2=34&sec2=29	4/10	Numbers 33:1-34:29
4/11	民 35:1-36:13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=民&chap=35&sec=1&chap2=36&sec2=13	4/11	Numbers 35:1-36:13
4/12	申 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=1	4/12	Deuteronomy 1
4/13	申 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=2	4/13	Deuteronomy 2
4/14	申 3:1-4:49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=3&sec=1&chap2=4&sec2=49	4/14	Deuteronomy 3:1-4:49
4/15	申 5:1-6:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=5&sec=1&chap2=6&sec2=25	4/15	Deuteronomy 5:1-6:25
4/16	申 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=7	4/16	Deuteronomy 7
4/17	申 8:1-9:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=8&sec=1&chap2=9&sec2=29	4/17	Deuteronomy 8:1-9:29
4/18	申 10:1-11:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=10&sec=1&chap2=11&sec2=32	4/18	Deuteronomy 10:1-11:32
4/19	申 12:1-13:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=12&sec=1&chap2=13&sec2=18	4/19	Deuteronomy 12:1-13:18
4/20	申 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=14	4/20	Deuteronomy 14
4/21	申 15:1-16:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=15&sec=1&chap2=16&sec2=22	4/21	Deuteronomy 15:1-16:22
4/22	申 17:1-18:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=17&sec=1&chap2=18&sec2=22	4/22	Deuteronomy 17:1-18:22
4/23	申 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=19	4/23	Deuteronomy 19
4/24	申 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=20	4/24	Deuteronomy 20
4/25	申 21:1-22:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=21&sec=1&chap2=22&sec2=30	4/25	Deuteronomy 21:1-22:30
4/26	申 23:1-24:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=23&sec=1&chap2=24&sec2=22	4/26	Deuteronomy 23:1-24:22
4/27	申 25:1-26:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=25&sec=1&chap2=26&sec2=19	4/27	Deuteronomy 25:1-26:19
4/28	申 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=27	4/28	Deuteronomy 27
4/29	申 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=28	4/29	Deuteronomy 28
4/30	申 29:1-30:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=29&sec=1&chap2=30&sec2=20	4/30	Deuteronomy 29:1-30:20
5/1	申 31:1-32:52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=31&sec=1&chap2=32&sec2=52	5/1	Deuteronomy 31:1-32:52
5/2	申 33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=33	5/2	Deuteronomy 33
5/3	申 34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=申&chap=34	5/3	Deuteronomy 34
5/4	書 1:1-2:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=1&sec=1&chap2=2&sec2=24	5/4	Joshua 1:1-2:24
5/5	書 3:1-4:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=3&sec=1&chap2=4&sec2=24	5/5	Joshua 3:1-4:24
5/6	書 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=5	5/6	Joshua 5
5/7	書 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=6	5/7	Joshua 6
5/8	書 7:1-8:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=7&sec=1&chap2=8&sec2=35	5/8	Joshua 7:1-8:35
5/9	書 9:1-10:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=9&sec=1&chap2=10&sec2=43	5/9	Joshua 9:1-10:43
5/10	書 11:1-12:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=11&sec=1&chap2=12&sec2=24	5/10	Joshua 11:1-12:24
5/11	書 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=13	5/11	Joshua 13
5/12	書 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=14	5/12	Joshua 14
5/13	書 15:1-16:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=15&sec=1&chap2=16&sec2=10	5/13	Joshua 15:1-16:10
5/14	書 17:1-18:28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=17&sec=1&chap2=18&sec2=28	5/14	Joshua 17:1-18:28
5/15	書 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=19	5/15	Joshua 19
5/16	書 20:1-21:45	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=20&sec=1&chap2=21&sec2=45	5/16	Joshua 20:1-21:45
5/17	書 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=22	5/17	Joshua 22
5/18	書 23:1-24:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=書&chap=23&sec=1&chap2=24&sec2=33	5/18	Joshua 23:1-24:33
5/19	士 1:1-2:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=1&sec=1&chap2=2&sec2=23	5/19	Judges 1:1-2:23
5/20	士 3:1-4:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=3&sec=1&chap2=4&sec2=24	5/20	Judges 3:1-4:24
5/21	士 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=5	5/21	Judges 5
5/22	士 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=6	5/22	Judges 6
5/23	士 7:1-8:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=7&sec=1&chap2=8&sec2=35	5/23	Judges 7:1-8:35
5/24	士 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=9	5/24	Judges 9
5/25	士 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=10	5/25	Judges 10
5/26	士 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=11	5/26	Judges 11
5/27	士 12:1-13:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=12&sec=1&chap2=13&sec2=25	5/27	Judges 12:1-13:25
5/28	士 14:1-15:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=14&sec=1&chap2=15&sec2=20	5/28	Judges 14:1-15:20
5/29	士 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=16	5/29	Judges 16
5/30	士 17:1-18:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=17&sec=1&chap2=18&sec2=31	5/30	Judges 17:1-18:31
5/31	士 19:1-20:48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=19&sec=1&chap2=20&sec2=48	5/31	Judges 19:1-20:48
6/1	士 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=士&chap=21	6/1	Judges 21
6/2	得 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=得&chap=1	6/2	Ruth 1
6/3	得 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=得&chap=2	6/3	Ruth 2
6/4	得 3:1-4:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=得&chap=3&sec=1&chap2=4&sec2=22	6/4	Ruth 3:1-4:22
6/5	撒上 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=1	6/5	1 Samuel 1
6/6	撒上 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=2	6/6	1 Samuel 2
6/7	撒上 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=3	6/7	1 Samuel 3
6/8	撒上 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=4	6/8	1 Samuel 4
6/9	撒上 5:1-6:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=5&sec=1&chap2=6&sec2=21	6/9	1 Samuel 5:1-6:21
6/10	撒上 7:1-8:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=7&sec=1&chap2=8&sec2=22	6/10	1 Samuel 7:1-8:22
6/11	撒上 9:1-10:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=9&sec=1&chap2=10&sec2=27	6/11	1 Samuel 9:1-10:27
6/12	撒上 11:1-12:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=11&sec=1&chap2=12&sec2=25	6/12	1 Samuel 11:1-12:25
6/13	撒上 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=13	6/13	1 Samuel 13
6/14	撒上 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=14	6/14	1 Samuel 14
6/15	撒上 15:1-16:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=15&sec=1&chap2=16&sec2=23	6/15	1 Samuel 15:1-16:23
6/16	撒上 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=17	6/16	1 Samuel 17
6/17	撒上 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=18	6/17	1 Samuel 18
6/18	撒上 19:1-20:42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=19&sec=1&chap2=20&sec2=42	6/18	1 Samuel 19:1-20:42
6/19	撒上 21:1-22:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=21&sec=1&chap2=22&sec2=23	6/19	1 Samuel 21:1-22:23
6/20	撒上 23:1-24:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=23&sec=1&chap2=24&sec2=22	6/20	1 Samuel 23:1-24:22
6/21	撒上 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=25	6/21	1 Samuel 25
6/22	撒上 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=26	6/22	1 Samuel 26
6/23	撒上 27:1-28:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=27&sec=1&chap2=28&sec2=25	6/23	1 Samuel 27:1-28:25
6/24	撒上 29:1-30:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=29&sec=1&chap2=30&sec2=31	6/24	1 Samuel 29:1-30:31
6/25	撒上 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒上&chap=31	6/25	1 Samuel 31
6/26	撒下 1:1-2:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=1&sec=1&chap2=2&sec2=32	6/26	2 Samuel 1:1-2:32
6/27	撒下 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=3	6/27	2 Samuel 3
6/28	撒下 4:1-5:12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=4&sec=1&chap2=5&sec2=12	6/28	2 Samuel 4:1-5:12
6/29	撒下 6:1-7:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=6&sec=1&chap2=7&sec2=29	6/29	2 Samuel 6:1-7:29
6/30	撒下 8:1-9:13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=8&sec=1&chap2=9&sec2=13	6/30	2 Samuel 8:1-9:13
7/1	撒下 10:1-11:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=10&sec=1&chap2=11&sec2=27	7/1	2 Samuel 10:1-11:27
7/2	撒下 12:1-13:39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=12&sec=1&chap2=13&sec2=39	7/2	2 Samuel 12:1-13:39
7/3	撒下 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=14	7/3	2 Samuel 14
7/4	撒下 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=15	7/4	2 Samuel 15
7/5	撒下 16:1-17:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=16&sec=1&chap2=17&sec2=29	7/5	2 Samuel 16:1-17:29
7/6	撒下 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=18	7/6	2 Samuel 18
7/7	撒下 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=19	7/7	2 Samuel 19
7/8	撒下 20:1-21:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=20&sec=1&chap2=21&sec2=22	7/8	2 Samuel 20:1-21:22
7/9	撒下 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=22	7/9	2 Samuel 22
7/10	撒下 23:1-24:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=撒下&chap=23&sec=1&chap2=24&sec2=25	7/10	2 Samuel 23:1-24:25
7/11	王上 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=1	7/11	1Kings 1
7/12	王上 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=2	7/12	1Kings 2
7/13	王上 3:1-4:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=3&sec=1&chap2=4&sec2=34	7/13	1Kings 3:1-4:34
7/14	王上 5:1-6:38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=5&sec=1&chap2=6&sec2=38	7/14	1Kings 5:1-6:38
7/15	王上 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=7	7/15	1Kings 7
7/16	王上 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=8	7/16	1Kings 8
7/17	王上 9:1-10:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=9&sec=1&chap2=10&sec2=29	7/17	1Kings 9:1-10:29
7/18	王上 11:1-12:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=11&sec=1&chap2=12&sec2=33	7/18	1Kings 11:1-12:33
7/19	王上 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=13	7/19	1Kings 13
7/20	王上 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=14	7/20	1Kings 14
7/21	王上 15:1-16:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=15&sec=1&chap2=16&sec2=34	7/21	1Kings 15:1-16:34
7/22	王上 17:1-18:46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=17&sec=1&chap2=18&sec2=46	7/22	1Kings 17:1-18:46
7/23	王上 19:1-20:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=19&sec=1&chap2=20&sec2=43	7/23	1Kings 19:1-20:43
7/24	王上 21:1-22:53	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王上&chap=21&sec=1&chap2=22&sec2=53	7/24	1Kings 21:1-22:53
7/25	王下 1:1-2:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=1&sec=1&chap2=2&sec2=25	7/25	2Kings 1:1-2:25
7/26	王下 3:1-4:44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=3&sec=1&chap2=4&sec2=44	7/26	2Kings 3:1-4:44
7/27	王下 5:1-6:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=5&sec=1&chap2=6&sec2=33	7/27	2Kings 5:1-6:33
7/28	王下 7:1-8:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=7&sec=1&chap2=8&sec2=29	7/28	2Kings 7:1-8:29
7/29	王下 9:1-10:36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=9&sec=1&chap2=10&sec2=36	7/29	2Kings 9:1-10:36
7/30	王下 11:1-12:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=11&sec=1&chap2=12&sec2=21	7/30	2Kings 11:1-12:21
7/31	王下 13:1-14:29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=13&sec=1&chap2=14&sec2=29	7/31	2Kings 13:1-14:29
8/1	王下 15:1-16:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=15&sec=1&chap2=16&sec2=20	8/1	2Kings 15:1-16:20
8/2	王下 17:1-18:37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=17&sec=1&chap2=18&sec2=37	8/2	2Kings 17:1-18:37
8/3	王下 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=19	8/3	2Kings 19
8/4	王下 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=20	8/4	2Kings 20
8/5	王下 21:1-22:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=21&sec=1&chap2=22&sec2=20	8/5	2Kings 21:1-22:20
8/6	王下 23:1-24:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=23&sec=1&chap2=24&sec2=20	8/6	2Kings 23:1-24:20
8/7	王下 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=王下&chap=25	8/7	2Kings 25
8/8	代上 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=1	8/8	1 Chronicles 1
8/9	代上 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=2	8/9	1 Chronicles 2
8/10	代上 3:1-4:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=3&sec=1&chap2=4&sec2=43	8/10	1 Chronicles 3:1-4:43
8/11	代上 5:1-6:81	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=5&sec=1&chap2=6&sec2=81	8/11	1 Chronicles 5:1-6:81
8/12	代上 7:1-8:40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=7&sec=1&chap2=8&sec2=40	8/12	1 Chronicles 7:1-8:40
8/13	代上 9:1-10:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=9&sec=1&chap2=10&sec2=14	8/13	1 Chronicles 9:1-10:14
8/14	代上 11:1-12:40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=11&sec=1&chap2=12&sec2=40	8/14	1 Chronicles 11:1-12:40
8/15	代上 13:1-14:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=13&sec=1&chap2=14&sec2=17	8/15	1 Chronicles 13:1-14:17
8/16	代上 15:1-16:43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=15&sec=1&chap2=16&sec2=43	8/16	1 Chronicles 15:1-16:43
8/17	代上 17:1-18:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=17&sec=1&chap2=18&sec2=17	8/17	1 Chronicles 17:1-18:17
8/18	代上 19:1-20:8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=19&sec=1&chap2=20&sec2=8	8/18	1 Chronicles 19:1-20:8
8/19	代上 21:1-22:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=21&sec=1&chap2=22&sec2=18	8/19	1 Chronicles 21:1-22:18
8/20	代上 23:1-24:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=23&sec=1&chap2=24&sec2=31	8/20	1 Chronicles 23:1-24:31
8/21	代上 25:1-26:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=25&sec=1&chap2=26&sec2=32	8/21	1 Chronicles 25:1-26:32
8/22	代上 27:1-28:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=27&sec=1&chap2=28&sec2=21	8/22	1 Chronicles 27:1-28:21
8/23	代上 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代上&chap=29	8/23	1 Chronicles 29
8/24	代下 1:1-2:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=1&sec=1&chap2=2&sec2=18	8/24	2 Chronicles 1:1-2:18
8/25	代下 3:1-4:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=3&sec=1&chap2=4&sec2=22	8/25	2 Chronicles 3:1-4:22
8/26	代下 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=5	8/26	2 Chronicles 5
8/27	代下 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=6	8/27	2 Chronicles 6
8/28	代下 7:1-8:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=7&sec=1&chap2=8&sec2=18	8/28	2 Chronicles 7:1-8:18
8/29	代下 9:1-10:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=9&sec=1&chap2=10&sec2=19	8/29	2 Chronicles 9:1-10:19
8/30	代下 11:1-12:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=11&sec=1&chap2=12&sec2=16	8/30	2 Chronicles 11:1-12:16
8/31	代下 13:1-14:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=13&sec=1&chap2=14&sec2=15	8/31	2 Chronicles 13:1-14:15
9/1	代下 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=15	9/1	2 Chronicles 15
9/2	代下 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=16	9/2	2 Chronicles 16
9/3	代下 17:1-18:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=17&sec=1&chap2=18&sec2=34	9/3	2 Chronicles 17:1-18:34
9/4	代下 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=19	9/4	2 Chronicles 19
9/5	代下 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=20	9/5	2 Chronicles 20
9/6	代下 21:1-22:12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=21&sec=1&chap2=22&sec2=12	9/6	2 Chronicles 21:1-22:12
9/7	代下 23:1-24:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=23&sec=1&chap2=24&sec2=27	9/7	2 Chronicles 23:1-24:27
9/8	代下 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=25	9/8	2 Chronicles 25
9/9	代下 26:1-27:9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=26&sec=1&chap2=27&sec2=9	9/9	2 Chronicles 26:1-27:9
9/10	代下 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=28	9/10	2 Chronicles 28
9/11	代下 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=29	9/11	2 Chronicles 29
9/12	代下 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=30	9/12	2 Chronicles 30
9/13	代下 31:1-32:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=31&sec=1&chap2=32&sec2=33	9/13	2 Chronicles 31:1-32:33
9/14	代下 33:1-34:33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=33&sec=1&chap2=34&sec2=33	9/14	2 Chronicles 33:1-34:33
9/15	代下 35:1-36:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=代下&chap=35&sec=1&chap2=36&sec2=23	9/15	2 Chronicles 35:1-36:23
9/16	拉 1:1-2:70	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拉&chap=1&sec=1&chap2=2&sec2=70	9/16	Ezra 1:1-2:70
9/17	拉 3:1-4:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拉&chap=3&sec=1&chap2=4&sec2=24	9/17	Ezra 3:1-4:24
9/18	拉 5:1-6:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拉&chap=5&sec=1&chap2=6&sec2=22	9/18	Ezra 5:1-6:22
9/19	拉 7:1-8:36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拉&chap=7&sec=1&chap2=8&sec2=36	9/19	Ezra 7:1-8:36
9/20	拉 9:1-10:44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拉&chap=9&sec=1&chap2=10&sec2=44	9/20	Ezra 9:1-10:44
9/21	尼 1:1-2:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=1&sec=1&chap2=2&sec2=20	9/21	Nehemiah 1:1-2:20
9/22	尼 3:1-4:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=3&sec=1&chap2=4&sec2=23	9/22	Nehemiah 3:1-4:23
9/23	尼 5:1-6:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=5&sec=1&chap2=6&sec2=19	9/23	Nehemiah 5:1-6:19
9/24	尼 7:1-8:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=7&sec=1&chap2=8&sec2=18	9/24	Nehemiah 7:1-8:18
9/25	尼 9:1-10:39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=9&sec=1&chap2=10&sec2=39	9/25	Nehemiah 9:1-10:39
9/26	尼 11:1-13:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=尼&chap=11&sec=1&chap2=13&sec2=31	9/26	Nehemiah 11:1-13:31
9/27	斯 1:1-2:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=斯&chap=1&sec=1&chap2=2&sec2=23	9/27	Esther 1:1-2:23
9/28	斯 3:1-4:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=斯&chap=3&sec=1&chap2=4&sec2=17	9/28	Esther 3:1-4:17
9/29	斯 5:1-6:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=斯&chap=5&sec=1&chap2=6&sec2=14	9/29	Esther 5:1-6:14
9/30	斯 7:1-8:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=斯&chap=7&sec=1&chap2=8&sec2=17	9/30	Esther 7:1-8:17
10/1	斯 9:1-10:3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=斯&chap=9&sec=1&chap2=10&sec2=3	10/1	Esther 9:1-10:3
10/2	耶 1:1-2:37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=1&sec=1&chap2=2&sec2=37	10/2	Jeremiah 1:1-2:37
10/3	耶 3:1-4:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=3&sec=1&chap2=4&sec2=31	10/3	Jeremiah 3:1-4:31
10/4	耶 5:1-6:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=5&sec=1&chap2=6&sec2=30	10/4	Jeremiah 5:1-6:30
10/5	耶 7:1-8:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=7&sec=1&chap2=8&sec2=22	10/5	Jeremiah 7:1-8:22
10/6	耶 9:1-10:25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=9&sec=1&chap2=10&sec2=25	10/6	Jeremiah 9:1-10:25
10/7	耶 11:1-12:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=11&sec=1&chap2=12&sec2=17	10/7	Jeremiah 11:1-12:17
10/8	耶 13:1-14:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=13&sec=1&chap2=14&sec2=22	10/8	Jeremiah 13:1-14:22
10/9	耶 15:1-16:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=15&sec=1&chap2=16&sec2=21	10/9	Jeremiah 15:1-16:21
10/10	耶 17:1-18:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=17&sec=1&chap2=18&sec2=23	10/10	Jeremiah 17:1-18:23
10/11	耶 19:1-20:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=19&sec=1&chap2=20&sec2=18	10/11	Jeremiah 19:1-20:18
10/12	耶 21:1-22:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=21&sec=1&chap2=22&sec2=30	10/12	Jeremiah 21:1-22:30
10/13	耶 23:1-24:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=23&sec=1&chap2=24&sec2=10	10/13	Jeremiah 23:1-24:10
10/14	耶 25:1-26:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=25&sec=1&chap2=26&sec2=24	10/14	Jeremiah 25:1-26:24
10/15	耶 27:1-28:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=27&sec=1&chap2=28&sec2=17	10/15	Jeremiah 27:1-28:17
10/16	耶 29:1-30:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=29&sec=1&chap2=30&sec2=24	10/16	Jeremiah 29:1-30:24
10/17	耶 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=31	10/17	Jeremiah 31
10/18	耶 32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=32	10/18	Jeremiah 32
10/19	耶 33:1-34:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=33&sec=1&chap2=34&sec2=22	10/19	Jeremiah 33:1-34:22
10/20	耶 35:1-36:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=35&sec=1&chap2=36&sec2=32	10/20	Jeremiah 35:1-36:32
10/21	耶 37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=37	10/21	Jeremiah 37
10/22	耶 38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=38	10/22	Jeremiah 38
10/23	耶 39:1-40:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=39&sec=1&chap2=40&sec2=16	10/23	Jeremiah 39:1-40:16
10/24	耶 41:1-42:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=41&sec=1&chap2=42&sec2=22	10/24	Jeremiah 41:1-42:22
10/25	耶 43:1-44:30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=43&sec=1&chap2=44&sec2=30	10/25	Jeremiah 43:1-44:30
10/26	耶 45:1-46:28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=45&sec=1&chap2=46&sec2=28	10/26	Jeremiah 45:1-46:28
10/27	耶 47:1-48:47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=47&sec=1&chap2=48&sec2=47	10/27	Jeremiah 47:1-48:47
10/28	耶 49:1-50:46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=49&sec=1&chap2=50&sec2=46	10/28	Jeremiah 49:1-50:46
10/29	耶 51:1-52:34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=耶&chap=51&sec=1&chap2=52&sec2=34	10/29	Jeremiah 51:1-52:34
10/30	哀 1:1-2:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=哀&chap=1&sec=1&chap2=2&sec2=22	10/30	Lamentations 1:1-2:22
10/31	哀 3:1-4:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=哀&chap=3&sec=1&chap2=4&sec2=22	10/31	Lamentations 3:1-4:22
11/1	哀 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=哀&chap=5	11/1	Lamentations 5
11/2	結 1:1-2:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=1&sec=1&chap2=2&sec2=10	11/2	Ezekiel 1:1-2:10
11/3	結 3:1-4:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=3&sec=1&chap2=4&sec2=17	11/3	Ezekiel 3:1-4:17
11/4	結 5:1-6:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=5&sec=1&chap2=6&sec2=14	11/4	Ezekiel 5:1-6:14
11/5	結 7:1-8:18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=7&sec=1&chap2=8&sec2=18	11/5	Ezekiel 7:1-8:18
11/6	結 9:1-10:22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=9&sec=1&chap2=10&sec2=22	11/6	Ezekiel 9:1-10:22
11/7	結 11:1-12:28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=11&sec=1&chap2=12&sec2=28	11/7	Ezekiel 11:1-12:28
11/8	結 13:1-14:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=13&sec=1&chap2=14&sec2=23	11/8	Ezekiel 13:1-14:23
11/9	結 15:1-16:63	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=15&sec=1&chap2=16&sec2=63	11/9	Ezekiel 15:1-16:63
11/10	結 17:1-18:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=17&sec=1&chap2=18&sec2=32	11/10	Ezekiel 17:1-18:32
11/11	結 19:1-20:49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=19&sec=1&chap2=20&sec2=49	11/11	Ezekiel 19:1-20:49
11/12	結 21:1-22:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=21&sec=1&chap2=22&sec2=31	11/12	Ezekiel 21:1-22:31
11/13	結 23:1-24:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=23&sec=1&chap2=24&sec2=27	11/13	Ezekiel 23:1-24:27
11/14	結 25:1-26:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=25&sec=1&chap2=26&sec2=21	11/14	Ezekiel 25:1-26:21
11/15	結 27:1-28:26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=27&sec=1&chap2=28&sec2=26	11/15	Ezekiel 27:1-28:26
11/16	結 29:1-30:26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=29&sec=1&chap2=30&sec2=26	11/16	Ezekiel 29:1-30:26
11/17	結 31:1-32:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=31&sec=1&chap2=32&sec2=32	11/17	Ezekiel 31:1-32:32
11/18	結 33:1-34:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=33&sec=1&chap2=34&sec2=31	11/18	Ezekiel 33:1-34:31
11/19	結 35:1-36:38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=35&sec=1&chap2=36&sec2=38	11/19	Ezekiel 35:1-36:38
11/20	結 37:1-38:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=37&sec=1&chap2=38&sec2=23	11/20	Ezekiel 37:1-38:23
11/21	結 39:1-40:49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=39&sec=1&chap2=40&sec2=49	11/21	Ezekiel 39:1-40:49
11/22	結 41:1-42:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=41&sec=1&chap2=42&sec2=20	11/22	Ezekiel 41:1-42:20
11/23	結 43:1-44:31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=43&sec=1&chap2=44&sec2=31	11/23	Ezekiel 43:1-44:31
11/24	結 45:1-46:24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=45&sec=1&chap2=46&sec2=24	11/24	Ezekiel 45:1-46:24
11/25	結 47:1-48:35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=結&chap=47&sec=1&chap2=48&sec2=35	11/25	Ezekiel 47:1-48:35
11/26	但 1:1-2:49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=1&sec=1&chap2=2&sec2=49	11/26	Daniel 1:1-2:49
11/27	但 3:1-4:37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=3&sec=1&chap2=4&sec2=37	11/27	Daniel 3:1-4:37
11/28	但 5:1-6:28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=5&sec=1&chap2=6&sec2=28	11/28	Daniel 5:1-6:28
11/29	但 7:1-8:27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=7&sec=1&chap2=8&sec2=27	11/29	Daniel 7:1-8:27
11/30	但 9:1-10:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=9&sec=1&chap2=10&sec2=21	11/30	Daniel 9:1-10:21
12/1	但 11:1-12:13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=但&chap=11&sec=1&chap2=12&sec2=13	12/1	Daniel 11:1-12:13
12/2	何 1:1-2:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=1&sec=1&chap2=2&sec2=23	12/2	Hosea 1:1-2:23
12/3	何 3:1-4:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=3&sec=1&chap2=4&sec2=19	12/3	Hosea 3:1-4:19
12/4	何 5:1-6:11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=5&sec=1&chap2=6&sec2=11	12/4	Hosea 5:1-6:11
12/5	何 7:1-8:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=7&sec=1&chap2=8&sec2=14	12/5	Hosea 7:1-8:14
12/6	何 9:1-10:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=9&sec=1&chap2=10&sec2=15	12/6	Hosea 9:1-10:15
12/7	何 11:1-12:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=11&sec=1&chap2=12&sec2=14	12/7	Hosea 11:1-12:14
12/8	何 13:1-14:9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=何&chap=13&sec=1&chap2=14&sec2=9	12/8	Hosea 13:1-14:9
12/9	珥 1:1-2:32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=珥&chap=1&sec=1&chap2=2&sec2=32	12/9	Joel 1:1-2:32
12/10	珥 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=珥&chap=3	12/10	Joel 3
12/11	摩 1:1-2:16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=摩&chap=1&sec=1&chap2=2&sec2=16	12/11	Amos 1:1-2:16
12/12	摩 3:1-4:13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=摩&chap=3&sec=1&chap2=4&sec2=13	12/12	Amos 3:1-4:13
12/13	摩 5:1-6:14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=摩&chap=5&sec=1&chap2=6&sec2=14	12/13	Amos 5:1-6:14
12/14	摩 7:1-9:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=摩&chap=7&sec=1&chap2=9&sec2=15	12/14	Amos 7:1-9:15
12/15	俄 1:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=俄&chap=1&sec=1-21	12/15	Obadiah 1:1-21
12/16	拿 1:1-2:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拿&chap=1&sec=1&chap2=2&sec2=10	12/16	Jonah 1:1-2:10
12/17	拿 3:1-4:11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=拿&chap=3&sec=1&chap2=4&sec2=11	12/17	Jonah 3:1-4:11
12/18	彌 1:1-3:12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彌&chap=1&sec=1&chap2=3&sec2=12	12/18	Micah 1:1-3:12
12/19	彌 4:1-5:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彌&chap=4&sec=1&chap2=5&sec2=15	12/19	Micah 4:1-5:15
12/20	彌 6:1-7:20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=彌&chap=6&sec=1&chap2=7&sec2=20	12/20	Micah 6:1-7:20
12/21	鴻 1:1-3:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=鴻&chap=1&sec=1&chap2=3&sec2=19	12/21	Nahum 1:1-3:19
12/22	哈 1:1-3:19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=哈&chap=1&sec=1&chap2=3&sec2=19	12/22	Habakkuk 1:1-3:19
12/23	番 1:1-2:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=番&chap=1&sec=1&chap2=2&sec2=15	12/23	Zephaniah 1:1-2:15
12/24	番 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=番&chap=3	12/24	Zephaniah 3
12/25	該 1:1-2:23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=該&chap=1&sec=1&chap2=2&sec2=23	12/25	Haggai 1:1-2:23
12/26	亞 1:1-3:10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=亞&chap=1&sec=1&chap2=3&sec2=10	12/26	Zechariah 1:1-3:10
12/27	亞 4:1-6:15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=亞&chap=4&sec=1&chap2=6&sec2=15	12/27	Zechariah 4:1-6:15
12/28	亞 7:1-9:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=亞&chap=7&sec=1&chap2=9&sec2=17	12/28	Zechariah 7:1-9:17
12/29	亞 10:1-14:21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=亞&chap=10&sec=1&chap2=14&sec2=21	12/29	Zechariah 10:1-14:21
12/30	瑪 1:1-2:17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=瑪&chap=1&sec=1&chap2=2&sec2=17	12/30	Malachi 1:1-2:17
12/31	瑪 3:1-4:6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=瑪&chap=3&sec=1&chap2=4&sec2=6	12/31	Malachi 3:1-4:6
1/1	詩 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=1	1/1	Psalms 1
1/2	詩 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=2	1/2	Psalms 2
1/3	詩 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=3	1/3	Psalms 3
1/4	詩 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=4	1/4	Psalms 4
1/5	詩 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=5	1/5	Psalms 5
1/6	詩 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=6	1/6	Psalms 6
1/7	詩 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=7	1/7	Psalms 7
1/8	詩 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=8	1/8	Psalms 8
1/9	詩 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=9	1/9	Psalms 9
1/10	詩 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=10	1/10	Psalms 10
1/11	詩 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=11	1/11	Psalms 11
1/12	詩 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=12	1/12	Psalms 12
1/13	詩 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=13	1/13	Psalms 13
1/14	詩 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=14	1/14	Psalms 14
1/15	詩 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=15	1/15	Psalms 15
1/16	詩 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=16	1/16	Psalms 16
1/17	詩 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=17	1/17	Psalms 17
1/18	詩 18:1-24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=18&sec=1-24	1/18	Psalms 18:1-24
1/19	詩 18:25-50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=18&sec=25-50	1/19	Psalms 18:25-50
1/20	詩 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=19	1/20	Psalms 19
1/21	詩 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=20	1/21	Psalms 20
1/22	詩 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=21	1/22	Psalms 21
1/23	詩 22:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=22&sec=1-11	1/23	Psalms 22:1-11
1/24	詩 22:12-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=22&sec=12-31	1/24	Psalms 22:12-31
1/25	詩 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=23	1/25	Psalms 23
1/26	詩 24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=24	1/26	Psalms 24
1/27	詩 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=25	1/27	Psalms 25
1/28	詩 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=26	1/28	Psalms 26
1/29	詩 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=27	1/29	Psalms 27
1/30	詩 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=28	1/30	Psalms 28
1/31	詩 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=29	1/31	Psalms 29
2/1	詩 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=30	2/1	Psalms 30
2/2	詩 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=31	2/2	Psalms 31
2/3	詩 32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=32	2/3	Psalms 32
2/4	詩 33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=33	2/4	Psalms 33
2/5	詩 34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=34	2/5	Psalms 34
2/6	詩 35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=35	2/6	Psalms 35
2/7	詩 36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=36	2/7	Psalms 36
2/8	詩 37:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=37&sec=1-22	2/8	Psalms 37:1-22
2/9	詩 37:23-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=37&sec=23-40	2/9	Psalms 37:23-40
2/10	詩 38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=38	2/10	Psalms 38
2/11	詩 39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=39	2/11	Psalms 39
2/12	詩 40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=40	2/12	Psalms 40
2/13	詩 41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=41	2/13	Psalms 41
2/14	詩 42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=42	2/14	Psalms 42
2/15	詩 43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=43	2/15	Psalms 43
2/16	詩 44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=44	2/16	Psalms 44
2/17	詩 45	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=45	2/17	Psalms 45
2/18	詩 46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=46	2/18	Psalms 46
2/19	詩 47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=47	2/19	Psalms 47
2/20	詩 48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=48	2/20	Psalms 48
2/21	詩 49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=49	2/21	Psalms 49
2/22	詩 50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=50	2/22	Psalms 50
2/23	詩 51	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=51	2/23	Psalms 51
2/24	詩 52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=52	2/24	Psalms 52
2/25	詩 53	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=53	2/25	Psalms 53
2/26	詩 54	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=54	2/26	Psalms 54
2/27	詩 55	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=55	2/27	Psalms 55
2/28	詩 56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=56	2/28	Psalms 56
3/1	詩 57	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=57	3/1	Psalms 57
3/2	詩 58	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=58	3/2	Psalms 58
3/3	詩 59	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=59	3/3	Psalms 59
3/4	詩 60	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=60	3/4	Psalms 60
3/5	詩 61	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=61	3/5	Psalms 61
3/6	詩 62	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=62	3/6	Psalms 62
3/7	詩 63	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=63	3/7	Psalms 63
3/8	詩 64	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=64	3/8	Psalms 64
3/9	詩 65	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=65	3/9	Psalms 65
3/10	詩 66	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=66	3/10	Psalms 66
3/11	詩 67	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=67	3/11	Psalms 67
3/12	詩 68	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=68	3/12	Psalms 68
3/13	詩 69:1-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=69&sec=1-18	3/13	Psalms 69:1-18
3/14	詩 69:19-36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=69&sec=19-36	3/14	Psalms 69:19-36
3/15	詩 70	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=70	3/15	Psalms 70
3/16	詩 71	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=71	3/16	Psalms 71
3/17	詩 72	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=72	3/17	Psalms 72
3/18	詩 73	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=73	3/18	Psalms 73
3/19	詩 74	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=74	3/19	Psalms 74
3/20	詩 75	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=75	3/20	Psalms 75
3/21	詩 76	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=76	3/21	Psalms 76
3/22	詩 77	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=77	3/22	Psalms 77
3/23	詩 78:1-39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=78&sec=1-39	3/23	Psalms 78:1-39
3/24	詩 78:40-72	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=78&sec=40-72	3/24	Psalms 78:40-72
3/25	詩 79	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=79	3/25	Psalms 79
3/26	詩 80	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=80	3/26	Psalms 80
3/27	詩 81	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=81	3/27	Psalms 81
3/28	詩 82	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=82	3/28	Psalms 82
3/29	詩 83	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=83	3/29	Psalms 83
3/30	詩 84	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=84	3/30	Psalms 84
3/31	詩 85	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=85	3/31	Psalms 85
4/1	詩 86	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=86	4/1	Psalms 86
4/2	詩 87	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=87	4/2	Psalms 87
4/3	詩 88	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=88	4/3	Psalms 88
4/4	詩 89:1-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=89&sec=1-18	4/4	Psalms 89:1-18
4/5	詩 89:19-52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=89&sec=19-52	4/5	Psalms 89:19-52
4/6	詩 90	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=90	4/6	Psalms 90
4/7	詩 91	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=91	4/7	Psalms 91
4/8	詩 92	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=92	4/8	Psalms 92
4/9	詩 93	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=93	4/9	Psalms 93
4/10	詩 94	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=94	4/10	Psalms 94
4/11	詩 95	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=95	4/11	Psalms 95
4/12	詩 96	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=96	4/12	Psalms 96
4/13	詩 97	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=97	4/13	Psalms 97
4/14	詩 98	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=98	4/14	Psalms 98
4/15	詩 99	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=99	4/15	Psalms 99
4/16	詩 100	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=100	4/16	Psalms 100
4/17	詩 101	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=101	4/17	Psalms 101
4/18	詩 102	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=102	4/18	Psalms 102
4/19	詩 103	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=103	4/19	Psalms 103
4/20	詩 104	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=104	4/20	Psalms 104
4/21	詩 105	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=105	4/21	Psalms 105
4/22	詩 106:1-23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=106&sec=1-23	4/22	Psalms 106:1-23
4/23	詩 106:24-48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=106&sec=24-48	4/23	Psalms 106:24-48
4/24	詩 107	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=107	4/24	Psalms 107
4/25	詩 108	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=108	4/25	Psalms 108
4/26	詩 109	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=109	4/26	Psalms 109
4/27	詩 110	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=110	4/27	Psalms 110
4/28	詩 111	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=111	4/28	Psalms 111
4/29	詩 112	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=112	4/29	Psalms 112
4/30	詩 113	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=113	4/30	Psalms 113
5/1	詩 114	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=114	5/1	Psalms 114
5/2	詩 115	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=115	5/2	Psalms 115
5/3	詩 116	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=116	5/3	Psalms 116
5/4	詩 117	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=117	5/4	Psalms 117
5/5	詩 118	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=118	5/5	Psalms 118
5/6	詩 119:1-8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=1-8	5/6	Psalms 119:1-8
5/7	詩 119:9-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=9-16	5/7	Psalms 119:9-16
5/8	詩 119:17-24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=17-24	5/8	Psalms 119:17-24
5/9	詩 119:25-32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=25-32	5/9	Psalms 119:25-32
5/10	詩 119:33-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=33-40	5/10	Psalms 119:33-40
5/11	詩 119:41-48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=41-48	5/11	Psalms 119:41-48
5/12	詩 119:49-56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=49-56	5/12	Psalms 119:49-56
5/13	詩 119:57-64	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=57-64	5/13	Psalms 119:57-64
5/14	詩 119:65-72	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=65-72	5/14	Psalms 119:65-72
5/15	詩 119:73-80	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=73-80	5/15	Psalms 119:73-80
5/16	詩 119:81-88	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=81-88	5/16	Psalms 119:81-88
5/17	詩 119:89-96	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=89-96	5/17	Psalms 119:89-96
5/18	詩 119:97-104	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=97-104	5/18	Psalms 119:97-104
5/19	詩 119:105-112	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=105-112	5/19	Psalms 119:105-112
5/20	詩 119:113-120	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=113-120	5/20	Psalms 119:113-120
5/21	詩 119:121-128	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=121-128	5/21	Psalms 119:121-128
5/22	詩 119:129-136	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=129-136	5/22	Psalms 119:129-136
5/23	詩 119:137-144	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=137-144	5/23	Psalms 119:137-144
5/24	詩 119:145-152	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=145-152	5/24	Psalms 119:145-152
5/25	詩 119:153-160	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=153-160	5/25	Psalms 119:153-160
5/26	詩 119:161-168	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=161-168	5/26	Psalms 119:161-168
5/27	詩 119:169-176	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=119&sec=169-176	5/27	Psalms 119:169-176
5/28	詩 120	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=120	5/28	Psalms 120
5/29	詩 121	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=121	5/29	Psalms 121
5/30	詩 122	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=122	5/30	Psalms 122
5/31	詩 123	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=123	5/31	Psalms 123
6/1	詩 124	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=124	6/1	Psalms 124
6/2	詩 125	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=125	6/2	Psalms 125
6/3	詩 126	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=126	6/3	Psalms 126
6/4	詩 127	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=127	6/4	Psalms 127
6/5	詩 128	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=128	6/5	Psalms 128
6/6	詩 129	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=129	6/6	Psalms 129
6/7	詩 130	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=130	6/7	Psalms 130
6/8	詩 131	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=131	6/8	Psalms 131
6/9	詩 132	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=132	6/9	Psalms 132
6/10	詩 133	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=133	6/10	Psalms 133
6/11	詩 134	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=134	6/11	Psalms 134
6/12	詩 135	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=135	6/12	Psalms 135
6/13	詩 136	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=136	6/13	Psalms 136
6/14	詩 137	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=137	6/14	Psalms 137
6/15	詩 138	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=138	6/15	Psalms 138
6/16	詩 139	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=139	6/16	Psalms 139
6/17	詩 140	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=140	6/17	Psalms 140
6/18	詩 141	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=141	6/18	Psalms 141
6/19	詩 142	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=142	6/19	Psalms 142
6/20	詩 143	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=143	6/20	Psalms 143
6/21	詩 144	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=144	6/21	Psalms 144
6/22	詩 145	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=145	6/22	Psalms 145
6/23	詩 146	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=146	6/23	Psalms 146
6/24	詩 147	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=147	6/24	Psalms 147
6/25	詩 148	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=148	6/25	Psalms 148
6/26	詩 149	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=149	6/26	Psalms 149
6/27	詩 150	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=詩&chap=150	6/27	Psalms 150
6/28	箴 1:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=1&sec=1-19	6/28	Proverbs 1:1-19
6/29	箴 1:20-33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=1&sec=20-33	6/29	Proverbs 1:20-33
6/30	箴 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=2	6/30	Proverbs 2
7/1	箴 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=3	7/1	Proverbs 3
7/2	箴 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=4	7/2	Proverbs 4
7/3	箴 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=5	7/3	Proverbs 5
7/4	箴 6:1-19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=6&sec=1-19	7/4	Proverbs 6:1-19
7/5	箴 6:20-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=6&sec=20-35	7/5	Proverbs 6:20-35
7/6	箴 7:1-8:36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=7&sec=1&chap2=8&sec2=36	7/6	Proverbs 7:1-8:36
7/7	箴 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=9	7/7	Proverbs 9
7/8	箴 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=10	7/8	Proverbs 10
7/9	箴 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=11	7/9	Proverbs 11
7/10	箴 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=12	7/10	Proverbs 12
7/11	箴 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=13	7/11	Proverbs 13
7/12	箴 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=14	7/12	Proverbs 14
7/13	箴 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=15	7/13	Proverbs 15
7/14	箴 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=16	7/14	Proverbs 16
7/15	箴 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=17	7/15	Proverbs 17
7/16	箴 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=18	7/16	Proverbs 18
7/17	箴 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=19	7/17	Proverbs 19
7/18	箴 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=20	7/18	Proverbs 20
7/19	箴 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=21	7/19	Proverbs 21
7/20	箴 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=22	7/20	Proverbs 22
7/21	箴 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=23	7/21	Proverbs 23
7/22	箴 24:1-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=24&sec=1-22	7/22	Proverbs 24:1-22
7/23	箴 24:23-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=24&sec=23-34	7/23	Proverbs 24:23-34
7/24	箴 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=25	7/24	Proverbs 25
7/25	箴 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=26	7/25	Proverbs 26
7/26	箴 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=27	7/26	Proverbs 27
7/27	箴 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=28	7/27	Proverbs 28
7/28	箴 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=29	7/28	Proverbs 29
7/29	箴 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=30	7/29	Proverbs 30
7/30	箴 31:1-9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=31&sec=1-9	7/30	Proverbs 31:1-9
7/31	箴 31:10-31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=箴&chap=31&sec=10-31	7/31	Proverbs 31:10-31
8/1	傳 1:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=1&sec=1-11	8/1	Ecclesiastes 1:1-11
8/2	傳 1:12-18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=1&sec=12-18	8/2	Ecclesiastes 1:12-18
8/3	傳 2:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=2&sec=1-11	8/3	Ecclesiastes 2:1-11
8/4	傳 2:12-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=2&sec=12-16	8/4	Ecclesiastes 2:12-16
8/5	傳 2:17-26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=2&sec=17-26	8/5	Ecclesiastes 2:17-26
8/6	傳 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=3	8/6	Ecclesiastes 3
8/7	傳 4:1-12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=4&sec=1-12	8/7	Ecclesiastes 4:1-12
8/8	傳 4:13-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=4&sec=13-16	8/8	Ecclesiastes 4:13-16
8/9	傳 5:1-7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=5&sec=1-7	8/9	Ecclesiastes 5:1-7
8/10	傳 5:8-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=5&sec=8-20	8/10	Ecclesiastes 5:8-20
8/11	傳 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=6	8/11	Ecclesiastes 6
8/12	傳 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=7	8/12	Ecclesiastes 7
8/13	傳 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=8	8/13	Ecclesiastes 8
8/14	傳 9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=9	8/14	Ecclesiastes 9
8/15	傳 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=10	8/15	Ecclesiastes 10
8/16	傳 11:1-6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=11&sec=1-6	8/16	Ecclesiastes 11:1-6
8/17	傳 11:7-10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=11&sec=7-10	8/17	Ecclesiastes 11:7-10
8/18	傳 12:1-8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=12&sec=1-8	8/18	Ecclesiastes 12:1-8
8/19	傳 12:9-14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=傳&chap=12&sec=9-14	8/19	Ecclesiastes 12:9-14
8/20	歌 1:1-7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=1&sec=1-7	8/20	Song of Songs 1:1-7
8/21	歌 1:8-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=1&sec=8-17	8/21	Song of Songs 1:8-17
8/22	歌 2:1-7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=2&sec=1-7	8/22	Song of Songs 2:1-7
8/23	歌 2:8-17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=2&sec=8-17	8/23	Song of Songs 2:8-17
8/24	歌 3:1-5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=3&sec=1-5	8/24	Song of Songs 3:1-5
8/25	歌 3:6-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=3&sec=6-11	8/25	Song of Songs 3:6-11
8/26	歌 4:1-7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=4&sec=1-7	8/26	Song of Songs 4:1-7
8/27	歌 4:8-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=4&sec=8-16	8/27	Song of Songs 4:8-16
8/28	歌 5:1-9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=5&sec=1-9	8/28	Song of Songs 5:1-9
8/29	歌 5:10-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=5&sec=10-16	8/29	Song of Songs 5:10-16
8/30	歌 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=6	8/30	Song of Songs 6
8/31	歌 7:1-9	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=7&sec=1-9	8/31	Song of Songs 7:1-9
9/1	歌 7:10-13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=7&sec=10-13	9/1	Song of Songs 7:10-13
9/2	歌 8:1-7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=8&sec=1-7	9/2	Song of Songs 8:1-7
9/3	歌 8:8-14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=歌&chap=8&sec=8-14	9/3	Song of Songs 8:8-14
9/4	伯 1:1-12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=1&sec=1-12	9/4	Job 1:1-12
9/5	伯 1:13-22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=1&sec=13-22	9/5	Job 1:13-22
9/6	伯 2:1-10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=2&sec=1-10	9/6	Job 2:1-10
9/7	伯 2:11-13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=2&sec=11-13	9/7	Job 2:11-13
9/8	伯 3	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=3	9/8	Job 3
9/9	伯 4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=4	9/9	Job 4
9/10	伯 5	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=5	9/10	Job 5
9/11	伯 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=6	9/11	Job 6
9/12	伯 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=7	9/12	Job 7
9/13	伯 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=8	9/13	Job 8
9/14	伯 9:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=9&sec=1-20	9/14	Job 9:1-20
9/15	伯 9:21-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=9&sec=21-35	9/15	Job 9:21-35
9/16	伯 10	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=10	9/16	Job 10
9/17	伯 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=11	9/17	Job 11
9/18	伯 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=12	9/18	Job 12
9/19	伯 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=13	9/19	Job 13
9/20	伯 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=14	9/20	Job 14
9/21	伯 15:1-16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=15&sec=1-16	9/21	Job 15:1-16
9/22	伯 15:17-35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=15&sec=17-35	9/22	Job 15:17-35
9/23	伯 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=16	9/23	Job 16
9/24	伯 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=17	9/24	Job 17
9/25	伯 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=18	9/25	Job 18
9/26	伯 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=19	9/26	Job 19
9/27	伯 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=20	9/27	Job 20
9/28	伯 21:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=21&sec=1-21	9/28	Job 21:1-21
9/29	伯 21:22-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=21&sec=22-34	9/29	Job 21:22-34
9/30	伯 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=22	9/30	Job 22
10/1	伯 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=23	10/1	Job 23
10/2	伯 24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=24	10/2	Job 24
10/3	伯 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=25	10/3	Job 25
10/4	伯 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=26	10/4	Job 26
10/5	伯 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=27	10/5	Job 27
10/6	伯 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=28	10/6	Job 28
10/7	伯 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=29	10/7	Job 29
10/8	伯 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=30	10/8	Job 30
10/9	伯 31:1-23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=31&sec=1-23	10/9	Job 31:1-23
10/10	伯 31:24-40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=31&sec=24-40	10/10	Job 31:24-40
10/11	伯 32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=32	10/11	Job 32
10/12	伯 33:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=33&sec=1-11	10/12	Job 33:1-11
10/13	伯 33:12-33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=33&sec=12-33	10/13	Job 33:12-33
10/14	伯 34:1-20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=34&sec=1-20	10/14	Job 34:1-20
10/15	伯 34:21-37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=34&sec=21-37	10/15	Job 34:21-37
10/16	伯 35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=35	10/16	Job 35
10/17	伯 36:1-15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=36&sec=1-15	10/17	Job 36:1-15
10/18	伯 36:16-33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=36&sec=16-33	10/18	Job 36:16-33
10/19	伯 37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=37	10/19	Job 37
10/20	伯 38:1-21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=38&sec=1-21	10/20	Job 38:1-21
10/21	伯 38:22-41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=38&sec=22-41	10/21	Job 38:22-41
10/22	伯 39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=39	10/22	Job 39
10/23	伯 40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=40	10/23	Job 40
10/24	伯 41:1-11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=41&sec=1-11	10/24	Job 41:1-11
10/25	伯 41:12-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=41&sec=12-34	10/25	Job 41:12-34
10/26	伯 42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=伯&chap=42	10/26	Job 42
10/27	賽 1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=1	10/27	Isaiah 1
10/28	賽 2	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=2	10/28	Isaiah 2
10/29	賽 3:1-4:1	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=3&sec=1&chap2=4&sec2=1	10/29	Isaiah 3:1-4:1
10/30	賽 4:2-5:7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=4&sec=2&chap2=5&sec2=7	10/30	Isaiah 4:2-5:7
10/31	賽 5:8-30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=5&sec=8-30	10/31	Isaiah 5:8-30
11/1	賽 6	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=6	11/1	Isaiah 6
11/2	賽 7	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=7	11/2	Isaiah 7
11/3	賽 8	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=8	11/3	Isaiah 8
11/4	賽 9:1-10:4	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=9&sec=1&chap2=10&sec2=4	11/4	Isaiah 9:1-10:4
11/5	賽 10:5-34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=10&sec=5-34	11/5	Isaiah 10:5-34
11/6	賽 11	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=11	11/6	Isaiah 11
11/7	賽 12	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=12	11/7	Isaiah 12
11/8	賽 13	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=13	11/8	Isaiah 13
11/9	賽 14	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=14	11/9	Isaiah 14
11/10	賽 15	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=15	11/10	Isaiah 15
11/11	賽 16	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=16	11/11	Isaiah 16
11/12	賽 17	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=17	11/12	Isaiah 17
11/13	賽 18	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=18	11/13	Isaiah 18
11/14	賽 19	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=19	11/14	Isaiah 19
11/15	賽 20	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=20	11/15	Isaiah 20
11/16	賽 21	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=21	11/16	Isaiah 21
11/17	賽 22	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=22	11/17	Isaiah 22
11/18	賽 23	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=23	11/18	Isaiah 23
11/19	賽 24	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=24	11/19	Isaiah 24
11/20	賽 25	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=25	11/20	Isaiah 25
11/21	賽 26	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=26	11/21	Isaiah 26
11/22	賽 27	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=27	11/22	Isaiah 27
11/23	賽 28	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=28	11/23	Isaiah 28
11/24	賽 29	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=29	11/24	Isaiah 29
11/25	賽 30	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=30	11/25	Isaiah 30
11/26	賽 31	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=31	11/26	Isaiah 31
11/27	賽 32	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=32	11/27	Isaiah 32
11/28	賽 33	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=33	11/28	Isaiah 33
11/29	賽 34	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=34	11/29	Isaiah 34
11/30	賽 35	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=35	11/30	Isaiah 35
12/1	賽 36	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=36	12/1	Isaiah 36
12/2	賽 37	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=37	12/2	Isaiah 37
12/3	賽 38	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=38	12/3	Isaiah 38
12/4	賽 39	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=39	12/4	Isaiah 39
12/5	賽 40	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=40	12/5	Isaiah 40
12/6	賽 41	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=41	12/6	Isaiah 41
12/7	賽 42	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=42	12/7	Isaiah 42
12/8	賽 43	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=43	12/8	Isaiah 43
12/9	賽 44	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=44	12/9	Isaiah 44
12/10	賽 45	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=45	12/10	Isaiah 45
12/11	賽 46	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=46	12/11	Isaiah 46
12/12	賽 47	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=47	12/12	Isaiah 47
12/13	賽 48	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=48	12/13	Isaiah 48
12/14	賽 49	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=49	12/14	Isaiah 49
12/15	賽 50	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=50	12/15	Isaiah 50
12/16	賽 51	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=51	12/16	Isaiah 51
12/17	賽 52	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=52	12/17	Isaiah 52
12/18	賽 53	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=53	12/18	Isaiah 53
12/19	賽 54	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=54	12/19	Isaiah 54
12/20	賽 55	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=55	12/20	Isaiah 55
12/21	賽 56	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=56	12/21	Isaiah 56
12/22	賽 57	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=57	12/22	Isaiah 57
12/23	賽 58	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=58	12/23	Isaiah 58
12/24	賽 59	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=59	12/24	Isaiah 59
12/25	賽 60	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=60	12/25	Isaiah 60
12/26	賽 61	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=61	12/26	Isaiah 61
12/27	賽 62	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=62	12/27	Isaiah 62
12/28	賽 63	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=63	12/28	Isaiah 63
12/29	賽 64	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=64	12/29	Isaiah 64
12/30	賽 65	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=65	12/30	Isaiah 65
12/31	賽 66	https://bible.fhl.net/new/read.php?VERSION=unv&TABFLAG=1&chineses=賽&chap=66	12/31	Isaiah 66";
    }
}