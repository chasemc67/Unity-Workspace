using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float vInput;
    private float hInput;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        /*
        // this sort of movement is generally used in kinematic movement
        // where the moving entity is not part of the physics 
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }


    // apparently any rigidBody code always goes inside FixedUpdate instead of update
    // this is because FixedUpdate is part of the physics step, 
    // and update is part of the game logic steps, which happens after all the physics is done
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        // need a Quaternion instead of a Vector3 to pass to MoveRotation
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // addForce and AddTorque can be used instead of MovePosition and MoveRotation
        // but MovePosition is higher level function, which uses addForce underneath and also takes some edge cases into account
        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);    
    }
}
