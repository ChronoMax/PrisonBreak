using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, Iinteractable
{
    public string name;
    public float weight;

    private void Start()
    {
        gameObject.tag = "Pickup";
    }

    public void Actoin(PlayerManager player)
    {
        player.AddItem(CreateItem());
        Destroy(gameObject);
    }

    public abstract Item CreateItem();

}
