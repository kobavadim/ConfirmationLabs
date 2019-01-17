using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    [TestFixture]
    public class ImportedDataValidationTests
    {
        [TestCase(
            120,
            "mongodb+srv://stage-one:HpiKyWZ00U8CyrkG@bloqboard-twwqb.mongodb.net/Loans?retryWrites=true",
            "Loans",
            "agreements",
            "mongodb+srv://stage-one:HpiKyWZ00U8CyrkG@bloqboard-twwqb.mongodb.net/Loans?retryWrites=true",
            "Loans",
            "agreements")]
        public void ValidateImportedData(
            long lookBackPeriodInMinutes,
            string expectedDataDatabaseConnectionString,
            string expectedDataDatabaseName,
            string expectedDataCollectionName,
            string actualDataDatabaseConnectionString,
            string actualDataDatabaseName,
            string actualDataCollectionName)
        {
            // initialize fields
            var lookBackDateTime = DateTime.UtcNow.AddMinutes((-1) * lookBackPeriodInMinutes);
            var pageNumber = 0;
            var pageSize = 1000;

            var expectedDataClient = new MongoClient(expectedDataDatabaseConnectionString);
            var expectedDataCollection = expectedDataClient.GetDatabase(expectedDataDatabaseName).GetCollection<Agreement>(expectedDataCollectionName);  //here can be different Agreement classes

            var actualDataClient = new MongoClient(actualDataDatabaseConnectionString);
            var actualDataCollection = actualDataClient.GetDatabase(actualDataDatabaseName).GetCollection<Agreement>(actualDataCollectionName);  //here can be different Agreement classes

            //enumerate and compare entries
            List<Agreement> expectedData;
            List<Agreement> actualData;
            do
            {
                expectedData = expectedDataCollection.AsQueryable().Skip(pageNumber * pageSize).Take(pageSize).ToList();
                actualData = actualDataCollection.AsQueryable().Skip(pageNumber * pageSize).Take(pageSize).ToList();

                // we are applying predicates on items in memory as IQueryable for Mongo does not seem to support queries against embedded arrays
                var expectedDataRefinedAgainstLookBackPeriod = expectedData
                    .Where(x => x.blockTimeStamp < lookBackDateTime
                                && x.issuances.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.repayments.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.collateralModifications.All(y => y.blockTimeStamp < lookBackDateTime)
                                && (x.makerDaoFields == null
                                    || (x.makerDaoFields.ownerUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.bites.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.governanceFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.liquidationFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.interestFeeUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && (x.makerDaoFields.shut == null || x.makerDaoFields.shut.blockTimeStamp < lookBackDateTime)
                                        )
                                    )
                            )
                    .ToList();

                var actualDataRefinedAgainstLookBackPeriod = actualData
                    .Where(x => x.blockTimeStamp < lookBackDateTime
                                && x.issuances.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.repayments.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.collateralModifications.All(y => y.blockTimeStamp < lookBackDateTime)
                                && (x.makerDaoFields == null
                                    || (x.makerDaoFields.ownerUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.bites.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.governanceFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.liquidationFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.interestFeeUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && (x.makerDaoFields.shut == null || x.makerDaoFields.shut.blockTimeStamp < lookBackDateTime)
                                        )
                                )
                    )
                    .ToList();

                actualDataRefinedAgainstLookBackPeriod.Count.Should().Be(expectedDataRefinedAgainstLookBackPeriod.Count);
                for (var index = 0; index < actualDataRefinedAgainstLookBackPeriod.Count; index++)
                {
                    // logging id of the mismatched agreement into "because" part of the assertion message
                    actualDataRefinedAgainstLookBackPeriod[index].Should().BeEquivalentTo(expectedDataRefinedAgainstLookBackPeriod[index], expectedDataRefinedAgainstLookBackPeriod[index].AgreementId);
                }

                pageNumber++;
            } while (expectedData.Count > 1);
        }

        [Test]
        public void ValidateImportedDataParameterized()
        {
            string lookBackPeriodInMinutes = TestContext.Parameters["lookBackPeriodInMinutes"];
            long lookBackPeriodInMinutesLong = (long)Convert.ToDouble(lookBackPeriodInMinutes);
         
            Console.WriteLine(lookBackPeriodInMinutes);
            
            string expectedDataDatabaseConnectionString = TestContext.Parameters["expectedDataDatabaseConnectionString"];
            string expectedDataDatabaseName = TestContext.Parameters["expectedDataDatabaseName"];
            string expectedDataCollectionName = TestContext.Parameters["expectedDataCollectionName"];
            string actualDataDatabaseConnectionString = TestContext.Parameters["actualDataDatabaseConnectionString"];
            string actualDataDatabaseName = TestContext.Parameters["actualDataDatabaseName"];
            string actualDataCollectionName = TestContext.Parameters["actualDataCollectionName"];

            Console.WriteLine(expectedDataDatabaseConnectionString);
            Console.WriteLine(expectedDataDatabaseName);
            Console.WriteLine(expectedDataCollectionName);
            Console.WriteLine(actualDataDatabaseConnectionString);
            Console.WriteLine(actualDataDatabaseName);
            Console.WriteLine(actualDataCollectionName);

            // initialize fields
            var lookBackDateTime = DateTime.UtcNow.AddMinutes((-1) * lookBackPeriodInMinutesLong);
            var pageNumber = 0;
            var pageSize = 1000;

            var expectedDataClient = new MongoClient(expectedDataDatabaseConnectionString);
            var expectedDataCollection = expectedDataClient.GetDatabase(expectedDataDatabaseName).GetCollection<Agreement>(expectedDataCollectionName);  //here can be different Agreement classes

            var actualDataClient = new MongoClient(actualDataDatabaseConnectionString);
            var actualDataCollection = actualDataClient.GetDatabase(actualDataDatabaseName).GetCollection<Agreement>(actualDataCollectionName);  //here can be different Agreement classes

            //enumerate and compare entries
            List<Agreement> expectedData;
            List<Agreement> actualData;
            do
            {
                expectedData = expectedDataCollection.AsQueryable().Skip(pageNumber * pageSize).Take(pageSize).ToList();
                actualData = actualDataCollection.AsQueryable().Skip(pageNumber * pageSize).Take(pageSize).ToList();

                // we are applying predicates on items in memory as IQueryable for Mongo does not seem to support queries against embedded arrays
                var expectedDataRefinedAgainstLookBackPeriod = expectedData
                    .Where(x => x.blockTimeStamp < lookBackDateTime
                                && x.issuances.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.repayments.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.collateralModifications.All(y => y.blockTimeStamp < lookBackDateTime)
                                && (x.makerDaoFields == null
                                    || (x.makerDaoFields.ownerUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.bites.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.governanceFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.liquidationFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.interestFeeUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && (x.makerDaoFields.shut == null || x.makerDaoFields.shut.blockTimeStamp < lookBackDateTime)
                                        )
                                    )
                            )
                    .ToList();

                var actualDataRefinedAgainstLookBackPeriod = actualData
                    .Where(x => x.blockTimeStamp < lookBackDateTime
                                && x.issuances.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.repayments.All(y => y.blockTimeStamp < lookBackDateTime)
                                && x.collateralModifications.All(y => y.blockTimeStamp < lookBackDateTime)
                                && (x.makerDaoFields == null
                                    || (x.makerDaoFields.ownerUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.bites.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.governanceFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.liquidationFees.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && x.makerDaoFields.interestFeeUpdates.All(y => y.blockTimeStamp < lookBackDateTime)
                                        && (x.makerDaoFields.shut == null || x.makerDaoFields.shut.blockTimeStamp < lookBackDateTime)
                                        )
                                )
                    )
                    .ToList();

                actualDataRefinedAgainstLookBackPeriod.Count.Should().Be(expectedDataRefinedAgainstLookBackPeriod.Count);
                for (var index = 0; index < actualDataRefinedAgainstLookBackPeriod.Count; index++)
                {
                    // logging id of the mismatched agreement into "because" part of the assertion message
                    actualDataRefinedAgainstLookBackPeriod[index].Should().BeEquivalentTo(expectedDataRefinedAgainstLookBackPeriod[index], expectedDataRefinedAgainstLookBackPeriod[index].AgreementId);
                }

                pageNumber++;
            } while (expectedData.Count > 1);
        }

        [Category("Importer")]
        [Test]
        public void ValidateImportFromScript()
        {
            string contents = File.ReadAllText(@"C:\\Users\\Administrator\\Documents\\result.txt");
            var result = contents.Substring(contents.Length - 10);
            Console.WriteLine(result);
            if (result.Contains("ERROR"))
            {
                throw new Exception("Importer is working incorrectly");
            }
        }
    }
}