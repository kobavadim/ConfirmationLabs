using System;
using Newtonsoft.Json;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    public static class MakerDaoValidation
    {
        private const ulong BlockNumberPrecision = 5;
        private static readonly TimeSpan TimestampPrecision = TimeSpan.FromMinutes(5);
        
        public static bool CompareMakerDaoFields(MakerDaoFields newMakerDaoFields, MakerDaoFields oldMakerDaoFields, string agreementId)
        {
            bool areEqual = true;
            
            //case when it's not makerDao agreement
            if (newMakerDaoFields == null && oldMakerDaoFields == null)
                return true;

            //incorrect case when only one object is null
            if (newMakerDaoFields == null || oldMakerDaoFields == null)
            {
                Console.WriteLine($"For agreement id {agreementId} new agreement maker dao fields are {JsonConvert.SerializeObject(newMakerDaoFields)}" +
                                  $"and for the old one {JsonConvert.SerializeObject(oldMakerDaoFields)}");
                return false;
            }

            if (
                !DataValidationUtils.CompareEntities(newMakerDaoFields.creatorAddress, oldMakerDaoFields.creatorAddress, agreementId, string.Equals, "creatorAddress") |
                !DataValidationUtils.CompareEntities(newMakerDaoFields.ownerAddress, oldMakerDaoFields.ownerAddress, agreementId, string.Equals, "ownerAddress") |
                !DataValidationUtils.CompareEntities(newMakerDaoFields.shut, oldMakerDaoFields.shut, agreementId, ShutsAreEqual, "shut")
            )
            {
                areEqual = false;
            }

            if (
                !DataValidationUtils.CompareCollections(newMakerDaoFields.ownerUpdates, oldMakerDaoFields.ownerUpdates, agreementId, OwnerUpdatesMatcher, "owner update") |
                !DataValidationUtils.CompareCollections(newMakerDaoFields.bites, oldMakerDaoFields.bites, agreementId, BitesMatcher, "bite") |
                !DataValidationUtils.CompareCollections(newMakerDaoFields.governanceFees, oldMakerDaoFields.governanceFees, agreementId, FeesMatcher, "governance fee") |
                !DataValidationUtils.CompareCollections(newMakerDaoFields.liquidationFees, oldMakerDaoFields.liquidationFees, agreementId, FeesMatcher, "liquidation fee") |
                !DataValidationUtils.CompareCollections(newMakerDaoFields.interestFeeUpdates, oldMakerDaoFields.interestFeeUpdates, agreementId, InterestFeesMatcher,"interest fee update") |
                !DataValidationUtils.CompareCollections(newMakerDaoFields.rates, oldMakerDaoFields.rates, agreementId, RatesMatcher, "rates")
            )
            {
                areEqual = false;
            }

            return areEqual;
        }
        
        private static bool OwnerUpdatesMatcher(OwnerUpdate a, OwnerUpdate b)
        {
            return a.value == b.value &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }

        private static bool BitesMatcher(Bite a, Bite b)
        {
            return a.amount == b.amount &&
                   a.tokenAddress == b.tokenAddress &&
                   a.beneficiaryAddress == b.beneficiaryAddress &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }

        private static bool FeesMatcher(Fee a, Fee b)
        {
            return a.amount == b.amount &&
                   a.tokenAddress == b.tokenAddress &&
                   a.beneficiaryAddress == b.beneficiaryAddress &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }

        private static bool InterestFeesMatcher(InterestFee a, InterestFee b)
        {
            return a.value == b.value &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }

        private static bool RatesMatcher(MakerDaoRates a, MakerDaoRates b)
        {
            return a.daiToUsd == b.daiToUsd &&
                   a.ethToUsd == b.ethToUsd &&
                   a.mkrToUsd == b.mkrToUsd &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }
        
        private static bool ShutsAreEqual(TransactionBase a, TransactionBase b)
        {
            if (a == null && b == null)            
                return true;

            //case when only on shut is not null
            if (a == null || b == null)
                return false;
            
            return Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }
    }
}