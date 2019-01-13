using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationGuiManager : MonoBehaviour {
    private GameObject[] atoms;

    void Start () {
        atoms = GameObject.FindGameObjectsWithTag("atom");
        SetInformationGuis();
    }

	private void SetInformationGuis() {
	    foreach (GameObject atom in atoms)
	    {
            atom.GetComponent<AtomGuiDetails>().enabled = true;
        }
	}
}
