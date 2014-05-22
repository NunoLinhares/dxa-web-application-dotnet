﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sdl.Web.Mvc.Models
{
    [SemanticEntity(EntityName = "Image", Prefix = "i", Vocab = Configuration.CoreVocabulary)]
    [SemanticEntity(EntityName = "Article", Prefix = "a", Vocab = Configuration.CoreVocabulary)]
    public class Teaser : Entity
    {
        //A teaser can be mapped from an article, in which case the link should be to the article itself
        [SemanticProperty("a:_self")]
        public Link Link { get; set; }
        public string Headline { get; set; }
        //A teaser can be mapped from an individual image, in which case the image property is set from the source entity itself
        [SemanticProperty("i:_self")]
        public Image Image { get; set; }
        [SemanticProperty("a:introText")]
        public string Text { get; set; }
    }
}