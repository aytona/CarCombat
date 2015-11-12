using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TurretLookAt))]
[RequireComponent(typeof(TurretIdle))]
public class TurretTrigger : MonoBehaviour {

    [SerializeField]
    private TurretLookAt lookAt;
    [SerializeField]
    private TurretIdle idle;

    void Start()
    {
        lookAt = GetComponent<TurretLookAt>();
        idle = GetComponent<TurretIdle>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lookAt.enabled = true;
            idle.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            lookAt.enabled = false;
            idle.enabled = true;
        }
    }
}
