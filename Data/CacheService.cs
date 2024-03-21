using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


using StackExchange.Redis;


namespace MVC.Data
{
    public class CacheService : ICacheService
    {

        private IDatabase _db;


        public CacheService()
        {

        }

        private void ConfigureRedis()
        {

            _db = ConnectionHelper.Connection.GetDatabase();


        }

        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonContent.DeserializeObject<T>(value);
            }
            return default;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConverter.SerializeObject(value), expiryTime);
            return isSet;
        }



        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }


    }
}