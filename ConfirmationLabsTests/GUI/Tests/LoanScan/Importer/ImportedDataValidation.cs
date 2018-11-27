using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

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
    }
}