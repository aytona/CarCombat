using UnityEngine;
using System.Collections;

public class PlayerExplode : MonoBehaviour {

    public GameObject explosion;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update()
    {
        if (GameManager.Instance.LoseCondition)
        {
            Instantiate(explosion, player.transform.position, Quaternion.identity);
        }
    }
}
