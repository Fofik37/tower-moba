using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawnController : MonoBehaviour
{
    public List<GameObject> enemyType;


    float intervalofSpawn = 5f;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(intervalofSpawn, enemyType));
    } 
    
    private IEnumerator spawnEnemy(float interval,List<GameObject> enemies)
    {
        Debug.Log(enemies.Count);
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemies[Random.Range(0,enemies.Count)], new Vector3(transform.position.x + Random.Range(-3,3), 0 , transform.position.z + Random.Range(-3, 3)), Quaternion.Euler(0, 0, 0));
        StartCoroutine(spawnEnemy(interval, enemies));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
}
