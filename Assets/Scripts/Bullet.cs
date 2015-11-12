using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private float force;
    private Rigidbody rb;

    void Start()
    {
        Vector3 appliedForce = Vector3.forward * force;
        rb.AddForce(appliedForce, ForceMode.Acceleration);
    }
}
