using System;
using System.Collections.Generic;

namespace WalkFido.Models
{
    public class Walker
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } //FK

        public AppUser User { get; set; }

       
        public string Area { get; set; }

        public List<DogWalker>DogWalkers{ get; set; }
        public List<Availability>Availabilities{ get; set; }


    }
}
