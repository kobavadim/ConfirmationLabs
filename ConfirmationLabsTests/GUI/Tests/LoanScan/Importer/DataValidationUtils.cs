using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan.Importer
{
    public static class DataValidationUtils
    {
        public static bool CompareEntities<T>(
            T newEntity,
            T oldEntity,
            string agreementId,
            Func<T, T, bool> equals,
            string entityName 
        )
        {
            if (equals(newEntity, oldEntity))
            {
                return true;
            }
            Console.WriteLine($"For agreement id {agreementId} {entityName} has different values. New value is {JsonConvert.SerializeObject(newEntity)} " +
                              $"and the old one is {JsonConvert.SerializeObject(oldEntity)}");
            return false;
        }

        public static bool CompareCollections<T>(
            List<T> newCollection,
            List<T> oldCollection,
            string agreementId,
            Func<T, T, bool> matcher,
            string entityName
        )
        {
            bool areEqual = true;
            
            if (newCollection.Count != oldCollection.Count)
            {
                Console.WriteLine($"For agreement id {agreementId} {entityName} collection lengths are not equal: " +
                                  $"new length is {newCollection.Count} and old length is {oldCollection.Count}");
                areEqual = false;
            }

            var oldCollectionCopy = new List<T>(oldCollection);
            var newCollectionCopy = new List<T>(newCollection);

            //handle case when there can be multiple events that matches the specific matcher's condition
            var newNotMatchedEntities = newCollection.Where(a =>
            {
                var item = oldCollectionCopy.FirstOrDefault(b => matcher(a, b));
                if (item == null)
                    return true;
                oldCollectionCopy.Remove(item);
                return false;
            });
            
            var oldNotMatchedEntities = oldCollection.Where(a =>
            {
                var item = newCollectionCopy.FirstOrDefault(b => matcher(a, b));
                if (item == null)
                    return true;
                newCollectionCopy.Remove(item);
                return false;
            });

            foreach (var entity in newNotMatchedEntities)
            {
                Console.WriteLine($"For agreement id {agreementId} {entityName} {JsonConvert.SerializeObject(entity)} is not found in old collection");
                areEqual = false;
            }
            
            foreach (var entity in oldNotMatchedEntities)
            {
                Console.WriteLine($"For agreement id {agreementId} {entityName} {JsonConvert.SerializeObject(entity)} is not found in new collection");
                areEqual = false;
            }

            return areEqual;
        }
    }
}