using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (camera.targetDisplay > 0)
            {
                camera.targetDisplay = 0;
            }
            else
            {
                camera.targetDisplay = 1;
            }
        }
    }

    



}
