using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.WebAPI.Models.Common
{
    public class BaseRequest<T>
    {
        public string Token { get; set; }
        public T Data { get; set; }
    }

    public class BaseResponse<T> {
        public string[] Errors { get; set; }
        public string Status { get; set; }
        public T Data { get; set; }
    }
}