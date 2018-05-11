using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        public static string ReadUserName()
        {
            string userName;

            Console.WriteLine("Please enter your name:");
            userName = Console.ReadLine();
            while (!isValidEnglishString(userName))
            {
                Console.WriteLine("Invalid Name, please enter again");
                userName = Console.ReadLine();
            }

            return userName;
        }

        public static string ReadUserPhoneNumber()
        {
            string phoneNumer;

            Console.WriteLine("Please enter your phone number:");
            phoneNumer = Console.ReadLine();
            while (!isValidNumberString(phoneNumer))
            {
                Console.WriteLine("Invalid phonr number, please enter again");
                phoneNumer = Console.ReadLine();
            }

            return phoneNumer;
        }

        public static Vehicle.eVehicleType NewVehicleType()
        {
            Vehicle.eVehicleType returnType;
            int userInput;
            string message = string.Format(
                @"Press the number of the vehicle type.
1. Electric car
2. Electric Motorcycle
3. Fueled car
4. Fueled motorcycle
5. Fueled truck");

            Console.WriteLine(message);
            userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    returnType = Vehicle.eVehicleType.ElectricCar;
                    break;
                case 2:
                    returnType = Vehicle.eVehicleType.ElectricMotorcycle;
                    break;
                case 3:
                    returnType = Vehicle.eVehicleType.FueledCar;
                    break;
                case 4:
                    returnType = Vehicle.eVehicleType.FueledMotorcycle;
                    break;
                case 5:
                    returnType = Vehicle.eVehicleType.FueledTruck;
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    returnType = NewVehicleType();
                    break;
            }

            return returnType;
        }
        
        








        private static bool isValidEnglishString(string i_InputString)
        {
            bool isValid = true;

            if (i_InputString == string.Empty)
            {
                isValid = false;
            }
            else
            {
                foreach (char currentChar in i_InputString)
                {
                    if (currentChar < 'a' || currentChar > 'z')
                    {
                        if (currentChar < 'A' || currentChar > 'Z')
                        {
                            isValid = false;
                        }
                    }
                }
            }

            return isValid;
        }

        private static bool isValidNumberString(string i_InputString)
        {
            bool isValid = true;

            if (i_InputString == string.Empty)
            {
                isValid = false;
            }
            else
            {
                foreach (char currentChar in i_InputString)
                {
                    if (currentChar < '0' || currentChar > '9')
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }
}
