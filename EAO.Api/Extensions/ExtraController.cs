using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EAO.Api.Extensions
{
    public class ExtraController: ControllerBase
    {

        public static List<string> GetErrorMessages(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            foreach (var state in modelState)
            {
                var errorMessages = state.Value.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();

                if (errorMessages.Any())
                {
                    errors.AddRange(errorMessages);
                }
            }

            return errors;
        }



    }
}
