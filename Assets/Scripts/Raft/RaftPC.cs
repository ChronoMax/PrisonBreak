using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class RaftPC : MonoBehaviour, IInteractable
{
    public GameObject raftPCUI, raftPrefab;
    public Transform spawnpoint;
    public int CountOfLogs;
    public Text Count, CountUI;
    

    public void AccesComputer()
    {
        FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        raftPCUI.gameObject.SetActive(!raftPCUI.gameObject.activeSelf);
        if (raftPCUI.gameObject.activeSelf)
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

    public void UpdateText()
    {
        CountOfLogs++;
        Count.text = CountOfLogs.ToString() + "/4";
        CountUI.text = CountOfLogs.ToString() + "/4";
    }

    public void OnClickCraftBoat()
    {
        if (CountOfLogs == 4 && CountOfLogs !<= 4)
        {
            Instantiate(raftPrefab, spawnpoint);
            CountOfLogs = 0;
        }

    }

    public void Action(PlayerManager player)
    {
        AccesComputer();
    }
}
