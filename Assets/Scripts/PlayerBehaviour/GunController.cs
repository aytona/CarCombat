using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    [Header("Spawner:")]
    [SerializeField]
    private Transform spawner1;
    [SerializeField]
    private Transform spawner2;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float mouseSensitivity = 3f;
    [SerializeField]
    private float xLimit = 20f;
    [SerializeField]
    private float yLimit = 15f;

    private float xCurrent = 0f;
    private float yCurrent = 0f;
    private float speed = 3f;
    private float lifeSpan = 10f;

    void Update()
    {
        float xRotation = Input.GetAxisRaw("Mouse X");
        float yRotation = Input.GetAxisRaw("Mouse Y");
        PerformRotation(xRotation, yRotation);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet1 = Instantiate(bullet, spawner1.position, Quaternion.identity) as GameObject;
            GameObject bullet2 = Instantiate(bullet, spawner2.position, Quaternion.identity) as GameObject;
            bullet1.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0f, -speed, 0f));
            bullet2.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0f, -speed, 0f));
            Destroy(bullet1, lifeSpan);
            Destroy(bullet2, lifeSpan);
        }
    }

    private void PerformRotation(float xInput, float yInput)
    {
        float xGunRot = xInput * mouseSensitivity;
        xCurrent -= xGunRot;
        xCurrent = Mathf.Clamp(xCurrent, -xLimit, xLimit);
        float yGunRot = yInput * mouseSensitivity;
        yCurrent -= yGunRot;
        yCurrent = Mathf.Clamp(yCurrent, -yLimit, yLimit);

        transform.localEulerAngles = new Vector3(yCurrent, 0f, xCurrent);
    }

}
