using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class QuantumController : MonoBehaviour {
    [SerializeField]
    private Transform atom;
    private List<Atom> atoms=new List<Atom>();
    private Structure structure;
    [SerializeField]
    private GameObject bondController;
    private QuantumInstancer quantumInstancer;
    private CifConverter cifConverter = new CifConverter();



    void Start() {
        //DrawFromCifConverter();
        DrawFromHardCoded();
        bondController.GetComponent<BondManager>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Draws hardcoded austenite frame
    void DrawFromHardCoded() {
        atoms.Add(new Atom(0, 0, 0, "Ni"));
        atoms.Add(new Atom(3.0149999, 0, 0, "Ni"));
        atoms.Add(new Atom(0, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(0, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(3.0149999, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(0, 3.0149999, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999 / 2, 3.0149999 / 2, 3.0149999 / 2, "Ti"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 3.0149999, "Ni"));
        structure = new Structure(atoms, (float)3.0149999, atom);
        quantumInstancer = new QuantumInstancer(structure);
        quantumInstancer.drawEveryLayer();
    }
    //Draws from .cif file
    void DrawFromCifConverter() {
        structure = cifConverter.getStructure("TO IMPLEMENT");
        quantumInstancer = new QuantumInstancer(structure);
        quantumInstancer.drawEveryLayer();
    }
}
