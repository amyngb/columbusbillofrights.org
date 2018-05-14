using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCBOR.Web.Models
{
    public class Site
    {}

    public class MetaTags
    {
        public string charset { get; set; }
        public string language { get; set; }
        public string viewport { get; set; }
        public string httpEquivHTML { get; set; }
        public string XUACompatible { get; set; }
        public string author { get; set; }
        public string designer { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public string keywords { get; set; }
        public string robots { get; set; }
        public string copyright { get; set; }

        public static MetaTags Fill(String author, String description, String keywords)
        {

            MetaTags metaTags = new MetaTags();

            metaTags.charset = String.Format(@"
<meta charset=""{0}"">", "utf-8");

            metaTags.language = String.Format(@"
<meta name=""language"" content=""{0}"">", "english");

            metaTags.viewport = String.Format(@"
<meta name=""viewport"" content=""{0}"">", "width=device-width, maximum-scale=1, initial-scale=1, user-scalable=0");

            metaTags.httpEquivHTML = String.Format(@"
<meta http-equiv=""content-type"" content=""{0}"">", "text/html");

            metaTags.XUACompatible = String.Format(@"
<meta http-equiv=""X-UA-Compatible"" content=""{0}"">", "IE=edge,chrome=1");

            metaTags.author = String.Format(@"
<meta name=""author"" content=""{0}"">", author);

            metaTags.designer = String.Format(@"
<meta name=""designer"" content=""{0}"">", author);

            metaTags.publisher = String.Format(@"
<meta name=""publisher"" content=""{0}"">", author);

            metaTags.description = String.Format(@"
<meta name=""description"" content=""{0}"">", description);

            metaTags.keywords = String.Format(@"
<meta name=""keywords"" content=""{0}"">", keywords);

            metaTags.robots = String.Format(@"
<meta name=""robots"" content=""{0}"">", "index,follow");

            metaTags.copyright = String.Format(@"
<meta name=""copyright"" content=""{0}"">", "Copyright (c) 2000-2017 JMG Software");

            return metaTags;

        }

    }

}