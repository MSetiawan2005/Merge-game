using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int increaseScore;
    int score;
    [SerializeField] private AudioSource MissionSound;
    GameObject triggered;
    TileElement tm;
    Stack Sprites;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Misi") )
        {
            
            GameUI1.timeLeft += 3;
            GameUI1.scoreCount += increaseScore;
            MissionSound.Play();

        }

    }


}
