using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float distance;
    public float height;
    public float damping;
    public float rotationDamping;

    void Update()
    {
        Vector3 followPosition;
        followPosition = target.TransformPoint(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.fixedDeltaTime * damping);
        Quaternion followRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, followRotation, Time.fixedDeltaTime * rotationDamping);
    }
}
