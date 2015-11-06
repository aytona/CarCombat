using UnityEngine;
using System.Collections;

public class Unflip : MonoBehaviour {

    private Quaternion initialRotation;
    private bool onGround;
    void Start()
    {
        initialRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (transform.rotation.z >= 180 && transform.rotation.z < 360 && onGround)
            transform.rotation = initialRotation;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
            onGround = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            onGround = false;
    }
}
