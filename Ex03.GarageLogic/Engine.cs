﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        public enum eEngineType
        {
            Fuel,
            Electric
        }

        public enum eEnergyType
        {
            Electricity,
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        private float m_CurrentLeftEnergy;
        private float m_MaxEnergyCapacity;
        private float m_EnergyPercentgeLeft;
        private eEngineType m_EngineType;
        private eEnergyType m_EnergyType;

        public Engine(eEngineType i_EngineType, float i_EnergyLeft, Vehicle.eVehicleType i_VehicleType)
        {
            m_EngineType = i_EngineType;
            m_CurrentLeftEnergy = i_EnergyLeft;

            switch (m_EngineType)
            {
                case eEngineType.Fuel:
                    switch (i_VehicleType)
                    {
                        case Vehicle.eVehicleType.Car:
                            m_MaxEnergyCapacity = 45;
                            m_EnergyType = eEnergyType.Octan98;
                            break;
                        case Vehicle.eVehicleType.Motorcycle:
                            m_MaxEnergyCapacity = 6;
                            m_EnergyType = eEnergyType.Octan96;
                            break;
                        case Vehicle.eVehicleType.Truck:
                            m_MaxEnergyCapacity = 115;
                            m_EnergyType = eEnergyType.Octan96;
                            break;
                        default:
                            throw new ArgumentException();
                    }
                    break;
                case eEngineType.Electric:
                    switch (i_VehicleType)
                    {
                        case Vehicle.eVehicleType.Car:
                            m_MaxEnergyCapacity = 3.2f;
                            m_EnergyType = eEnergyType.Electricity;
                            break;
                        case Vehicle.eVehicleType.Motorcycle:
                            m_MaxEnergyCapacity = 1.8f;
                            m_EnergyType = eEnergyType.Electricity;
                            break;
                        default:
                            throw new ArgumentException();
                    }
                    break;
            }

            if (m_CurrentLeftEnergy > m_MaxEnergyCapacity)
            {
                throw new ArgumentException();
            }
        }

        public float MaxEnergyCapacity
        {
            get { return m_MaxEnergyCapacity; }
        }

        public float CurrentLeftEnergy
        {
            get { return m_CurrentLeftEnergy; }
            set { m_CurrentLeftEnergy = value; }
        }

        public float EnergyPercentgeLeft
        {
            get { return m_EnergyPercentgeLeft; }
        }

        public eEngineType EngineType
        {
            get { return m_EngineType; }
        }

        public eEnergyType EnergyType
        {
            get { return m_EnergyType; }
        }

        internal void AddEnergy(eEnergyType i_EngineType, float i_AmountToAdd)
        {
            if (m_EnergyType != i_EngineType)
            {
                throw new ArgumentException();
            }

            if (m_CurrentLeftEnergy + i_AmountToAdd > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyCapacity);
            }

            try
            {
                m_CurrentLeftEnergy += i_AmountToAdd;
                m_EnergyPercentgeLeft = (m_CurrentLeftEnergy * 100) / m_MaxEnergyCapacity;
            }
            catch (FormatException exception)
            {
                throw exception;
            }

        }
    }
}
