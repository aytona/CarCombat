using UnityEngine;
using System.Collections;

public abstract class TargetFollower : MonoBehaviour {

    [SerializeField]
    protected Transform _Target;
    [SerializeField]
    private bool _AutoTargetPlayer = true;
    [SerializeField]
    private UpdateType _UpdateType;

    protected Rigidbody rb;

	public enum UpdateType
    {
        FixedUpdate,
        LateUpdate,
        ManualUpdate
    }

    protected virtual void Start()
    {
        if (_AutoTargetPlayer)
            FindAndTargetPlayer();
        if (_Target == null)
            return;
        rb = _Target.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_AutoTargetPlayer && (_Target == null || !_Target.gameObject.activeSelf))
            FindAndTargetPlayer();
        if (_UpdateType == UpdateType.FixedUpdate)
            FollowTarget(Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (_AutoTargetPlayer && (_Target == null || !_Target.gameObject.activeSelf))
            FindAndTargetPlayer();
        if (_UpdateType == UpdateType.LateUpdate)
            FollowTarget(Time.deltaTime);
    }

    private void ManualUpdate()
    {
        if (_AutoTargetPlayer && (_Target == null || !_Target.gameObject.activeSelf))
            FindAndTargetPlayer();
        if (_UpdateType == UpdateType.ManualUpdate)
            FollowTarget(Time.deltaTime);
    }

    protected abstract void FollowTarget(float deltaTime);

    public void FindAndTargetPlayer()
    {
        var targetObj = GameObject.FindGameObjectWithTag("Player");
        if (targetObj)
            SetTarget(targetObj.transform);
    }

    public virtual void SetTarget(Transform newTransform)
    {
        _Target = newTransform;
    }

    public Transform Target
    {
        get { return _Target; }
    }
}
