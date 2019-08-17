using System;
namespace WalkFido.Models
{
    public class Availability
    {
        public int Id { get; set; }
      
        public string Day{ get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool Available { get; set; }

        public Walker Walker { get; set; }
        public int WalkerId { get; set; }

      



    }

    
}
