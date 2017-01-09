using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    class CarDecorator
    {//http://safakunel.blogspot.com/2013/11/c-decorator-pattern-kullanimi-oop-design.html
        public static void Main(string[] args)
        {
            Car car = new Car() { Model = "Astra", Brand = "Opel", Price = 35.1m, Description = "New car added." };
            car.PrintDetail();

            //nesnemize airbag özelliği ekleniyor
            AirBagDecorator carWithairbag = new AirBagDecorator(car);
            carWithairbag.PrintDetail();

            //nesnemize abs özelliği ekleniyor
            ABSDecorator carWithABS = new ABSDecorator(car);
            carWithABS.PrintDetail();

            Console.ReadKey();
        }
    }

    public interface ICarDecorator
    {
        void PrintDetail();
        void AddPrice(decimal addedPrice);
        void AddDescription(string addedDescription);
    }

    public class Car : ICarDecorator
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Car()
        {
            Price = 10.6m;
        }

        public void PrintDetail()
        {
            Console.WriteLine(Description);
        }

        public void AddDescription(string addedDescription)
        {
            Description = "Model: " + Model + " Brand: " + Brand + " Current Price: " + Price.ToString() + " " + addedDescription;
        }

        public void AddPrice(decimal addedPrice)
        {
            Price += addedPrice;
        }
    }

    public class CarDecoratorBase : ICarDecorator
    {
        internal ICarDecorator Car;

        public CarDecoratorBase(ICarDecorator car)
        {
            this.Car = car;
        }

        public void AddDescription(string addedDescription)
        {
            Car.AddDescription(addedDescription);
        }

        public virtual void AddPrice(decimal addedPrice)
        {
            Car.AddPrice(addedPrice);
        }

        public virtual void PrintDetail()
        {
            Car.PrintDetail();
        }
    }

    public class ABSDecorator : CarDecoratorBase
    {
        public ABSDecorator(ICarDecorator car) : base(car)
        {
        }

        public override void PrintDetail()
        {
            base.Car.AddPrice(6.1m);
            base.Car.AddDescription("ABS added to current car.");
            base.Car.PrintDetail();
        }
    }

    public class AirBagDecorator : CarDecoratorBase
    {
        public AirBagDecorator(ICarDecorator car) : base(car)
        {
        }

        public override void PrintDetail()
        {
            base.Car.AddPrice(3.4m);
            base.Car.AddDescription("Airbag added to current car.");
            base.Car.PrintDetail();
        }
    }

















}
