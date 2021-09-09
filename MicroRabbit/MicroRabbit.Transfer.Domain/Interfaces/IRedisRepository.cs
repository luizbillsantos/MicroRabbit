using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Interfaces
{
    public interface IRedisRepository<T> where T:class
    {

        public bool SetValueKey(string key, object value);

        public T GetValueKey(string key);

    }
}
