using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        public enum eVehicleType
        {
            ElectricCar,
            ElectricMotorcycle,
            FueledCar,
            FueledMotorcycle,
            FueledTruck
        }

        public enum eEnergyType
        {
            Octan96,
            Octan98,
            Electric
        }

        public enum eRepairStatus
        {
            InProgress,
            Completed,
            Paid
        }

        public class Wheel
        {
            private string m_ManufactorName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

            internal Wheel(string i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                m_ManufactorName = i_ManufactorName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }

            public string ManufactorName
            {
                get { return m_ManufactorName; }
                set { m_ManufactorName = value; }
            }

            public float CurrentAirPressure
            {
                get { return m_CurrentAirPressure; }
                set { m_CurrentAirPressure = value; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
                set { m_MaxAirPressure = value; }
            }

            internal void Inflate(float i_MountToInflate)
            {
                if (m_CurrentAirPressure + i_MountToInflate > MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }

                m_CurrentAirPressure += i_MountToInflate; //TODO make sure this Exception works as expected.
            }
        }

        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeftPrecentage;
        private float m_CurrentEnergy;
        private float m_MaxEnergyCapacity;
        private LinkedList<Wheel> m_Wheels;
        private eRepairStatus m_RepairStatus;
        private eEnergyType m_EnergyType;
        private eVehicleType m_VehicleType;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels, eVehicleType i_VehicleType)
        {
            try
            {
                m_ModelName = i_ModelName;
                m_LicenseNumber = i_LicenseNumber;
                m_CurrentEnergy = i_CurrentEnergy;
                m_MaxEnergyCapacity = i_MaxEnergyCapacity;
                m_Wheels = i_Wheels;
                m_EnergyType = i_EnergyType;
                m_RepairStatus = eRepairStatus.InProgress;
                m_EnergyLeftPrecentage = m_CurrentEnergy / m_MaxEnergyCapacity;
                m_VehicleType = i_VehicleType;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeftPrecentage
        {
            get { return m_EnergyLeftPrecentage; }
            set { m_EnergyLeftPrecentage = value; }
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set { m_CurrentEnergy = value; }
        }

        public float MaxEnergyCapacity
        {
            get { return m_MaxEnergyCapacity; }
            set { m_MaxEnergyCapacity = value; }
        }

        public eRepairStatus RepairStatus
        {
            get { return m_RepairStatus; }
            set { m_RepairStatus = value; }
        }

        public void InflateAllWheels(float io_MountToInflate)
        {
            foreach (Wheel currentWheel in m_Wheels)
            {
                currentWheel.Inflate(io_MountToInflate);
            }
        }

        public void AddEnergy(eEnergyType i_EnergyType, float i_AmountToAdd)
        {
            if (m_EnergyType != i_EnergyType)
            {
                throw new ArgumentException();
            }

            if (m_CurrentEnergy + i_AmountToAdd > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyCapacity);
            }

            try
            {
                m_CurrentEnergy += i_AmountToAdd;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
            
        }

    }
}
