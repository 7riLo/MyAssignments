using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerZoneAddScore : MonoBehaviour
{

    private UIManager uIManager;

    private bool triggered = false;


    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {

            triggered = true;
            //would not work with lowercare uIManager variable, so this is a work around.
            UIManager.score++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
