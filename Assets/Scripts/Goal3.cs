using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.name == "Player")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("EndScene");
        }
    }
}
