using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObjectsInArea : MonoBehaviour {

	public Transform startPosition;
	public Transform endPosition;
	public float length;
	public string axis;
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
			// TODO: There has to be a better way to determine which axis the point should generate to
			// HINT: Vector3.Normalize ?
			if (axis == "x")
				point += new Vector3(length, 0, 0);
			else if (axis == "y")
				point += new Vector3(0, length, 0);
			else if (axis == "z")
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
