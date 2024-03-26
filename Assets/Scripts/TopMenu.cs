using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class TopMenu : MonoBehaviour
{
    private Label WaveLabel;
    private Label CreditLabel;
    private Label GateHealth;
    private Button Play;
    private VisualElement root;
    /*Je hebt dus minstens drie labels nodig, en een button. 
     * Als je menu klaar is, dan maak je een script 'TopMenu'. 
     * Je weet al hoe je toegang krijgt tot de root van je menu, hoe je toegang krijgt tot een button, 
     * en hoe je een functie koppelt aan een button. 
     * Hoe je toegang krijgt tot labels, zoek je zelf uit. 
     * Het is in elk geval nodig dat je er toegang toe krijgt, 
     * want anders kan je de teksten niet aanpassen.  
     * Vergeet niet de functie OnDestroy toe te voegen. 
     * Daarin verwijder je de callback functie die aan de button gelinkt is. 
    */
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Play = root.Q<Button>("Play");
        WaveLabel = root.Q<Label>("WaveLabel");
        CreditLabel = root.Q<Label>("CreditLabel");
        GateHealth = root.Q<Label>("GateHealth");
        if (Play != null)
        {
                Play.clicked += OnPlayButtonClicked;
        }
        root.visible = false;
    }
    private void OnPlayButtonClicked()
    {
        GameManager.Instance.StartGame();
    }
    public void SetHealthLabel(string text)
    {
        GateHealth.text = text;
    }
    public void SetWaveLabel(string text) 
    {
        WaveLabel.text = text;
    }
    public void SetCreditLabel(string text) 
    {
        CreditLabel.text = text;
    }
    public void OnDestroy()
    {
        if (Play != null)
        {
            Play.clicked -= OnPlayButtonClicked;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
