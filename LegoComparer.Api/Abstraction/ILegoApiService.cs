using LegoComparer.Model.LegoApi;

namespace LegoComparer.ApiSource.Abstraction
{
    public interface ILegoApiService
    {
        Task<Users> GetUsers();
        Task<User> GetUserByUserName(string name);
        Task<User> GetUserByUserId(string id);
        Task<Sets> GetSets();
        Task<Set> GetSetByName(string name);
        Task<Set> GetSetById(string id);
        Task<Colours> GetColours();
    }
}