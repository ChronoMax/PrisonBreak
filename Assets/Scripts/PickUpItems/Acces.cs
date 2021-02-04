using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acces : Pickup
{
    public int doorId;

    public override Item CreateItem()
    {
        return new AccesItem(name, weight, doorId);
    }
}
