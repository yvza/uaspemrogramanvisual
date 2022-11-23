using System;
using System.Collections.Generic;

namespace mvcwithlogin.Models
{
    public partial class AspNetPlayerDetail
    {
        public string UserId { get; set; } = null!;
        public int HasPunishment { get; set; }

        public virtual AspNetUser User { get; set; } = null!;
    }
}
