using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    public Image view;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnTimelineLimit += ModifyView;
        GameManager.OnResetTime += ResetView;
    }

    private void OnDisable()
    {
        GameManager.OnTimelineLimit -= ModifyView;
        GameManager.OnResetTime -= ResetView;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ModifyView(float real_time,float time_max)
    {
        float time = time_max - real_time;
        float percent = time * 100 / time_max;
        if (percent >= 70)
        {
            percent = 70;
        }
        view.color = new Color(color.r,color.g,color.b,percent/100);
    }

    void ResetView()
    {
        view.color = new Color(color.r, color.g, color.b, color.a);
    }
}
