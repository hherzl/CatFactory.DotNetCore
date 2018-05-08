﻿using System.Text;
using CatFactory.CodeFactory;
using CatFactory.OOP;

namespace CatFactory.NetCore
{
    public class CSharpCodeBuilder : DotNetCodeBuilder
    {
        public static void CreateFiles(string outputDirectory, string subdirectory, bool forceOverwrite, params IDotNetObjectDefinition[] definitions)
        {
            foreach (var definition in definitions)
            {
                if (definition is CSharpClassDefinition)
                {
                    var codeBuilder = new CSharpClassBuilder
                    {
                        OutputDirectory = outputDirectory,
                        ForceOverwrite = forceOverwrite,
                        ObjectDefinition = (CSharpClassDefinition)definition
                    };

                    codeBuilder.CreateFile(subdirectory);
                }
                else if (definition is CSharpInterfaceDefinition)
                {
                    var codeBuilder = new CSharpInterfaceBuilder
                    {
                        OutputDirectory = outputDirectory,
                        ForceOverwrite = forceOverwrite,
                        ObjectDefinition = (CSharpInterfaceDefinition)definition
                    };

                    codeBuilder.CreateFile(subdirectory);
                }
            }
        }

        public CSharpCodeBuilder()
        {
            ConstantsRegionDescription = "[ Constants ]";
            EventsRegionDescription = "[ Events ]";
            FieldsRegionDescription = "[ Fields ]";
            ConstructorsRegionDescription = "[ Constructor ]";
            FinalizerRegionDescription = "[ Finalizer ]";
            IndexersRegionDescription = "[ Indexers ]";
            PropertiesRegionDescription = "[ Properties ]";
            MethodsRegionDescription = "[ Methods ]";
        }

        protected override void AddDocumentation(StringBuilder output, int start, Documentation documentation)
        {
            if (!string.IsNullOrEmpty(documentation.Summary))
            {
                //output.AppendFormat("{0}/// <summary>", Indent(start));
                //output.AppendLine();

                Lines.Add(new CodeLine("{0}/// <summary>", Indent(start)));
                //Lines.Add(new CodeLine());

                //output.AppendFormat("{0}/// {1}", Indent(start), documentation.Summary);
                //output.AppendLine();

                Lines.Add(new CodeLine("{0}/// {1}", Indent(start), documentation.Summary));
                //Lines.Add(new CodeLine());

                //output.AppendFormat("{0}/// </summary>", Indent(start));
                //output.AppendLine();

                Lines.Add(new CodeLine("{0}/// </summary>", Indent(start)));
                //Lines.Add(new CodeLine());
            }

            if (!string.IsNullOrEmpty(documentation.Remarks))
            {
                //output.AppendFormat("{0}/// <remarks>{1}</remarks>", Indent(start), documentation.Remarks);
                //output.AppendLine();

                Lines.Add(new CodeLine("{0}/// <remarks>{1}</remarks>", Indent(start), documentation.Remarks));
                //Lines.Add(new CodeLine());
            }
        }

        public override string FileExtension
            => "cs";

        protected override string GetComment(string description)
            => string.Format("//{0}", description);

        protected override string GetPreprocessorDirective(string name)
            => string.Format("#{0}", name);

        protected override string GetTodo(string description)
            => string.Format("// todo: {0}", description);
    }
}
