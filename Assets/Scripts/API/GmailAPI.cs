using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class GmailAPI : MonoBehaviour
{
    IEnumerator GetRequestAPI(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Error" + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("HTTP Error" + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Recieved: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    //assignment gmail login
                    //slprisonbreakassignment@gmail.com
                    //SintlucasPrisonBreak2021

                    //Response
                    //{
                    //    "id": string,
                    //    "threadId": string,
                    //    "labelIds": [
                    //    string
                    //    ],
                    //    "snippet": string,
                    //    "historyId": string,
                    //    "internalDate": string,
                    //    "payload": {
                    //        object(MessagePart)
                    //    },
                    //    "sizeEstimate": integer,
                    //    "raw": string
                    //}

                    //https://developers.google.com/oauthplayground

                    break;
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetRequestAPI("https://gmail.googleapis.com/gmail/v1/users/slprisonbreakassignment@gmail.com/messages"));
    }
}
