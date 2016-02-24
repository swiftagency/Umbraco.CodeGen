﻿using System;
using System.CodeDom;
using NUnit.Framework;
using Umbraco.CodeGen.Configuration;
using Umbraco.CodeGen.Definitions;
using Umbraco.CodeGen.Generators;
using Umbraco.ModelsBuilder.Building;

namespace Umbraco.CodeGen.Tests.Generators.GenerateOnly
{
    [TestFixture]
    public class InterfacePropertyDeclarationGeneratorTests : TypeCodeGeneratorTestBase
    {
        private GeneratorConfig codeGenConfig;
        private PropertyModel property;
        private CodeMemberProperty codeProperty;

        [SetUp]
        public void SetUp()
        {
            Configuration = new GeneratorConfig();
            Generator = new InterfacePropertyDeclarationGenerator(
                Configuration
            );
            Candidate = codeProperty = new CodeMemberProperty();
            property = new PropertyModel { Alias = "aProperty", ClrName = "AProperty", ClrType = typeof(string) };
        }

        [Test]
        public void Generate_PropertyIsAbstract()
        {
            Generate();
            Assert.AreEqual(MemberAttributes.Abstract, codeProperty.Attributes);
        }

        [Test]
        public void Generate_Type_WhenConfigured_IsConfiguredType()
        {
            property.ClrType = typeof (int);
            Generate();
            Assert.AreEqual("System.Int32", codeProperty.Type.BaseType);
        }


        protected virtual void Generate()
        {
            Generator.Generate(Candidate, property);
        }
    }
}