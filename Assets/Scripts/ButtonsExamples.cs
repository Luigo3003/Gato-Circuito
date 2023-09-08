using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsExamples : MonoBehaviour
{
    public GameObject Button;
    void Start()
    {
      
    }
    void Update()
    {
        
    }

    public void Speak(string text)
    {
        print(text);
    }
    public void ChangeColor()
    {
        Button.GetComponent<Image>().color = Color.red;
    }

}
