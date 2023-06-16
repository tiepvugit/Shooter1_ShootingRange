using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextBinder : MonoBehaviour
{
    [SerializeField]
    private Text loadedAmmoText;

    public void OnLoadedAmmo(int ammo) => loadedAmmoText.text = ammo.ToString();
}
