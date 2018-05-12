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
            string ownerLisenceNumber = UserInterface.GetLisenceNumber();

            if (garageClients.ContainsKey(ownerLisenceNumber))
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
            string clientName = UserInterface.ReadOwnerName();
            string clientPhoneNumber = UserInterface.ReadOwnerPhoneNumber();
            Vehicle.eVehicleType vehicleType = UserInterface.ReadVehicleType();
            string modelName = UserInterface.ReadModelName();
            float energyLeft = UserInterface.ReadEnergyLeft();
            float maxEnergy = UserInterface.ReadMaxEnergy();
            LinkedList<Vehicle.Wheel> wheels = UserInterface.ReadWheels(vehicleType);
            object uniqueParamOne = UserInterface.ReadUniqueParamOne(vehicleType);
            object oniqueParamTwo = UserInterface.ReadUniqueParamTwo(vehicleType); ;
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

    }
}
