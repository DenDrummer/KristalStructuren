using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerButtonManager : MonoBehaviour {

    private float timer;
    [SerializeField]
    private Transform RadialProgress;
    [SerializeField]
    private float waitAmount = 3;

    void Start()
    {
        timer = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = timer;
    }

    void Update()
    {
        timer += Time.deltaTime;
        RadialProgress.GetComponent<Image>().fillAmount = timer/waitAmount;
        if (timer >= waitAmount)
        {
            ChangeScene();
        }
    }

    public void Reset()
    {
        timer = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = timer;
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
