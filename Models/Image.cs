using System;
using System.Collections.Generic;

#nullable disable

namespace dotnetBRAHIMNAMMOUCHI.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Chemin { get; set; }
        public int? IdProduit { get; set; }

        public virtual Produit IdProduitNavigation { get; set; }
    }
}
