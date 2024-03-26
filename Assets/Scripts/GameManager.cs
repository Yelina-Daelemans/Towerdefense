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
    private GameObject tower;
    private TopMenu topMenu;
    public GameObject Topmenu;
    private int Credits;
    private int Health;
    private int CurrentWave;
    
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
    public void StartGame() 
    {
        Credits = 200;
        Health = 10;
        CurrentWave = 0;
        topMenu.SetCreditLabel("Credits: " + Credits);
        topMenu.SetHealthLabel("Gate Health: "+Health);
        topMenu.SetWaveLabel("Current wave: "+CurrentWave);
    }
    public void AttackGate()
    {
        // reduce health with 1 
        Health -= 1;
        // update the label in topmenu 
        topMenu.SetHealthLabel("Gate Health: " + Health);
    }
    public void AddCredits(int amount)
    {
        // update credits 
        Credits += amount;
        // update the label in topMenu 
        topMenu.SetCreditLabel("Credits: " + Credits);
        // evaluate the tower menu. This does nothing for now, 
        // but we will soon add code over there to check for credits 
        towerMenu.EvaluateMenu();
    }
    public void RemoveCredits(int amount)
    {
        // similar to the previous function 
        Credits -= amount;
    }
    public int GetCredits()
    {
        // you can figure this out 
        return Credits;

    }
    public int GetCost(TowerType type, SiteLevel level, bool selling = false)
    {
        int cost = 0;
        // return the cost for every type of tower
        switch (type) 
        {
            case TowerType.Archer:
                switch (level)
                {
                    case SiteLevel.Level1:
                        cost = 50;
                        break;
                        case SiteLevel.Level2:
                        cost = 200;
                        break;
                        case SiteLevel.Level3:
                        cost = 350;
                        break;
                }
                break;
            case TowerType.Sword:
                switch (level)
                {
                    case SiteLevel.Level1:
                        cost = 50;
                        break;
                    case SiteLevel.Level2:
                        cost = 200;
                        break;
                    case SiteLevel.Level3:
                        cost = 350;
                        break;
                }
                break;
            case TowerType.Wizard:
                switch (level)
                {
                    case SiteLevel.Level1:
                        cost = 50;
                        break;
                    case SiteLevel.Level2:
                        cost = 200;
                        break;
                    case SiteLevel.Level3:
                        cost = 350;
                        break;
                }
                break;
        }
        // Reduce the cost if selling
        if (selling)
        {
            cost /= 2; // For example, halve the cost when selling
        }

        return cost;
        // the return should be lower if you are selling 
    }
    // Start is called before the first frame update
    void Start()
    {
        towerMenu = TowerMenu.GetComponent<TowerMenu>();
        topMenu = Topmenu.GetComponent<TopMenu>();
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
