using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float speed=5f;
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _enemyCon;
    [SerializeField]
    private float time;
    private bool isDead = false;



    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

   
    void Update()
    {
        Spawnning();
         
    }
    void spawn()
    {

        Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
        GameObject a = Instantiate(_EnemyPrefab, posToSpawn, Quaternion.identity);
        a.transform.parent = _enemyCon.transform;

    }

    IEnumerator SpawnEnemy()
    {
        while (isDead == false)
        {

            spawn();
            yield return new WaitForSeconds(time);
        }
    }

    void Spawnning()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
    }
   
}
