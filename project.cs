using System;
using System.Collections.Generic;

class Inventory
{
    public List<string> items = new List<string>();

    public void AddItem()
    {
        Console.WriteLine("Enter the item you would like to add: ");
        string item = Console.ReadLine();
        items.Add(item);
    }

    public void DeleteItem()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty. Nothing to delete.");
            return;
        }

        Console.WriteLine("Enter the item you would like to delete: ");
        string deleted = Console.ReadLine();

        if (items.Contains(deleted))
        {
            items.Remove(deleted);
            Console.WriteLine($"{deleted} has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine($"{deleted} is not in the inventory.");
        }
    }

    public void Display()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        Console.WriteLine("Your inventory:");
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    enum UserAction
    {
        Add,
        Delete,
        Exit
    }

    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        while (true)
        {
            inventory.Display();
            Console.WriteLine("Choose what would you like to do (Add/Delete/Exit): ");
            string choice = Console.ReadLine();

            UserAction action;
            if (Enum.TryParse(choice, true, out action))
            {
                switch (action)
                {
                    case UserAction.Add:
                        inventory.AddItem();
                        break;
                    case UserAction.Delete:
                        inventory.DeleteItem();
                        break;
                    case UserAction.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}
