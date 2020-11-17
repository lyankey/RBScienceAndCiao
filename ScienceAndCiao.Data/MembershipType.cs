using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Data
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public string MembershipName { get; set; }
        public int SignUpFee { get; set; }
        public byte SubscriptionDuration { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte NoMembership = 1;
    }
}
