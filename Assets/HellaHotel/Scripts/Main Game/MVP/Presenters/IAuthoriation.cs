using GameServer.DTO.DTO;
using GameServer.DTO.Requests;
using System;

namespace Assets.HellaHotel.Scripts.Main_Game.MVP.Views.Interfaces
{
    public interface IAuthorization
    {
        event Action<AuthorizationDTO> OnAuthorization;
        event Action<UserDTO> OnRegistration;
        void OpenGame();
    }
}
