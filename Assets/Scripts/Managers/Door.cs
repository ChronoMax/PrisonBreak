using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int id;
    public bool open = false;
    private float initialRotation;
    public Animator cellDoorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
        initialRotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            cellDoorAnimator.SetBool("Close", false);
            cellDoorAnimator.SetBool("Open", true);
        }
        else if (!open)
        {
            cellDoorAnimator.SetBool("Open", false);
            cellDoorAnimator.SetBool("Close", true);
        }
    }

    public void Open()
    {
        open = !open;
    }

    public void Action(PlayerManager player)
    {
        if (player.CanOpenDoor(id))
        {
            Open();
        }
    }
}
