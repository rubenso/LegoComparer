using System.Runtime.Serialization;

namespace LegoComparer.Model.Result
{
    /// <summary>
    ///     Describes Error that occured when processing a Request in Micro-service.
    /// </summary>
    [DataContract]
    public class Error
    {
        public Error() : this("BadRequest")
        {
        }

        public Error(string code = "BadRequest")
        {
            Code = code;
        }

        public Error(string code, string message, object interpolation = null) : this(code)
        {
            //dynamic expando = interpolation;
            Message = message;
            Interpolation = interpolation; //interpolation != null ? ToDictionary(interpolation) : null;
        }

        public Error(string code, string message, int? index = null, object interpolation = null)
            : this(code, message, interpolation)
        {
            Index = index;
        }

        public string Code { get; set; }


        public string Message { get; set; }

        /// <summary>
        ///     Index can be used when returning errors for multiple inputs. For example when saving
        ///     multiple records, each Error can refer to input on specific index.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        ///     Interpolation object can be used for Errors which we want to translate. Message could be:
        ///     'Value {value} is invalid as FirstName' and Interpolation will be {value: "Foo"}.
        ///     Message string can be then translated based on localization files on FrontEnd
        /// </summary>
        [DataMember(Name = "interpolation")]
        public object Interpolation { get; set; }
    }
}