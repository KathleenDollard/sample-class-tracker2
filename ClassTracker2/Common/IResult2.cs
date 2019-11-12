//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;

//namespace Common
//{
//    public interface IResult2
//    {
//        IEnumerable<string> ValidationIssues { get; } // for users
//        IEnumerable<string> Errors { get; }           // for users
//        IEnumerable<Exception> Exceptions { get; }    // for programmers DO NOT RETURN
//    }
//    public interface IInResult2<TIn> : IResult
//    {
//        TIn Input { get; }
//    }
//    public interface IResult2<TOut> : IResult
//    {
//        TOut Output { get; }
//    }
//    public interface IResult2<TIn, TOut> : IResult2<TOut>, IInResult2<TIn>
//    {
//        IResult2<TIn, TOut> WithOutput(TOut output);
//    }

//    public readonly struct ResultInfo
//    {
//        private ResultInfo(
//              ImmutableList<string> validationIssues,
//              ImmutableList<string> errors,
//              ImmutableList<Exception> exceptions)
//        {
//            this.validationIssues = ImmutableList<string>.Empty.AddRange(validationIssues);
//            this.errors = ImmutableList<string>.Empty.AddRange(errors);
//            this.exceptions = ImmutableList<Exception>.Empty.AddRange(exceptions);
//        }
//        private readonly ImmutableList<string> validationIssues;
//        public IEnumerable<string> ValidationIssues => validationIssues.Select(x => x);
//        private readonly ImmutableList<string> errors;
//        public IEnumerable<string> Errors => errors.Select(x => x);
//        private readonly ImmutableList<Exception> exceptions;
//        public IEnumerable<Exception> Exceptions => exceptions.Select(x => x);
//    }

//    public readonly struct Result2<TIn, TOut> //: IResult2<TIn, TOut>
//    {
//        private Result2(TIn input, TOut output,
//            ResultInfo resultInfo)
//        {
//            Input = input;
//            Output = output;
//            ResultInfo = resultInfo;
//        }

//        public Result2(TIn input)
//            : this(input, default, default)
//        { }

//        public TIn Input { get; }
//        public TOut Output { get; }
//        public ResultInfo ResultInfo { get; }

//        public Result2<TIn, TOut> WithOutput(TOut output)
//            => new Result2<TIn, TOut>(Input, output, ResultInfo);

//    }

   
//}
