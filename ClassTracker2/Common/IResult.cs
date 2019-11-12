using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public interface IResult
    {
        IEnumerable<string> ValidationIssues { get; } // for users
        IEnumerable<string> Errors { get; }           // for users
        IEnumerable<Exception> Exceptions { get; }    // for programmers DO NOT RETURN
        public bool IsOk { get; }
    }
    //public interface IInResult<TIn> : Result
    //{
    //    TIn Input { get; }
    //}
    //public interface Result<TOut> : Result
    //{
    //    TOut Output { get; }
    //}
    //public interface Result<TIn, TOut> : Result<TOut>, IInResult<TIn>
    //{
    //    Result<TIn, TOut> WithOutput(TOut output);
    //    Result<TIn, TOut> WithAnotherValidationMessage(string message);
    //}

    public readonly struct Result<TIn, TOut> : IResult
    {
        private Result(TIn input, TOut output,
            ImmutableList<string> validationIssues,
            ImmutableList<string> errors,
            ImmutableList<Exception> exceptions)
        {
            Input = input;
            Output = output;
            this.validationIssues = ImmutableList<string>.Empty.AddRange(validationIssues);
            this.errors = ImmutableList<string>.Empty.AddRange(errors);
            this.exceptions = ImmutableList<Exception>.Empty.AddRange(exceptions);
        }

        public Result(TIn input)
            : this(input, default, ImmutableList<string>.Empty,
                  ImmutableList<string>.Empty, ImmutableList<Exception>.Empty)
        { }

        public TIn Input { get; }
        public TOut Output { get; }
        private readonly ImmutableList<string> validationIssues;
        public IEnumerable<string> ValidationIssues => validationIssues.Select(x => x);
        private readonly ImmutableList<string> errors;
        public IEnumerable<string> Errors => errors.Select(x => x);
        private readonly ImmutableList<Exception> exceptions;
        public IEnumerable<Exception> Exceptions => exceptions.Select(x => x);

        public Result<TIn, TOut> WithOutput(TOut output)
            => new Result<TIn, TOut>(Input, output, validationIssues, errors, exceptions);

        public Result<TIn, TOut> WithAnotherValidationIssue(string message)
            => new Result<TIn, TOut>(Input, Output,
                    validationIssues.Add(message), errors, exceptions);
        public Result<TIn, TOut> WithAnotherException(Exception ex)
             => new Result<TIn, TOut>(Input, Output,
                    validationIssues, errors, exceptions.Add(ex));

        public bool IsOk
            => validationIssues.Count() + errors.Count() + Exceptions.Count() == 0;

  
    }
}
