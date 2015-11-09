using UnityEngine;
using System.Collections;

public abstract class CameraRig : TargetFollower {

    protected Transform _Cam;
    protected Transform _Pivot;
    protected Vector3 _LastTargetPosition;

    protected virtual void Awake()
    {
        _Cam = GetComponent<Camera>().transform;
        _Pivot = _Cam.parent;
    }
}
