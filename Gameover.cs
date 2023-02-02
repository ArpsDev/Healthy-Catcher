using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI finalscoredisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalscoredisplay.text =
            GameController.finalscore.ToString("D4");
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameLevel");
        }
    
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
