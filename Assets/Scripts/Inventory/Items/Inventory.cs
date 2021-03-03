using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private float weight = 0;
    public float maximumWeight;

    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= maximumWeight)
        {
            items.Add(i);
            weight += i.GetWeight();
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool RemoveItem(Item i)
    {
        bool succes = items.Remove(i);
        if (succes)
        {
            weight -= i.GetWeight();
        }

        return succes;
    }

    public bool HasItem(Item i)
    {
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if (item is AccesItem)
            {
                if (((AccesItem) item).OpensDoor(id))
                {
                    result = true;
                }
            }            
        }
        return result;
    }

    public int Count()
    {
        return items.Count;
    }

    public float GetCurrentWeight()
    {
        float currentWeight = weight;

        return currentWeight;
    }

    public void DebugInventory()
    {
        Debug.Log("Inventory has " + Count() + " items");
        Debug.Log("Total weight: " + GetCurrentWeight());

        foreach (Item item in items)
        {
            Debug.Log(item.GetName() + "-----" + item.GetWeight() + "Kg");
        }
    }
}
