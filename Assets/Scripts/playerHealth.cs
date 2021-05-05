using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class playerHealth : MonoBehaviour

{
 

    public float health;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
      
        text.text = "HEALTH :" +health;
    }
    //reduce on collision with the enemy
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Enemy")
            health = health -10;

        //load the scene again when the health becomes 0
        if(health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}
