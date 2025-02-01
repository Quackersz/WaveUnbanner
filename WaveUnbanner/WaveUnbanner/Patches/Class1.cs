using System;
using System.Text;
using Steamworks;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class SteamAuthenticator : MonoBehaviour
{
    void Awake()
    {
        AuthenticateWithPlayFab(OnAuthSuccess, OnAuthFailure);
    }

    public void AuthenticateWithPlayFab(Action<string> successCallback, Action<string> failureCallback)
    {


        string customID = "MyCustomID-" + Guid.NewGuid().ToString(); 

        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
        {
            CustomId = customID,  
            CreateAccount = true 
        },
        result => {
            successCallback?.Invoke(result.PlayFabId);
        },
        error => {
            failureCallback?.Invoke(error.GenerateErrorReport()); 
        });
    }

    // Success callback
    private void OnAuthSuccess(string playFabId)
    {
    }

    // Failure callback
    private void OnAuthFailure(string errorReport)
    {
    }
}
