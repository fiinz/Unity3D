using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public TMP_Dropdown dp;
    // Start is called before the first frame update
    void Start()
    {
        //clickEvent= Test;
        // dp.onValueChanged=>(int i){ Debug.Log("changed")};
        // dp.onValueChanged =clickEvent;
        dp.onValueChanged.AddListener((int value) => { Debug.Log("changed to"+value); });
        var options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData("option_1"));
        options.Add(new TMP_Dropdown.OptionData("option_2"));
        dp.options = options;
        txt.maxVisibleCharacters = 2;
     }
    void Test() { }
    // Update is called once per frame
    void Update()
    {
        
    }
}
