using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulator.Models
{
    public class Slot
    {
        public int Number { get; set; } 

        //public VehicleEnum VehicleType { get; set; }
        public Vehicle? VehicleDetail { get; set; }

        public bool IsParked { get; set; }
    }
}
