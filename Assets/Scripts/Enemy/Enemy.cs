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
        
    }
}
