using System;
using System.Collections.Generic;

namespace Lab3_3_DeliCounterMenuWithObjects
{
    class Program
    {
        class MenuItem
        {
            public string itemName;
            public decimal itemPrice;
            public int itemQOH;
            public void Sell(int numSell)
            {
                itemQOH -= numSell;
            }
        }
        
        static void printMenu(Dictionary<string, MenuItem> menu)  // Prints the menu
        {
            Console.WriteLine("\n=======================================================");
            Console.WriteLine("\n\t\t\tMENU");
            Console.WriteLine("\nItem\t\t\tCost\t\t\tQOH");
            Console.WriteLine("======\t\t\t======\t\t\t======");

            foreach (var item in menu)
            {
                Console.WriteLine($"\n{item.Value.itemName}\t\t${item.Value.itemPrice}\t\t\t{item.Value.itemQOH}");
            }

            Console.WriteLine("\n=======================================================");
        }

        static void askPrintMenu(Dictionary<string, MenuItem> menu)  // Asks user whether to print menu
        {
            Console.Write("\nDo you want to see the menu? (y/n) ");
            string userPrintMenu = Console.ReadLine().ToUpper();

            switch (userPrintMenu)
            {
                case "Y":
                    printMenu(menu);
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            MenuItem item1 = new MenuItem();
            item1.itemName = "CLUB SANDWICH";
            item1.itemPrice = 9.99m;
            item1.itemQOH = 75;

            MenuItem item2 = new MenuItem();
            item2.itemName = "FRENCH DIP";
            item2.itemPrice = 11.99m;
            item2.itemQOH = 50;

            MenuItem item3 = new MenuItem();
            item3.itemName = "HOUSE SALAD";
            item3.itemPrice = 7.99m;
            item3.itemQOH = 45;

            MenuItem item4 = new MenuItem();
            item4.itemName = "SOUP OF THE DAY";
            item4.itemPrice = 3.99m;
            item4.itemQOH = 100;

            MenuItem item5 = new MenuItem();
            item5.itemName = "HOUSE CHIPS";
            item5.itemPrice = 2.99m;
            item5.itemQOH = 150;

            Dictionary<string, MenuItem> menu = new Dictionary<string, MenuItem>();
            menu.Add("CLUB SANDWICH", item1);
            menu.Add("FRENCH DIP", item2);
            menu.Add("HOUSE SALAD", item3);
            menu.Add("SOUP OF THE DAY", item4);
            menu.Add("HOUSE CHIPS", item5);

            Console.WriteLine("\tWelcome to Jeremy's Deli Counter!");
            printMenu(menu);

            bool quit = false;
            do
            {
                Console.WriteLine("\n\tMAIN MENU");
                Console.WriteLine("********************************");
                Console.WriteLine("Enter A to ADD a new menu item.");
                Console.WriteLine("Enter R to REMOVE a menu item.");
                Console.WriteLine("Enter C to CHANGE a menu item.");
                Console.WriteLine("Enter S to sell a menu item.");
                Console.WriteLine("Enter V to VIEW menu.");
                Console.WriteLine("Enter Q to QUIT.");
                Console.Write("\nWhat do you want to do? ");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "A": // Adds a new menu item
                        Console.WriteLine("\nThis will ADD a new menu item. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME: ");
                        string newMenuItem = Console.ReadLine().ToUpper();

                        if (menu.ContainsKey(newMenuItem))
                        {
                            Console.WriteLine($"\n{newMenuItem} is already on the menu.");
                        }
                        else if (newMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("PRICE: ");
                            decimal newPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("QOH: ");
                            int newQOH = int.Parse(Console.ReadLine());

                            MenuItem addMenuItem = new MenuItem();                            
                            addMenuItem.itemName = newMenuItem;
                            addMenuItem.itemPrice = newPrice;
                            addMenuItem.itemQOH = newQOH;
                            menu.Add(newMenuItem, addMenuItem);
                            
                            Console.WriteLine($"\nYou ADDED {addMenuItem.itemName} for ${addMenuItem.itemPrice} with {addMenuItem.itemQOH} on hand to the menu.");
                            askPrintMenu(menu);
                        }

                        break;

                    case "R": // Removes a menu item
                        Console.WriteLine("\nThis will REMOVE an item from the menu. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME of the menu item to REMOVE: ");
                        string removeMenuItem = Console.ReadLine().ToUpper();

                        if (removeMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else if (menu.ContainsKey(removeMenuItem))
                        {
                            menu.Remove(removeMenuItem);
                            Console.WriteLine($"\nYou REMOVED {removeMenuItem} from the menu");
                            askPrintMenu(menu);
                        }
                        else
                        {
                            Console.WriteLine($"\n{removeMenuItem} is not on the menu and therefore cannot be removed.");
                        }

                        break;

                    case "C": // Changes a menu item
                        Console.WriteLine("\nThis will CHANGE the price and/or QOH of a menu item. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME of the menu item to CHANGE: ");
                        string changeMenuItem = Console.ReadLine().ToUpper();

                        if (changeMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else if (menu.ContainsKey(changeMenuItem))
                        {
                            Console.WriteLine($"The current price for {menu[changeMenuItem].itemName} is ${menu[changeMenuItem].itemPrice}.");
                            Console.Write("New price: ");
                            menu[changeMenuItem].itemPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("QOH: ");
                            menu[changeMenuItem].itemQOH = int.Parse(Console.ReadLine());
                            Console.WriteLine($"\nYou CHANGED the price of {menu[changeMenuItem].itemName} to ${menu[changeMenuItem].itemPrice} and QOH to {menu[changeMenuItem].itemQOH}.");
                            askPrintMenu(menu);
                        }
                        else
                        {
                            Console.WriteLine($"\n{changeMenuItem} is not on the menu and therefore cannot be changed.");
                        }

                        break;

                    case "S": // Sells an item
                        Console.WriteLine("\nThis will SELL a menu item and update QOH. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME of the item to SELL: ");
                        string sellItem = Console.ReadLine().ToUpper();

                        if (sellItem == "CANCEL")
                        {
                            break;
                        }
                        else if (menu.ContainsKey(sellItem))
                        {
                            Console.WriteLine($"There is/are {menu[sellItem].itemQOH} {menu[sellItem].itemName} available for sale.");
                            Console.Write("QUANTITY to SELL: ");
                            int numSell = int.Parse(Console.ReadLine());

                            if (numSell >= 0 && numSell <= menu[sellItem].itemQOH)
                            {
                                menu[sellItem].Sell(numSell);
                                Console.WriteLine($"\n{numSell} {menu[sellItem].itemName} have been removed from inventory and {menu[sellItem].itemQOH} is/are available to sell.");
                                askPrintMenu(menu);
                            }
                            else if (numSell < 0)
                            {
                                Console.WriteLine("\nYou're trying to sell a negative number of items.");
                                break;
                            }
                            else if (numSell > menu[sellItem].itemQOH)
                            {
                                Console.WriteLine("\nYou're trying to sell more than is in inventory.");
                                break;
                            }
                        }
                        break;
                    
                    case "V": // Prints menu
                        printMenu(menu);
                        break;

                    case "Q": // Exits program
                        quit = true;
                        break;

                    default: // Invalid entry
                        Console.WriteLine("\nThat's an invalid entry.");
                        break;
                }
            }
            while (!quit);
        }
    }
}