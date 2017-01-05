using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class BuilderVehicle
    {
        public static void Main()
        {
            VehicleBuilder builder;

            Shop shop = new Shop();

            //Consturct and display vehicles
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();


            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycyleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            Console.ReadKey();
        }
    }

    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuldWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuldWheels();
        public abstract void BuildDoors();
    }

    class MotorCycyleBuilder : VehicleBuilder
    {
        public MotorCycyleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "250 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuldWheels()
        {
            vehicle["wheels"] = "2";
        }
    }

    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "1600 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuldWheels()
        {
            vehicle["wheels"] = "4";
        }
    }

    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuldWheels()
        {
            vehicle["wheels"] = "2";
        }
    }

    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)// Constructor
        {
            this._vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}
