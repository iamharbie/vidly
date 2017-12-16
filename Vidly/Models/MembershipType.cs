using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; } 
        public byte DiscountRate { get; set; }

        public static readonly byte UNKNOWN = 0;
        public static readonly byte PAY_AS_YOU_GO = 1;

    }
}