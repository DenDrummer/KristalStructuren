
using UnityEngine;

public class MenuAtomManager : MonoBehaviour
{
    private bool activated;

    void Start()
    {
        activated = true;
    }

    public void ButtonPress()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform innerChild in child)
            {
                innerChild.gameObject.SetActive(activated);
            }
        }
        activated = !activated;
    }
}
