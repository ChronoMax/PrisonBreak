using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight = 100;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item i )
    {
        return inventory.AddItem(i);
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            Iinteractable i = hit.gameObject.GetComponent<Iinteractable>();
            i.Actoin(this);
        }
    }
}
