using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    void Update()
    {
       if (Input.GetKey(KeyCode.Space))
       {
            SceneManager.LoadScene("GameLevel");
       }
    }
}
