using System.Net;

namespace DevopsAPI.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
        public dynamic Message { get; set; }
    }
}
