using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodleGradeClient.Models
{
    public class TokenModel
    {
        [JsonProperty("token", Required = Required.Always)]
        public string Token { get; set; }

        [JsonProperty("privatetoken", Required = Required.Always)]
        public string PrivateToken { get; set; }
    }
}
