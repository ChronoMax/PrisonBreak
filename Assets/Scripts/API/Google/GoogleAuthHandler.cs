using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;

public static class GoogleAuthHandler
{
    ////web
    //private static string clientId = "598007857407-keo34prvph91v4ladmc8c1948te1vel1.apps.googleusercontent.com";
    //private static string clientSecret = "F2O9wK1rZDqW6Usq8D48LSwB";

    //desktop
    private static string clientId = "598007857407-g9nmh6d2r6hf9275svlnn70gb2m92124.apps.googleusercontent.com";
    private static string clientSecret = "cQCpZ7vAeBsCcfMrqD9VVDh5";

    public static void GetUserCode()
    {
        Application.OpenURL($"https://accounts.google.com/o/oauth2/v2/auth?client_id={clientId}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&response_type=code&scope=email");
    }

    public static void ExchangeAuthCodeWithToken(string code, Action<string> callback)
    {
        RestClient.Post($"https://oauth2.googleapis.com/token?code={code}&client_id={clientId}&client_secret={clientSecret}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&grant_type=authorization_code", null).Then(response =>
        {
            var data = StringSerializationAPI.Deserialize(typeof(GoogleIDResponse),response.Text) as GoogleIDResponse;
            callback(data.id_token);
        });
    }
}
