using UnityEngine;
using System.Collections;

public class TurretDeath : MonoBehaviour {

    public bool isSupport;

    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject objectAfterDeath;

    private float length;
    private TurretSupportTrigger support;

	void Start()
    {
        support = GetComponent<TurretSupportTrigger>();
        StartCoroutine(DeathAnim(length));
    }

    private IEnumerator DeathAnim(float delay)
    {
        Instantiate(explosion, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        if (isSupport)
            support.enabled = true;
    }
}
