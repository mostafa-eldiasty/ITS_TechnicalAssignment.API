using System.Net;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace ITS_TechnicalAssignment.API.Models
{
    public interface IResponse<T> where T : class
    {
        List<T> Results { get; set; }
        int Status { get; set; }
        List<string> Messages { get; set; }

        void BuildResponse(List<T> Results, HttpStatusCode Status, List<string> Messages);
        void BuildResponse(List<T> Results, HttpStatusCode Status, string Message);
        void BuildResponse(T Result, HttpStatusCode Status, List<string> Messages);
        void BuildResponse(T Results, HttpStatusCode Status, string Message);
        void BuildResponse(HttpStatusCode Status, List<string> Messages);
        void BuildResponse(HttpStatusCode Status, string Message);
        void HandleModelState(ValueEnumerable ModelStateValues);
    }
}
