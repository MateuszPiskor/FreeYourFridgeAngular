using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Helpers
{
    public class ApiKeyReader
    {
        private string _key = System.IO.File.ReadAllText("SpoonacularApiKey.txt");
        
        public string getKey()
        {
            return _key;
        }

    }
}
