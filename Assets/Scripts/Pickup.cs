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
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Actoin(PlayerManager player)
    {
        if (player.AddItem(CreateItem()))
        {
            Remove();
        }
    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        gameObject.SetActive(false);
    }

    public abstract Item CreateItem();

}
