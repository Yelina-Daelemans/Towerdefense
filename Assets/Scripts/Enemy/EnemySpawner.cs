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
    private int ufoCounter = 0;
    public void StartWave(int number)
    {
        // reset counter 
        ufoCounter = 0;
        switch (number)
        {
            case 1:
                InvokeRepeating("StartWave1", 1f, 1.5f);
                break;
        }
    }
    public void StartWave1()
    {
        ufoCounter++;
        // leave some gaps 
        if (ufoCounter % 6 <= 1) return;
        if (ufoCounter < 30)
        {
            SpawnEnemy(0, Path.Path1);
        }
        else if (ufoCounter <= 50)
        {
            SpawnEnemy(0, Path.Path2);
        }
        else if (ufoCounter < 75)
        {
            SpawnEnemy(1, Path.Path1);
        }
        else if (ufoCounter <= 100)
        {
            SpawnEnemy(1, Path.Path1);
            SpawnEnemy(0, Path.Path2);
        }
        else if (ufoCounter <= 100)
        {
            SpawnEnemy(0, Path.Path1);
            SpawnEnemy(1, Path.Path2);
        }
        else if (ufoCounter <= 150)
        {
            SpawnEnemy(2, Path.Path1);
            SpawnEnemy(3, Path.Path2);
        }
        else
        {
            // the last Enemy will be level 2 
            SpawnEnemy(1, Path.Path1);
        }
        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1"); // the reverse of InvokeRepeating 
            // depending on your singleton declaration, Get might be somthing else 
            GameManager.Instance.EndWave(); // let the gameManager know. 
        }
    }
    public void StartWave2()
    {
        ufoCounter++;
        // leave some gaps 
        if (ufoCounter % 6 <= 1) return;
         if (ufoCounter <= 50)
        {
            SpawnEnemy(0, Path.Path2);
        }
        else
        {
            // the last Enemy will be level 2 
            SpawnEnemy(1, Path.Path1);
        }
        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1"); // the reverse of InvokeRepeating 
            // depending on your singleton declaration, Get might be somthing else 
            GameManager.Instance.EndWave(); // let the gameManager know. 
        }
    }
    public void StartWave3()
    {
        ufoCounter++;
        // leave some gaps 
        if (ufoCounter % 6 <= 1) return;
         if(ufoCounter < 75)
        {
            SpawnEnemy(1, Path.Path1);
        }
        else if (ufoCounter <= 100)
        {
            SpawnEnemy(1, Path.Path1);
            SpawnEnemy(0, Path.Path2);
        }
        else
        {
            // the last Enemy will be level 2 
            SpawnEnemy(1, Path.Path1);
        }
        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1"); // the reverse of InvokeRepeating 
            // depending on your singleton declaration, Get might be somthing else 
            GameManager.Instance.EndWave(); // let the gameManager know. 
        }
    }
    public void StartWave4()
    {
        ufoCounter++;
        // leave some gaps 
        if (ufoCounter % 6 <= 1) return;
        if (ufoCounter <= 100)
        {
            SpawnEnemy(1, Path.Path1);
            SpawnEnemy(0, Path.Path2);
        }
        else
        {
            // the last Enemy will be level 2 
            SpawnEnemy(1, Path.Path1);
        }
        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1"); // the reverse of InvokeRepeating 
            // depending on your singleton declaration, Get might be somthing else 
            GameManager.Instance.EndWave(); // let the gameManager know. 
        }
    }
    public void StartWave5()
    {
        ufoCounter++;
        // leave some gaps 
        if (ufoCounter % 6 <= 1) return;
        if (ufoCounter <= 100)
        {
            SpawnEnemy(0, Path.Path1);
            SpawnEnemy(1, Path.Path2);
        }
        else if (ufoCounter <= 150)
        {
            SpawnEnemy(2, Path.Path1);
            SpawnEnemy(3, Path.Path2);
        }
        else if (ufoCounter <= 151)
        {
            SpawnEnemy(3, Path.Path1);
            SpawnEnemy(3, Path.Path2);
        }
        else
        {
            // the last Enemy will be level 2 
            SpawnEnemy(1, Path.Path1);
        }
        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1"); // the reverse of InvokeRepeating 
            // depending on your singleton declaration, Get might be somthing else 
            GameManager.Instance.EndWave(); // let the gameManager know. 
        }
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
