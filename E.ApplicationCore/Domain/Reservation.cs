using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public  class Reservation
    {
        public DateTime DateReservation { get; set; }
        [Range (1,30)]
        public int DureeJours { get; set; }
        
        public int LocataireFK { get; set; }
        public Locataire Locataire { get; set; }
        public int VehiculeKey { get; set; }
        public Vehicule vehicule { get; set; }  

    }
}
