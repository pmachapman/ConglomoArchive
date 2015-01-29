// -----------------------------------------------------------------------
// <copyright file="RSS.ashx.cs" company="Conglomo">
// Copyright 2015 Peter Chapman. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.Archive
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Xml.Linq;

    /// <summary>
    /// THe RSS feed handler.
    /// </summary>
    public class Rss : IHttpHandler
    {
        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler" /> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler" /> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            // Make sure there is a context
            if (context != default(HttpContext))
            {
                // Set the output to XML
                context.Response.ContentType = "text/xml";

                // Generate the feed
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("rss", new XAttribute("version", "2.0"), new XElement("channel", new XElement("title", "Conglomo Archives"), new XElement("link", context.Request.Url.GetLeftPart(UriPartial.Authority) + context.Request.ApplicationPath), CreateElements(context))));
                context.Response.ContentType = "text/xml";
                document.Save(context.Response.Output);
                context.Response.End();
            }
        }

        /// <summary>
        /// Creates the elements.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The elements.</returns>
        private static IEnumerable<XElement> CreateElements(HttpContext context)
        {
            // Set up the list of elements
            List<XElement> list = new List<XElement>();

            // Get the website url
            string website = context.Request.Url.GetLeftPart(UriPartial.Authority) + context.Request.ApplicationPath;
            if (!website.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                website += "/";
            }

            // Gerate the list of elements
            foreach (string file in GetFiles(context))
            {
                // Get the parts for the element
                string link = website + file;
                string path = context.Server.MapPath("~/" + file);
                string title = Path.GetFileNameWithoutExtension(path);
                string pubDate = File.GetLastWriteTimeUtc(path).ToString("o", CultureInfo.CurrentCulture);

                // Generate the element
                XElement itemElement = new XElement("item", new XElement("title", title), new XElement("pubDate", pubDate), new XElement("link", link));

                // Add the element to the list
                list.Add(itemElement);
            }

            return list;
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The list of files.</returns>
        private static List<string> GetFiles(HttpContext context)
        {
            // Get the list of files
            List<string> files = Directory.GetFiles(context.Server.MapPath("~/"), "*.*", SearchOption.AllDirectories).ToList();

            // Remove the local path, and clean the slashes
            for (int i = 0; i < files.Count; i++)
            {
                files[i] = files[i].Replace(context.Server.MapPath("~/"), string.Empty);
                files[i] = files[i].Replace("\\", "/").TrimStart('/');
            }

            // Remove any files in the ban list
            files = files.Where(f => !Settings.InvalidFiles.Contains(f.ToUpper(CultureInfo.CurrentCulture))).ToList();

            // Remove any files from the banned directories
            foreach (string directory in Settings.InvalidDirectories)
            {
                files = files.Where(f => !f.ToUpper(CultureInfo.CurrentCulture).StartsWith(directory + "/", StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Remove any files with banned extensions
            foreach (string extension in Settings.InvalidFileExtensions)
            {
                files = files.Where(f => !f.ToUpper(CultureInfo.CurrentCulture).EndsWith(extension, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return files;
        }
    }
}