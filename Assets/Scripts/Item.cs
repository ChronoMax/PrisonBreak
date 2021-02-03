using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //propeties
    private string name;
    private float weight;

    //constructor
    //the constuctor allows you to create methods
    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }

    //methods
    public string GetName()
    {
        return name;
    }

    public float GetWeight()
    {
        return weight;
    }
}
