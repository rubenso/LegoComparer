using LegoComparer.ApiSource;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LegoComparer.Test;

[TestClass]
public class LegoApiTest
{
    private LegoApiService _legoApiService;

    [TestInitialize]
    public void Init()
    {
        _legoApiService = new LegoApiService("https://d16m5wbro86fg2.cloudfront.net/api");
    }

    [TestMethod]
    public async Task GetUser()
    {
        var user = await _legoApiService.GetUserByUserName("brickfan35");
        Assert.IsNotNull(user);
    }

    public async Task GetUserById()
    {
        var data = await _legoApiService.GetSetById("6d6bc9f2-a762-4a30-8d9a-52cf8d8373fc");
        Assert.IsNotNull(data);
    }
    
    [TestMethod]
    public async Task GetUsers()
    {
        var data = await _legoApiService.GetUsers();
        Assert.IsNotNull(data);
        Assert.IsNotNull(data.Items);
    }

    [TestMethod]
    public async Task GetSets()
    {
        var data = await _legoApiService.GetSets();
        Assert.IsNotNull(data);
        Assert.IsNotNull(data.Items);
    }

    [TestMethod]
    public async Task GetSet()
    {
        var data = await _legoApiService.GetSetByName("tropical-island");
        Assert.IsNotNull(data);
    }

    [TestMethod]
    public async Task GetColours()
    {
        var data = await _legoApiService.GetColours();
        Assert.IsNotNull(data);
        Assert.IsNotNull(data.Colors);

    }
}