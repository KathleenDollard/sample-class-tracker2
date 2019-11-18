using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Helpers
    {
        // Designed to show switch usage
        public static string ValidateKey<TKey>(object key)
            => key is TKey typedKey
                ? ValidateKey(typedKey)
                : "Invalid key";

         private static string ValidateKey<TKey>(TKey key)
            => key switch
            {
                int i => ValidateKey(i),
                long l => l > 0 ? "" : "Key must be greater than zero",
                Guid g => g != Guid.Empty ? "" : "Key cannot be empty",
                string s => !string.IsNullOrWhiteSpace(s) 
                        ? "" 
                        : "Key cannot be empty", // please no
                _ => ""
            };

        public static string ValidateKey(int key)
         => key > 0 ? "" : "Key must be greater than zero";

        public static Result<TIn, TOut> ValidateInputAsKey<TIn, TOut>(Result<TIn, TOut> result)
        {
            var message = Helpers.ValidateKey<int>(result.Input);
            if (string.IsNullOrEmpty(message))
            {
                // all is well, just return result
                return result;
            }
            return result.WithAnotherValidationIssue(message);
        }
    }
}
