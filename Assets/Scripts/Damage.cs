using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    // Update is called once per frame
    void Update()
    {
      

    }

    void OncollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage()
    {
        Health.currenthealth -= damage;
    }
}
