using System.Net;

namespace Application.Errors.Interfaces
{
    public interface IRequestException
    {
        public string Name { get; set; }
        public string Severity { get; set; }
        public string Message { get; }
        public bool Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
