using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Transform atom;
    List<Atom> atoms=new List<Atom>();
    Structure structure1;
    [SerializeField]private GameObject bondController;

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
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void setElementen() {
        using (var reader = new StreamReader(@"Assets\MyAssets Jorne\Data\data.csv")) {
            //Eerste lijn met benamingen skippen
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Debug.Log(values[1]);
               

            }
        }
    }

   
}
