using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
