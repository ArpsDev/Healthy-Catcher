using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
using System;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    [Header("Time Values")]
    [Range(0, 60)]
    public int seconds;
    [Range(0, 60)]
    public int minutes;

    public Color fontcolour;

    private float currentseconds;
    private int timerdefault;

    private float lifelossfooddelay;

    public static int finalscore; 

    public TextMeshProUGUI scoredisplay; 
    public TextMeshProUGUI livesdisplay;

    public int playerscore; 
    private int playerlives;

    public GameObject foodloselife; 
    public GameObject foodaddpoints; 
    public GameObject foodaddlife;
    public GameObject foodtimeadd;
    public GameObject foodfrenzy;
    public GameObject foodlosetime;
    public GameObject foodlosepoints;

    public Transform wallleft; 
    public Transform wallright; 

    // Start is called before the first frame update
    void Start()
    {
        timertext.color = fontcolour;
        timerdefault = 0;
        timerdefault += (seconds + (minutes * 60)); 
        currentseconds = timerdefault;

        playerscore = 0; 
        playerlives = 3;
        lifelossfooddelay = 6.0f; 

        InvokeRepeating("spawnaddtimefood", 1, 2);
        InvokeRepeating("spawnpointsfood", 2, 2); 
        Invoke("spawnloselifefood", lifelossfooddelay); 
        InvokeRepeating("spawnaddlifefood", 11, 7);
        InvokeRepeating("spawnfoodfrenzy", 30, 60);
        InvokeRepeating("spawnlosetimefood", 30, 10);
        InvokeRepeating("spawnlosepointsfood", 30, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentseconds -= Time.deltaTime) <= 0) 
        {
            timeup();
        }
        else
        {
            timertext.text = TimeSpan.FromSeconds(currentseconds).ToString(@"mm\:ss");
        }

        scoredisplay.text = "Score: " + (playerscore.ToString("D4")); 
        //Debug.Log("Player Score: " + playerscore);
        livesdisplay.text = "Lives: " + (playerlives.ToString("D2")); 
        //Debug.Log("Player Lives: " + playerlives);
        
        if (playerlives <= 0) 
        {
            //Debug.Log("You Lose!");
            finalscore = playerscore; 
            SceneManager.LoadScene("Gameover");
        }
    }

    void spawnpointsfood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 6;
        Instantiate(foodaddpoints, new Vector2(x, y),
            Quaternion.identity);
    }

    void spawnloselifefood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 8;
        Instantiate(foodloselife, new Vector2(x, y),
            Quaternion.identity);
        Invoke("spawnloselifefood", lifelossfooddelay);
    }

    void spawnaddlifefood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 10;
        Instantiate(foodaddlife, new Vector2(x, y),
            Quaternion.identity);
    }

    void spawnaddtimefood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 12;
        Instantiate(foodtimeadd, new Vector2(x, y),
            Quaternion.identity);
    }
    
    void spawnfoodfrenzy()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 14;
        Instantiate(foodfrenzy, new Vector2(x, y),
            Quaternion.identity);
    }
    
    void spawnlosetimefood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
             wallright.position.x - 4f);
        int y = 16;
        Instantiate(foodlosetime, new Vector2(x, y),
            Quaternion.identity);
    }
    
    void spawnlosepointsfood()
    {
        int x = (int)Random.Range(wallleft.position.x + 4f,
            wallright.position.x - 4f);
        int y = 18;
        Instantiate(foodlosepoints, new Vector2(x, y),
            Quaternion.identity);
    }
    
    public void Addpoints()
    {
        playerscore += 10; 
        
        if (lifelossfooddelay > 2.0f) 
        {
            lifelossfooddelay -= .25f;
        }

        if (playerscore == 100) 
        {
            Invoke("spawnloselifefood", 1);
        }
    }

    public void Loselife()
    {
        playerlives -= 1; 
    }

    public void Addlife()
    {
        playerlives += 1;
    }

     private void timeup()
    {
        finalscore = playerscore;
        timertext.text = "00:00";
        SceneManager.LoadScene("Gameover");
    }

    public void AddTime()
    {
        currentseconds += 5;
    }

    public void FoodFrenzy()
    {
        Invoke("spawnaddtimefood", 0);
        Invoke("spawnaddtimefood", 0);
        Invoke("spawnaddlifefood", 0);
        Invoke("spawnaddlifefood", 0);
        Invoke("spawnpointsfood", 0);
        Invoke("spawnpointsfood", 0);
        Invoke("spawnaddtimefood", 1);
        Invoke("spawnaddtimefood", 1);
        Invoke("spawnaddlifefood", 1);
        Invoke("spawnaddlifefood", 1);
        Invoke("spawnpointsfood", 1);
        Invoke("spawnpointsfood", 1);
        Invoke("spawnaddtimefood", 2);
        Invoke("spawnaddtimefood", 2);
        Invoke("spawnaddlifefood", 2);
        Invoke("spawnaddlifefood", 2);
        Invoke("spawnpointsfood", 2);
        Invoke("spawnpointsfood", 2);
        Invoke("spawnaddtimefood", 3);
        Invoke("spawnaddtimefood", 3);
        Invoke("spawnaddlifefood", 3);
        Invoke("spawnaddlifefood", 3);
        Invoke("spawnpointsfood", 3);
        Invoke("spawnpointsfood", 3);
    }

    public void Losetime()
    {
        currentseconds -= 10;
    }

    public void Losepoints()
    {
        playerscore -= 20;
    }
}

