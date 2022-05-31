// <copyright file="DemoSnippetsParser.cs" company="Matt Lacey Ltd.">
// Copyright (c) Matt Lacey Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Xml;

namespace DemoSnippets
{
    public class SnippetsParser
    {
        public List<ToolboxEntry> GetItemsToAdd(string snippetXml)
        {
            var result = new List<ToolboxEntry>();

            using (var reader = XmlReader.Create(snippetXml))
            {
                reader.ReadToFollowing("CodeSnippet");

                do
                {
                    var toAdd = new ToolboxEntry();

                    toAdd.Tab = "Snippets From Filesystem";

                    reader.ReadToFollowing("Title");
                    toAdd.Label = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("Shortcut");
                    toAdd.Snippet = reader.ReadElementContentAsString();

                    result.Add(toAdd);
                } while (reader.ReadToFollowing("CodeSnippet"));
            }
            return result;
        }
    }
}
