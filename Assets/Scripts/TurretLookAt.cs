using UnityEngine;
using System.Collections;

public class TurretLookAt : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
