using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

    [SerializeField]
    private float boostForce;

	void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Rigidbody>().AddForce(-transform.right * boostForce);
    }
}
