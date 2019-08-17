using System;
namespace WalkFido.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Messages { get; set; }

        public int OwnerId { get; set; }
        public int WalkerId { get; set; }



    }
}
