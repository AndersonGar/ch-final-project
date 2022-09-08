using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Canvas HUD, FireEffect;
    public GameObject meteorEffect;
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
            if (GetComponent<AudioSource>())
            {
                if (camera.targetDisplay == 0)
                {

                    GetComponent<AudioSource>().Play();
                    HUD.enabled = false;
                    FireEffect.enabled = false;
                    meteorEffect.SetActive(true);
                }
                else
                {
                    GetComponent<AudioSource>().Stop();
                    HUD.enabled = true;
                    FireEffect.enabled = true;
                    meteorEffect.SetActive(false);
                }
            }
        }
    }

    



}
