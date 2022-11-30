using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDagger : MonoBehaviour
{
    [SerializeField] private int _damage = 10, _heavyDamage = 20;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnemyHealth enemy = col.GetComponent<EnemyHealth>();
            enemy.Damage(_damage);
        }
        if (col.gameObject.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.Mouse1))
        {
            EnemyHealth enemy = col.GetComponent<EnemyHealth>();
            enemy.Damage(_heavyDamage);
        }
    }

    void Start()
    {
        GetComponent<MeshCollider>().enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<MeshCollider>().enabled = true;

        }
        if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetComponent<MeshCollider>().enabled = false;
        }
    }
}
