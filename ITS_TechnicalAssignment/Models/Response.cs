using ITS_TechnicalAssignment.DataAccess.DTOs;
using System.Net;
using System.Web.Http.ModelBinding;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace ITS_TechnicalAssignment.API.Models
{
    public class Response<T>:IResponse<T> where T : class
    {
        public List<T> Results { get; set; }
        public int Status { get; set; }
        public List<string> Messages { get; set; }

        public Response()
        {
            Results = new List<T>();
            Status = 0;
            Messages = new List<string>();
        }

        public void BuildResponse(List<T> Results, HttpStatusCode Status, List<string> Messages)
        {
            this.Results = Results;
            this.Status = (int)Status;
            this.Messages = Messages;
        }

        public void BuildResponse(List<T> Results, HttpStatusCode Status, string Message)
        {
            this.Results = Results;
            this.Status = (int)Status;
            this.Messages.Add(Message);
        }

        public void BuildResponse(T Result, HttpStatusCode Status, List<string> Messages)
        {
            this.Results.Add(Result);
            this.Status = (int)Status;
            this.Messages = Messages;
        }

        public void BuildResponse(T Results, HttpStatusCode Status, string Message)
        {
            this.Results.Add(Results);
            this.Status = (int)Status;
            this.Messages.Add(Message);
        }

        public void BuildResponse(HttpStatusCode Status, List<string> Messages)
        {
            this.Status = (int)Status;
            this.Messages = Messages;
        }

        public void BuildResponse(HttpStatusCode Status, string Message)
        {
            this.Status = (int)Status;
            this.Messages.Add(Message);
        }

        public void HandleModelState(ValueEnumerable ModelStateValues)
        {
            foreach (var value in ModelStateValues)
            {
                if (value.Errors != null)
                {
                    string Error = value.Errors.FirstOrDefault().ErrorMessage;
                    Messages.Add(Error);
                }
            }

            this.Status = (int)HttpStatusCode.BadRequest;
            this.Results = new List<T>();
        }
    }
}
