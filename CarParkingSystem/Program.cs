using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem
{
    class Program
    {
        static public int[] parkingFloors = { 0, 0, 0, 0, 0, 0 };

        static public int balance = 0;

        static void Main(string[] args)
        {
            menu();
        }

        private static void menu()
        {
            Console.WriteLine("1.\tAdd new car in parking");
            Console.WriteLine("2.\tExit the car in parking");
            Console.WriteLine("3.\tView of floors");
            Console.WriteLine("4.\tView of balance");
            Console.WriteLine("5.\tExit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addCar();
                    break;

                case "2":
                    exitCar();
                    break;

                case "3":
                    viewFloors();
                    break;

                case "4":
                    viewBalance();
                    break;

                case "5":
                    exit();
                    break;

                default:
                    invalidChoice();
                    break;
            }
        }

        private static void viewBalance()
        {
            Console.Clear();

            Console.WriteLine(balance);

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void viewFloors()
        {
            Console.Clear();

            for (int i = 0; i < parkingFloors.Length; i++)
            {
                Console.WriteLine($"{i + 1}. floor have {parkingFloors[i]} cars");
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void addCar()
        {
            Console.Clear();

            Console.Write("Enter floor : ");

            string line = Console.ReadLine();

            if (checkValue(line))
            {
                int floor = int.Parse(line);

                if (floor - 1 >= 0 && floor - 1 < parkingFloors.Length)
                {
                    Console.Write("Enter hour : ");
                    string hourLine = Console.ReadLine();

                    if (checkValue(hourLine))
                    {

                        parkingFloors[floor - 1]++;
                        int hour = int.Parse(hourLine);

                        balance += (5 * hour);

                        Console.WriteLine("Transaction successfull");
                    }
                    else
                    {
                        Console.WriteLine("İnvalid input...");
                    }

                }

                else
                    Console.WriteLine($"There aren't {floor} floor");
            }

            else
                Console.WriteLine($"İnvalid input");


            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void exitCar()
        {
            Console.Clear();

            Console.Write("Enter floor : ");

            string line = Console.ReadLine();

            if (checkValue(line))
            {
                int floor = int.Parse(line);

                if (floor - 1 >= 0 && floor - 1 < parkingFloors.Length)
                {
                    if (parkingFloors[floor - 1] != 0)
                    {
                        parkingFloors[floor - 1]--;
                        Console.WriteLine("Transaction successfull");
                    }

                    else
                        Console.WriteLine($"There are no car in {floor}. floor");
                }

                else
                    Console.WriteLine($"There aren't {line} floor");
            }

            else
                Console.WriteLine($"İnvalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static bool checkValue(string floor)
        {
            int result;

            if (int.TryParse(floor, out result))
                return true;

            else
                return false;
        }

        private static void invalidChoice()
        {
            Console.Clear();

            Console.WriteLine("İnvalid choice");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void exit()
        {
            Environment.Exit(0);
        }

    }
}
