﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.CodeGen.Definitions;

namespace Umbraco.CodeGen.Parsers
{
    public class MediaTypeCodeParser : ContentTypeCodeParser
    {
        public MediaTypeCodeParser(ContentTypeConfiguration configuration, InfoCodeParser infoParser)
            : base(configuration, infoParser)
        {
        }

        protected override ContentType CreateDefinition()
        {
            return new MediaType();
        }
    }
}
