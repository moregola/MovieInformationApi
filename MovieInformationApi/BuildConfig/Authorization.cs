namespace MovieInformationApi.BuildConfig
{
    public class Authorization
    {
        private readonly string _validKey = "A811D35E-8073-4B37-9359-1A24B68C33F0"; // Substitua pela sua 

        public bool IsAuthenticated(string providedKey)
        {
            return providedKey == _validKey;
        }
    }
}
