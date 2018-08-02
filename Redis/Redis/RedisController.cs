using StackExchange.Redis;
using Newtonsoft.Json;
using System;

namespace Redis
{
    class RedisController
    {
        public static IDatabase redis = RedisStore.RedisCache;

        public void AddLoginAsString(Login login)
        {
            var serializedLogin = JsonConvert.SerializeObject(login);
            redis.StringSet(login.SessionId, serializedLogin);
            //Console.WriteLine(login.SessionId + " added.");
        }
        public Login GetStringLogin(string SessionId)
        {
            Login login = JsonConvert.DeserializeObject<Login>(redis.StringGet(SessionId));
            return login;
        }
        public void AddLoginAsHash(Login login)
        {
            redis.HashSet(login.SessionId, login.LoginToHashEntry());
            //Console.WriteLine(login.SessionId + " added.");
        }
        public Login GetHashLogin(string SessionId)
        {
            Login login = new Login(redis.HashGetAll(SessionId));
            return login;
        }
        public void DeleteLogin(string SessionId)
        {
            redis.KeyDelete(SessionId);
            Console.WriteLine(SessionId + " deleted succesfully.");
        }
    }
}
