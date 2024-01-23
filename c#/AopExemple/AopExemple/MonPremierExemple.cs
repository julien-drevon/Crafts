namespace AopExemple
{
    public class MonPremierExemple : IMUseCase<string, string>
    {
        private ILog _logger;


          public MonPremierExemple(ILog logger)
        {
            this._logger = logger;
        }

        public string Execute(string query)
        {

           _logger.Log($"Execute : {query}");

            return query;
        }
    }

}