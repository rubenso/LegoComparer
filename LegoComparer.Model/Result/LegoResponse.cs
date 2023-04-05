namespace LegoComparer.Model.Result
{
    public class LegoResponse
    {
        public LegoResponse()
        {
            Errors = Array.Empty<Error>();
        }

        public LegoResponse(IEnumerable<string>? errors, string code = ErrorCode.BadRequest)
        {
            Errors = errors != null
                ? errors.Select(e => new Error { Message = e, Code = code }).ToArray()
                : Array.Empty<Error>();
        }

        public LegoResponse(Error[] errors)
        {
            Errors = errors ?? Array.Empty<Error>();
        }

        public LegoResponse(Error error)
        {
            Errors = error != null ? new[] { error } : Array.Empty<Error>();
        }

        public Error[] Errors { get; set; }

        public bool IsError()
        {
            return Errors != null && Errors.Any();
        }

        public string GetErrorsString()
        {
            return !IsError() ? string.Empty : string.Join("\n", Errors.Select(e => e.Message));
        }


        public int AddError(string code)
        {
            var e = new Error(code);
            _ = Errors.Append(e);
            return Errors.Length;
        }

        public int AddErrors(Error[] errors)
        {
            _ = Errors.Concat(errors);
            return Errors.Length;
        }
    }

    public class LegoResponse<T> : LegoResponse
    {
        public LegoResponse()
        {
        }



        public LegoResponse(IEnumerable<string>? errors, string code = ErrorCode.BadRequest)
            : base(errors)
        {
        }

        public LegoResponse(Error[] errors) : base(errors)
        {
        }

        public LegoResponse(Error error) : base(error)
        {
        }

        public int Version { get; set; }

        public T Data { get; set; }

        /// <summary>
        ///     key is class name + unauthorized property collection
        /// </summary>
        public Dictionary<string, List<string>> UnauthorizedProperties { get; set; }
    }
}