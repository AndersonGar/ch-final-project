using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Canvas HUD, FireEffect;
    public GameObject meteorEffect, lightTopView;
    Camera camera;
    bool allowChangeCamera;
    public static event Action<bool> onChangingCamera;
    // Start is called before the first frame update
    void Start()
    {
        allowChangeCamera = true;
        camera = GetComponent<Camera>();
        MenuManager.onPausingOrResuming += AllowChange;
    }
    private void OnDisable()
    {
        MenuManager.onPausingOrResuming -= AllowChange;
    }
    // Update is called once per frame
    void Update()
    {
        if (allowChangeCamera)
        {
            CameraChange();
        }
        
    }

    void AllowChange(bool value)
    {
        allowChangeCamera = value;
        if (!value && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Stop();
            HUD.enabled = value;
        }
        else if(GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Play();
            if (camera.targetDisplay > 0)
            {
                HUD.enabled = value;
            }
        }
    }

    void CameraChange()
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
                    lightTopView.SetActive(true);
                    meteorEffect.SetActive(true);
                }
                else
                {
                    GetComponent<AudioSource>().Stop();
                    HUD.enabled = true;
                    FireEffect.enabled = true;
                    meteorEffect.SetActive(false);
                    lightTopView.SetActive(false);
                }
                if (onChangingCamera != null)
                {
                    onChangingCamera(!meteorEffect.activeSelf);
                }
            }
        }
    }



}
