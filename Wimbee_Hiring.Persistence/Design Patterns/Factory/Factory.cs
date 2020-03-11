using System;
using System.Collections.Generic;
using System.Text;

namespace Wimbee_Hiring.Persistence.Design_Patterns.Factory
{
    public class Factory<T> : IFactory<T> where T:class
    {
        private readonly T _initFunc;

        public Factory(T initFunc)
        {
            _initFunc = initFunc;
        }

        public T create()
        {
            return _initFunc;
        }
    }
}
