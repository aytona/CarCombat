using UnityEngine;
using System.Collections;

public class TurretPulse : MonoBehaviour {

    [SerializeField]
    private float rateOfFire = 2f;
    [SerializeField]
    private float lifeSpan = 2.5f;
    [SerializeField]
    private GameObject particleEffect = null;

    void Start()
    {
        StartCoroutine(PulseCoroutine(rateOfFire));
    }

    private void BombPulse()
    {
        GameObject bombPulse = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(bombPulse, lifeSpan);
    }

    private IEnumerator PulseCoroutine(float delay)
    {
        while(true)
        {
            BombPulse();
            yield return new WaitForSeconds(delay);
            if (!this.isActiveAndEnabled)
                break;
        }
    }
}
