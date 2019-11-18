using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassTracker2.Lib
{
    public class CrudHandler
    {
        private static readonly DomainFactory domainFactory = new DomainFactory();

        public static IResult Get<TDto>(int key) 
            => ((IDomain<int, TDto>)domainFactory.Get<TDto>()).GetById(key);
    }
}
