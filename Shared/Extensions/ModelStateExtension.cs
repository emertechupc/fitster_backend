using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fitster.API.Shared.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}