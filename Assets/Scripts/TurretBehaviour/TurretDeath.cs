using UnityEngine;
using System.Collections;

public class TurretDeath : MonoBehaviour {

    public bool isSupport;

    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject objectAfterDeath;
    [SerializeField]
    private TurretSupportTrigger support;

    public float length;
    public bool isDead;

    private bool supportToggle;

	void Start()
    {
        if (isSupport)
        {
            support = GetComponent<TurretSupportTrigger>();
            supportToggle = support.enabled;
        }
        StartCoroutine(DeathAnim(length));
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

    private IEnumerator DeathAnim(float delay)
    {
        Instantiate(explosion, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        if (isSupport)
            support.enabled = !supportToggle;
    }
}
