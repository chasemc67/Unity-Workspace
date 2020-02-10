using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        // if we use the Unity editor to populate this, then it should log here
        if (camTransform) {
            Debug.Log(camTransform.localPosition);
        }
        // can use getComponent to get other components on this game object
        // this works because the script is attached to a game object
        // which also has a transform component
        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);

        // if you want to get a compponent from va different game object,
        // you have to use the find method
        camTransform = GameObject.Find("Directional Light").GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
