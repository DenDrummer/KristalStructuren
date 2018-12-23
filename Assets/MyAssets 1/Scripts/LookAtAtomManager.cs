
using UnityEngine;

public class LookAtAtomManager : MonoBehaviour
{
    private Renderer myRenderer;
    private Color color;
    private Color gazedAtColor;
    private bool activateMenu;
    private GameObject[] atomGuis;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        color = myRenderer.material.color;
        gazedAtColor = color * 1.5f;
        gazedAtColor.a = 1;
        activateMenu = true;
    }

    void Update()
    {
        //float emission = Mathf.PingPong(Time.time, 1.0f);
        //Color baseColor = color; 
        //Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        //myRenderer.material.SetColor("_EmissionColor", color);
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt && (UserStats.State.Equals(State.SelectAtom) || UserStats.State.Equals(State.MeasureDistance)))
        {
            //myRenderer.material.color = gazedAtColor;
            myRenderer.material.SetColor("_EmissionColor", new Color(0.15f, 0.15f, 0.15f));
        }
        else if (!gazedAt)
        {
            //myRenderer.material.color = color;
            myRenderer.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public void ClickAtom()
    {
        if (UserStats.State.Equals(State.SelectAtom))
        {
            atomGuis = GameObject.FindGameObjectsWithTag("atomgui");
            if (atomGuis.Length > 0)
            {
                foreach (GameObject atomGui in atomGuis)
                {
                    atomGui.SetActive(false);
                }
            }
            bool activeSelf = transform.GetChild(0).gameObject.activeSelf ? true : false;
            transform.GetChild(0).gameObject.SetActive(activeSelf);
            activateMenu = activateMenu ? false : true;
        }
    }
}
