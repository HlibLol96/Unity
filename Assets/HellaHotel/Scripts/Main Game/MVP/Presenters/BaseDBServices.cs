using GameServer.DTO.DTO;
using GameServer.DTO.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assets.HellaHotel.Scripts.DBServices
{
    public abstract class BaseDBServices<TDto, TKey>
    {
        protected readonly string controllerName;
        protected BaseDBServices()
        {
            controllerName = typeof(TDto).Name switch
            {
                nameof(UserDTO) => ServerInfo.User
            };
        }

        public virtual async Task<TDto> GetById(GetByIdRequestDto<TKey> request)
        {
            var url = ServerInfo.CreateRequestURL(ServerInfo.Host, controllerName, ServerInfo.GetById);

            var serData = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(serData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessVerifivation.Instance.Token);
                var response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<TDto>(await response.Content.ReadAsStringAsync());
                    return data;
                }
                else
                    throw new Exception(
                        JsonConvert.DeserializeObject<Exception>(await response.Content.ReadAsStringAsync()).Message
                        );
            }
        }

        public virtual async Task Update(TDto model)
        {
            var url = ServerInfo.CreateRequestURL(ServerInfo.Host, controllerName, ServerInfo.Update);

            var serData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(serData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccesVerification.Instance.Token);
                var response = await client.PutAsync(url, stringContent);
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
