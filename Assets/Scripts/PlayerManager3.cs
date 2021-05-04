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
    void Start()
    {
        InvokeRepeating("ReduceHealth", 1, 1);
    }



    void ReduceHealth()
    {
        health = health - 5;
        healthBar.value = health;



        if (health <= 0)
        {
            SceneManager.LoadScene("Level3start");
            healthBar.value = health;
            health = health += 100;

        }
    }
}
