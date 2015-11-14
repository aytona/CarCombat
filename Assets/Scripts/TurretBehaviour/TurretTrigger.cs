using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TurretLookAt))]
[RequireComponent(typeof(TurretIdle))]
[RequireComponent(typeof(TurretAttack))]
[RequireComponent(typeof(TurretPulse))]
public class TurretTrigger : MonoBehaviour {

    [SerializeField]
    private TurretLookAt lookAt;
    [SerializeField]
    private TurretIdle idle;
    [SerializeField]
    private TurretAttack attack;
    [SerializeField]
    private TurretPulse pulse;

    public bool isMissile;

    void Start()
    {
        lookAt = GetComponent<TurretLookAt>();
        idle = GetComponent<TurretIdle>();
        attack = GetComponent<TurretAttack>();
        pulse = GetComponent<TurretPulse>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isMissile)
            {
                attack.enabled = true;
                lookAt.enabled = true;
                idle.enabled = false;
            }
            else if (!isMissile)
                pulse.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            lookAt.enabled = false;
            attack.enabled = false;
            pulse.enabled = false;
            idle.enabled = true;
        }
    }
}
