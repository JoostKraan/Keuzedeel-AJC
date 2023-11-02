using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float speed;
    private int index;
    
    
    void Start()
    {
        textComp.text = string.Empty;


    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLines());
    }
    IEnumerator TypeLines()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLines());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }

        }
    }
    
}
