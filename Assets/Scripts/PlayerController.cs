using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float angle;
    private float maxSpeed = 10;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, 0, -angle * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, 0, angle * Time.deltaTime);
        if (speed < maxSpeed && (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow))))
            speed++;
        else if (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && speed > 0)
            speed--;
    }
}
