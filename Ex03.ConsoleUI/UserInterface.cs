using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;
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
                @"Hello, what would you like to do?
1. Insert a new vehicle to the garage
2. Show a list of all license numbers in the garage
3. Change a vehicle status
4. Inflate a vehicle weels (to max)
5. Fuel a Fueled vehicle.
6. Charge an electrical vehicle.
7. Display a specific vehicle details.
0. Exit the system." + Environment.NewLine);

            while (stayInSystem)
            {
                Console.WriteLine(message);
                mainMenuUserInputStr = Console.ReadLine();
                maimMenuUserInput = validationUserSelection(mainMenuUserInputStr);
                switch (maimMenuUserInput)
                {
                    case 1:
                        checkIfExistLisenceNumber();
                        break;
      /*              case 2:
                        showListOfLicenseNumbers(newGarage);
                        break;
                    case 3:
                        changeVehicleStatus(newGarage);
                        break;
                    case 4:
                        inflateVehicleWheelsToMax(newGarage);
                        break;
                    case 5:
                        refuelVehicle(newGarage);
                        break;
                    case 6:
                        chargeBatteryOfVehicle(newGarage);
                        break;
                    case 7:
                        displayDataOfSpecificVehicle(newGarage);
                        break;*/
                    case 0:
                        stayInSystem = false;
                        exitMode();
                        break;
                }
            }
        }



        private static int readStatusToShow()
        {
            string statusStr;
            int chosenStatus;
            string message = string.Format(
                    @"Please insert the correct number of the required repair status:
1. In Progress
2. Complited
3. Paid");

            Console.WriteLine(message);
            statusStr = Console.ReadLine();
            while (statusStr != "1" && statusStr != "2" && statusStr != "3")
            {
                Console.WriteLine("Invalid status. please choose a number between 1-3");
                statusStr = Console.ReadLine();
            }

            chosenStatus = int.Parse(statusStr);

            return chosenStatus;
        }
        
        private void gernericInsert(string io_LicenseNumber)
        {

            /*  get a vehicle type
                define fields[] of the type
                build messeges as string to output for user
                get from user the relevant fields todo how to determine if relevant?
                parse to the type*/

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
            vehicleType = (Vehicle.eVehicleType) readEnumType(typeof(Vehicle.eVehicleType));
            modelName = readModelName();
            //engineType = readEngineType();
            engineType = (Engine.eEngineType)readEnumType(typeof(Engine.eEngineType));
            energyLeft = readCurrentEnergy();
            wheelsManufacture = readWheelsManufacture();
            wheelsAirPressure = readWheelsCurrentAirPressure();
            uniqueParametersList = readUniqueParametersList(vehicleType);

            m_Garage.AddClient(clientName, clientPhoneNumber, modelName, io_LicenseNumber, vehicleType, wheelsManufacture,
                wheelsAirPressure, engineType, energyLeft, uniqueParametersList);
        }

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
                Console.WriteLine("Invalid type, please try again:");
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
            bool isValidairPressure;

            Console.WriteLine("Please enter wheels current air pressure: ");
            isValidairPressure = float.TryParse(Console.ReadLine(), out currentAirPressure);
            while (!isValidairPressure)
            {
                Console.WriteLine("Invalid wheels current air pressure, please try again:");
                isValidairPressure = float.TryParse(Console.ReadLine(), out currentAirPressure);
            }

            return currentAirPressure;
        }

        private static void exitMode()
        {
            Console.WriteLine("Bye Bye");
        }

        private static int validationUserSelection(string io_MainMenuUserInputStr)
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

        private void checkIfExistLisenceNumber()
        {
            string ownerLisenceNumber = getLisenceNumber();

            if (m_Garage.ContainsLicenseNumber(ownerLisenceNumber))
            {
               // m_Garage.updateExistingClient(ownerLisenceNumber);
                Console.WriteLine("Car already exist in system. Status was updated.");
            }
            else
            {
                gernericInsert(ownerLisenceNumber);
            }
        }

        private static string getLisenceNumber()
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
            string currentEnergyStr;
            float currentEnergy;
            bool isValidEnergy;

            Console.WriteLine("Please enter vehicle's current energy left:");
            currentEnergyStr = Console.ReadLine();
            isValidEnergy = float.TryParse(currentEnergyStr,out currentEnergy);
            while (!isValidEnergy)
            {
                Console.WriteLine("Invalid energy left. please insert a number");
                isValidEnergy = float.TryParse(currentEnergyStr, out currentEnergy);
            }

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
            phoneNumer = validationOfOwnersPhoneNumber(Console.ReadLine());

            return phoneNumer;
        }

        private static string validationOfOwnersPhoneNumber(string io_OwnersPhoneNumber)
        {
            int ownersPhoneNumber = 0;
            bool validNumber = int.TryParse(io_OwnersPhoneNumber, out ownersPhoneNumber);
            while (!validNumber)
            {
                Console.WriteLine("Phone number must contain only digits. Please try again");
                io_OwnersPhoneNumber = Console.ReadLine();
                ownersPhoneNumber = 0;
                validNumber = int.TryParse(io_OwnersPhoneNumber, out ownersPhoneNumber);
            }

            return ownersPhoneNumber.ToString();
        }




        public static Vehicle.eVehicleType readVehicleType()
        {
            int userSelection;
            bool isValidSelection;
            Vehicle.eVehicleType selectedType;
            StringBuilder message = new StringBuilder();
            List<Vehicle.eVehicleType> vehiclesTypes = new List<Vehicle.eVehicleType>();

            //add all the vehicles types to the list
            foreach (Vehicle.eVehicleType typeValue in Enum.GetValues(typeof(Vehicle.eVehicleType)))
            {
                vehiclesTypes.Add(typeValue);
            }

            // build the message
            for (int i = 0; i < vehiclesTypes.Count; i++)
            {
                message.Append((i + 1) + ". " + vehiclesTypes[i].ToString() + Environment.NewLine);
            }

            Console.WriteLine("Please select one of the following type number:");
            Console.WriteLine(message);
            isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            while (!isValidSelection || userSelection < 1 || userSelection > vehiclesTypes.Count)
            {
                Console.WriteLine("Invalid type, please select a single number from the list:");
                isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            }

            selectedType = vehiclesTypes[userSelection - 1];

            return selectedType;
        }

        private static Engine.eEngineType readEngineType()
        {
            int userSelection;
            bool isValidSelection;
            Engine.eEngineType selectedType;
            StringBuilder message = new StringBuilder();
            List<Engine.eEngineType> engineTypes = new List<Engine.eEngineType>();

            //add all the engine types to the list
            foreach (Engine.eEngineType typeValue in Enum.GetValues(typeof(Engine.eEngineType)))
            {
                engineTypes.Add(typeValue);
            }

            // build the message
            for (int i = 0; i < engineTypes.Count; i++)
            {
                message.Append((i + 1) + ". " + engineTypes[i].ToString() + Environment.NewLine);
            }

            Console.WriteLine("Please select one of the following type number:");
            Console.WriteLine(message);
            isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            while (!isValidSelection || userSelection < 1 || userSelection > engineTypes.Count)
            {
                Console.WriteLine("Invalid type, please try again:");
                isValidSelection = int.TryParse(Console.ReadLine(), out userSelection);
            }

            selectedType = engineTypes[userSelection - 1];

            return selectedType;
        }
        
    }
}
