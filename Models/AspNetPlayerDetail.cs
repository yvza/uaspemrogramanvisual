using System;
using System.Collections.Generic;

namespace mvcwithlogin.Models
{
    public partial class AspNetPlayerDetail
    {
        public string UserId { get; set; } = null!;
        public string HasPunishment { get; set; } = null!;

        public virtual AspNetUser User { get; set; } = null!;
    }
}
