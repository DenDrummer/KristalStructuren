
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private float timer;
    private float waitAmount = 5f;
    private Light lt;
    private float lightStep = 1f;

    void Start()
    {
        timer = 1f;
        lt = GetComponentInChildren<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        lt.intensity += lightStep * Time.deltaTime;
        if (timer >= waitAmount)
        {
            EnterQuantumWorld();
        }
    }

    public void EnterQuantumWorld()
    {
        SceneManager.LoadScene("QuantumWorld");
    }
}
