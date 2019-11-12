using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IRepo
    {
    }
    public interface IRepo<TKey, TDto> : IRepo
    {
    }
}
