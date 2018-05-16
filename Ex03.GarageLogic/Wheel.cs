using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
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

        internal string ManufactorName
        {
            get { return m_ManufactorName; }
            set { m_ManufactorName = value; }
        }

        internal float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        internal float MaxAirPressure
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

            m_CurrentAirPressure += i_MountToInflate;
        }

        internal void InflateToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format("Manufactor Name: {0}, Current Air Pressure: {1}, Maximum Air Pressure: {2}", m_ManufactorName,
                m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}
