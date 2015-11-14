using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    private Vector3 player = Vector3.zero;

    void Update()
    {
        PerformMove();
    }

    public void Move(Vector3 _player)
    {
        player = _player;
    }

    private void PerformMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
    }
}
