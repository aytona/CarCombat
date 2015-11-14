using UnityEngine;
using System.Collections;

public class TurretIdle : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.1f;

    void Update()
    {
        transform.Rotate(transform.up, speed * 360 * Time.deltaTime);
    }

}
