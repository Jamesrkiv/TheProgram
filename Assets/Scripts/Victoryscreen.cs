using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoryscreen : MonoBehaviour

    
{
    public GameObject boss;

    public GameObject victoryText;

    public GameObject victoryButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
        {
            victoryButton.SetActive(true);
            victoryText.SetActive(true);
        }
    }
}
