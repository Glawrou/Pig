using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if(target != null) transform.position = new Vector3(target.position.x / 2, target.transform.position.y / 2, transform.position.z);
    }
}
