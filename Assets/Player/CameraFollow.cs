using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (GameManager.player.transform.position.x, GameManager.player.transform.position.y, -10f) ;
    }
}
