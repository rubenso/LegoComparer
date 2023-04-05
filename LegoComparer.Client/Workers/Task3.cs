using LegoComparer.ApiSource.Abstraction;

namespace LegoComparer.Client.Workers
{
    internal class Task3 : TaskBase
    {
        public Task3(ILegoApiService apiService) : base(apiService)
        {

        }

        /// <summary>
        /// Main function of class
        /// </summary>
        /// <param name="userName">Current user name</param>
        /// <returns>users </returns>
        public IEnumerable<string>? Work(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
