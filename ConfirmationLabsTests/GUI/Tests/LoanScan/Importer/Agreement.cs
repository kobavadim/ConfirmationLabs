using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    public enum CollateralModificationType : byte
    {
        Seized = 1,
        Returned = 2,
        Increment = 3,
        Decrement = 4
    }

    public enum AgreementProtocolType : byte
    {
        Dharma = 1,
        MakerDao = 2
    }

    [BsonIgnoreExtraElements]
    public class TransactionBase
    {
        //[BsonElement("txHash")]
        public string txHash { get; set; }
        public ulong blockNumber { get; set; }
        public DateTime blockTimeStamp { get; set; }
    }

    public class TransactionBaseWithNetworkId : TransactionBase
    {
        public string networkId { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Agreement : TransactionBaseWithNetworkId
    {
        /// <summary>
        /// Dharma protocol -> IssuanceHash,
        /// MakerDAO protocol -> CDP Id
        /// </summary>
        [BsonId]
        public string AgreementId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public AgreementProtocolType agreementProtocolType { get; set; }
        //public string AgreementProtocol { get; set; }

        public List<CollateralModification> collateralModifications { get; set; }

        public List<IssuanceUpdate> issuances { get; set; }
        public List<RepaymentUpdate> repayments { get; set; }

        public decimal interestRate { get; set; }
        public string totalAmountToRepay { get; set; }  //empty for MakerDao protocol

        public TimeSpan? loanTerm { get; set; }  //empty for MakerDao protocol

        //protocol specific fields
        public DharmaFields dharmaFields { get; set; }
        public MakerDaoFields makerDaoFields { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class IssuanceUpdate : TransactionBase
    {
        // this is reference field
        [BsonIgnore]
        public string AgreementId { get; set; }

        public string payerAddress { get; set; }
        public string beneficiaryAddress { get; set; }
        public string amount { get; set; }
        public string tokenAddress { get; set; }

        public string interestRateAtOrigination { get; set; } // empty for Dharma protocol
    }

    //consider using the same model for IssuanceUpdated and RepaymentUpdated with proper naming
    [BsonIgnoreExtraElements]
    public class RepaymentUpdate : TransactionBase
    {
        [BsonIgnore]
        public string AgreementId { get; set; }

        public string payerAddress { get; set; }
        public string beneficiaryAddress { get; set; }
        public string amount { get; set; }
        public string tokenAddress { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class CollateralModification : TransactionBase
    {
        // this is reference field
        [BsonIgnore]
        public string AgreementId { get; set; }

        public string payerAddress { get; set; }
        public string amount { get; set; }
        public string tokenAddress { get; set; }
        public string beneficiaryAddress { get; set; }  // might be empty
        public CollateralModificationType modificationType { get; set; }
    }

    public class DharmaFields
    {
        public string kernelAddress { get; set; }
        public string repaymentAddress { get; set; }
        public string debtorFee { get; set; }
        public string creditorFee { get; set; }
        public string relayer { get; set; }
        public string relayerFee { get; set; }
        public string underwriter { get; set; }
        public string underwriterFee { get; set; }
        public string underwriterRiskRating { get; set; }
        public string termsContract { get; set; }
        public byte[] termsContractParameters { get; set; }
        [BsonRepresentation(BsonType.String)]
        public TermsParams.RepaymentFrequencyType repaymentFrequency { get; set; }
    }

    public class MakerDaoFields
    {
        public string ownerAddress { get; set; }
        public string creatorAddress { get; set; }
        public List<OwnerUpdate> ownerUpdates { get; set; }  // CDP ownership could be transferred
        public List<Bite> bites { get; set; }
        public List<Fee> governanceFees { get; set; }
        public List<Fee> liquidationFees { get; set; }
        public List<InterestFee> interestFeeUpdates { get; set; }
        public TransactionBase shut { get; set; }

        public List<MakerDaoRates> rates { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class InterestFee : TransactionBase
    {
        public string value { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MakerDaoRates
    {
        public ulong blockNumber { get; set; }
        public DateTime blockTimeStamp { get; set; }

        public string daiToUsd { get; set; }
        public string ethToUsd { get; set; }
        public string mkrToUsd { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Fee : TransactionBase
    {
        public string payerAddress { get; set; }
        public string beneficiaryAddress { get; set; }
        public string amount { get; set; }
        public string tokenAddress { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Bite : TransactionBase
    {
        public string beneficiaryAddress { get; set; }
        public string amount { get; set; }
        public string tokenAddress { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class OwnerUpdate : TransactionBase
    {
        public string value { get; set; }
    }
}