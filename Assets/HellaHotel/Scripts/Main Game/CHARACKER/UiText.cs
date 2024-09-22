using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI text;
    int number = 0;
    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Upbutton();  
    }
    public void Upbutton()
    {
        Debug.Log("Up");
        number++;
        text.text = number.ToString();
    }
    public void Downbutton()
    {
        Debug.Log("Down");
        number--;
        text.text = number.ToString();
    }


}
