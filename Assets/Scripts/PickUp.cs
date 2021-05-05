using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //When player collects the bonus(Medication), the timeline increases by +5 to complete the game
        if (other.gameObject.tag == "Player") { 
        PlayerManager.health +=5;
        Destroy(this.gameObject);
        }
    }




}
