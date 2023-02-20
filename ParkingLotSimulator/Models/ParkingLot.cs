using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulator.Models
{
    public class ParkingLot
    {
        public List<Ticket> Tickets { get; set; }

        public IDictionary<VehicleType, List<Slot>>? Slots {get;set;}
    }
}
