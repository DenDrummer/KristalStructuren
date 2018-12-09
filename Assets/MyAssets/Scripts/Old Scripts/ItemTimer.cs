using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTimer : MonoBehaviour {
    private float timer;
    [SerializeField]
    private Transform RadialProgress;
    [SerializeField]
    private float waitAmount = 3;
    [SerializeField]
    private GameObject gameController;
    private GameManager gameManager;

    void Start()
    {
        timer = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = timer;
        gameManager = gameController.GetComponent<GameManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        RadialProgress.GetComponent<Image>().fillAmount = timer / waitAmount;
        if (timer >= waitAmount)
        {
            Reset();
            CollectItem();
        }
    }

    public void Reset()
    {
        timer = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = timer;
    }

    private void CollectItem()
    {
        //Tried with 'gameObject.tag'. Did work in editor but not in VR Cardboard
        gameManager.ItemCollected(gameObject.GetComponent<Text>().text,gameObject.transform.position);
        gameObject.SetActive(false);
    }
}
