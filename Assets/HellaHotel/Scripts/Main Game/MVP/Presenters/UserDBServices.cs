

using GameServer.DTO.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using GameServer.DTO.Requests;

namespace Assets.HellaHotel.Scripts.DBServices
{
    public class UserDBServices : BaseDBServices<UserDTO, int>
    {
        public async Task Registration(UserDTO user)
        {
            var url = ServerInfo.CreateRequestURL(ServerInfo.Host, controllerName, ServerInfo.Registration);

            var serData = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(serData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    //return data;
                }
                else
                    throw new Exception(
                        JsonConvert.DeserializeObject<Exception>(await response.Content.ReadAsStringAsync()).Message
                        );
            }
        }
        public async Task Authorization(AuthorizationDTO user)
        {
            var url = ServerInfo.CreateRequestURL(ServerInfo.Host, controllerName, ServerInfo.Authorization);

            var serData = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(serData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    //return data;
                }
                else
                    throw new Exception(
                        JsonConvert.DeserializeObject<Exception>(await response.Content.ReadAsStringAsync()).Message
                        );
            }
        }
    }
}
