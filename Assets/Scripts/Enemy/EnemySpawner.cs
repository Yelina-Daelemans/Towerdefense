using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }
    public List<GameObject>Path1 = new List<GameObject>();
    public List<GameObject>Path2 = new List<GameObject>();
    public List<GameObject>Enemies = new List<GameObject>();

    private void SpawnEnemy(int type, Path path)
    {
        var newEnemy = Instantiate(Enemies[type], Path1[0].transform.position, Path1[0].transform.rotation);
        var script = newEnemy.GetComponentInParent<Enemy>();

        // zet hier het path en target voor je enemy in 

        script.path = path;
        script.target = Path1[1];
    }
    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1);
    }
    public GameObject RequestTarget(Path path, int index)
    {
        List<GameObject> currentPath;
    switch (path)
    {
        case Path.Path1:
            currentPath = Path1;
            break;
        case Path.Path2:
            currentPath = Path2;
            break;
        default:
            currentPath = Path1; // Default to Path1 if path is invalid
            break;
    }

    if (index >= currentPath.Count)
    {
        // If the index is out of bounds, return null (reached end of path)
        return null;
    }
    else
    {
        // Return the waypoint at the specified index
        return currentPath[index];
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTester", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
