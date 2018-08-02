using System;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisController redisController = new RedisController();
            //Loginleri excel dosyasından okuma
            string[] allLines = System.IO.File.ReadAllLines(@"logins.csv");
            for (int i = 1; i < allLines.Length; i++)
            {
                string[] line = allLines[i].Split(';');
                Login login = new Login(line);
                //String olarak ekleme
                //redisController.AddLoginAsString(login);

                //Hash olarak ekleme
                redisController.AddLoginAsHash(login);
            }
            //Redisten String veri çekme
            //Login lgn = redisController.GetStringLogin("bfe94950-e5d9-4bc2-90be-a726fc7c9d28");

            //Redisten Hash olarak çekme
            Login lgn = redisController.GetHashLogin("bfe94950-e5d9-4bc2-90be-a726fc7c9d28");

            Console.WriteLine("Account Name : " + lgn.AccountName);
            redisController.DeleteLogin(lgn.SessionId);
            Console.ReadKey();
        }
    }
}
