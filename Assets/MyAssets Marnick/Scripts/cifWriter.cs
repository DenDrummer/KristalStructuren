using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class cifWriter : MonoBehaviour {
    [SerializeField]
    private TextAsset cifFile;
    [SerializeField]
    private GameObject startSceneManager;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickElement()
    {
        string path = Application.persistentDataPath + "/" + cifFile.name + ".txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, cifFile.text);
        }
        UserStats.Cif = path;
        startSceneManager.GetComponent<StartSceneManager>().enabled = true;
    }
}
