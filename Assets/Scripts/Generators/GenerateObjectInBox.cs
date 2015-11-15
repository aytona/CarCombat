using UnityEngine;
using System.Collections;

public class GenerateObjectInBox : MonoBehaviour {

	public int density;
	public float yLength;
	public GameObject[] objectArray;
	
	void Start()
	{
		for(int i = 0; i < density; i++)
		{
			Vector3 randPosition;
			randPosition = new Vector3(Random.Range (-1f, 1f), 0f, Random.Range(-1f, 1f));
			randPosition = transform.TransformPoint(randPosition * 0.5f);
			Instantiate(objectArray[Random.Range(0, objectArray.Length)], new Vector3(randPosition.x, yLength, randPosition.z), Quaternion.Euler(-90f, Random.Range(0f, 360f), 0f)); 
		}
	}
}
