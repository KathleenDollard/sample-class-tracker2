using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Common
{
    public class FactoryBase<T>
    {
        private readonly Dictionary<Type, T> cache = new Dictionary<Type, T>();
        private readonly Dictionary<Type, Func<T>> lazyMakers = new Dictionary<Type, Func<T>>();

        protected void AddMaker<TKey>(Func<T> maker) 
            => lazyMakers.Add(typeof(TKey), maker);
 
        private T CreateCacheAndReturn(Type key)
        {
            if (! lazyMakers.TryGetValue(key, out var f))
            {
                return default;
            }
            var t = f();
            cache.Add(key, t);
            return t;
        }

        public T Get<TDto>()
            => Get(typeof(TDto));

        public T Get(Type dtoType)
            => cache.TryGetValue(dtoType, out T ret)
                    ? ret
                    : CreateCacheAndReturn(dtoType);

    }
   
}