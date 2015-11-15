using UnityEngine;
using System.Collections;

public class Unflip : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.transform.rotation = Quaternion.identity;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
