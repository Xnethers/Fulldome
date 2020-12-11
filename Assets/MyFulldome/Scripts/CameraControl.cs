using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public Transform[] cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraPosition(int p)
    {
        mainCamera.transform.position = cameraPosition[p].position;
    }
}
