using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject Asteroids;


    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotRoutine());
        StartCoroutine(AsteroidSpawnRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AsteroidSpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(-8f, 8f), 7);
            Instantiate(Asteroids, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 12f));
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 posTospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy =  Instantiate(_enemyPrefab, posTospawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2.0f);
        }
        
    }
   
    IEnumerator SpawnTripleShotRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 posTospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], posTospawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 8f));
        }
    }
  

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}