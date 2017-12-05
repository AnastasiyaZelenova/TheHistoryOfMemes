using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfMemes
{
    public class Meme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1000,2017)]
        public int Year { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public List<Group> Groups { get; set; }

        public int Likes { get; set; }

        public Meme()
        {

        }
    }
}
