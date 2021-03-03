using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour
{
    public InventoryUI inventoryUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InventoryButton"))
        {
            TroggleInventory();
        }
    }

    void TroggleInventory()
    {
        FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        if (inventoryUI.gameObject.activeSelf)
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

    public void UpdateInventoryUI()
    {
        inventoryUI.UpdateUI();
    }
}
