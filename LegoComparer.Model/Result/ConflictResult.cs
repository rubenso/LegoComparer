namespace LegoComparer.Model.Result
{
    public class ConflictResult<T> : LegoResponse<T>
    {
        public ConflictResult()
        {
            Errors = new[] { new Error(ErrorCode.Conflict) };
        }
    }
}