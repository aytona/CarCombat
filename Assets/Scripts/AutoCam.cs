using UnityEngine;
using System.Collections;

public class AutoCam : CameraRig {

    [SerializeField]
    private float _MoveSpeed = 3f;
    [SerializeField]
    private float _TurnSpeed = 1f;
    [SerializeField]
    private float _RollSpeed = 0.2f;
    [SerializeField]
    private float _SpinTurnLimit = 90f;
    [SerializeField]
    private float _TargetVelocityLowerLimit = 4f;
    [SerializeField]
    private float _SmoothTurnTime = 0.2f;
    [SerializeField]
    private bool _FollowVelocity = false;
    [SerializeField]
    private bool _FollowTilt = true;

    private float _LastFlatAngle;
    private float _CurrentTurnAmount;
    private float _TurnSpeedVelocityChange;
    private Vector3 _RollUp = Vector3.up;

    protected override void FollowTarget(float deltaTime)
    {
        if (!(deltaTime > 0) || _Target == null)
            return;
        var targetForward = _Target.forward;
        var targetUp = _Target.up;
        if(_FollowVelocity && Application.isPlaying)
        {
            if (rb.velocity.magnitude > _TargetVelocityLowerLimit)
            {
                targetForward = rb.velocity.normalized;
                targetUp = Vector3.up;
            }
            else
                targetUp = Vector3.up;
            _CurrentTurnAmount = Mathf.SmoothDamp(_CurrentTurnAmount, 1, ref _TurnSpeedVelocityChange, _SmoothTurnTime);
        }
        else
        {
            var currentFlatAngle = Mathf.Atan2(targetForward.x, targetForward.z) * Mathf.Rad2Deg;
            if (_SpinTurnLimit > 0)
            {
                var targetSpinSpeed = Mathf.Abs(Mathf.DeltaAngle(_LastFlatAngle, currentFlatAngle)) / deltaTime;
                var desiredTurnAmount = Mathf.InverseLerp(_SpinTurnLimit, _SpinTurnLimit * 0.75f, targetSpinSpeed);
                var turnReactSpeed = (_CurrentTurnAmount > desiredTurnAmount ? .1f : 1f);
                if (Application.isPlaying)
                    _CurrentTurnAmount = Mathf.SmoothDamp(_CurrentTurnAmount, desiredTurnAmount, ref _TurnSpeedVelocityChange, turnReactSpeed);
                else
                    _CurrentTurnAmount = desiredTurnAmount;
            }
            else
                _CurrentTurnAmount = 1;
            _LastFlatAngle = currentFlatAngle;
        }
        transform.position = Vector3.Lerp(transform.position, _Target.position, deltaTime * _MoveSpeed);
        if (!_FollowTilt)
        {
            targetForward.y = 0;
            if (targetForward.sqrMagnitude < float.Epsilon)
                targetForward = transform.forward;
        }
        var rollRotation = Quaternion.LookRotation(targetForward, _RollUp);
        _RollUp = _RollSpeed > 0 ? Vector3.Slerp(_RollUp, targetUp, _RollSpeed * deltaTime) : Vector3.up;
        transform.rotation = Quaternion.Lerp(transform.rotation, rollRotation, _TurnSpeed * _CurrentTurnAmount * deltaTime);
    }
}
