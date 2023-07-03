using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{
    [SerializeField]
    private Image _foreground;

    //private void OnValidate() => _foreground = GetComponentsInChildren<Image>()[1];

    public void OnHealthChanged(int currentHealth, int maxhealth)
    {
        _foreground.fillAmount = (float)currentHealth / maxhealth;
    }


}
