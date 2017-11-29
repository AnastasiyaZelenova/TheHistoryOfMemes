using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfMemes
{
    public class Meme
    {
        public string Name { get; set; }
        public uint Year { get; set; }
        public byte[] Image { get; set; }
        public List<Group> Groups { get; set; }
        public List<Statistics> Statistics { get; set; }
    }
}
