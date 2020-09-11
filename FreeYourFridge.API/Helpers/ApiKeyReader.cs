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