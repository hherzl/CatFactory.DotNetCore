﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatFactory.CodeFactory;
using CatFactory.OOP;

namespace CatFactory.DotNetCore
{
    public static class ObjectBuilderExtensions
    {
        private static void AddAttributes(CodeBuilder codeBuilder, List<MetadataAttribute> attributes, StringBuilder output, Int32 start)
        {
            foreach (var attrib in attributes)
            {
                var attributeDefinition = new StringBuilder();

                attributeDefinition.Append("[");

                attributeDefinition.AppendFormat("{0}", attrib.Name);

                if (attrib.HasMembers)
                {
                    attributeDefinition.Append("(");

                    if (attrib.HasArguments)
                    {
                        attributeDefinition.Append(String.Join(", ", attrib.Arguments));
                    }

                    if (attrib.HasSets)
                    {
                        attributeDefinition.AppendFormat(", {0}", String.Join(", ", attrib.Sets.Select(item => String.Format("{0} = {1}", item.Name, item.Value))));
                    }

                    attributeDefinition.Append(")");
                }

                attributeDefinition.Append("]");

                output.AppendFormat("{0}{1}", codeBuilder.Indent(1), attributeDefinition.ToString());
                output.AppendLine();
            }
        }

        public static void AddAttributes(this CSharpClassBuilder classBuilder, StringBuilder output, Int32 start)
        {
            AddAttributes(classBuilder, classBuilder.ObjectDefinition.Attributes, output, start);
        }

        public static void AddAttributes(this CSharpInterfaceBuilder interfaceBuilder, StringBuilder output, Int32 start)
        {
            AddAttributes(interfaceBuilder, interfaceBuilder.ObjectDefinition.Attributes, output, start);
        }

        public static void AddAttributes(this DotNetCodeBuilder codeBuilder, PropertyDefinition propertyDefinition, StringBuilder output, Int32 start)
        {
            AddAttributes(codeBuilder, propertyDefinition.Attributes, output, start);
        }
    }
}
