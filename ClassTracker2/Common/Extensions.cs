using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Extensions
    {
        public static Result<TIn, TOut> Apply<TIn, TOut>(
            this Result<TIn, TOut> result, Func<Result<TIn, TOut>, Result<TIn, TOut>> func)
            => result.IsOk
                ? func(result)
                : result;

        // Validation is a variation of Apply
        public static Result<TIn, TOut> Validate<TIn, TOut>(
               this Result<TIn, TOut> result, Func<TIn, string> func)
        {
            var message = func(result.Input);
            if (string.IsNullOrEmpty(message))
            {
                // all is well, just return result
                return result;
            }
            return result.WithAnotherValidationIssue(message);
        }

        public static Result<TIn, TOut> BindOutput<TIn, TOut>(this Result<TIn, TOut> result, Func<TIn, TOut> func)
        {
            try
            {
                return result.WithOutput(func(result.Input));
            }
            catch (Exception ex)
            {
                return result.WithAnotherException(ex);
            }
        }

       


    }
}
