﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.CodeGen.Configuration;
using Umbraco.CodeGen.Generators.GenerateOnly;

namespace Umbraco.CodeGen.Generators
{
    public class InterfaceGeneratorFactory : CodeGeneratorFactory
    {
        public override CodeGeneratorBase Create(Configuration.GeneratorConfig configuration)
        {
            return CreateInterfaceGenerator(configuration);
        }

        public CodeGeneratorBase CreateInterfaceGenerator(Configuration.GeneratorConfig configuration)
        {
            return new NamespaceGenerator(
                configuration,
                new ImportsGenerator(configuration),
                new InterfaceGenerator(configuration,
                    new CompositeCodeGenerator(
                        configuration,
                        new InterfaceNameGenerator(configuration)
                        ),
                    new PropertiesGenerator(
                        configuration,
                        new InterfacePropertyDeclarationGenerator(
                            configuration,
                            new EntityNameGenerator(configuration),
                            new InterfacePropertyBodyGenerator(configuration)
                            )
                        )
                    )
                );
        }
    }
}
