using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerManager3 : MonoBehaviour
{
    public static int health = 100;
    public GameObject player;
    public Slider healthBar;


    // Start is called before the first frame update
    // repeat the reduction of health from start
    void Start()
    {
        InvokeRepeating("ReduceHealth", 1, 1);
    }


    //reduce health by 2
    void ReduceHealth()
    {
        health = health - 2;
        healthBar.value = health;


        //reload scene (level3) when health is 0 and again keep the bar unit back to 100
        if (health <= 0)
        {
            SceneManager.LoadScene("Level3start");
            healthBar.value = health;
            health = health += 100;

        }
    }
}
