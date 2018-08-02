using System;
using StackExchange.Redis;

namespace Redis
{
    class Login
    {
        public long id { get; set; }
        public DateTime Created { get; set; }
        public string AccountName { get; set; }
        public DateTime LastLoginTime { get; set; }
        public byte LoggedIn { get; set; }
        public string SessionId { get; set; }
        public string IpString { get; set; }
        public string Source { get; set; }
        public string AppStr { get; set; }
        public string Version { get; set; }
        public DateTime LastLoginRequest { get; set; }
        public string LoginCount { get; set; }
        public string LogoffCount { get; set; }

        public Login()
        {

        }
        public Login(HashEntry[] hashEntries)
        {
            this.id = Int32.Parse(hashEntries[0].Value);
            this.Created = DateTime.Parse(hashEntries[1].Value);
            this.AccountName = hashEntries[2].Value;
            this.LastLoginTime = DateTime.Parse(hashEntries[3].Value);
            this.LoggedIn = Byte.Parse(hashEntries[4].Value);
            this.SessionId = hashEntries[5].Value;
            this.IpString = hashEntries[6].Value;
            this.Source = hashEntries[7].Value;
            this.AppStr = hashEntries[8].Value;
            this.Version = hashEntries[9].Value;
            this.LastLoginRequest = DateTime.Parse(hashEntries[10].Value);
            this.LoginCount = hashEntries[11].Value;
            this.LogoffCount = hashEntries[12].Value;
        }
        public Login(string[] line)
        {
            this.id = Int32.Parse(line[0]);
            this.Created = DateTime.Parse(line[1]);
            this.AccountName = line[2];
            this.LastLoginTime = DateTime.Parse(line[3]);
            this.LoggedIn = Byte.Parse(line[4]);
            this.SessionId = line[5];
            this.IpString = line[6];
            this.Source = line[7];
            this.AppStr = line[8];
            this.Version = line[9];
            this.LastLoginRequest = DateTime.Parse(line[10]);
            this.LoginCount = line[11];
            this.LogoffCount = line[12];
        }
        public HashEntry[] LoginToHashEntry()
        {
            HashEntry[] hashEntries = {
                new HashEntry("id", this.id),
                new HashEntry("Created", this.Created.ToString()),
                new HashEntry("AccountName", this.AccountName),
                new HashEntry("LastLoginTime", this.LastLoginTime.ToString()),
                new HashEntry("LoggedIn", this.LoggedIn.ToString()),
                new HashEntry("SessionId", this.SessionId),
                new HashEntry("IpString", this.IpString),
                new HashEntry("Source", this.Source),
                new HashEntry("AppStr", this.AppStr),
                new HashEntry("Version", this.Version),
                new HashEntry("LastLoginRequest", this.LastLoginRequest.ToString()),
                new HashEntry("LoginCount", this.LoginCount),
                new HashEntry("LogoffCount", this.LogoffCount)
            };
            return hashEntries;
        }
    }
}
