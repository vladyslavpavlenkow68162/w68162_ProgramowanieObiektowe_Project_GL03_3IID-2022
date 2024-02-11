using System;
using System.Collections.Generic;

class Inventory
{
    private Dictionary<string, string> items = new Dictionary<string, string>();

    public void AddItem()
    {
        Console.WriteLine("Enter the item you would like to add: ");
        string itemName = Console.ReadLine();

        Console.WriteLine("Enter the description of the item: ");
        string itemDescription = Console.ReadLine();

        items[itemName] = itemDescription;
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

        if (items.ContainsKey(deleted))
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
        foreach (var kvp in items)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    public IReadOnlyDictionary<string, string> GetItems()
    {
        return items;
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
            Console.WriteLine("Choose what you would like to do (Add/Delete/Exit): ");
            string choice = Console.ReadLine().Trim();

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
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Please enter a valid option.");
            }
        }
    }
}
