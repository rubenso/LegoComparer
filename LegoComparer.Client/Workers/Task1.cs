using LegoComparer.ApiSource.Abstraction;
using LegoComparer.Model.LegoApi;

namespace LegoComparer.Client.Workers;

public class Task1 : TaskBase
{
    /// <summary>
    /// brickfan35 user possible sets
    /// </summary>
    /// <param name="apiService">Source of API data</param>
    public Task1(ILegoApiService apiService) : base(apiService)
    {
    }

    public List<string> Work(string userName)
    {
        var possibleSets = new List<string>();

        var userDetail = apiService.GetUserByUserId(allUsers.Result.Items.First(u => u.Username == userName).Id
            .ToString()).Result;

        if (allSets.Result.Items == null) throw new Exception("Empty list of sets");
        foreach (var set in allSets.Result.Items)
        {
            if (set.TotalPieces > userDetail.BrickCount) continue;
            //Read complete set of pices
            var setDetail = apiService.GetSetById(set.Id.ToString());
            if (CompareVariants(userDetail.UserPieces.ToList(), setDetail.Result.Pieces))
            {
                possibleSets.Add(set.Name);
            }
        }

        return possibleSets;
    }
    /// <summary>
    /// Compare inventory of user pieces  vs. pieces of each set
    /// </summary>
    /// <param name="userPieces">List of user pieces</param>
    /// <param name="setPieces">Array of set pieces</param>
    /// <returns></returns>
    private bool CompareVariants(List<UserPiece> userPieces, IEnumerable<SetPiece> setPieces)
    {
        try
        {
            foreach (var setPiece in setPieces)
            {
                var foundPiece = userPieces.FirstOrDefault(up => up.PieceId == setPiece.Part.DesignId);
                if (foundPiece != null)
                {
                    if (!foundPiece.Variants.Any(fp =>
                            fp.ColourNmr == setPiece.Part.Colour && fp.Count >= setPiece.Quantity))
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString()); 
            return false;
        }
    }
}