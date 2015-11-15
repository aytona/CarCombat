using UnityEngine;
using System.Collections;

public class RandomMesh : MonoBehaviour {

    public Mesh[] meshArray;
    public string meshResource;
    public int currentMesh = -1;

    void Start()
    {
        if (meshResource != "")
        {
            meshArray = Resources.LoadAll<Mesh>(meshResource);
            if (currentMesh == -1)
                currentMesh = Random.Range(0, meshArray.Length);
            else if (currentMesh > meshArray.Length)
                currentMesh = meshArray.Length - 1;

            GetComponent<MeshFilter>().mesh = meshArray[currentMesh];
        }
	}
}
