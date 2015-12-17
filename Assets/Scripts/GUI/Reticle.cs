using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

    public Texture2D reticleImage;

    private int reticleWidth, reticleHeight = 100;
    private Transform currentTransform;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        currentTransform = transform;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(currentTransform.position);
        screenPos.y = Screen.height - screenPos.y;
        GUI.DrawTexture(new Rect(screenPos.x, screenPos.y, reticleWidth, reticleHeight), reticleImage);
    }
}
