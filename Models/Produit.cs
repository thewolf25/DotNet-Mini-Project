using System;
using System.Collections.Generic;

#nullable disable

namespace dotnetBRAHIMNAMMOUCHI.Models
{
    public partial class Produit
    {
        public Produit()
        {
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
