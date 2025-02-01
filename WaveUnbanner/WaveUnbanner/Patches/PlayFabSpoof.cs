using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabSpoofer : MonoBehaviour
{
    void Start()
    {
        SpoofPlayFabID();
    }

    void SpoofPlayFabID()
    {
        string fakeID = System.Guid.NewGuid().ToString(); 

        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
        {
            CustomId = fakeID,
            CreateAccount = true
        }, result =>
        {
        }, error =>
        {
        });
    }
}
