﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BondManager : MonoBehaviour
{
    private GameObject[] atoms;
    [SerializeField] private Transform cylinderRef;
    private GameObject[] atomsParent;

    [SerializeField] private int AmountOfClosestBonds = 1;
    // Use this for initialization
    void Start ()
    {
        //atoms = atomsParent.GetComponentsInChildren<Transform>();
	    atoms = GameObject.FindGameObjectsWithTag("atom");
	    MakeBonds();
	}

    void MakeBonds()
	{
	    float distance = 100f;
	    HashSet<float> distances = new HashSet<float>();
	    float[] distancesArray;
	    //Transform atomFirst = atoms[0];
        //Transform atomSecond = atoms[0];
	    List<BondDistances> bonds = new List<BondDistances>();
        //Dictionary<float,BondDistances[]> bonds = new Dictionary<float, BondDistances[]>();
        
        foreach (var atom in atoms)
	    {
	        foreach (var atom2 in atoms)
	        {
	            float dis = Vector3.Distance(atom.transform.position, atom2.transform.position);
                bonds.Add(new BondDistances(dis,atom.GetComponent<Transform>(),atom2.GetComponent<Transform>()));
	            /*if (distance > Vector3.Distance(atom.transform.position, atom2.transform.position) && Vector3.Distance(atom.transform.position, atom2.transform.position) != 0)
	            {
	                distance = Vector3.Distance(atom.transform.position, atom2.transform.position);
	                atomFirst = atom;
	                atomSecond = atom2;
	            }*/
	            distances.Add((float)Math.Round(dis * 100f)/100f);
	        }
	    }
	    distancesArray = distances.ToArray();
        Array.Sort(distancesArray);
        for (int i = 0; i < AmountOfClosestBonds; i++)
	    {
            foreach (var bondDistanceBond in bonds.FindAll(b => Math.Abs(b.distance - distancesArray[i+1]) < 0.1))
	        {
                GameObject gameObject = GameObject.Instantiate(cylinderRef.gameObject, transform.position, Quaternion.identity);
                Transform bondTransform = gameObject.GetComponentInChildren<Transform>();
                gameObject.transform.localScale = new Vector3(1f, 1f, bondDistanceBond.distance / 2);
                gameObject.transform.position = bondDistanceBond.atomFirst.transform.position;
                gameObject.transform.LookAt(bondDistanceBond.atomSecond.transform);
                gameObject.transform.SetParent(bondDistanceBond.atomFirst);
	        }
	    }

        //List<BondDistances> bonds1 = bonds.OrderBy(n=>n.distance).ToList().FindAll(b => b.distance.Equals(bonds.First().distance));
        //bonds.RemoveAll(b => b.distance.Equals(bonds.First().distance));
        //List<BondDistances> bonds2 = bonds.FindAll(b => b.distance.Equals(bonds.First().distance));
        //distances.ToArray()[0]

        //cylinderRef.localScale = new Vector3(-2, 0, -2);
        /*
        GameObject gameObject = GameObject.Instantiate(cylinderRef.gameObject, transform.position, Quaternion.identity);
	    Transform bondTransform = gameObject.GetComponentInChildren<Transform>();
        gameObject.transform.localScale = new Vector3(1f,1f,distance/2);
        gameObject.transform.position = atomFirst.transform.position;
        gameObject.transform.LookAt(atomSecond.transform); 
        gameObject.transform.SetParent(atomFirst);
        */
    }
}
