using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        //TestCreateItem();
        TestInventory();
    }

    public void TestCreateItem()
    {
        Item i = new AccesItem("Key", 10, 1);
        DebugItem(i);

        Item j = new BonusItem("potato of the gods", 2, 100);
        DebugItem(j);
    }


    private void TestInventory()
    {
        Item i = new AccesItem("Key of Doom", 10, 1);
        Item j = new BonusItem("potato of the gods", 50, 50);
        Item k = new BonusItem("Globe of eternal sunshine", 50, 100);
        Item h = new PuzzelItem("Riddle01", 5, "When do i say hello?", "When i join the call");

        inventory.AddItem(h);

        if (inventory.AddItem(i))
        {
            Debug.Log("Succes" + i.GetName());
        }
        else
        {
            Debug.Log("Failed" + i.GetName());
        }
        if (inventory.AddItem(j))
        {
            Debug.Log("Succes" + j.GetName());
        }
        else
        {
            Debug.Log("Failed" + j.GetName());
        }
        if (inventory.AddItem(k))
        {
            Debug.Log("Succes" + k.GetName());
        }
        else
        {
            Debug.Log("Failed" + k.GetName());
        }

        inventory.DebugInventory();

        if (inventory.CanOpenDoor(1))
        {
            Debug.Log("Door can be opend");
        }
        else
        {
            Debug.Log("Door cannot be opend");
        }

        if (inventory.CanOpenDoor(2))
        {
            Debug.Log("Door can be opend");
        }
        else
        {
            Debug.Log("Door cannot be opend");
        }

        if (inventory.HasItem(i))
        {
            Debug.Log("Has key of doom");
        }
        else
        {
            Debug.Log("has not key of doom");
        }

        inventory.RemoveItem(i);

        if (inventory.RemoveItem(i))
        {
            Debug.Log("Key removed");
        }
        else
        {
            Debug.Log("key was not removed");
        }

        if (inventory.CanOpenDoor(1))
        {
            Debug.Log("Door can be opend");
        }
        else
        {
            Debug.Log("Door cannot be opend");
        }

        if (inventory.HasItem(i))
        {
            Debug.Log("Has key of doom");
        }
        else
        {
            Debug.Log("has not key of doom");
        }

        TestRiddle(h);
    }

    private void TestRiddle(Item i)
    {
        if (i is PuzzelItem)
        {
            PuzzelItem h = (PuzzelItem)i;
            Debug.Log(h.GetRiddle());
            Debug.Log(h.GetAnwser());
            Debug.Log(h.IsSolved());
            Debug.Log(h.checkAnwser("When i join the call"));
            Debug.Log(h.checkAnwser("number 5 large"));
            Debug.Log(h.IsSolved());
        }
    }

    public void DebugItem(Item i)
    {
        string itemInfo = "The Item: " + (i.GetName()) + " weighs " + i.GetWeight() + " KG";
        string extraInfo = "";
        if (i is AccesItem)
        {
            AccesItem ai = (AccesItem)i;
            extraInfo = " and opens door: " + ai.GetDoorId();
        }
        else if (i is BonusItem)
        {
            BonusItem bi = (BonusItem)i;
            extraInfo = " and gives you: " + bi.GetPoints() + " points";
        }
        Debug.Log( itemInfo + extraInfo);
    }
}
