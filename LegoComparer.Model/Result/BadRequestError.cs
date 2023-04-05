namespace LegoComparer.Model.Result
{
    public class BadRequestError : Error
    {
        public BadRequestError(string message) : base(ErrorCode.BadRequest, message, null)
        {
        }

        public BadRequestError(string message, object interpolation)
            : base(ErrorCode.BadRequest, message, null, interpolation)
        {
        }
    }
}