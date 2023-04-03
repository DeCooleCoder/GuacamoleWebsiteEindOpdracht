using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebsiteEindOpdracht.DataBase
{
    public class films
    {
        public int Film_id { get; set; }

        public string Naam { get; set; }

        public string Tijdsduur { get; set; }

        public string Genre { get; set; }

        public int Regisseur_id { get; set; }

        public string Plot { get; set; }

        public string ReleaseDate { get; set; }
    }
}
