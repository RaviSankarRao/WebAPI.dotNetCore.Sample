using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementService.Response
{
    public class EmployeeServiceResponse : IActionResult
    {
        public object ResponseData { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public EmployeeServiceResponse(object response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            ResponseData = response;
            StatusCode = statusCode;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(ResponseData)
            {
                StatusCode = (int)StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
