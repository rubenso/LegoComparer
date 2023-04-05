
using LegoComparer.ApiSource.Abstraction;
using LegoComparer.Model.LegoApi;

namespace LegoComparer.Client.Workers
{
    public class TaskBase
    {
        protected readonly ILegoApiService apiService;
        protected readonly Task<Users> allUsers;
        protected readonly Task<Sets> allSets;
        /// <summary>
        /// Base class with common field for all tasks
        /// </summary>
        /// <param name="apiService"></param>
        public TaskBase(ILegoApiService apiService)
        {
            this.apiService = apiService;
            allUsers = apiService.GetUsers();
            allSets = apiService.GetSets();
        }
    }
}
