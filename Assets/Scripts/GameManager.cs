using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
    public GameObject TowerMenu;
    private TowerMenu towerMenu;
    public List<GameObject> Archers;
    public List<GameObject> Swords;
    public List<GameObject> Wizards;
    public ConstructionSite ConstructionSite;

    public void SelectSite(ConstructionSite site)
    {
        // remember the selected site 
        ConstructionSite = site;
        // pass the selected site to the towerMenu 
        // by calling SetSite 
        towerMenu.SetSite(site);
    }
    // Start is called before the first frame update
    void Start()
    {
        towerMenu = TowerMenu.GetComponent<TowerMenu>();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
