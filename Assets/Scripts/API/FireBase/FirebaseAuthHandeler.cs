using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using SimpleJSON;
public static class FirebaseAuthHandeler
{
    private const string apiKey = "AIzaSyAvF3l-AM1EGaR1cpTExXdHDHh9yn9bTGs";
    public static string email = "email";

    public static void SignInWithToken(string id_token, string provider_id)
    {
        var payload = $"{{\"postBody\":\"id_token={id_token}&providerId={provider_id}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={apiKey}", payload).Then(response =>
        {
            Debug.Log(response.Text);

            JSONNode GoogleInfo = JSON.Parse(response.Text);

            Debug.Log("The email adress= " + GoogleInfo["email"].Value);
            email = GoogleInfo["email"].Value;

            Computer.EmailRecieved(email);


            //this is the JSON respone:
            //"federatedId": "https://accounts.google.com/107842334442273950098",
            //"providerId": "google.com",
            //"email": "slprisonbreakassignment@gmail.com",
            //"emailVerified": true,
            //"localId": "8rAdCOKZu1OuBjs51iN8oALLbjY2",
            //"idToken":


        }).Catch(Debug.Log);
    }
}
