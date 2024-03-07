using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner instance;
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
    }
    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
