using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TurretIdle))]
[RequireComponent(typeof(TurretAttack))]
[RequireComponent(typeof(TurretPulse))]
[RequireComponent(typeof(TurretDeath))]
public class TurretTrigger : MonoBehaviour {

    [SerializeField]
    private TurretLookAt lookAt;
    [SerializeField]
    private TurretIdle idle;
    [SerializeField]
    private TurretAttack attack;
    [SerializeField]
    private TurretPulse pulse;
    [SerializeField]
    private TurretDeath death;

    public bool isMissile;

    void Start()
    {
        lookAt = GetComponent<TurretLookAt>();
        idle = GetComponent<TurretIdle>();
        attack = GetComponent<TurretAttack>();
        pulse = GetComponent<TurretPulse>();
        death = GetComponent<TurretDeath>();
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
        if (other.tag == "Bullet")
        {
            death.enabled = true;
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
