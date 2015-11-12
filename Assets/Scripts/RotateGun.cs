using UnityEngine;
using System.Collections;

public class RotateGun : MonoBehaviour {

    private float rotateSpeed = 25f;

	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            transform.Rotate(Vector3.up, rotateSpeed * 360 * Time.deltaTime);
	}
}
