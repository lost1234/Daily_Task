using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace testHTML
{
    class Program
    {
        /*
        public static string html_table(string htmlstring)
        {
            Regex reg = new Regex("(?is)(?<=<table[^>]*?[^>]*?>(?:(?!</?table).)*)(?is)<tr[^>]*?[^>]*?>(?:\\s*<td[^>]*>(.*?)</td>)*\\s*</tr>");
            //MactchCollection mc = reg.Matches(htmlstring);
        }
        */
        public static string NoHtml(string Htmlstring)
        {
            //delete script   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "/", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(/d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("/r/n", "");

            return Htmlstring;
        }

        static void Main(string[] args)
        {
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;
                Byte[] pageData = MyWebClient.DownloadData("https://docs.microsoft.com/en-us/azure/cognitive-services/Translator/language-support"); //从指定网站下载数据                                                                                                                                          //string pageHtml = Encoding.Default.GetString(pageData);     
                string pageHtml = Encoding.UTF8.GetString(pageData);
                //Console.WriteLine(pageHtml);
                //pageHtml = NoHtml(pageHtml) ;
                using (StreamWriter sw = new StreamWriter("test.txt"))
                {
                    sw.Write(pageHtml);
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message.ToString());
            }
        }
    }
}
