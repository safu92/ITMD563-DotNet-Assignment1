using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Http_Module_Assignment_1.App_Code
{
    public class IPModule : IHttpModule
    {
        public IPModule() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
        }

        private void Application_BeginRequest(object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;
            string ipAddress = context.Request.UserHostAddress;
            //context.Response.Write(ipAddress);
            if (IsValidIpAddress(ipAddress))
            {
                context.Response.StatusCode = 403;  // (Forbidden)

            }
        }

        private bool IsValidIpAddress(string ipAddress)
        {
            return (ipAddress == "192.168.1.90");
        }

        public void Dispose() { /* clean up */ }
    }
}