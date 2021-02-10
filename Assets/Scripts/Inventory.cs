using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;
    private float weight;
    private float maximumWeight;

    public Inventory()
    {
        items = new List<Item>();
        weight = 0;
        maximumWeight = 100;
    }

    public Inventory(float maxiumweight) : this()
    {
        this.maximumWeight = maxiumweight;
    }

    public bool Setmaximumweight(float maxWeight)
    {
        if (maxWeight >= weight)
        {
            maximumWeight = maxWeight;
            return true;
        }

        return false;
    }

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

    public Item GetItemWithName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[])
            {

            }
        }
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
        Debug.Log("Inventory has " + Count() + " Items");
        Debug.Log("totalWeight is " + GetCurrentWeight());

        foreach (Item item in items)
        {
            Debug.Log("");
        }
    }
}
