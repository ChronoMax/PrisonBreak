using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
public static class FirebaseAuthHandeler
{
    private const string apiKey = "AIzaSyAvF3l-AM1EGaR1cpTExXdHDHh9yn9bTGs";

    public static void SignInWithToken(string id_token, string provider_id)
    {
        var payload = $"{{\"postBody\":\"id_token={id_token}&providerId={provider_id}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={apiKey}", payload).Then(response =>
        {
            Debug.Log(response.Text);
        }).Catch(Debug.Log);
    }
}
