using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text timeUI;
    [SerializeField]
    private Text penaltyUI;
    [SerializeField]
    private float penaltyIncrease;
    private float penalty;
    [SerializeField]
    private Text debug;

    private int itemsToFind = 4;
    private float timePassed = 0;

    [SerializeField]
    private GameObject collectables;
    private List<string> itemTags;

    [SerializeField]
    private GameObject UIItems;

    private Text[] itemTexts;
    private Text[] collectablesText;
    private List<string> searchItems;
    
    [SerializeField]
    private GameObject textBalloon;
    private System.Random rand = new System.Random();

    // Use this for initialization
    void Start()
    {
        //Tried with tags. Did work in editor but not in VR Cardboard
        //collectables = GameObject.FindGameObjectWithTag("collectables");
        //UIItems = GameObject.FindGameObjectWithTag("items");
        itemTexts = UIItems.GetComponentsInChildren<Text>();
        collectablesText = collectables.GetComponentsInChildren<Text>();
        SetItemsToCollect();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timeUI.text = ConvertTime(timePassed);
        //CheckKeyPress();
    }

    private void SetItemsToCollect()
    {
        itemTags = new List<string>();
        searchItems = new List<string>();

        foreach (Text collectable in collectablesText)
        {
            itemTags.Add(collectable.text);
        }
        foreach (Text item in itemTexts)
        {
            bool itemSet = false;
            do{
                int index = rand.Next(0, itemTags.Count);
                string toCollect = itemTags[index];
                if (!searchItems.Contains(toCollect))
                {
                    item.text = toCollect;
                    itemSet = true;
                }
                itemTags.RemoveAt(index);
            }while (!itemSet) ;
            searchItems.Add(item.text);
        }
        
    }

    public void ItemCollected(string itemName, Vector3 itemPosition)
    {
        bool itemFound = false;
        foreach (Text item in itemTexts)
        {   
            if (item.text.Equals(itemName))
            {
                item.text += " FOUND";
                item.color = Color.green;
                itemsToFind--;
                itemFound = true;
                string textBalloonText = itemName + " found!";
                SetTextBalloon(itemPosition,textBalloonText,1);
            } else if (item.text.Equals(itemName + " FOUND"))
            {
                string textBalloonText = "Already collected a " + itemName;
                SetTextBalloon(itemPosition, textBalloonText, 2);
                itemFound = true;
            }
        }
        if (!itemFound)
        {
            string textBalloonText = "Wrong item " + itemName + "!";
            SetTextBalloon(itemPosition, textBalloonText, 3);
            penalty += penaltyIncrease;
            penaltyUI.text = "+" + ConvertTime(penalty);
        }
        if (itemsToFind == 0)
        {
            //Uses a Static class to store the playerstats, so you don't have to access device files
            PlayerStats.ScoreTime = ConvertTime(penalty+timePassed);
            PlayerStats.EndGame = 1;
            SceneManager.LoadScene("StartScene");
        }
    }

    private string ConvertTime(float floatTime)
    {
        string minutes = Mathf.Floor(floatTime / 60).ToString("00");
        string seconds = (floatTime % 60).ToString("00");
        return string.Format("{0}:{1}", minutes, seconds);
    }

    private void CheckKeyPress()
    {
        Event e = Event.current;
        if (e.isKey)
            debug.text = "e.keyCode: " + e.keyCode;
    }

    private void SetTextBalloon(Vector3 locationItem, string textBallonText, int itemFound)
    {
        textBalloon.transform.position = locationItem;
        Vector3 v = Camera.main.transform.position - textBalloon.transform.position;
        v.x = v.z = 0.0f;
        textBalloon.transform.LookAt(Camera.main.transform.position - v);
        textBalloon.transform.Rotate(0, 180, 0);
        textBalloon.GetComponentInChildren<Text>().text = textBallonText;
        if (itemFound == 1)
        {
            textBalloon.GetComponentInChildren<Text>().color = Color.green;
        }
        else if (itemFound == 2)
        {
            textBalloon.GetComponentInChildren<Text>().color = Color.blue;
        }
        else
        {
            textBalloon.GetComponentInChildren<Text>().color = Color.red;
        }
    }
}

