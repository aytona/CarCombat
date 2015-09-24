using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObjectsInArea : MonoBehaviour {

	public Transform startPosition;
	public Transform endPosition;
	public float length;
	public GameObject[] prefabArray;

	private List<Vector3> pointsArray;
	private Vector3 point;
	private float distanceBetween;
	private float pointCounter;

	void Start()
	{
		pointsArray = new List<Vector3>();
		distanceBetween += Vector3.Distance(startPosition.transform.position, endPosition.transform.position);

		while (pointCounter < distanceBetween)
		{
			point += new Vector3(0, 0, length);
			pointsArray.Add(point);
			pointCounter += length;
		}

		for (int i = 0; i < pointsArray.Count; i++)
		{
			Instantiate(prefabArray[Random.Range(0, prefabArray.Length)], (Vector3)pointsArray[i] + startPosition.position, startPosition.transform.rotation);
		}
	}
}
