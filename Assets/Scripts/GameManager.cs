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
    public GameObject tower;
    public void SelectSite(ConstructionSite site)
    {
        // remember the selected site 
        ConstructionSite = site;
        // pass the selected site to the towerMenu 
        // by calling SetSite 
        towerMenu.SetSite(site);
    }
    public void Build(TowerType type, SiteLevel level)
    {
        List<GameObject> pref = new List<GameObject>();
        // you cannot build anything if there is no site selected 
        // if so, return 
        if(ConstructionSite == null) 
        {
            return;
        }
        // use switch with the towertype to select the correct list 
        switch(type) 
        {
            case TowerType.Archer: pref = Archers; break;
                case TowerType.Wizard: pref = Wizards; break;
                case TowerType.Sword: pref = Swords; break;
        }
        // use switch with the level to create a GameObject tower 
        switch(level)
        {
            case SiteLevel.Level1: tower = pref[0]; break;
                case SiteLevel.Level2: tower = pref[1]; break;
                case SiteLevel.Level3: tower = pref[2]; break;
        }
        // configure the SelectedSite to set the tower 
        Instantiate(tower);
        // pass null to the SetSite function in towerMenu to  
        // hide the menu 
        if (ConstructionSite == null)
        {
            // If the site is null, pass null to hide the menu
            towerMenu.SetSite(null);
        }
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
