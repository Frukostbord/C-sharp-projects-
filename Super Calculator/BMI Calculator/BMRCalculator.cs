using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Super_Calculator
{
    public class BMRCalculator
    {
        // Local variables
        private Activity_Level activityLevel = Activity_Level.Moderately_Active; // Activity level
        private Gender gender = Gender.Male; // Gender
        private UnitTypes unit = UnitTypes.Metric; // Unit type (Metric/Imperial)
        private int age; // Age (years)
        private double weight, height; // Weight (kg), height (cm)
        private string name; // User name

        #region Setters & Getters

        // Setter & getter for activity level
        public Activity_Level ActivityLevel
        {
            get { return activityLevel; }
            set { activityLevel = value; }
        }

        // Setter & getter for gender
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        // Setter & getter for age
        public int Age
        {
            get { return age; }

            set
            {
                if (age > 0)
                    age = value;
            }
        }

        // Setter & getter for username
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    name = "Unknown";
            }
        }

        // Setter & getter for unit type (Metric/Imperial)
        public UnitTypes Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        // Setter & getter for weight (lbs/kgs)
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0.0)
                    weight = value;
            }
        }

        // Setter & getter for weight (inches/cm)
        public double Height

        {
            get { return height; }

            set
            {
                if (value > 0.0)
                    height = value;
            }
        }

        #endregion
        #region Calculate result

        // Calculating BMR
        public double[] CalculateBMR()
        {
            // Base calculation
            double bmr = 10 * weight + 6.25 * height - 5 * age;

            // Adjusting for gender
            if (gender == Gender.Male)
                bmr += 5;
            else
                bmr -= 161;           
            

            // Creating an array for each value
            double[] bmr_array = new double[6]
            {
                bmr,
                bmr *= BMRFactor(), // Adjust for activity level
                bmr - 500,
                bmr - 1000,
                bmr + 500,
                bmr + 1000,
            };

            return bmr_array;
        }

        // BMR factor depending on activity level
        private double BMRFactor()
        {
            switch (activityLevel)
            {
                case Activity_Level.Sedentary:
                    return 1.2;                    
                case Activity_Level.Lightly_Active:
                    return 1.375;
                case Activity_Level.Moderately_Active:
                    return 1.550;
                case Activity_Level.Very_Active:
                    return 1.725;
                default:
                    return 1.9;                    
            }

        }

        #endregion

    }
}
