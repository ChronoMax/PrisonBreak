using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();

        //TestCreateItem();
        TestInventory();
    }

    public void TestCreateItem()
    {
        Debug.Log("============== Testing creation of items =============");
        Item i = new AccesItem("Key of doom", 10, 1);
        DebugItem(i);

        Item j = new BonusItem("Potato of the gods", 2, 100);
        DebugItem(j);
    }

    private void TestInventory()
    {
        Debug.Log("============== Testing inventory functionality =============");
        Item i = new AccessItem("Key of doom", 10, 1);
        Item j = new BonusItem("Potato of the gods", 50, 50);
        Item k = new BonusItem("Globe of eternal sunshine", 50, 100);

        if (inventory.AddItem(i))
        {
            Debug.Log("Added " + i.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + i.GetName() + " to the inventory");
        }

        if (inventory.AddItem(j))
        {
            Debug.Log("Added " + j.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + j.GetName() + " to the inventory");
        }

        if (inventory.AddItem(k))
        {
            Debug.Log("Added " + k.GetName() + " to the inventory");
        }
        else
        {
            Debug.Log("Failed to add " + k.GetName() + " to the inventory");
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
