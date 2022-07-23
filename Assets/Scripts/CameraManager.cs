using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager cameraManager;

    //Variables de camaras
    public Camera playerCamera;
    bool posChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (posChanging)
        {
            
        }
    }

    public static void ChangeUbication(Vector3 position)
    {
        cameraManager.MoveTo(position);
    }

    public void MoveTo(Vector3 position)
    {
        //Transform camera = cameraManager.playerCamera.transform;
        //camera.position = Vector3.MoveTowards(camera.position,position,5f);
    }


}
