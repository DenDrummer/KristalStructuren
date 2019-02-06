using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Overseeing class that instantiates structures and other controllers
 */
public class ARGameController : MonoBehaviour
{
    [SerializeField]
    private Transform atom;
    List<Atom> atoms = new List<Atom>();
    Structure structure;
    [SerializeField]
    private GameObject bondController;
    [SerializeField]
    private QuantumInstancer quantumInstancer;
    private CifConverter cifConverter;
    private GameObject crystal;

    void Start()
    {
        crystal = new GameObject("Crystal");
        Destroy(crystal);
        cifConverter = new CifConverter(atom);
        //DrawFromCifConverter();
        DrawFromHardCoded();
        bondController.GetComponent<BondManager>().enabled = true;
        Instantiate(crystal);
    }

    //Draws hardcoded austenite frame
    void DrawFromHardCoded()
    {
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
        quantumInstancer = new QuantumInstancer(structure, 5, crystal);
        quantumInstancer.drawEveryLayer();
    }

    //Draws from .cif file
    void DrawFromCifConverter()
    {
        structure = cifConverter.getStructure(UserStats.Cif);
        quantumInstancer = new QuantumInstancer(structure, UserStats.Size, crystal);
        quantumInstancer.drawEveryLayer();
    }
}

