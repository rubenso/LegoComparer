using LegoComparer.ApiSource.Abstraction;
using LegoComparer.Model.LegoApi;

namespace LegoComparer.Client.Workers;

public class Task2 : TaskBase
{
    public Task2(ILegoApiService apiService) : base(apiService)
    {
    }

    /// <summary>
    /// Main function of class
    /// </summary>
    /// <param name="userName">Current user name</param>
    /// <param name="setName">Current set for analyze</param>
    /// <returns>users </returns>
    public IEnumerable<string>? Work(string userName, string setName)
    {
        //First are searching pieces, which are missing in 'landscape-artist' inventory for 'tropical-island' set
        var missingPieces = new List<SetPiece>();

        var userDetail = apiService.GetUserByUserId(allUsers.Result.Items.First(u => u.Username == userName).Id
            .ToString()).Result;

        var tropicalIslandSetDetail = apiService
            .GetSetById(allSets.Result.Items.First(s => s.Name == setName).Id.ToString()).Result;
        
        foreach (var piece in tropicalIslandSetDetail.Pieces)
        {
            var foundPiece = userDetail.UserPieces.FirstOrDefault(up => up.PieceId == piece.Part.DesignId);
            if (foundPiece == null)
            {
                missingPieces.Add(piece);
            }
            else
            {
                var foundVariant = foundPiece.Variants.FirstOrDefault(fp =>
                    fp.ColourNmr == piece.Part.Colour);

                if (foundVariant == null)
                {
                    missingPieces.Add(piece);
                    continue;
                }

                var piecesCountDifference = piece.Quantity - foundVariant.Count;
                if (piecesCountDifference > 0)
                    missingPieces.Add(new SetPiece { Part = piece.Part, Quantity = piecesCountDifference });
            }
        }

        return SearchUserForCoop(userName, missingPieces);
    }

    /// <summary>
    ///     Compare pieces of user vs. pieces of each set
    /// </summary>
    /// <param name="currentUser">Current user - 'landscape-artist'</param>
    /// <param name="missingSetPieces">Array of set pieces missing for current user</param>
    /// <returns></returns>
    private List<string>? SearchUserForCoop(string currentUser, List<SetPiece> missingSetPieces)
    {
        try
        {
            var usersForCooperation = new List<string>();
            var potentialUsers = allUsers.Result.Items.Where(u => u.Username != currentUser);

            foreach (var user in potentialUsers)
            {
                var userDetail = apiService.GetUserByUserId(user.Id.ToString()).Result;

                //Situation, when count of user pieces is lower than necessary pieces
                if (userDetail.BrickCount < missingSetPieces.Sum(p => p.Quantity))
                    continue;

                var conditionFulfilled = true;

                foreach (var setPiece in missingSetPieces)
                {
                    var foundPiece = userDetail.UserPieces.FirstOrDefault(up => up.PieceId == setPiece.Part.DesignId);
                    if (foundPiece == null)
                    {
                        conditionFulfilled = false;
                        break;
                    }

                    if (!foundPiece.Variants.Any(fp =>
                            fp.ColourNmr == setPiece.Part.Colour && fp.Count >= setPiece.Quantity))
                    {
                        conditionFulfilled = false;
                        break;
                    }
                }

                if (conditionFulfilled) usersForCooperation.Add(user.Username);
            }

            return usersForCooperation;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
}