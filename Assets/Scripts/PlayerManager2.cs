using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerManager2 : MonoBehaviour
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
            SceneManager.LoadScene("IntroScene");

        }
    }



    // public void PauseGame()
    //{
    //     Time.timeScale = 5f;

    // }


    //public void ReLoadLevel()
    //{
    //   Scene scene = SceneManager.GetActiveScene();
    //   SceneManager.LoadScene(scene.name);

    // }





}