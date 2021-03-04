using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight = 100;
    public Transform directionSetter;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;
            //Debug.DrawLine(directionSetter.position, directionSetter.position+directionSetter.forward * 2f, Color.red, 1f);
            if (Physics.SphereCast(directionSetter.position, 0.1f, directionSetter.forward, out hit, 2))
            {
                //Debug.Log(hit.collider.gameObject.name);
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    i.Action(this);
                }
            }
        }

        //Temporary code to test dropping
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropItem("Key of Doom");
        }
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);

        if (i != null)
        {
            inventory.RemoveItem(i);
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
        }
        GameManager.Instance.TriggerInventoryUIUpdate();
    }

    public bool AddItem(Item i )
    {
        return inventory.AddItem(i);
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            IInteractable i = hit.gameObject.GetComponent<IInteractable>();
            i.Action(this);
        }
    }
    public bool CanOpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
    }

    public string[] GetItemNames()
    {
        return inventory.GetItemNames();
    }
}
