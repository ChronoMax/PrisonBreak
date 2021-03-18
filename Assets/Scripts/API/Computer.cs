using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Computer : MonoBehaviour, IInteractable
{
    public GameObject loginUI, computerUI, commandScreen;
    public Button OpenButton;
    public InputField codeField;
    public static string emailText;
    public Text emailTextHolder, infoText;
    public Animator doorAnimator;
    private int secondsToWait = 5;

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
            StartCoroutine(startNewScreen(secondsToWait));
        });
    }

    public static void ReceviedEmailHandller(string emailRecieved)
    {
        emailText = emailRecieved;
    }

    private IEnumerator startNewScreen(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ConsoleScreen();
        yield return waitTime;
    }

    private void ConsoleScreen()
    {
        emailTextHolder.text = emailText;
        loginUI.SetActive(false);
        commandScreen.SetActive(true);

        switch (emailText)
        {
            case "slprisonbreakassignment@gmail.com":
                OpenButton.interactable = true;
                break;
            default:
                OpenButton.interactable = false;
                infoText.color = Color.red;
                infoText.text = "unauthorized login detected";
                break;
        }
    }

    public void OnClickOpenDoor()
    {
        Debug.Log("open button clicked");
        doorAnimator.SetBool("play", true);
    }

    public void Action(PlayerManager player)
    {
        AccesComputer();
    }
}
