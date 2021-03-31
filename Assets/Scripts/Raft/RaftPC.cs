using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class RaftPC : MonoBehaviour, IInteractable
{
    public GameObject raftPCUI;
    public int CountOfLogs;

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

    public void AddCount()
    {

    }

    public void OnClickCraftBoat()
    {
        //spawnboat at pos.
    }

    public void Action(PlayerManager player)
    {
        AccesComputer();
    }
}
