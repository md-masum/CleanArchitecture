using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Results
{
    public class Result
    {
        private Result(bool succeeded, IEnumerable<string> errors, string success)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Message = success;
        }

        public bool Succeeded { get; set; }

        private string Message { get; set; }

        public string[] Errors { get; set; }

        public static Result Success(string success = "Success")
        {
            return new Result(true, new string[] { }, success);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors, null);
        }
    }
}