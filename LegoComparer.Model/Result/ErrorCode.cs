

using Microsoft.AspNetCore.Http;

namespace LegoComparer.Model.Result
{
    public class ErrorCode
    {
        public const string BadRequest = "BadRequest";
        public const string Unauthorized = "Unauthorized";
        public const string NotFound = "NotFound";
        public const string Conflict = "Conflict";
        public const string InternalServerError = "InternalServerError";
        public const string ServiceUnavailable = "ServiceUnavailable";

        private static readonly Dictionary<string, int> ErrorCodesMap = new()
        {
            { BadRequest, StatusCodes.Status400BadRequest },
            { Unauthorized, StatusCodes.Status401Unauthorized },
            { NotFound, 404 },
            { InternalServerError, 500 },
            { ServiceUnavailable, 503 },
            { Conflict, StatusCodes.Status409Conflict }
        };

        public static int GetHttpStatusCode(Error error)
        {
            return ErrorCodesMap.ContainsKey(error.Code)
                ? ErrorCodesMap[error.Code]
                : StatusCodes.Status400BadRequest;
        }
    }
}