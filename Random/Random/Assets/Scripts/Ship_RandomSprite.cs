using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ship_RandomSprite : MonoBehaviour
{
    private float vx;
    private float vy;
    private SpriteRenderer sr;
    [Header("Sprites To Random")]
    [Tooltip("Drag Sprites to this Array")]
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); //reference to SpriteRenderer
        vx = Random.Range(-10, 10); //random velcocity X
        vy = Random.Range(-10, 10); //random velcocity Y

    }
    [MenuItem("MyMenu/RandomTest")] //u could test this function by going to the menu window
    public void RandomTest()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
        //time.deltatime compensa o framerate das maquinas

    }
}
