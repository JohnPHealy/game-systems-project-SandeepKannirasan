using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //generate enemies
        StartCoroutine(EnemyDrop());
    }
    //
    IEnumerator EnemyDrop()
    {
        //number of enemies and the position within which they have to be generated.
        //the enemy is spread across the environment
        while (enemyCount < 100)
        {
            xPos = Random.Range(1, -38);
            zPos = Random.Range(1, 287);
            Instantiate(theEnemy, new Vector3(xPos, 6, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            enemyCount += 2;

        }
    }


}
