using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulator.Models
{
    public class Ticket
    {
        public string? VehicleNumber { get; set; }
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
    }
}
