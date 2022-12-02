using System.Net;

namespace DevopsAPI.Models
{
    public class Response
    {
        /// <summary>
        /// Result of request
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// HttpStatusCode of response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Dynamic data of response
        /// </summary>
        public dynamic? Data { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public dynamic? Message { get; set; }


        public Response()
        {

        }


        /// <summary>
        /// Response initializer for the case where the everything is ok
        /// </summary>
        /// <param name="isSuccess"></param>
        public Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
            StatusCode = HttpStatusCode.OK;
        }


        /// <summary>
        /// Response initializer for the case where the everything is ok but data is optional.
        /// </summary>
        /// <param name="statusCode">httpStatus code</param>
        /// <param name="data">dynamic data</param>
        public Response(HttpStatusCode statusCode, dynamic? data = null)
        {
            StatusCode = statusCode;
            IsSuccess = ((int)statusCode).ToString().StartsWith('2');
            Data = data;
        }

        /// <summary>
        /// Response initializer for the case where the status code is bad request and message is required.
        /// </summary>
        /// <param name="message"></param>
        public Response(dynamic message)
        {
            StatusCode = HttpStatusCode.BadRequest;
            IsSuccess=false;
            Message = message;
        }
    }
}
