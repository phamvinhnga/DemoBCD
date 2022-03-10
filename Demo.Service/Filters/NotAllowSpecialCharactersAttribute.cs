using Demo.Service.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Service.Filters
{
    public class NotAllowSpecialCharactersAttribute : ActionFilterAttribute
    {
        private readonly string _property;
        private readonly Regex _charSet = new Regex("[^A-Za-z0-9]");

        public NotAllowSpecialCharactersAttribute(
            string property
        )
        {
            _property = property;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var input = context.ActionArguments.First().Value;
            var value = input.GetType().GetProperty(_property).GetValue(input, null).ToString();

            if (_charSet.IsMatch(value)) {
                throw new NotAllowSpecialCharaterException($"Property { _property } has special character.");
            }

            base.OnActionExecuting(context);
        }
    }
}
