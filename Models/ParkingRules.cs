using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class ParkingRules
    {
        public int Id { get; set; }
        public string RuleDescription { get; set; }
        public double Amount { get; set; }
    }
}
