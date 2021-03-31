using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RaftController : MonoBehaviour
{
    private Camera cam;
    private Animator camera, boat;
    public GameObject BoatObject, playerObject, cameraObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Collider")
        {
            cam = GameObject.Find("AnimationCam").GetComponent<Camera>();
            camera = GameObject.Find("AnimationCam").GetComponent<Animator>();
            boat = GameObject.Find("Row_Boat(Clone)").GetComponent<Animator>();
            BoatObject = GameObject.Find("Row_Boat(Clone)");
            playerObject = GameObject.Find("FPSController");

            cam.enabled = true;
            Destroy(playerObject);
            boat.enabled = true;
            camera.SetBool("AnimationPlay", true);
            boat.SetBool("AnimationPlay", true);
        }
    }
}
