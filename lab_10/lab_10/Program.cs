using System.Collections.Generic;
using System;

public class Program
{
    // private field for data
    private int _value;

    // --- NEW ---
    // A static variable is shared by ALL objects of this class
    private static int activeObjectCount = 0;

    // Constructor
    public Program()
    {
        _value = 0; // Initialize the field

        // --- NEW ---
        // Increment the shared counter
        activeObjectCount++;
        Console.WriteLine($"Constructor Called. (Active objects: {activeObjectCount})");
    }

    // Destructor
    ~Program()
    {
        // --- NEW ---
        // Decrement the shared counter
        activeObjectCount--;
        Console.WriteLine($"Object Destroyed. (Active objects: {activeObjectCount})");
    }

    // Method to assign a value
    public void set_data(int x)
    {
        this._value = x;
    }

    // Method to print the value
    public void show_data()
    {
        Console.WriteLine($"The object's value is: {this._value}");
    }

    // Main method - entry point
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Starting Main Method ---");

        List<Program> objectList = new List<Program>();

        objectList.Add(new Program());
        objectList.Add(new Program());
        objectList.Add(new Program());

        Console.WriteLine($"--- List created. It contains {objectList.Count} objects. ---");

        objectList[0].set_data(10);
        objectList[1].set_data(20);
        objectList[2].set_data(30);

        Console.WriteLine("--- Displaying Data ---");
        foreach (Program obj in objectList)
        {
            obj.show_data();
        }

        Console.WriteLine("--- End of Main Method ---");

        // --- FIX ADDED HERE ---
        // This will pause the console window and wait for the user to press Enter.
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
        // --- END OF FIX ---
    }
}