using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.PARAM
{
    public class UserResponse
    {
        [JsonPropertyName("Userid")]
        public string Userid {  get; set; }
        [JsonPropertyName("Usercod")]
        public string Usercod { get; set; }
        [JsonPropertyName("UserPrivilegio")]
        public string UserPrivilegio { get; set; }
        [JsonPropertyName("UserRuta")]
        public string UserRuta { get; set; }
        [JsonPropertyName("Token")]
        public string Token { get; set; }
    }
}
