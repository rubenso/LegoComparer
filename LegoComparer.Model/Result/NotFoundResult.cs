namespace LegoComparer.Model.Result
{
    public class NotFoundResult<T> : LegoResponse<T>
    {
        public NotFoundResult(string errorMessage, object interpolation = null)
            : base(new Error(ErrorCode.NotFound, errorMessage, interpolation))
        {
        }
    }
}