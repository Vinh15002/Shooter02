using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    Transform transformtarget;

    private void FixedUpdate() {
        transformtarget = PlayerMovement.instance.transform;
        transform.position = new Vector3(transformtarget.position.x, transformtarget.position.y, -10f);
        
    }
}
