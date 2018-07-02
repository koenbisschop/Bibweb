using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using BibDomain.Business;

namespace Bibweb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.1.1.min.js",
                    CdnDebugPath = "http://code.jquery.com/jquery-3.1.1.js",
                    CdnPath = "http://code.jquery.com/jquery-3.1.1.min.js"
                });// Load jQuery
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "bootstrap",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/bootstrap.min.js",
                    CdnPath = "http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.min.js",
                    CdnDebugPath = "http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.js"
                }); // Load Bootstrap
             
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Controller"] = new Controller();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}