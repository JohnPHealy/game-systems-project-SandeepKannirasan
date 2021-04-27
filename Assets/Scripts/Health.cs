using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthslider;
    public float MaxHealth;
    public static float currenthealth;
    public GameObject player;
   

    public GameObject DeathCanvas;


    private void Start()
    {
     
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Enemy")
           currenthealth = -5;
    }

    // Update is called once per frame
    void Update()
    {
        healthslider.value = currenthealth;

        if (currenthealth <= 0)
        {
            DeathCanvas.SetActive(true);
        }
    }
}
