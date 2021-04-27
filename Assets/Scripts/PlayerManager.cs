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
    public UnityEvent playerDeath;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("ReduceHealth", 1, 1);
    }

 

    void ReduceHealth()
    {
       health = health -10;



        if (health <= 0)
        {
            playerDeath.Invoke();
       
            

        }
    }

    

  //  public void PauseGame()
  //  {
  //      Time.timeScale = 1f;
        
 //   }


    public void ReLoadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    
    }





}