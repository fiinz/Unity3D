using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearInput : MonoBehaviour
{
    public TMP_InputField test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            test.text = "";
        }
        
    }
}
