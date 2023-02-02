using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCoins : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip addPointsSound;
    public AudioClip loselifesound;
    public AudioClip addtimesound;
    public AudioClip addlifesound;
    public AudioClip frenzysound;
    public AudioClip losetimesound;
    public AudioClip losepointssound;
    
    public GameController myGameController;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Something Hit Me " + other.gameObject.name);
            if (other.gameObject.name.StartsWith("A"))
            {
                myAudioSource.PlayOneShot(addPointsSound, .5f);
                Destroy(other.gameObject);
                myGameController.Addpoints();
            }

            if (other.gameObject.name.StartsWith("B"))
            {
                myAudioSource.PlayOneShot(loselifesound, .5f);
                Destroy(other.gameObject);
                myGameController.Loselife();
            }
           
            if (other.gameObject.name.StartsWith("O"))
            {
                myAudioSource.PlayOneShot(addlifesound, .5f);
                myGameController.Addlife();
                Destroy(other.gameObject);
            }

            if (other.gameObject.name.StartsWith("C"))
            {
                myAudioSource.PlayOneShot(addtimesound, .5f);
                myGameController.AddTime();
                Destroy(other.gameObject);
            }

            if (other.gameObject.name.StartsWith("G"))
            {
                myAudioSource.PlayOneShot(frenzysound, .5f);
                myGameController.FoodFrenzy();
                Destroy(other.gameObject);
            }

            if (other.gameObject.name.StartsWith("M"))
            {
                myAudioSource.PlayOneShot(losetimesound, .5f);
                myGameController.Losetime();
                Destroy(other.gameObject);
            }

            if (other.gameObject.name.StartsWith("I"))
            {
                myAudioSource.PlayOneShot(losepointssound, .5f);
                myGameController.Losepoints();
                Destroy(other.gameObject);
            }
    }
}
