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
      
        text.text = "Health :" +health;
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Enemy")
            health = health -10;

        if(health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}
