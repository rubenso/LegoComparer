namespace LegoComparer.Model.Result
{
    public class InternalErrorResult<T> : LegoResponse<T>
    {
        public InternalErrorResult(string message = null)
            : base(new Error(ErrorCode.InternalServerError, message ?? string.Empty, interpolation: null))
        {
        }
    }

    public class InternalErrorResult : LegoResponse
    {
        public InternalErrorResult(string message = null)
            : base(new Error(ErrorCode.InternalServerError, message ?? string.Empty, interpolation: null))
        {
        }
    }
}