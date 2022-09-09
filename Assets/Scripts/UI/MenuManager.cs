using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Canvas canvas;
    public MenuBehaviour menuBehaviour;
    bool pause;
    public Text progress, press;
    int mazeProgress;
    public static event Action<bool> onPausingOrResuming;
    public enum MenuBehaviour
    {
        MainMenu,
        PauseMenu
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        pause = false;
        if (!PlayerPrefs.HasKey("mazes_completed"))
        {
            PlayerPrefs.SetInt("mazes_completed",0);
            PlayerPrefs.Save();
        }
        mazeProgress = PlayerPrefs.GetInt("mazes_completed");
        TextSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape))
        {
            PressSpace();
        }
    }


    void TextSetup()
    {
        switch (menuBehaviour)
        {
            case MenuBehaviour.MainMenu:
                progress.text = mazeProgress + " de 2 laberintos";
                press.text = "PRESIONA F PARA EMPEZAR";
                break;
            case MenuBehaviour.PauseMenu:
                progress.text = "Laberinto "+(mazeProgress+1);
                press.text = "PRESIONA ESCAPE PARA REANUDAR";
                break;
            default:
                break;
        }
    }

    void PressSpace()
    {
        switch (menuBehaviour)
        {
            case MenuBehaviour.MainMenu:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuBehaviour.PauseMenu:
                pause = !pause;
                canvas.enabled = pause;
                if (pause)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
                if (onPausingOrResuming!=null)
                {
                    onPausingOrResuming(!pause);
                }
                break;
            default:
                break;
        }
    }
}
