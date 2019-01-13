using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Transform atom;
    List<Atom> atoms=new List<Atom>();
    List<Atom> atoms2 = new List<Atom>();
    Structure structure1;
    [SerializeField]
    private GameObject bondController;
    [SerializeField]
    private GameObject InformationController;

    [SerializeField] private Text debugGui;

    [SerializeField] private GameObject exitButtons;
    [SerializeField] private GameObject enterButtons;


    // Use this for initialization
    void Start() {
        atoms.Add(new Atom(0, 0, 0,"Ni"));
        atoms.Add(new Atom(3.0149999, 0, 0,"Ni"));
        atoms.Add(new Atom(0, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(0, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(3.0149999, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(0, 3.0149999, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999 / 2, 3.0149999 / 2, 3.0149999 / 2, "Ti"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 3.0149999, "Ni"));
        structure1 = new Structure(atoms,(float) 3.0149999,atom);
        structure1.drawEveryLayer();
        bondController.GetComponent<BondManager>().enabled = true;
        InformationController.GetComponent<InformationGuiManager>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetDebugText(String debug)
    {
        debugGui.text = debug;
    }

    public List<GameObject> GetExitButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform Button in exitButtons.transform)
        {
            buttons.Add(Button.gameObject);
        }
        return buttons;
    }

    public List<GameObject> GetEnterButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform enterButton in enterButtons.transform)
        {
            buttons.Add(enterButton.gameObject);
        }
        return buttons;
    }
}
