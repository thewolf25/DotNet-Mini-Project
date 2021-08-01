using System;
using System.Collections.Generic;

#nullable disable

namespace miniProject.Models
{
    public partial class Utilisateur
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Motdepasse { get; set; }
        public string Role { get; set; }
    }
}
