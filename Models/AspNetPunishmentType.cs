using System;
using System.Collections.Generic;

namespace mvcwithlogin.Models
{
    public partial class AspNetPunishmentType
    {
        public AspNetPunishmentType()
        {
            AspNetHasPunishments = new HashSet<AspNetHasPunishment>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<AspNetHasPunishment> AspNetHasPunishments { get; set; }
    }
}
