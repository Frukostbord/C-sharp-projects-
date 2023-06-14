using Super_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Calculator
{
    public class SavingsCalculator
    {
        // Local variables
        private double startingAmount = 0;
        private double interest, fees, monthlyDeposit;
        private int years;

        #region Setters & Getters

        // Setter & getter for starting amount
        public double StartingAmount
        {
            get { return startingAmount; }

            set
            {
                if (value > 0.0)
                    startingAmount = value;
            }
        }

        // Setter & getter for monthly deposit
        public double MonthlyDeposit
        {
            get { return monthlyDeposit; }
            
            set
            {
                if (value > 0.0)
                    monthlyDeposit = value;
            }
        }

        // Setter & getter for interest rate
        public double Interest
        {
            get { return interest; }

            set
            {
                if (value > 0.0)
                    interest = value;
            }
        }

        // Setter & getter for fees
        public double Fees
        {
            get {  return fees; }

            set 
            { 
                if (value > 0.0)
                    fees = value;             
            }
        }

        // Setter & getter for years to save
        public int Years
        {
            get { return years; }

            set
            {
                if(value > 0)
                    years = value;
            }
        }

        #endregion

        #region Methods for calculations

        // Returns deposit + starting value
        public double AmountPaid()
        {
            double paid = monthlyDeposit * 12 * years + startingAmount;
            return paid;

        }

        // Returns money earned from interest rate
        public double AmountEarned()
        {
            int numOfMonths = years * 12;
            double moneyEarned = startingAmount;

            // 1. First we calculate the TOTAL sum
            // 2. Then we subtract the money put in + starting value (AmountPaid())
            // 3. The remainder is earned from interest
            for (int i = 0; i < numOfMonths; i++)
            {
                double interestEarned = ((interest/100)/12) * moneyEarned;
                moneyEarned += interestEarned + monthlyDeposit;
            }

            return moneyEarned - AmountPaid();
        }


        // Add starting value + deposit + interest 
        // Subtract fee
        public double FinalBalance()
        {
            double totalAmount = AmountPaid() + AmountEarned() - TotalFees();
            return totalAmount;

        }


        // 1. First we calculate the TOTAL sum
        // 2. Then we subtract the money put in + starting value
        // 3. The remainder is the fee (same principle as with interest)
        public double TotalFees()
        {
            int numOfMonths = years * 12;
            double totalFee = 0;

            for (int i = 0; i < numOfMonths; i++)
            {
                double fee = ((fees/100)/12) * totalFee;
                totalFee += fee + monthlyDeposit;
                    
            }

            return totalFee - AmountPaid();

        }
        #endregion
    }
}
