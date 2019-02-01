using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    [TestFixture]
    public class ImportedDataValidationTests
    {
        private const ulong BlockNumberPrecision = 5;
        private static readonly TimeSpan TimestampPrecision = TimeSpan.FromMinutes(5);
        
        [TestCase(
            "mongodb+srv://stage-one:HpiKyWZ00U8CyrkG@bloqboard-twwqb.mongodb.net/Loans?retryWrites=true",
            "LoansProdCopy2",
            "agreementsLoanscanConsumers",
            "mongodb+srv://stage-one:HpiKyWZ00U8CyrkG@bloqboard-twwqb.mongodb.net/Loans?retryWrites=true",
            "LoansProdCopy2",
            "agreements")]
        [Category("Importer")]
        public void ValidateImportedData(
            string newCollectionDatabaseConnectionString,
            string newCollectionDatabaseName,
            string newCollectionName,    
            string oldCollectionDatabaseConnectionString,
            string oldCollectionDatabaseName,
            string oldCollectionName)
        {
            var newCollectionClient = new MongoClient(newCollectionDatabaseConnectionString);
            var newCollection = newCollectionClient.GetDatabase(newCollectionDatabaseName).GetCollection<Agreement>(newCollectionName).AsQueryable().ToList();  //here can be different Agreement classes

            var oldCollectionClient = new MongoClient(oldCollectionDatabaseConnectionString);
            var oldCollection = oldCollectionClient.GetDatabase(oldCollectionDatabaseName).GetCollection<Agreement>(oldCollectionName).AsQueryable().ToList();  //here can be different Agreement classes

            var areEqual = CompareAgreementsCollections(newCollection, oldCollection);

            Console.WriteLine("new collection: " + newCollection.Count + " old collection: " + oldCollection.Count);
            areEqual.Should().Be(true);
        }

        [Test]
        public void ValidateImportedDataParameterized()
        {
            string newCollectionDatabaseConnectionString = TestContext.Parameters["newCollectionDatabaseConnectionString"];
            string newCollectionDatabaseName = TestContext.Parameters["newCollectionDatabaseName"];
            string newCollectionName = TestContext.Parameters["newCollectionName"];
            string oldCollectionDatabaseConnectionString = TestContext.Parameters["oldCollectionDatabaseConnectionString"];
            string oldCollectionDatabaseName = TestContext.Parameters["oldCollectionDatabaseName"];
            string oldCollectionName = TestContext.Parameters["oldCollectionName"];

            Console.WriteLine(newCollectionDatabaseConnectionString);
            Console.WriteLine(newCollectionDatabaseName);
            Console.WriteLine(newCollectionName);
            Console.WriteLine(oldCollectionDatabaseConnectionString);
            Console.WriteLine(oldCollectionDatabaseName);
            Console.WriteLine(oldCollectionName);

            var newCollectionClient = new MongoClient(newCollectionDatabaseConnectionString);
            var newCollection = newCollectionClient.GetDatabase(newCollectionDatabaseName).GetCollection<Agreement>(newCollectionName).AsQueryable().ToList();  //here can be different Agreement classes

            var oldCollectionClient = new MongoClient(oldCollectionDatabaseConnectionString);
            var oldCollection = oldCollectionClient.GetDatabase(oldCollectionDatabaseName).GetCollection<Agreement>(oldCollectionName).AsQueryable().ToList();  //here can be different Agreement classes

            var areEqual = CompareAgreementsCollections(newCollection, oldCollection);

            areEqual.Should().Be(true);
        }

        private bool CompareAgreementsCollections(List<Agreement> newCollection, List<Agreement> oldCollection)
        {
            Console.WriteLine($"New collection length: {newCollection.Count}");
            Console.WriteLine($"Old collection length: {oldCollection.Count}");

            var areEqual = true;

            var commonAgreementIds = newCollection
                .Select(x => new {Id = x.AgreementId, Protocol = x.agreementProtocolType})
                .Intersect(oldCollection.Select(x => new {Id = x.AgreementId, Protocol = x.agreementProtocolType}))
                .ToList();

            foreach (var agreement in newCollection)
            {
                if (commonAgreementIds.FirstOrDefault(x => x.Id == agreement.AgreementId && x.Protocol == agreement.agreementProtocolType) == null)
                {
                    Console.WriteLine($"Agreement with id {agreement.AgreementId} and protocol {agreement.agreementProtocolType} is not found in old collection");
                    areEqual = false;
                }
            }

            foreach (var agreement in oldCollection)
            {
                if (commonAgreementIds.FirstOrDefault(x => x.Id == agreement.AgreementId && x.Protocol == agreement.agreementProtocolType) == null)
                {
                    Console.WriteLine($"Agreement with id {agreement.AgreementId} and protocol {agreement.agreementProtocolType} is not found in new collection");
                    areEqual = false;
                }
            }

            var diffAgreementsCount = 0;
            foreach (var agreement in commonAgreementIds)
            {
                var newAgreement = newCollection.Find(x => x.AgreementId == agreement.Id && x.agreementProtocolType == agreement.Protocol);
                var oldAgreement = oldCollection.Find(x => x.AgreementId == agreement.Id && x.agreementProtocolType == agreement.Protocol);

                if (!CompareAgreements(newAgreement, oldAgreement))
                {
                    diffAgreementsCount++;
                    areEqual = false;
                    Console.WriteLine();
                };
            }
            
            Console.WriteLine($"{diffAgreementsCount} agreements are not equal between new and old collections");

            return areEqual;
        }

        private bool CompareAgreements(Agreement newAgreement, Agreement oldAgreement)
        {
            var agreementId = newAgreement.AgreementId;
            
            //exclude all lists and objects with nested collections
            //we assume that there can be chain reorganization that affects value of block number and block timestamp
            //Standard fluent assertion workflow is not applicable as we want to continue comparison even after AssertionException
            //use single & to check all conditions and write logs about all differences
            //agreements are not equal if one of these comparisons will fail
            //same solution in methods below
            bool areEqual = 
                DataValidationUtils.CompareEntities(newAgreement.interestRate, oldAgreement.interestRate, agreementId, decimal.Equals, "interest rate") &
                DataValidationUtils.CompareEntities(newAgreement.loanTerm, oldAgreement.loanTerm, agreementId, LoanTermsAreEqual, "loan term") &
                DataValidationUtils.CompareEntities(newAgreement.totalAmountToRepay, oldAgreement.totalAmountToRepay, agreementId, string.Equals, "total amount to repay") &
                DataValidationUtils.CompareEntities(newAgreement.dharmaFields, oldAgreement.dharmaFields, agreementId, DharmaFieldsAreEqual, "dharma fields") &
                DataValidationUtils.CompareEntities(newAgreement.networkId, oldAgreement.networkId, agreementId, string.Equals, "network id") &
                DataValidationUtils.CompareEntities(newAgreement.blockTimeStamp, oldAgreement.blockTimeStamp, agreementId, CompareBlockTimestamps, "block timestamp") &
                DataValidationUtils.CompareEntities(newAgreement.blockNumber, oldAgreement.blockNumber, agreementId, CompareBlockNumber, "block number");
            
            if (
                !MakerDaoValidation.CompareMakerDaoFields(newAgreement.makerDaoFields, oldAgreement.makerDaoFields, agreementId) |
                !DataValidationUtils.CompareCollections(newAgreement.collateralModifications, oldAgreement.collateralModifications, agreementId, CollateralModificationsMatcher, "collateral") |
                !DataValidationUtils.CompareCollections(newAgreement.repayments, oldAgreement.repayments, agreementId, RepaymentsMatcher, "repayment") |
                !DataValidationUtils.CompareCollections(newAgreement.issuances, oldAgreement.issuances, agreementId, IssuancesMatcher, "issuance")
            )
            {
                areEqual = false;
            }

            return areEqual;
        }

        private bool LoanTermsAreEqual(TimeSpan? a, TimeSpan? b)
        {
            if (a == null && b == null)
                return true;
            if (a == null || b == null)
                return false;

            return a.Value == b.Value;
        }

        private bool DharmaFieldsAreEqual(DharmaFields a, DharmaFields b)
        {
            if (a == null && b == null)
                return true;

            //case when only one shut is not null
            if (a == null || b == null)
                return false;

            return a.relayer == b.relayer &&
                   a.underwriter == b.underwriter &&
                   a.creditorFee == b.creditorFee &&
                   a.debtorFee == b.debtorFee &&
                   a.kernelAddress == b.kernelAddress &&
                   a.relayerFee == b.relayerFee &&
                   a.repaymentAddress == b.repaymentAddress &&
                   a.repaymentFrequency == b.repaymentFrequency &&
                   a.termsContract == b.termsContract &&
                   a.underwriterFee == b.underwriterFee &&
                   a.termsContractParameters.SequenceEqual(b.termsContractParameters) &&
                   a.underwriterRiskRating == b.underwriterRiskRating;
        }

        private bool CompareBlockNumber(ulong a, ulong b)
        {
            return Math.Abs((decimal) a - b) < BlockNumberPrecision;
        }

        private bool CompareBlockTimestamps(DateTime a, DateTime b)
        {
            return (a > b - TimestampPrecision) && (a < b + TimestampPrecision);
        }

        private bool CollateralModificationsMatcher(CollateralModification a, CollateralModification b)
        {
            return a.amount == b.amount &&
                   a.beneficiaryAddress == b.beneficiaryAddress &&
                   a.payerAddress == b.payerAddress &&
                   a.tokenAddress == b.tokenAddress &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision &&
                   a.modificationType == b.modificationType;
        }

        public bool RepaymentsMatcher(RepaymentUpdate a, RepaymentUpdate b)
        {
            return a.amount == b.amount &&
                   a.beneficiaryAddress == b.beneficiaryAddress &&
                   a.payerAddress == b.payerAddress &&
                   a.tokenAddress == b.tokenAddress &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }

        public bool IssuancesMatcher(IssuanceUpdate a, IssuanceUpdate b)
        {
            return a.amount == b.amount &&
                   a.tokenAddress == b.tokenAddress &&
                   a.payerAddress == b.payerAddress &&
                   a.interestRateAtOrigination == b.interestRateAtOrigination &&
                   Math.Abs((decimal) a.blockNumber - b.blockNumber) < BlockNumberPrecision &&
                   a.blockTimeStamp > b.blockTimeStamp - TimestampPrecision &&
                   a.blockTimeStamp < b.blockTimeStamp + TimestampPrecision;
        }
    }
}