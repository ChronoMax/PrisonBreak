using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Item i = new Item("Key", 10);

        Debug.Log("The name of the item is: " + (i.GetName()) + "weighs" + i.GetWeight() + " KG");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
