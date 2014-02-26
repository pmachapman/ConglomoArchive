// -----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Conglomo">
// Copyright 2014 Peter Chapman. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.Archive
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    /// <summary>
    /// The home page.
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Handles the Load event of the Page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "The site name should not be localised")]
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the folder we are looking at
            string folder;
            if (!string.IsNullOrWhiteSpace(this.Request["folder"]) && !this.Request["folder"].Contains("../"))
            {
                folder = this.Request["folder"].Trim();
                if (folder.StartsWith("/", StringComparison.OrdinalIgnoreCase))
                {
                    folder = folder.Substring(1);
                }

                if (!folder.EndsWith("/", StringComparison.OrdinalIgnoreCase))
                {
                    folder += "/";
                }
            }
            else
            {
                folder = string.Empty;
            }

            folder = "~/" + folder;

            // Build a list of web files
            List<WebFile> webFiles = new List<WebFile>();

            // If we are not in the root directory, show the navigate up button
            if (folder != "~/")
            {
                // Show the path in the title
                this.Page.Title = string.Format(CultureInfo.CurrentCulture, "Conglomo Archives - {0}", folder.TrimStart('~').Trim('/'));

                // Update the meta description
                this.Page.MetaDescription = string.Format(CultureInfo.CurrentCulture, "Conglomo Archives - Viewing {0}", folder.TrimStart('~').Trim('/'));

                // Build the web file object
                WebFile webFile = new WebFile();
                webFile.Icon = new Uri(ResolveUrl("~/FileIcons/previous.png"), UriKind.Relative);
                webFile.Name = "Previous Directory";
                string[] directoryParts = folder.Substring(1).Trim('/').Split(new char[] { '/' }, StringSplitOptions.None);
                string parent = Path.Combine(directoryParts.Take(directoryParts.Length - 1).ToArray()).Replace("\\", "/");
                if (string.IsNullOrEmpty(parent))
                {
                    webFile.Url = new Uri(ResolveUrl("~/"), UriKind.Relative);
                }
                else
                {
                    webFile.Url = new Uri(ResolveUrl("~/Default.aspx") + "?folder=/" + parent, UriKind.Relative);
                }

                // Add the web file to the list
                webFiles.Add(webFile);
            }
            else
            {
                this.Page.MetaDescription = "Welcome to the Conglomo Archives";
            }

            try
            {
                // Add directories in the directory
                foreach (string path in Directory.GetDirectories(Server.MapPath(folder), "*.*", SearchOption.TopDirectoryOnly).OrderBy(f => f))
                {
                    // Get the directory info
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);

                    // Exclude invalid directories
                    if (!Settings.InvalidDirectories.Contains(directoryInfo.Name.ToUpperInvariant()))
                    {
                        // Build the web file object
                        WebFile webFile = new WebFile();
                        webFile.Icon = new Uri(ResolveUrl("~/FileIcons/folder.png"), UriKind.Relative);
                        webFile.Name = directoryInfo.Name;
                        webFile.Url = new Uri(ResolveUrl("~/Default.aspx") + "?folder=" + folder.Substring(1) + directoryInfo.Name, UriKind.Relative);

                        // Add the web file to the list
                        webFiles.Add(webFile);
                    }
                }

                // Add files in the directory
                foreach (string path in Directory.GetFiles(Server.MapPath(folder), "*.*", SearchOption.TopDirectoryOnly).OrderBy(f => f))
                {
                    // Get the file info
                    FileInfo fileInfo = new FileInfo(path);

                    // Exclude invalid file types
                    if (!Settings.InvalidFileExtensions.Contains(fileInfo.Extension.ToUpperInvariant())
                        && !Settings.InvalidFiles.Contains(fileInfo.Name.ToUpperInvariant()))
                    {
                        // Get the icon
                        string icon = "~/FileIcons/" + GetCommonExtension(fileInfo.Extension.TrimStart('.').ToLower(CultureInfo.CurrentCulture)) + ".png";
                        if (!File.Exists(Server.MapPath(icon)))
                        {
                            icon = "~/FileIcons/default.png";
                        }

                        // Build the web file object
                        WebFile webFile = new WebFile();
                        webFile.Icon = new Uri(ResolveUrl(icon), UriKind.Relative);
                        webFile.Name = fileInfo.Name;
                        webFile.Url = new Uri(ResolveUrl(folder + fileInfo.Name), UriKind.Relative);

                        // Add the web file to the list
                        webFiles.Add(webFile);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!(ex is DirectoryNotFoundException
                    || ex is HttpException))
                {
                    throw;
                }
            }

            // Bind the list of files
            this.FileList.DataSource = webFiles.AsReadOnly();
            this.FileList.DataBind();
        }

        /// <summary>
        /// Gets an extension that is similar to the specified extension, one that we have an icon available for
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>The common extension.</returns>
        private static string GetCommonExtension(string extension)
        {
            switch (extension)
            {
                case "jfif":
                case "jif":
                case "jpeg":
                case "jpe":
                case "jp2":
                    extension = "jpg";
                    break;
                case "tiff":
                    extension = "tif";
                    break;
                case "html":
                case "asp":
                case "php":
                case "php3":
                case "shtml":
                case "cfm":
                case "fcgi":
                case "mvc":
                    extension = "htm";
                    break;
                case "wbmp":
                    extension = "wbm";
                    break;
                case "doc":
                case "docx":
                    extension = "doc";
                    break;
                case "ppt":
                case "pptx":
                    extension = "ppt";
                    break;
                case "xls":
                case "xlsx":
                    extension = "xls";
                    break;
                case "mp3":
                case "wav":
                case "wma":
                    extension = "mp3";
                    break;
                case "wmv":
                case "mpg":
                case "mpeg":
                case "avi":
                    extension = "wmv";
                    break;
                case "sql":
                case "csv":
                case "log":
                    extension = "txt";
                    break;
                case "pl":
                case "py":
                    extension = "pl";
                    break;
                case "7z":
                case "ace":
                case "arc":
                case "arj":
                case "cab":
                case "deb":
                case "gz":
                case "lzh":
                case "rar":
                case "tar":
                    extension = "zip";
                    break;
            }

            return extension;
        }
    }
}