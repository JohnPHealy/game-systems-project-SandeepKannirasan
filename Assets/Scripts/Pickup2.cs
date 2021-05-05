using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup2 : MonoBehaviour
{
    //When player collects the bonus(Medication), the timeline increases by +15 to complete the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager2.health += 15;
            Destroy(this.gameObject);
        }
    }
}
