using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    //public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;


    }

    // Update is called once per frame
    void Update()
    { //stopping distance from the the "Player"
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance &&
            Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //retreat when the stopping distance is reached 
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        //this script was written if the enemy had shooting power
        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
        }
        //time delay between recurring bullets
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
