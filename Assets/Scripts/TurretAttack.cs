using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    [SerializeField]
    private float rateOfFire = 3f;
    [SerializeField]
    private float lifeSpan = 5f;
    [SerializeField]
    private Transform projectileSpawner = null;
    [SerializeField]
    private GameObject bullet = null;

    private TurretBullet bulletScript;

	void Start () 
    {
        StartCoroutine(ShootCoroutine(rateOfFire));
	}

    private void Shoot()
    {
        GameObject bulletAttack = Instantiate(bullet, projectileSpawner.position, Quaternion.identity) as GameObject;
        bulletScript = bulletAttack.GetComponent<TurretBullet>();
        Vector3 _player = GameObject.FindGameObjectWithTag("Player").transform.position;
        bulletScript.Move(_player);
        Destroy(bulletAttack, lifeSpan);
    }

    private IEnumerator ShootCoroutine(float delay)
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(delay);
            if (!this.isActiveAndEnabled)
                break;
        }
    }
}
