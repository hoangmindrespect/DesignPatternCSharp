using System;
using System.ComponentModel;
namespace AbstractFactoryDesignPattern
{
    public interface IBike
    {
        void GetDetails();
    }

    public interface ICar
    {
        void GetDetails();

    }

    public class RegularBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("RegularBike");
        }
    }

    public class SportsBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("SportsBike");
        }
    }

    public class RegularCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("RegularCar");
        }
    }

    public class SportsCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("SportsCar");
        }
    }

    public interface IVehicleFactory
    {
        //Abstract Product A : Bike
        IBike CreateBike();
        //Abstract Product B : Car
        ICar CreateCar();
    }

    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }
        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }

    public class SportsVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportsBike();
        }
        public ICar CreateCar()
        {
            return new SportsCar();
        }
    }

    //Client Code
    class Program
    {
        public static void Main()
        {

            IVehicleFactory regularVehicleFactory = new RegularVehicleFactory();
            IVehicleFactory sportsVehicleFactory = new SportsVehicleFactory();

            IBike regularBike = regularVehicleFactory.CreateBike();
            IBike sportsBike = sportsVehicleFactory.CreateBike();
            ICar regularCar = regularVehicleFactory.CreateCar();
            ICar sportsCar = sportsVehicleFactory.CreateCar();

            regularBike.GetDetails();
            regularCar.GetDetails();
            sportsBike.GetDetails();
            sportsCar.GetDetails();

            Console.ReadKey();
        }
    }
}