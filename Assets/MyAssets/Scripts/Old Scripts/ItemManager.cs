using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class ItemManager : MonoBehaviour {

    private Renderer myRenderer;
    //Color lerpedColor = Color.white;
    [SerializeField]
    private Material inactiveMaterial;
    [SerializeField]
    private Material gazedAtMaterial;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        }
    }
}
