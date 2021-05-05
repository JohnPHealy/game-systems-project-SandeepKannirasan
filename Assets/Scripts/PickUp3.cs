using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp3 : MonoBehaviour
{
    //When player collects the bonus(Medication), the timeline increases by +10 to complete the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager3.health += 10;
            Destroy(this.gameObject);
        }
    }
}
