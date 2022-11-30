using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject _spawnPoint;
    public GameObject _enemy;
    //private int x;

    void Start()
    {
        /*x = Random.Range(0, 2);
        if (x == 1)
        {
            Instantiate(_enemy, _spawnPoint.transform.position, Quaternion.identity);
        }*/
        Instantiate(_enemy, _spawnPoint.transform.position, Quaternion.identity);
    }
}
