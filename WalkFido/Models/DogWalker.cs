using System;
namespace WalkFido.Models
{
    public class DogWalker
    {
        public int Id { get; set; }
        public Walker Walker { get; set; }
        public Dog Dog { get; set; }

    }
}
