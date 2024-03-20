using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace MVC.Data
{
    public class CacheService : ICacheService
    {

        private readonly Microsoft.EntityFrameworkCore.Storage.IDatabase _db;


        public CacheService()
        {

        }

        private void ConfigureRedis()
        {

            _db = ConnectionHelper.Connection.GetDatabase();


        }

        public T GetData<T>(string key)
        {
            throw new NotImplementedException();
        }

        public object RemoveData(string key)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            throw new NotImplementedException();
        }
    }
}