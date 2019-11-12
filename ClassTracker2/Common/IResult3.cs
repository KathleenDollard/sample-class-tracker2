using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
  
    public readonly struct ExceptionInfo<T>
    {
        private ExceptionInfo(
              ImmutableList<string> errors,
              ImmutableList<Exception> exceptions)
        {
            this.errors = ImmutableList<string>.Empty.AddRange(errors);
            this.exceptions = ImmutableList<Exception>.Empty.AddRange(exceptions);
        }
        private readonly ImmutableList<string> errors;
        public IEnumerable<string> Errors => errors.Select(x => x);
        private readonly ImmutableList<Exception> exceptions;
        public IEnumerable<Exception> Exceptions => exceptions.Select(x => x);
    }

    public readonly struct ValidationInfo<T>
    {
        private ValidationInfo(
              ImmutableList<string> validationIssues)
        {
            this.validationIssues = ImmutableList<string>.Empty.AddRange(validationIssues);
        }
        private readonly ImmutableList<string> validationIssues;
        public IEnumerable<string> ValidationIssues => validationIssues.Select(x => x);
    }

 

   
}
