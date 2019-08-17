using System;
using System.Collections.Generic;

namespace WalkFido.Models
{
    public class Dog //Primary key?? Foreign key???
    {
        public int Id { get; set; }
        public string DogName { get; set; }
        public string Breed { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool WalkerNeeded { get; set; }

        public List<DogWalker>DogWalkers { get; set; }

    }
}
