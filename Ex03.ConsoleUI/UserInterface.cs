using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private Ex03.GarageLogic.Garage m_Garage = new Garage();

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
0. Exit the system.");

            while (stayInSystem)
            {
                Console.WriteLine(message);
                mainMenuUserInputStr = Console.ReadLine();
                maimMenuUserInput = validationUserSelection(mainMenuUserInputStr);
                switch (maimMenuUserInput)
                {
                    case 1:
                        checkLisenceNumber();
                        break;
                    case 2:
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
                        break;
                    case 0:
                        stayInSystem = false;
                        exitMode();
                        break;
                }
            }
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
                    Console.WriteLine("Your choice must contain only digits between 0-7");
                }
                else
                {
                    Console.WriteLine("This option doesn't exist. Please choose an option between 0-7");
                }
                io_MainMenuUserInputStr = Console.ReadLine();
                mainMenuUserSelection = 0;
                validNumber = int.TryParse(io_MainMenuUserInputStr, out mainMenuUserSelection);
            }
            return mainMenuUserSelection;
        }

        // checks if the lisence number is already in the garage and redirect accordingly
        private void checkLisenceNumber()
        {
            string ownerLisenceNumber = getLisenceNumber();

            if (garage.Clients.ContainsKey(ownerLisenceNumber))
            {
                updateExistingClient(ownerLisenceNumber);
            }
            else
            {
                insertNewVehicle(ownerLisenceNumber);
            }
        }

        private void insertNewVehicle(string i_OwnerLisenceNumber)
        {
            string clientName = readOwnerName();
            string clientPhoneNumber = readOwnerPhoneNumber();
            Vehicle.eVehicleType vehicleType = readVehicleType();
            string modelName = readModelName();
            float energyLeft = readEnergyLeft();
            float maxEnergy = readMaxEnergy();
            LinkedList<Vehicle.Wheel> wheels =readWheels(vehicleType);
            object uniqueParamOne = readUniqueParamOne(vehicleType);
            object oniqueParamTwo = readUniqueParamTwo(vehicleType); ;
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            List<object> parametersList = new List<object>();

            parametersList.Add(vehicleType);
            parametersList.Add(i_OwnerLisenceNumber);
            parametersList.Add(modelName);
            parametersList.Add(energyLeft);
            parametersList.Add(maxEnergy);
            parametersList.Add(wheels);
            parametersList.Add(uniqueParamOne);
            parametersList.Add(oniqueParamTwo);

            Client newClient = new Client(clientName, clientPhoneNumber, parametersList);
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
            float energyLeft;
            LinkedList<Vehicle.Wheel> wheels;
            List<object> uniqueParametersList = new List<object>();
            FieldInfo[] fields;
            string message;

            clientName = readOwnerName();
            clientPhoneNumber = readOwnerPhoneNumber();
            vehicleType = readVehicleType();
            modelName = readModelName();
            energyLeft = readCurrentEnergy();
            wheels = readWheels(vehicleType);
            fields = m_Garage.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                message = string.Format("Enter {0}", fields[i].Name.Substring(2));
                Console.WriteLine(message);
                uniqueParametersList.Add(Console.ReadLine());
            }

            m_Garage.AddClient(clientName, clientPhoneNumber, vehicleType, modelName, energyLeft, wheels,
                uniqueParametersList);

        }

        private LinkedList<Vehicle.Wheel> readWheels(Vehicle.eVehicleType i_VehicleType)
        {
            string message;
            LinkedList < Vehicle.Wheel > wheelsList = new LinkedList<Vehicle.Wheel>();
            Vehicle.Wheel wheelNode;

            switch (i_VehicleType)
            {
                case (Vehicle.eVehicleType.FueledCar):
                case Vehicle.eVehicleType.ElectricCar:
                    message = "You need to enter 4 wheels." + Environment.NewLine;

                    break;
            }
        }




        // TODO ============================================== original UI ==================================

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

        public static Vehicle.eVehicleType readVehicleType()
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
                    returnType = readVehicleType();
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



        public static string readOwnerName()
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

        public static string readOwnerPhoneNumber()
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
