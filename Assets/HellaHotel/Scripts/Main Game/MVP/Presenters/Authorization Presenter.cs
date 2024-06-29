using Assets.HellaHotel.Scripts.DBServices;
using Assets.HellaHotel.Scripts.Main_Game.MVP.Views.Interfaces;
using GameServer.DTO.DTO;
using GameServer.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.HellaHotel.Scripts.Main_Game.MVP.Presenters
{
    public class AuthorizationPresenter
    {
        private readonly UserDBServices _dbServices = new UserDBServices();

        private readonly IAuthorization _view;
        public AuthorizationPresenter(IAuthorization view)
        {
            _view = view;
            _view.OnAuthorization += Autorization;
            _view.OnRegistration += Registration;
        }
        private async void Autorization(AuthorizationDTO authorization)
        {
            try
            {
                await _dbServices.Authorization(authorization);
                Debug.Log("Authorization Complete");
                _view.OpenGame();

            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        private async void Registration(UserDTO user)
        {
            try
            {
                await _dbServices.Registration(user);
                Debug.Log("Registration Complete");
                _view.OpenGame();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }
}
