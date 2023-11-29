using Application.Errors.Interfaces;
using System.Net;

namespace Application.Errors
{
    public class RequestError : IRequestError
    {
        public string Name { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public bool Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
