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
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 50)
        {
            xPos = Random.Range(1, -23);
            zPos = Random.Range(1, 150);
            Instantiate(theEnemy, new Vector3(xPos, 6, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 2;

        }
    }


}
