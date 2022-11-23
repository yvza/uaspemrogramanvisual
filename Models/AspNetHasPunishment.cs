using System;
using System.Collections.Generic;

namespace mvcwithlogin.Models
{
    public partial class AspNetHasPunishment
    {
        public string UserId { get; set; } = null!;
        public int Type { get; set; }
        public int Duration { get; set; }

        public virtual AspNetPunishmentType TypeNavigation { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
