using UnityEngine;
using System.Collections;

public class RandomPrefabGenerator : MonoBehaviour {

	public GameObject[] prefabArray;

	private Vector3 currentPosition;
	private Quaternion currentRotation;

	void Start()
	{
		GetCurrentTransform();
		GenerateNewObject();
	}

	void GetCurrentTransform()
	{
		currentPosition = this.transform.position;
		currentRotation = this.transform.rotation;
	}

	void GenerateNewObject()
	{
		GameObject newPrefab = Instantiate(prefabArray[Random.Range(0, prefabArray.Length)]) as GameObject;
		newPrefab.transform.position = currentPosition;
		newPrefab.transform.rotation = currentRotation;
	}
}