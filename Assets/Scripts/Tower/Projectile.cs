using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        // Rotate the projectile towards the target if it exists
        if (target != null)
        {
            RotateTowardsTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // When target is null, destroy this projectile
        if (target == null)
        {
            GameObject.Destroy(this);
            return;
        }

        // Move the projectile towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Check if the distance between this object and the target is smaller than 0.1. If so, destroy this object
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    // Method to rotate the projectile towards the target
    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 1000f);
    }

}
