using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController: MonoBehaviour
{

    public GameObject target;
    public float offsetY;

    // Use this for initialization
    void Start()
    {
        
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, -10);
        
    }
}
