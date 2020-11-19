using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class UIManagement : MonoBehaviour,IDragHandler
{
    [SerializeField]
    public Slider sb;
    public static UIManagement instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(this);}
    }
    // Start is called before the first frame update
    void Start()
    {
        Slider.SliderEvent sliderEvent = new Slider.SliderEvent();
        sb.onValueChanged.AddListener(Test);

        
    }

    void Test(float value)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
