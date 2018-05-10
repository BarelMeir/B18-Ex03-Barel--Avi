using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)

            : base(
                string.Format("Invalid value range: minimal value possible is: {0} , and maximal value possible is {1}", i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get{ return m_MaxValue; }
        }

        public float MinValue
        {
            get{ return m_MinValue; }
        }
    }
}
