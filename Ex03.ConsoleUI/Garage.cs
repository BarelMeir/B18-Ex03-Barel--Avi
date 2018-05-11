using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Garage
    {
        Dictionary<String, Ex03.GarageLogic.Client> garageClients = new Dictionary<string, Client>();

        public void GarageManager()
        {
            int userInput;
            string message = string.Format(
                @"Hello, what would you like to do?
1. Enter a new vehicle
2. Show a list of all license numbers in the garage
3. Change a vehicle status
4. Inflate a vehicle weels (to max)
5. Fuel a Fueled vehicle.
6. Charge an electrical vehicle.
7. Display a specific vehicle details.
0. Exit the system.");

            Console.WriteLine(message);
            userInput = int.Parse(Console.ReadLine());
            while (userInput != 0)
            {
                Console.WriteLine(message);
                userInput = int.Parse(Console.ReadLine());
            }
            
        }

        private void addVehicle()
        {

        }

    }
}
