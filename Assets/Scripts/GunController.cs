using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    [SerializeField]
    private float mouseSensitivity = 3f;
    [SerializeField]
    private float xLimit = 20f;
    [SerializeField]
    private float yLimit = 15f;

    private float xCurrent = 0f;
    private float yCurrent = 0f;

    void Update()
    {
        float xRotation = Input.GetAxisRaw("Mouse X");
        float yRotation = Input.GetAxisRaw("Mouse Y");
        PerformRotation(xRotation, yRotation);
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
