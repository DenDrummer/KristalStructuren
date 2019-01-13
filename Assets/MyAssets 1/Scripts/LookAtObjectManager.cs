using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObjectManager : MonoBehaviour {

    private Renderer myRenderer;
    private Color color;
    private Color gazedAtColor;
    private bool activateMenu;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        color = myRenderer.material.color;
        gazedAtColor = color * 1.5f;
        gazedAtColor.a = 1;
        activateMenu = true;
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            myRenderer.material.SetColor("_EmissionColor", new Color(0.15f, 0.15f, 0.15f));
        }
        else
        {
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

    public void ClickBond()
    {
        switch (UserStats.State)
        {
            case State.Default:
                SelectBond();
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
    }

    public void SelectAtom()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.GetChild(0).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }

    public void SelectBond()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.parent.parent.GetChild(1).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }

    /*
    public void ClickGameObject()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.parent.parent.GetChild(1).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }*/

    private void deactivateAtomGui()
    {
        GameObject[] atomGuis = GameObject.FindGameObjectsWithTag("atomgui");
        if (atomGuis.Length > 0)
        {
            foreach (GameObject atomGui in atomGuis)
            {
                atomGui.SetActive(false);
            }
        }
    }

    private void deactivateBondGui()
    {
        GameObject[] bondGuis = GameObject.FindGameObjectsWithTag("bondgui");
        if (bondGuis.Length > 0)
        {
            foreach (GameObject bondGui in bondGuis)
            {
                bondGui.SetActive(false);
            }
        }
    }
}
