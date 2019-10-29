using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float speed; // the speed of the enemy
    public float stoppingDistance; // the stopping distance of the enemy
    public float retreatDistance; // the retreat distance of the enemy

    private float timeBtwShots;
    public float startTimeBtwShots;

    [SerializeField]
    public int health = 100; // how much health the enemy has

    private Transform target; // what the enemy is targeting

    public GameObject deathEffect; // the death effect of the enemy
    public GameObject projectile;

    [SerializeField]
    private UnityEvent onDied;

    void Start()
    {
        // target is = to the "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        // goes towards the current target and retreats from target
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        // the time between shots
        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    // enemy takes damage
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // Destroy enemy
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        var prefabSpawner = this.GetComponent<PrefabSpawner>();
        if (prefabSpawner != null)
        {
            prefabSpawner.Spawn();
        }
    }
}
