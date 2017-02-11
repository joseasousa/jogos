using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;

public class SceneLoad : MonoBehaviour
{

    public Button[] butons;
    private int currentSene;

    // Use this for initialization
    void Start()
    {
        
        currentSene = PlayerPrefs.GetInt("fase", 0);
        butons[currentSene].image.color = new Color(0, 255, 0);
    }

    void Update()
    {
        if (Input.GetKey("m"))
        {
            PlayerPrefs.SetInt("fase", 0);    
        }

    }
	
}
