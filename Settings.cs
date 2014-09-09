// -----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Conglomo">
// Copyright 2014 Peter Chapman. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.Archive
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Website settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Gets the invalid directories.
        /// </summary>
        /// <value>
        /// The invalid directories.
        /// </value>
        public static ReadOnlyCollection<string> InvalidDirectories
        {
            get
            {
                return new List<string>() { "BIN", "OBJ", "FILEICONS", "APP_DATA", ".GIT" }.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the invalid file extensions.
        /// </summary>
        /// <value>
        /// The invalid file extensions.
        /// </value>
        public static ReadOnlyCollection<string> InvalidFileExtensions
        {
            get
            {
                return new List<string>() { ".ASHX", ".ASPX", ".CONFIG" }.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the invalid files.
        /// </summary>
        /// <value>
        /// The invalid files.
        /// </value>
        public static ReadOnlyCollection<string> InvalidFiles
        {
            get
            {
                return new List<string>() { "BINGSITEAUTH.XML", "FAVICON.ICO", "GOOGLE31F0BA739DE58F42.HTML", "ROBOTS.TXT" }.AsReadOnly();
            }
        }
    }
}