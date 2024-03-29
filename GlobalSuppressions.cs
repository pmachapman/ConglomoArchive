// -----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Conglomo">
// Copyright 2015-2023 Conglomo Limited. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Conglomo", Scope = "namespace", Target = "~N:Conglomo.Archive", Justification = "This is the company name.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "~N:Conglomo.Archive", Justification = "There is only one namespace")]
