using System;
using System.Collections.Generic;

namespace mvcwithlogin.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Hashtag { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
