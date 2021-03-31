using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIManager ui;
    public Camera camera;

    Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();

    public void Start()
    {
        camera.enabled = false;
    }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPickupItem(Pickup i)
    {
        if (!worldItems.ContainsKey(i.name))
        {
            worldItems.Add(i.name, i);
        }
        else
        {
            Debug.LogError("There is already a object with the name: " + i.name + "There cannot be a item with the same name!");
        }
    }

    public void DropItem(string name, Vector3 position)
    {
        worldItems[name].Respawn(position);
    }

    public Pickup GetPickupWithName(string name)
    {
        return worldItems[name];
    }

    public void TriggerInventoryUIUpdate()
    {
        ui.UpdateInventoryUI();
    }
}
