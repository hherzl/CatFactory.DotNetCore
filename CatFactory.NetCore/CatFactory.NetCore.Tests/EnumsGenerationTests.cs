﻿using CatFactory.OOP;
using Xunit;

namespace CatFactory.NetCore.Tests
{
    public class EnumsGenerationTests
    {
        [Fact]
        public void TestSimpleEnumGeneration()
        {
            // Arrange
            var definition = new CSharpEnumDefinition
            {
                Name = "OperationMode",
                Sets =
                {
                    new NameValue { Name = "First", Value = "0" },
                    new NameValue { Name = "Second", Value = "1" },
                    new NameValue { Name = "Third", Value = "2" }
                }
            };

            // Act
            CSharpEnumBuilder.CreateFiles("C:\\Temp\\CatFactory.NetCore", string.Empty, true, definition);
        }

        [Fact]
        public void TestEnumWithFlagsGeneration()
        {
            // Arrange
            var definition = new CSharpEnumDefinition
            {
                Namespaces =
                {
                    "System"
                },
                Attributes =
                {
                    new MetadataAttribute("Flags")
                },
                Name = "CarOptions",
                Sets =
                {
                    new NameValue { Name = "SunRoof", Value = "0x01" },
                    new NameValue { Name = "Spoiler", Value = "0x02" },
                    new NameValue { Name = "FogLights", Value = "0x04" },
                    new NameValue { Name = "TintedWindows", Value = "0x08" }
                }
            };

            // Act
            CSharpEnumBuilder.CreateFiles("C:\\Temp\\CatFactory.NetCore", string.Empty, true, definition);
        }
    }
}
