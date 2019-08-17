using System;
namespace WalkFido.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } //FK
        public AppUser User { get; set; }

    }
}
