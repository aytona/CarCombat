using UnityEngine;
using System.Collections;

public class TurretBarrier : MonoBehaviour {

    public GameObject[] barriers;

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float barrierCooldDown = 3f;

    private bool toggle = true;

    void Start()
    {
        StartCoroutine(ToggleBarrier(barrierCooldDown));
    }

    void Update()
    {
        transform.Rotate(transform.up, speed * 360 * Time.deltaTime);
    }

    private IEnumerator ToggleBarrier(float delay)
    {
        while (true)
        {
            foreach (GameObject barrier in barriers)
            {
                barrier.SetActive(toggle);
            }
            yield return new WaitForSeconds(delay);
            toggle = !toggle;
        }
    }
}
