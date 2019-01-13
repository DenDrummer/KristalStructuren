using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeMenu : MonoBehaviour {
    [SerializeField]
    private GameObject number;
    [SerializeField]
    private GameObject up;
    [SerializeField]
    private GameObject down;
    // Use this for initialization
    void Start () {
        number.GetComponent<Text>().text = UserStats.Size.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickUp()
    {
        if (UserStats.Size < 5)
        {
            ++UserStats.Size;
            number.GetComponent<Text>().text = UserStats.Size.ToString();
        }
        if (UserStats.Size == 5)
        {
            up.SetActive(false);
        }
        down.SetActive(true);
    }

    public void ClickDown()
    {
        if (UserStats.Size > 1)
        {
            --UserStats.Size;
            number.GetComponent<Text>().text = UserStats.Size.ToString();
        }
        if (UserStats.Size == 1)
        {
            down.SetActive(false);
        }
        up.SetActive(true);
    }
}
