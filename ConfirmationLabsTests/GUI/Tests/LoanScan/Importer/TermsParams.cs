using System;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    public class TermsParams
    {
        public enum RepaymentFrequencyType
        {
            Hourly = 0,
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Yearly = 4
        }

        public TimeSpan LoanTerm { get; set; }

        public RepaymentFrequencyType RepaymentFrequency { get; set; }

        public decimal InterestRate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal CollateralAmount { get; set; }

        public string CollateralTokenAddress { get; set; }
    }
}