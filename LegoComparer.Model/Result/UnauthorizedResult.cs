namespace LegoComparer.Model.Result
{
    public class UnauthorizedResult<T> : LegoResponse<T>
    {
        public UnauthorizedResult(params string[]? errorsMessages) : base(errorsMessages, ErrorCode.Unauthorized)
        {
        }

        public UnauthorizedResult(Error[] errors) : base(errors)
        {
        }
    }

    public class UnauthorizedResult : LegoResponse
    {
        public UnauthorizedResult(string[]? errorsMessages) : base(errorsMessages)
        {
        }

        public UnauthorizedResult(Error[] errors) : base(errors)
        {
        }
    }
}