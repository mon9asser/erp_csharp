using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections;
 
namespace sales_management.DB
{

    class Server
    {

        public int Id { get; set; }

        public string ServerId { get; set; }

        public string Port { get; set; }

        public string DatabaseName { get; set; }

        public string UserName { get; set; }

        public bool isIntegrated { get; set; }

        public String Password { get; set; }

    }


    class Config
    {
        
        public string dir = Directory.GetCurrentDirectory() + "/";
        public string fileName = "app-config.json";


        private string networkId;
        private string databaseName;
        private string port;
        private string userName;
        private string password;
        private bool isIntegrated;

        public string GetNetworkId() {
            return this.networkId;
        }

        public string GetDatabaseName()
        {
            return this.databaseName;
        }

        public string GetPort()
        {
            return this.port;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetUserName()
        {
            return this.userName;
        }

        public bool isIntegratedSecurity() {
            return this.isIntegrated;
        }

        public bool isFileExists()
        {
            return File.Exists(this.dir + this.fileName);
        }

        public void LoadSystemConfiguration() {

            string _dir = this.dir + this.fileName;
            string strJson = File.ReadAllText(_dir);
            var dirctionary = JsonConvert.DeserializeObject<IDictionary>(strJson);

            foreach(DictionaryEntry entry in dirctionary)
            {
                switch ( entry.Key) {
                    
                    case "ServerId":
                        this.networkId = entry.Value.ToString();
                        break;

                    case "DatabaseName":
                        this.databaseName = entry.Value.ToString();
                        break;

                    case "UserName":
                        this.userName = entry.Value.ToString();
                        break;

                    case "Password":
                        this.password = entry.Value.ToString();
                        break;

                    case "Port":
                        this.port = entry.Value.ToString();
                        break;

                    case "isIntegrated":
                        this.isIntegrated = Convert.ToBoolean(entry.Value);
                        break;
                } 

            }
        }

        public void CreateServerInformation(Server jsonObject ) {
            string strResultJson = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText( this.dir + this.fileName, strResultJson );
        }

    }
}
