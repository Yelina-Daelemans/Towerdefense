using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class TowerMenu : MonoBehaviour
{
    private Button archerButton;
    private Button swordButton;
    private Button wizardButton;
    private Button updateButton;
    private Button destroyButton;
    private VisualElement root;
    private ConstructionSite selectedSite;
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        archerButton = root.Q<Button>("archer-button");
        swordButton = root.Q<Button>("sword-button");
        wizardButton = root.Q<Button>("wizard-button");
        updateButton = root.Q<Button>("button-upgrade");
        destroyButton = root.Q<Button>("button-destroy");
        if (archerButton != null)
        {
            archerButton.clicked += OnArcherButtonClicked;
        }
        if (swordButton != null)
        {
            swordButton.clicked += OnSwordButtonClicked;
        }
        if (wizardButton != null)
        {
            wizardButton.clicked += OnWizardButtonClicked;
        }
        if (updateButton != null)
        {
            updateButton.clicked += OnUpdateButtonClicked;
        }
        if (destroyButton != null)
        {
            destroyButton.clicked += OnDestroyButtonClicked;
        }
        root.visible = false;
    }
    private void OnArcherButtonClicked()
    {
    }
    private void OnSwordButtonClicked()
    {
    }
    private void OnWizardButtonClicked()
    {
    }
    private void OnUpdateButtonClicked()
    {
    }
    private void OnDestroyButtonClicked()
    {
    }
    private void OnDestroy()
    {
        if (archerButton != null)
        {
            archerButton.clicked -= OnArcherButtonClicked;
        }
        if (swordButton != null)
        {
            swordButton.clicked -= OnSwordButtonClicked;
        }
        if (wizardButton != null)
        {
            wizardButton.clicked -= OnWizardButtonClicked;
        }
        if (updateButton != null)
        {
            updateButton.clicked -= OnUpdateButtonClicked;
        }
        if (destroyButton != null)
        {
            destroyButton.clicked -= OnArcherButtonClicked;
        }
    }
    public void EvaluateMenu()
    {
        // return if selectedSite equals null 
        if (selectedSite == null)
        {
            return;
        }
        // use the SetEnabled() function on every button 
        // If the sitelevel for the selectedSite is zero, only the  
        // archerButton, wizardButton and swordButton should 
        // be enabled. 
        archerButton.SetEnabled(true);
        swordButton.SetEnabled(true);
        wizardButton.SetEnabled(true);
        // If the sitelevel is 1 or 2, only the 
        // update and destroybutton should work 
        // If the siteLevel is 3, only the destroyButton is on. 
        // Hint: use a switch for this logic. 
        switch (selectedSite.SiteLevel)
        {
            case 0:
                updateButton.SetEnabled(false);
                destroyButton.SetEnabled(false);
                break;
            case SiteLevel.Level1:
                
                case SiteLevel.Level2:
                updateButton.SetEnabled(true);
                destroyButton.SetEnabled(true);
                archerButton.SetEnabled(false);
                swordButton.SetEnabled(false);
                wizardButton.SetEnabled(false);
                break;
            case SiteLevel.Level3:
                updateButton.SetEnabled(false);
                destroyButton.SetEnabled(true);
                archerButton.SetEnabled(false);
                swordButton.SetEnabled(false);
                wizardButton.SetEnabled(false);
                break;
        }
    }
    public void SetSite(ConstructionSite site)
    {
        // assign the site to a variable selectedSite 
        selectedSite = site;
        // check if the selected site is equal to null 
        // if so, hide the menu by changing root.visible 
        // and return. 
        // if not, make sure the menu is visible  
        // and call evaluate menu 
        if (selectedSite == null)
        {
            root.visible = false;
            return;
        }
        else 
        {
            root.visible = true;
            EvaluateMenu();
        }
    }
}
