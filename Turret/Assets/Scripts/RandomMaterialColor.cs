using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialColor : MonoBehaviour
{
    private Renderer myRenderer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.SetColor("_Color", Random.ColorHSV());

    }
    private void OnDisable()
    {

        myRenderer.material.SetColor("_Color", Color.black);

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
