using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementService.Response
{
    public class ErrorResponse : IActionResult
    {
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public ErrorResponse(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Message)
            {
                StatusCode = (int)StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
