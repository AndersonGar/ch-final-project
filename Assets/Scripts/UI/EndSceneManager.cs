using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public static bool win;
    public Text title, caption;
    // Start is called before the first frame update
    void Start()
    {
        ResultGame();
    }

    void ResultGame()
    {
        if (win)
        {
            title.text = "GANASTE";
            caption.text = "FELICIDADES, PERO ESTO SOLO ES EL COMIENZO";
        }
        else
        {
            title.text = "PERDISTE";
            caption.text = "FELIZMENTE ES UN JUEGO, PUEDES VOLVER A INTENTARLO";
            PlayerPrefs.SetInt("mazes_completed", 0);
            PlayerPrefs.Save();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(0);
        }
    }
}
