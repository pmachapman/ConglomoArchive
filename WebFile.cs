// -----------------------------------------------------------------------
// <copyright file="WebFile.cs" company="Conglomo">
// Copyright 2014 Peter Chapman. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.Archive
{
    using System;

    /// <summary>
    /// A web file.
    /// </summary>
    public struct WebFile
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Uri Icon { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public Uri Url { get; set; }

        /// <summary>
        /// == comparison operator.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public static bool operator ==(WebFile object1, WebFile object2)
        {
            return object1.Equals(object2);
        }

        /// <summary>
        /// != comparison operator.
        /// </summary>
        /// <param name="object1">The object1.</param>
        /// <param name="object2">The object2.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is not equal to this instance; otherwise, <c>false</c>.</returns>
        public static bool operator !=(WebFile object1, WebFile object2)
        {
            return !object1.Equals(object2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Url.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is WebFile))
            {
                return false;
            }
            else
            {
                return this.Equals((WebFile)obj);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(WebFile obj)
        {
            if (this.Url != obj.Url)
            {
                return false;
            }
            else
            {
                return this.Url == obj.Url;
            }
        }
    }
}