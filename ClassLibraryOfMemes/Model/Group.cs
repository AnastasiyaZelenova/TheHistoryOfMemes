﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfMemes
{
    public class Group
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Meme> Memes { get; set; }
    }
}
