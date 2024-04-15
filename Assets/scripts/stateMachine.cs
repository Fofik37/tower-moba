using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class stateMachine : MonoBehaviour
{
    public TMP_Text text;
    public GameObject plyaer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Gold: " + plyaer.GetComponent<Stats>().money;
        
    }
}
