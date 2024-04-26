using System.Net;

namespace IFMS_Master_Backend.Models
{
    public class ServiceResponse<T>
    {
        public T result { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string errormessage { get; set; }
    }
}
