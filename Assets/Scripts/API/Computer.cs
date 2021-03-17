using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Computer : MonoBehaviour, IInteractable
{

    public GameObject computerUI;
    public InputField codeField;
    public string emailRecieved;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Computer";
    }

    public void AccesComputer()
    {
        FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        computerUI.gameObject.SetActive(!computerUI.gameObject.activeSelf);
        if (computerUI.gameObject.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            fps.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            fps.enabled = true;
        }
    }

    public void OnCloseClick()
    {
        computerUI.SetActive(false);
        FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fps.enabled = true;
    }

    public void OnClickGetGoogleCode()
    {
        GoogleAuthHandler.GetUserCode();
    }

    public void OnClickGoogleSignIn()
    {
        GoogleAuthHandler.ExchangeAuthCodeWithToken(codeField.text, idToken =>
        {
            FirebaseAuthHandeler.SignInWithToken(idToken, "google.com");
        });
    }

    public void Action(PlayerManager player)
    {
        AccesComputer();
    }
}
