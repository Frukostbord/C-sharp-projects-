using Super_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Calculator
{
    public class BMICalculator
    {
        // Instance variables 
        private string name; // User´s name
        private double height, weight; // User´s height and weight
        private UnitTypes unit = UnitTypes.Metric; // Metric or Imperial


        // Set user´s name
        public void SetName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                name = userName;
            else
                name = "Unknown";
        }

        // Returns user´s name
        public string GetName()
        {
            return name;
        }

        // Returns user´s height
        public double GetHeight()
        {
            return height;
        }

        // Sets user´s height
        public void SetHeight(double heightInput)
        {
            if (heightInput > 0.0)
                height = heightInput;
        }

        // Sets user´s weight
        public void SetWeight(double weightInput)
        {
            if(weightInput > 0.0)
                weight = weightInput;
        }

        // Sets user´s unit (Metric or Imperial)
        public void SetUnit(UnitTypes userUnit)
        {
            unit = userUnit;
        }

        // Returns unittype
        public UnitTypes GetUnit()
        {
            return unit;
        }

        // Calculates the user´s BMI based on instance variables values
        public double CalculateBMI()
        {
            double bmi;

            if (unit == UnitTypes.Metric)
                bmi = weight / Math.Pow((height/100), 2);

            else
                bmi = (weight * 703) / Math.Pow(height, 2);

            return bmi;
        }

        // Categorizing BMI according to World Health Organization´s standard
        public string BMIWeightCategory()
        {
            double bmi = CalculateBMI();
            string weightCategory = "";

            {
                if (bmi < 18.50)
                    weightCategory = "Underweight";

                else if ((bmi >= 18.50) && (bmi < 25))
                    weightCategory = "Healthy weight";

                else if ((bmi >= 25.0) && (bmi <= 29.9))
                    weightCategory = "Overweight";

                else if (bmi >= 30.0)
                    weightCategory = "Obesity";
            }
            return weightCategory;
        }     
     
        // Minimum recommended weight according to BMI
        public double GetMinimumWeight()
        {
            double minimumWeight;

            // Calculating minimum weight using instance variables
            if (unit == UnitTypes.Metric)
                minimumWeight = 18.5 * Math.Pow((height / 100), 2);
            else
                minimumWeight = (18.5 * Math.Pow(height, 2)) / 703;

            return minimumWeight;
        }
        
        // Maximum recommended weight according to BMI
        public double GetMaximumWeight()
        {
            double maximumWeight;

            // Calculating maximum weight using instance variables
            if (unit == UnitTypes.Metric)
                maximumWeight = 24.9 * Math.Pow((height / 100), 2);
           
            else
                maximumWeight = (24.9 * Math.Pow(height, 2)) / 703;

            return maximumWeight;
        }

    }
}
