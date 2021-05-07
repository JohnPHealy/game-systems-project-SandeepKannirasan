using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //collide and exit the level to move to another level
    void OnCollisionEnter(Collision gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.name == "Player")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Level3");
        }
    }

}