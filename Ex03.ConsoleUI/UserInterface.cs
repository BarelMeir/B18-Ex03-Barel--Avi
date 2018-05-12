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

        public static Vehicle.eVehicleType ReadVehicleType()
        {
            Vehicle.eVehicleType returnType;
            int userInput;
            StringBuilder message = new StringBuilder();
            List<Vehicle.eVehicleType> vehicleTypes = new List<Vehicle.eVehicleType>();
            foreach (Vehicle.eVehicleType typeValue in Enum.GetValues(typeof(Vehicle.eVehicleType)))
            {
                vehicleTypes.Add(typeValue);
            }

            // build the message
            for (int i = 0; i < vehicleTypes.Count; i++)
            {
                message.Append((i + 1) + vehicleTypes[i].ToString());
            }

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
                    returnType = ReadVehicleType();
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




        // TODO  ------------------------------------------------------from down here its Avia's code ------------------------------------------------------



        public static string ReadOwnerName()
        {
            string ownerName;

            try
            {
                Console.WriteLine("Please enter owner's name:");
                ownerName = ownerNameValidation(Console.ReadLine());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            return ownerName;
        }

        private static string ownerNameValidation(string i_OwnersNameInput)
        {
            StringBuilder ownersNameStr = new StringBuilder();
            char[] ownersNameArray = i_OwnersNameInput.ToUpper().ToCharArray();
            bool isValidName = false;

            if (i_OwnersNameInput.Equals(string.Empty))
            {
                throw new ArgumentException("Invalid name entered: empty name");
            }

            while (!isValidName)
            {
                for (int i = 0; i < ownersNameArray.Length; i++)
                {
                    if ((ownersNameArray[i] < 'A' || ownersNameArray[i] > 'Z') && !ownersNameArray[i].Equals(' '))
                    {
                        Console.WriteLine("Invalid name entered. Please try again");
                        ownersNameArray = Console.ReadLine().ToUpper().ToCharArray();
                        break;
                    }

                    if (i == ownersNameArray.Length - 1)
                    {
                        isValidName = true;
                    }
                }
            }

            for (int i = 0; i < ownersNameArray.Length; i++)
            {
                ownersNameStr.Append(ownersNameArray[i]);
            }

            return ownersNameStr.ToString();
        }

        public static string ReadOwnerPhoneNumber()
        {
            string phoneNumer;

            Console.WriteLine("Please enter owner's phone number:");
            phoneNumer = validationOfOwnersPhoneNumber(Console.ReadLine());

            return phoneNumer;
        }

        public static int SelectedVehicleType()
        {
            Vehicle.eVehicleType returnType;
            int selectedType = 0;
            bool isValidType;
            //TODO: correct the massage corresponding to the optional vihecle. (gmishot)
            string message = string.Format(
                @"Please select the number of the vehicle type from the following list:
1. Electric car
2. Electric Motorcycle
3. Fueled car
4. Fueled motorcycle
5. Fueled truck");

            Console.WriteLine(message);
            isValidType = int.TryParse(Console.ReadLine(), out selectedType);

            while (!isValidType || selectedType < 1 || selectedType > Ex03.GarageLogic.Vehicle.eVehicleType.)
            {
                Console.WriteLine("Invalid type, please select a single number from the list.");
                selectedType = 0;
                isValidType = int.TryParse(Console.ReadLine(), out selectedType);
            }

            return selectedType;
        }

        private static string validationOfOwnersPhoneNumber(string io_OwnersPhoneNumber)
        {
            int ownersPhoneNumber = 0;
            bool validNumber = int.TryParse(io_OwnersPhoneNumber, out ownersPhoneNumber);
            while (!validNumber || io_OwnersPhoneNumber.Length != 10)
            {
                if (!validNumber)
                {
                    Console.WriteLine("Phone number must contain only digits. Please try again");
                    io_OwnersPhoneNumber = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Phone number must contain exactly 10 digits. Please try again");
                    io_OwnersPhoneNumber = Console.ReadLine();
                }

                ownersPhoneNumber = 0;
                validNumber = int.TryParse(io_OwnersPhoneNumber, out ownersPhoneNumber);
            }

            return ownersPhoneNumber.ToString();
        }


    }
}
