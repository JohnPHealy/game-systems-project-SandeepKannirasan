using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public static int health = 100;
    public GameObject player;
    public Slider healthBar;
 

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts the time countdown starts 
        InvokeRepeating("ReduceHealth", 1, 1);
  
    }


    //Reduce time gradually

    void ReduceHealth()
    {
       health = health -4;
        healthBar.value = health;


        //Destroy/repspawn level when the time turns zero and load the scene again
        if (health <= 0)
        {

            // Scene scene = SceneManager.GetActiveScene();
            
            SceneManager.LoadScene("Level1start");
           
            healthBar.value = health;
            health = health +=100;



        }
    }


}