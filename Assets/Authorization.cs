using Assets.HellaHotel.Scripts.Main_Game.MVP.Presenters;
using Assets.HellaHotel.Scripts.Main_Game.MVP.Views.Interfaces;
using GameServer.DTO.DTO;
using GameServer.DTO.Requests;
using System;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Assets.HellaHotel.Scripts.Main_Game.MVP.Views
{
    internal class Authorization : MonoBehaviour, IAuthorization
    {
        [SerializeField] private GameObject _authorizationComp;
        [SerializeField] private GameObject _registrationComp;

        [Space(20)]
        [Header("Authorization")]
        [SerializeField] private TMP_InputField _passwordAuthorization;
        [SerializeField] private TMP_InputField _loginAuthorization;

        [Space(20)]
        [Header("Registration")]
        [SerializeField] private TMP_InputField _loginRegistration;
        [SerializeField] private TMP_InputField _passwordRegistration;
        [SerializeField] private TMP_InputField _email;
        [SerializeField] private TMP_InputField _username;


        public event Action<AuthorizationDTO> OnAuthorization;
        public event Action<UserDTO> OnRegistration;

        private AuthorizationPresenter _presenter;
        private void OnEnable()
        {
            if (_presenter == null)
            {
                _presenter = new AuthorizationPresenter(this);
            }
        }
        public void Registration()
        {
            UserDTO user = new UserDTO();
            user.Email = _email.text;
            user.Login = _loginRegistration.text;
            user.Name = _username.text;
            user.Password = _passwordRegistration.text;
            OnRegistration?.Invoke(user);

        }
        public void Authorizationl()
        {
            AuthorizationDTO user = new AuthorizationDTO();
            user.Login = _loginAuthorization.text;
            user.Password = _passwordAuthorization.text;
            OnAuthorization?.Invoke(user);

        }

        public void OpenRegistration()
        {
            _registrationComp.SetActive(true);
            _authorizationComp.SetActive(false);
        }
        public void OpenAuthorization()
        {
            _authorizationComp.SetActive(true);
            _registrationComp.SetActive(false);
        }
        public void OpenGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
