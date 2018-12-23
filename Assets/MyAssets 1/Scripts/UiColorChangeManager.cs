
using UnityEngine;
using UnityEngine.UI;

public class UiColorChangeManager : MonoBehaviour {
    //Change color of ui to color of atom
	// Use this for initialization
    private Material materialParent;
    private Image materialsChildren;

	void Start () {

	    //ChangeUIColor();
        //ChangeButtonColor();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeUIColor()
    {
        //Fetch the Renderer from the GameObject
        materialParent = transform.parent.GetComponent<Renderer>().material;
        materialsChildren = GetComponentInChildren<Image>(true);

        //foreach (Image mat in materialsChildren)
        //{
        materialsChildren.color = materialParent.color;
        //}
    }

    void ChangeButtonColor()
    {
        Button[] buttons = transform.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().material.color = materialParent.color*1.5f;
        }
    }
}
