using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public  class Locataire
    {
        [Required(ErrorMessage ="attention , une violation !")]
        public string Adresse { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdhesion { get; set; }
        public int Id  { get; set; }
        public int PointsBonus { get; set; }
        public string Telephone { get; set; }
        public Agent Agent { get; set; }
        public IList<Reservation>   Reservations { get; set;}
        
    }
}
