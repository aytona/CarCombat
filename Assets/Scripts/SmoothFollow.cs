using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float distance = 6f;
    public float height = 3f;
    public float damping = 2f;
    public float rotationDamping = 10f;

    void Update()
    {
        Vector3 followPosition;
        followPosition = target.TransformPoint(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.fixedDeltaTime * damping);
        Quaternion followRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, followRotation, Time.fixedDeltaTime * rotationDamping);
    }
}
