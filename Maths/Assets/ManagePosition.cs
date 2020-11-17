using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePosition : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var a = GetComponent<RectTransform>();
        a.anchoredPosition = new Vector2(200, 200);
        a.position = new Vector2(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
