using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private Garage m_Garage = new Garage();

        public void MainMenue()
        {
            bool stayInSystem = true;
            string mainMenuUserInputStr;
            int maimMenuUserInput;
            string message = string.Format(
                @"Hello, what would you like to do? (Enter the line number)
1. Insert a new vehicle to the garage
2. Show a list of license numbers in the garage
3. Change a vehicle status
4. Inflate a vehicle weels (to max)
5. Fuel a Fueled vehicle.
6. Charge an electrical vehicle.
7. Display a specific vehicle details.
0. Exit the system.");
            while (stayInSystem)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(message);
                mainMenuUserInputStr = Console.ReadLine();
                maimMenuUserInput = validateMainMenuSelection(mainMenuUserInputStr);
                switch (maimMenuUserInput)
                {
                    case 1:
                        addOrUpdateVehicle();
                        break;
                    case 2:
                        showListOfLicenseNumbers();
                        break;
                    case 3:
                        updapeVehicleStatus();
                        break;
                    case 4:
                        inflateWheelsToMax();
                        break;
                    case 5:
                        fuelVehicle();
                        break;
                    case 6:
                        chargeVehicle();
                        break;
                   case 7:
                        displayDataOfSpecificVehicle();
                        break; 
                   case 0:
                       stayInSystem = false;
                       break;
                }
            }

            Console.WriteLine("Bye Bye");
        }

        // ----------------------------------------------- main menu methods -------------------------

        private void insertNewVehicle(string io_LicenseNumber)
        {
            string clientName;
            string clientPhoneNumber;
            Vehicle.eVehicleType vehicleType;
            string modelName;
            Engine.eEngineType engineType;
            float energyLeft;
            string wheelsManufacture;
            float wheelsAirPressure;
            List<object> uniqueParametersList;

            clientName = readOwnerName();
            clientPhoneNumber = readOwnerPhoneNumber();
            //vehicleType = readVehicleType();
            vehicleType = (Vehicle.eVehicleType)readEnumType(typeof(Vehicle.eVehicleType));
            modelName = readModelName();
            //engineType = readEngineType();
            engineType = (Engine.eEngineType)readEnumType(typeof(Engine.eEngineType));
            energyLeft = readCurrentEnergy();
            wheelsManufacture = readWheelsManufacture();
            wheelsAirPressure = readWheelsCurrentAirPressure();
            uniqueParametersList = readUniqueParametersList(vehicleType);
            try
            {
                m_Garage.AddClient(clientName, clientPhoneNumber, modelName, io_LicenseNumber, vehicleType,
                    wheelsManufacture,
                    wheelsAirPressure, engineType, energyLeft, uniqueParametersList);
                Console.WriteLine(Environment.NewLine + "Vehicle added successfully. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops! Something went wrong. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }
        }

        private void showListOfLicenseNumbers()
        {
            bool showAllLicenseNumbers;
            Vehicle.eRepairStatus chosenStatus;

            Console.WriteLine("Display all the license numbers in the system? y / n");
            showAllLicenseNumbers = validateBooleanPresentor(Console.ReadLine());

            // Show all license numbers that are in the system
            if (showAllLicenseNumbers)
            {
                printLicenseNumbersFromList(m_Garage.GetAllLicenseNumbers());
            }
            else
            {
                chosenStatus = (Vehicle.eRepairStatus) readEnumType(typeof(Vehicle.eRepairStatus));
                printLicenseNumbersFromList(m_Garage.GetLicenseNumbersInStatus(chosenStatus));
            }
        }

        private void updapeVehicleStatus()
        {
            string licenseNumber; 
            Vehicle.eRepairStatus newStatus; 

            licenseNumber = readLisenceNumber();
            if (!m_Garage.ContainsLicenseNumber(licenseNumber))
            {
                Console.WriteLine("The lisence number is not in the system. Press Enter to exit back to Main Menu");
                Console.ReadLine();
                MainMenue();
            }

            newStatus = (Vehicle.eRepairStatus)readEnumType(typeof(Vehicle.eRepairStatus));
            m_Garage.updateExistingClient(licenseNumber, newStatus);
            Console.WriteLine("Status updated successfully. Press Enter to exit back to Main Menu");
            Console.ReadLine();
        }

        private void inflateWheelsToMax()
        {
            string licenseNumber = readLisenceNumber();

            if (!m_Garage.ContainsLicenseNumber(licenseNumber))
            {
                Console.WriteLine("The lisence number is not in the system. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }
            
            m_Garage.InflateWheelsToMax(licenseNumber);
            Console.WriteLine("Air pressure updated successfully. Press Enter to exit back to Main Menu.");
            Console.ReadLine();
        }

        private void fuelVehicle()
        {
            string licenseNumber;
            float addAmount;
            Engine.eEnergyType fuelType;

            licenseNumber = readLisenceNumber();
            if (!m_Garage.ContainsLicenseNumber(licenseNumber))
            {
                Console.WriteLine("The lisence number is not in the system. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }

            addAmount = readEnergyAddAmount();
            fuelType = (Engine.eEnergyType)readEnumType(typeof(Engine.eEnergyType));
            while (fuelType == Engine.eEnergyType.Electricity)
            {
                Console.WriteLine("Please select a FEUL type (not Electricity)");
                fuelType = (Engine.eEnergyType)readEnumType(typeof(Engine.eEnergyType));
            }

            try
            {
                m_Garage.FuelVehicle(licenseNumber, fuelType, addAmount);
                Console.WriteLine("Fuel updated successfully. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine("You overpass the max limit of yor gas tank. Press Enter to try again");
                Console.ReadLine();
                fuelVehicle();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Oops! Something went wrong. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }
        }

        private void chargeVehicle()
        {
            string licenseNumber;
            float addAmount;

            licenseNumber = readLisenceNumber();
            if (!m_Garage.ContainsLicenseNumber(licenseNumber))
            {
                Console.WriteLine("The lisence number is not in the system. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }

            addAmount = readEnergyAddAmount();
            try
            {
                m_Garage.ChargeVehicle(licenseNumber, addAmount);
                Console.WriteLine("Battery updated successfully. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException exception)
            {
                Console.WriteLine("You overpass the max limit of yor gas tank. Press Enter to try again");
                Console.ReadLine();
                chargeVehicle();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Oops! Something went wrong. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }
        }

        private void displayDataOfSpecificVehicle()
        {
            string licenseNumber = readLisenceNumber();

            if (!m_Garage.ContainsLicenseNumber(licenseNumber))
            {
                Console.WriteLine("The lisence number is not in the system. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
                MainMenue();
            }

            Console.WriteLine(m_Garage.PrintVehicle(licenseNumber));
            Console.WriteLine("Press Enter to exit back to Main Menu.");
            Console.ReadLine();
        }

        // ----------------------------------------------- main menu helper methods -------------------------

        private void addOrUpdateVehicle()
        {
            string ownerLisenceNumber = readLisenceNumber();

            if (m_Garage.ContainsLicenseNumber(ownerLisenceNumber))
            {
                m_Garage.updateExistingClient(ownerLisenceNumber, Vehicle.eRepairStatus.InProgress);
                Console.WriteLine("Car is already exist in the system. Status was updated to be In Progress. Press Enter to exit back to Main Menu.");
                Console.ReadLine();
            }
            else
            {
                insertNewVehicle(ownerLisenceNumber);
            }
        }

        private static void printLicenseNumbersFromList(List<string> listOfLicenseNumbers)
        {
            StringBuilder licenseNumbersStr = new StringBuilder();

            for (int i = 0; i < listOfLicenseNumbers.Count; i++)
            {
                licenseNumbersStr.Append(listOfLicenseNumbers[i] + ", ");
            }

            if (listOfLicenseNumbers.Count == 0)
            {
                Console.WriteLine("There are no match vehicles to your search.");
            }
            else
            {
                Console.WriteLine(licenseNumbersStr);

            }
            Console.WriteLine("Press Enter to exit back to Main Menu");
            Console.ReadLine();
        }

        // ----------------------------------------------- read input from user methods -------------------------

        private static Enum readEnumType(Type i_Enum)
        {
            int userSelection;
            bool isValidSelection;
            Enum selectedType;
            StringBuilder message = new StringBuilder();
            List<Enum> enumTypeValues = new List<Enum>();

            //add all the engine types to the list
            foreach (Enum typeValue in Enum.GetValues(i_Enum))
            {
                enumTypeValues.Add(typeValue);
            }

            // build the message
            for (int i = 0; i < enumTypeValues.Count; i++)
            {
                message.Append((i + 1) + ". " + enumTypeValues[i] + Environment.NewLine);
            }

            Console.WriteLine("Please select one of the following options (enter the number):");
            Console.WriteLine(message);
            isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            while (!isValidSelection || userSelection < 1 || userSelection > enumTypeValues.Count)
            {
                Console.WriteLine("Invalid line number, please try again:");
                isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            }

            selectedType = enumTypeValues[userSelection - 1];

            return selectedType;
        }

        private static List<object> readUniqueParametersList(Vehicle.eVehicleType i_vehicleType)
        {
            List<object> uniqueParametersList = new List<object>();
            FieldInfo[] fields;
            string message;            
            string vehicleTypeString = "Ex03.GarageLogic." + i_vehicleType + ",Ex03.GarageLogic";
            Type vehicleType = Type.GetType(vehicleTypeString);

            fields = vehicleType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].FieldType.IsEnum)
                {
                    uniqueParametersList.Add(readEnumType(fields[i].FieldType));
                }
                else if (fields[i].FieldType == typeof(bool))
                {
                    message = string.Format("Enter {0} , Please answer by: y / n", fields[i].Name.Substring(2));
                    Console.WriteLine(message);
                    uniqueParametersList.Add(validateBooleanPresentor(Console.ReadLine()));
                }
                else
                {
                    message = string.Format("Enter {0}", fields[i].Name.Substring(2));
                    Console.WriteLine(message);
                    uniqueParametersList.Add(Console.ReadLine());
                }
            }

            return uniqueParametersList;
        }

        private static string readWheelsManufacture()
        {
            string WheelsManufacture;

            Console.WriteLine("Please enter wheels manufacture name:");
            WheelsManufacture = Console.ReadLine();
            while (WheelsManufacture == string.Empty)
            {
                Console.WriteLine("Invalid manufacture name. please try again:");
                WheelsManufacture = Console.ReadLine();
            }

            return WheelsManufacture;
        }

        private static float readWheelsCurrentAirPressure()
        {
            float currentAirPressure;
            
            Console.WriteLine("Please enter wheels current air pressure: ");
            currentAirPressure = float.Parse(validateNumber(Console.ReadLine()));

            return currentAirPressure;
        }

        private static string readLisenceNumber()
        {
            string lisenceNumber;

            Console.WriteLine("Please enter car's lisence number:");
            lisenceNumber = Console.ReadLine();
            while (lisenceNumber == string.Empty)
            {
                Console.WriteLine("Lisence number cannot be empty. Please try again:");
                lisenceNumber = Console.ReadLine();
            }

            return lisenceNumber;
        }
        
        private static string readModelName()
        {
            string modelName;

            Console.WriteLine("Please enter model name:");
            modelName = Console.ReadLine();

            return modelName;
        }

        private static float readCurrentEnergy()
        {
            float currentEnergy;
            
            Console.WriteLine("Please enter vehicle's current energy left:");
            currentEnergy = float.Parse(validateNumber(Console.ReadLine()));

            return currentEnergy;
        }
 
        private static string readOwnerName()
        {
            string ownerName;

            Console.WriteLine("Please enter owner's name:");
            ownerName = Console.ReadLine();

            while(ownerName == string.Empty)
            {
                Console.WriteLine("Name cannot be empty, please enter again:");
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        private static string readOwnerPhoneNumber()
        {
            string phoneNumer;

            Console.WriteLine("Please enter owner's phone number:");
            phoneNumer = validateNumber(Console.ReadLine());

            return phoneNumer;
        }

        private static float readEnergyAddAmount()
        {
            float addAmount;

            Console.WriteLine("Please enter the amount to add:");
            addAmount = float.Parse(validateNumber(Console.ReadLine()));

            return addAmount;
        }

        // ----------------------------------------------- input validation methods -------------------------

        private static int validateMainMenuSelection(string io_MainMenuUserInputStr)
        {
            int mainMenuUserSelection = 0;
            bool validNumber = int.TryParse(io_MainMenuUserInputStr, out mainMenuUserSelection);
            while (!validNumber || mainMenuUserSelection > 7 || mainMenuUserSelection < 0)
            {
                if (!validNumber)
                {
                    Console.WriteLine("Your choice must contain only digits between 0-7. Please try again:");
                }
                else
                {
                    Console.WriteLine("This option doesn't exist. Please choose an option between 0-7:");
                }
                io_MainMenuUserInputStr = Console.ReadLine();
                mainMenuUserSelection = 0;
                validNumber = int.TryParse(io_MainMenuUserInputStr, out mainMenuUserSelection);
            }
            return mainMenuUserSelection;
        }

        private static string validateNumber(string i_Input)
        {
            float number = 0;
            bool validNumber = float.TryParse(i_Input, out number);

            while (!validNumber)
            {
                Console.WriteLine("This must contain only digits. Please try again");
                i_Input = Console.ReadLine();
                number = 0;
                validNumber = float.TryParse(i_Input, out number);
            }

            return number.ToString();
        }

        private static bool validateBooleanPresentor(string i_Input)
        {
            bool returnValue;

            while (i_Input != "y" && i_Input != "n")
            {
                Console.WriteLine("Invalid input, please choose y or n:");
                i_Input = Console.ReadLine();
            }

            returnValue = i_Input == "y";

            return returnValue;
        }
       
    }
}
