using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestCreateItem();
    }

    public void TestCreateItem()
    {
        Item i = new AccesItem("Key", 10, 1);
        DebugItem(i);

        Item j = new BonusItem("potato of the gods", 2, 100);
        DebugItem(j);
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
