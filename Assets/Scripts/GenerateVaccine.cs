using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateVaccine : MonoBehaviour
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
        while (enemyCount < 20)
        {
            xPos = Random.Range(1, -120);
            zPos = Random.Range(1, 400);
            Instantiate(theEnemy, new Vector3(xPos, 6, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            enemyCount += 1;

        }
    }
}
