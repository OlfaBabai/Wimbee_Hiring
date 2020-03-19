using System;
using System.Collections.Generic;
using System.Text;

namespace Wimbee_Hiring.Persistence.Design_Patterns.Factory
{
    public interface IFactory<T> where T:class
    {
        T create();
    }
}
