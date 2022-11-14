using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CloudBackend.Errors
{
    public class NotFound
    {
        public class Result
        {
            public int status { get; set; }
            public string error { get; set; }
        }

        public static string Error()
        {
            string json = JsonConvert.SerializeObject(new Result { status = 404, error = "Page isnt found" });
            return json;
        }
    }
}
