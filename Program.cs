using System;
using FinalProject.Services;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            bool running = true;

            try
            {
                while (running)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("===== Fast Food Order System =====");
                    Console.ResetColor();
                    Console.WriteLine("1. Place Order");
                    Console.WriteLine("2. Serve Next Order");
                    Console.WriteLine("3. Peek Next Order");
                    Console.WriteLine("4. View All Waiting Orders");
                    Console.WriteLine("5. View All Orders (Sorted A-Z)");
                    Console.WriteLine("6. Search Order by Name");
                    Console.WriteLine("7. Count Pending Orders");
                    Console.WriteLine("8. Exit");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nSelect an option (1-8): ");
                    Console.ResetColor();
                    string input = Console.ReadLine();
                    Console.WriteLine();

                    if (!int.TryParse(input, out int choice) || choice < 1 || choice > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                        Console.ResetColor();
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                orderService.PlaceOrder();
                                break;
                            case 2:
                                orderService.ServeNextOrder();
                                break;
                            case 3:
                                orderService.PeekNextOrder();
                                break;
                            case 4:
                                orderService.ViewWaitingOrders();
                                break;
                            case 5:
                                orderService.ViewSortedOrders();
                                break;
                            case 6:
                                orderService.SearchOrderByName();
                                break;
                            case 7:
                                orderService.CountPendingOrders();
                                break;
                            case 8:
                                running = false;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Exiting program... Goodbye!");
                                Console.ResetColor();
                                break;
                        }
                    }

                    if (running)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\nPress Enter to return to the menu...");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unexpected error: " + ex.Message);
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nProgram has ended. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
