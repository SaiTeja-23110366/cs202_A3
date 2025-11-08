using System;

// --- 1. The PARENT (or "Base") Class ---
public class Vehicle
{
    // 'protected' means this class AND any child classes can access these
    protected int speed;
    protected int fuel;

    // Constructor for the Vehicle
    public Vehicle(int speed, int fuel)
    {
        this.speed = speed;
        this.fuel = fuel;
    }

    // 'virtual' means a child class IS ALLOWED to "override" this method
    public virtual void ShowInfo()
    {
        Console.WriteLine($"--- Vehicle Info ---");
        Console.WriteLine($"Speed: {speed}");
        Console.WriteLine($"Fuel: {fuel}");
    }

    // Another 'virtual' method
    public virtual void Drive()
    {
        fuel -= 5; // Default fuel use
        Console.WriteLine("Vehicle is moving...");
    }
}

// --- 2. The first CHILD (or "Derived") Class ---
// 'public class Car : Vehicle' means "Car inherits from Vehicle"
public class Car : Vehicle
{
    // A new field that ONLY cars have
    private int passengers;

    // Car's constructor
    // ': base(speed, fuel)' calls the PARENT (Vehicle) constructor
    // to handle the speed and fuel initialization.
    public Car(int speed, int fuel, int passengers) : base(speed, fuel)
    {
        // We only need to set the new field
        this.passengers = passengers;
    }

    // 'override' means we are PROVIDING a new version of the parent's method
    public override void ShowInfo()
    {
        Console.WriteLine($"--- Car Info ---");
        Console.WriteLine($"Speed: {speed}");       // 'speed' is inherited
        Console.WriteLine($"Fuel: {fuel}");         // 'fuel' is inherited
        Console.WriteLine($"Passengers: {passengers}"); // This is new
    }

    // 'override' for the Drive method
    public override void Drive()
    {
        fuel -= 10; // Cars use more fuel
        Console.WriteLine("Car is driving with passengers...");
    }
}

// --- 3. The second CHILD (or "Derived") Class ---
public class Truck : Vehicle
{
    // A new field that ONLY trucks have
    private int cargoWeight;

    // Truck's constructor
    // It also calls the parent (base) constructor
    public Truck(int speed, int fuel, int cargoWeight) : base(speed, fuel)
    {
        this.cargoWeight = cargoWeight;
    }

    // 'override' for ShowInfo
    public override void ShowInfo()
    {
        Console.WriteLine($"--- Truck Info ---");
        Console.WriteLine($"Speed: {speed}");
        Console.WriteLine($"Fuel: {fuel}");
        Console.WriteLine($"Cargo Weight: {cargoWeight}"); // This is new
    }

    // 'override' for Drive
    public override void Drive()
    {
        fuel -= 15; // Trucks use the most fuel
        Console.WriteLine("Truck is hauling cargo...");
    }
}

// --- 4. The Main Program to TEST our classes ---
public class Program
{
    public static void Main(string[] args)
    {
        // Create one object of each type
        Vehicle myVehicle = new Vehicle(50, 100);
        Car myCar = new Car(80, 80, 4);
        Truck myTruck = new Truck(40, 150, 5000);

        // --- This is the most important part! ---
        // We can store all of them in an array of type 'Vehicle'
        // This is called "Polymorphism"
        Vehicle[] vehicleArray = new Vehicle[] { myVehicle, myCar, myTruck };

        Console.WriteLine("--- Looping through vehicle array ---");

        // Loop through the array
        foreach (Vehicle v in vehicleArray)
        {
            // Call the methods for each object
            v.Drive();    // This will call the correct (overridden) version!
            v.ShowInfo(); // This will also call the correct (overridden) version!
            Console.WriteLine(); // Add a blank line for readability
        }

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}