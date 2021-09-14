using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class RedisRepository<T> : IRedisRepository<T> where T:class
    {
        private ConnectionMultiplexer _redis;

        public RedisRepository(IConfiguration configuration)
        {
            
            _redis = ConnectionMultiplexer.Connect(
               configuration.GetConnectionString("RedisServer"));
            _redis.IncludeDetailInExceptions = true;
        }

        public T GetValueKey(string key)
        {
            var dbRedis = _redis.GetDatabase();
            var value = dbRedis.StringGet(key);

            return JsonConvert.DeserializeObject<T>(value);
        }

        public bool SetValueKey(string key, object value)
        {
            var dbRedis = _redis.GetDatabase();
            return dbRedis.StringSet(key, JsonConvert.SerializeObject(value));

        }
    }
}
