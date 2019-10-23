using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_RandomColor : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        sr.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        sr.color = Random.ColorHSV(); //podemos utilizar o metodo ColorHSV() da class Random

    }
}
