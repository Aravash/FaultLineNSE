using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRot : MonoBehaviour
{
    float heading = 0;
    float tilt = 15;

    void LateUpdate()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        tilt -= Input.GetAxis("Mouse Y") * Time.deltaTime * 180;

        tilt = Mathf.Clamp(tilt, -95, 90);

        transform.rotation = Quaternion.Euler(tilt, heading, 0);
    }
    // using LateUpdate instead of update means camera position 
    // will always change after the player position changes.
    // this avoids potential desync on lower framerates
}
