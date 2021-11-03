using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    //Assign player for transform component
    public Transform player;

    //Updates once per frame for fixed frame rate
    void FixedUpdate()
    {
        //Moves camera postition with the same position as the player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
