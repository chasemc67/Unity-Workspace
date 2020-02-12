using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 2.2f, -5f);
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        // target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // lateUpdate happens after the update frame
    // this is because we want to update our camera after we update our player position
    void LateUpdate()
    {
        // TransformPoint calculates and returns a relative position in world space
        this.transform.position = target.TransformPoint(camOffset);

        // LookAt function rotates the capsule to point to the target
        this.transform.LookAt(target);
    }
}
