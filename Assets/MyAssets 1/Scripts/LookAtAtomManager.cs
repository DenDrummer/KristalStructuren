using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LookAtAtomManager : MonoBehaviour {

    private Renderer myRenderer;
    private Color color;
    private Color gazedAtColor;
    private bool activateMenu;
    private GameObject[] atomGuis;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        color = myRenderer.material.color;
        gazedAtColor = color*1.5f;
        gazedAtColor.a = 1;
        activateMenu = true;
        
    }

    void update()
    {
        //float emission = Mathf.PingPong(Time.time, 1.0f);
        //Color baseColor = color; 
        //Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        //myRenderer.material.SetColor("_EmissionColor", color);
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            //myRenderer.material.color = gazedAtColor;
            myRenderer.material.SetColor("_EmissionColor", new Color(0.15f,0.15f,0.15f));
        }
        else
        {
            //myRenderer.material.color = color;
            myRenderer.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public void ClickAtom()
    {
        switch (UserStats.State)
        {
            case State.Default:
                SelectAtom();
                break;
            case State.MeasureDistance:
                MeasureDistance();
                break;
            case State.Teleport:
                Teleport();
                break;
            default:
                //Do nothing
                break;
        }
    }

    private void Teleport()
    {
        Teleport tp = gameObject.GetComponent<Teleport>();
        tp.TeleportToAtom();
    }

    private void MeasureDistance()
    {
        UserStats.SecondLocation = transform;
        throw new NotImplementedException();
    }

    private void SelectAtom()
    {
        //TODO: Ask Sam about why atomGuis is stored if it's reset everytime it's used anyways
        atomGuis = GameObject.FindGameObjectsWithTag("atomgui");
        if (atomGuis.Length > 0)
        {
            foreach (GameObject atomGui in atomGuis)
            {
                atomGui.SetActive(false);
            }
        }
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.GetChild(0).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }
}
