using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InputToKill : MonoBehaviour
{
    [SerializeField] List<string> words = new List<string> { "Wizard", "Enemy", "Backdoor", "TypetoKill", "Attack" };

    [SerializeField] TextMeshProUGUI wordInput;
    String palavraEscolhida;
    private string input, palavra;

    [SerializeField] Slider ManaSlider;

    float manaUsage = 10f;

    void Start()
    {
        palavra= words[Random.Range(0, words.Count)];
        input = wordInput.text;
    }

    private void Update()
    {
    }

    public void OnSubmit()
    {

        palavra = palavra.Trim().ToLower();
        input = wordInput.text.Trim((char)8203).ToLower();

        Debug.Log(($"Input : {input[input.Length-1]}"));
        Debug.Log(($"Palavra : {palavra.Length}"));



        if (input==palavra)
        {
            Debug.Log("You killed him");
        }
        else
        {
            Debug.Log("Wrong word");
        }


    }

}