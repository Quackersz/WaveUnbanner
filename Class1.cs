using System;
using UnityEngine; 
using PlayFab;
using PlayFab.ClientModels;
using Steamworks;

namespace WaveUnbanner
{
    public class Class1 : MonoBehaviour 
    {
        // Define necessary fields
        public bool loginFailed = false;
        public string userID;
        public ulong userIDLong;

        void Start()
        {
            if (SteamAPI.Init())
            {
                AuthenticateWithPlayFab();
            }
            else
            {
                AuthenticateWithPlayFab(); 
            }
        }


        public void AuthenticateWithPlayFab()
        {
            if (!this.loginFailed)
            {
                {
                    CSteamID steamID = SteamUser.GetSteamID();
                    this.userIDLong = (ulong)steamID;
                    this.userID = steamID.ToString();
                }
  

                string customID = Guid.NewGuid().ToString(); 
                PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
                {
                    CustomId = customID, 
                    CreateAccount = true 
                }, new Action<LoginResult>(this.OnLoginWithCustomIDResponse), new Action<PlayFabError>(this.OnPlayFabError));
            }
        }

        public void OnLoginWithCustomIDResponse(LoginResult result)
        {
        }
        public void OnPlayFabError(PlayFabError error)
        {
        }
    }
}
