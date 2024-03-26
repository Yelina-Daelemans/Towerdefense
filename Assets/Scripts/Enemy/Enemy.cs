using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float health = 10f;
    public int points = 1;
    public Path path { get; set; }
    public GameObject target { get; set; }
    private int pathIndex = 1;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        // check how close we are to the target 
        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            // if close, request a new waypoint 
            target = EnemySpawner.instance.RequestTarget(path, pathIndex);
            pathIndex++;
            // if target is null, we have reached the end of the path. 
            // Destroy the enemy at this point 
            if (target == null)
            {
                Destroy(gameObject);
            }
        }
    }
    //^(?([^\r\n])\s)*\r?$\r?\n this is for removing blank lines -> control+ H type this in find in and select "Use Regular Expression" than press replace all.
    public void Damage(int damage = 1)
    {
        // lower the health value 
        health -= damage;
        // if health is smaller or equal to zero 
        // destroy the game object 
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
