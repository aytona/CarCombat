using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject explosion;

    private float speed = 20f;
    private float lifeSpan = 3f;
    
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    //void Update()
    //{
    //    transform.position += transform.forward * speed * Time.deltaTime;
    //}

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //private IEnumerator LifeSpanCoroutine()
    //{
    //    yield return WaitForSeconds(3);
    //}
}