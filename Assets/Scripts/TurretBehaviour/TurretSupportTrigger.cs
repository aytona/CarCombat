using UnityEngine;
using System.Collections;

public class TurretSupportTrigger : MonoBehaviour {

    //public GameObject[] objectToTrigger;

    //void OnEnable()
    //{
    //    for (int i = 0; i < objectToTrigger.Length; i++)
    //        objectToTrigger[i].SetActive(true);
    //}

    //void OnDisable()
    //{
    //    for (int i = 0; i < objectToTrigger.Length; i++)
    //        objectToTrigger[i].SetActive(false);
    //}

    public GameObject triggerObjects;
    public bool trigger;

    private TurretDeath deathScript;

    void Start()
    {
        deathScript = GetComponent<TurretDeath>();
    }

    void Update()
    {
        if (deathScript.isDead)
        {
            triggerObjects.SetActive(trigger);
        }
    }
}
