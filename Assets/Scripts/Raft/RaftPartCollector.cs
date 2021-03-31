using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPartCollector : MonoBehaviour
{
    private RaftPC raftPC;

    private void Start()
    {
        raftPC = GameObject.Find("RaftCrafter").GetComponent<RaftPC>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RaftPiece_1" || collision.gameObject.name == "RaftPiece_2" || collision.gameObject.name == "RaftPiece_3" || collision.gameObject.name == "RaftPiece_4")
        {
            Destroy(collision.gameObject);
            raftPC.UpdateText();
        }
    }
}
