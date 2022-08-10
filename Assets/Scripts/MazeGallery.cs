using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeGallery : MonoBehaviour
{
    [SerializeField]
    public List<ScriptableObjectExample> mazeList;
    public Text name;
    public Image photo;
    public int timer;
    float time;
    int indexNow = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = timer;
        ShowMaze(indexNow);
        //Inheritance example
        MazeParent maze1 = new MazeParent();
        maze1.Pickups_count = 4;
        maze1.Level = 1;
        maze1.OpenMaze();

        HardMaze maze2 = new HardMaze();
        maze2.Pickups_count = 6;
        maze2.Level = 5;
        maze2.OpenMaze();
        maze2.EnemiesOn();
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void ShowMaze(int index)
    {
        name.text = "Maze " + mazeList[index].level.ToString();
        photo.sprite = mazeList[index].mazeImage;
    }

    void Timer()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            indexNow++;
            if (indexNow == mazeList.Count)
            {
                indexNow = 0;
            }
            ShowMaze(indexNow);
            time = timer;
        }
    }
}
