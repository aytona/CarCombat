using UnityEngine;
using System.Collections;

public class DestroyExplosionParticle : MonoBehaviour {

    public float duration;

	void Start()
    {
        Destroy(gameObject, duration);
    }
}
