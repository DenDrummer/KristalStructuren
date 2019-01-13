using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObjectManager : MonoBehaviour {

    private Renderer myRenderer;
    private Color color;
    private Color gazedAtColor;
    private bool activateMenu;
    private GameObject[] atomGuis;
    private GameObject[] bondGuis;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        color = myRenderer.material.color;
        gazedAtColor = color * 1.5f;
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
            myRenderer.material.SetColor("_EmissionColor", new Color(0.15f, 0.15f, 0.15f));
        }
        else
        {
            //myRenderer.material.color = color;
            myRenderer.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public void ClickAtom()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.GetChild(0).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }

    public void ClickBond()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.parent.GetChild(0).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }

    public void ClickGameObject()
    {
        deactivateAtomGui();
        deactivateBondGui();
        //bool activeSelf = !transform.GetChild(0).gameObject.activeSelf;
        transform.parent.parent.GetChild(1).gameObject.SetActive(activateMenu);
        activateMenu = !activateMenu;
    }

    private void deactivateAtomGui()
    {
        atomGuis = GameObject.FindGameObjectsWithTag("atomgui");
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
        bondGuis = GameObject.FindGameObjectsWithTag("bondgui");
        if (bondGuis.Length > 0)
        {
            foreach (GameObject bondGui in bondGuis)
            {
                bondGui.SetActive(false);
            }
        }
    }
}
