using ParkingLotSimulator.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("******************** Welcome To Parking Lot ********************");
        Console.WriteLine("Provide the number of slots to initialize parking");

        Console.WriteLine("Enter number of 2 wheeler slots");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of 4 wheeler slots");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of heavy vehicle slots");
        int o = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Your parking lot initialization is done.");

        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Slots = new Dictionary<VehicleType, List<Slot>>();
        parkingLot.Tickets = new List<Ticket>();


        var twoWheelerSlots = CreateSlots(m);
        var fourWheelerSlots = CreateSlots(n);
        var heavyVehicleSlots = CreateSlots(o);


        parkingLot.Slots.Add(VehicleType.TwoWheeler, twoWheelerSlots);
        parkingLot.Slots.Add(VehicleType.FourWheeler, fourWheelerSlots);
        parkingLot.Slots.Add(VehicleType.HeavyVehicle, heavyVehicleSlots);


        while (true)
        {

            Console.WriteLine("Now Enter\n 1. To Check Availability. \n 2. To Park Vehicle \n 3. To Unpark Vehicle");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Vehicle Type. 0 For Two Wheeler. 1 For Four Wheeler and 2 For Heavy Vehicle ");
            int vehicleType = Convert.ToInt32(Console.ReadLine());
            VehicleType type = (VehicleType)vehicleType;
            switch (i)
            {
                case 1:
                    int x = parkingLot.Slots[type].Where(f =>f.IsParked == false).Count();
                    Console.WriteLine("Availabile space for {0} is {1}",type,x);
                break;


                case 2:
                    Console.WriteLine("Enter the Vehicle Number to park");
                    string number = Console.ReadLine();
                    var z = parkingLot.Slots[type].Where(f => f.IsParked == false).FirstOrDefault();
                    
                    if (z != null)
                    {
                        z.VehicleDetail.Number = number;
                        z.IsParked = true;
                        Ticket recentTicket = new Ticket()
                        {
                            VehicleNumber = z.VehicleDetail.Number,
                            SlotNumber = z.Number,
                            InTime = DateTime.Now
                        };
                        parkingLot.Tickets.Add(new Ticket()
                        {
                            VehicleNumber = number,
                            SlotNumber = z.Number,
                            InTime = DateTime.Now
                        });
                        Console.WriteLine("Your Ticket\n");
                        Console.WriteLine(" Vehicle Number - {0}\n Slot Number - {1}\n In Time - {2}",
                            recentTicket.VehicleNumber,recentTicket.SlotNumber,recentTicket.InTime);

                        Console.WriteLine("Parked {0}", type);
                    }
                    else
                    {
                        Console.WriteLine("No slot available to park, please check availability first");
                    }
                    
             
                break;


                case 3:
                    Console.WriteLine("Enter vehicle number to unpark");
                    string vehicleNumber = Console.ReadLine();
                    Slot y = parkingLot.Slots[type].Where(f=> f.VehicleDetail.Number == vehicleNumber).FirstOrDefault();
                    if (y != null)
                    {
                        y.IsParked = false;
                        Console.WriteLine("Vehicle Unparked");
                    }
                    else
                    {
                        Console.WriteLine("There is no vehicle of vehicle number {0} parked.Enter the valid vehicle type and number",vehicleNumber);
                    }
                    

                break;

                default:

                    Console.WriteLine("Enter the valid number");
                    break;

            }
        }
        
        
    }

    private static List<Slot> CreateSlots( int numberOfSlots)
    {
        List<Slot> slots = new List<Slot>();
        for (int i = 0; i < numberOfSlots; i++)
        {
            slots.Add(new Slot()
            {
                Number = i + 1,
                IsParked = false,
                VehicleDetail = new Vehicle()
            });
        }
        return slots;
    }
}