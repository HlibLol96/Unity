using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour , IHpBar
{
    private HpBarPresenter _presenter;
    [SerializeField] private GameObject thirstBar;
    [SerializeField] private GameObject hungerBar;
    [SerializeField] private GameObject hpBar;
    private Image hpImage;
    private Image hungerImage;
    private Image thirstImage;

    void Start()
    {
        hpImage = hpBar.GetComponent<Image>();
        hungerImage = hungerBar.GetComponent<Image>();
        thirstImage = thirstBar.GetComponent<Image>();
        _presenter = new HpBarPresenter(this);
        StartCoroutine(NaturalProhibition());
        Debug.Log(Time.deltaTime);
    }
    void Update()
    { 
        ChangeBusEvent?.Invoke();
    }

    public event Action ChangeBusEvent;
    public event Action<float, float> SmallerStuff;

    public void Initialize(float hp, float hunger, float thirst)
    {
        hpImage.fillAmount = hp ;
        hungerImage.fillAmount = hunger ;
        thirstImage.fillAmount = thirst;
    }

    private IEnumerator NaturalProhibition()
    {
        while (true)
        {
            //hungerImage.fillAmount -= 0.05f / 100;
            //thirstImage.fillAmount -= 0.05f / 100;
            SmallerStuff.Invoke(0.05f,0.05f);
            yield return null;
            
        }
    }
}
