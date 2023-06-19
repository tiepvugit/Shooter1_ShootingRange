using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] guns;

    private void Update()
    {
        for (var i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                SetActiveGun(i);
            }
        }
    }

    private void SetActiveGun(int gunIndex)
    {
        for(var i = 0; i < guns.Length; i++)
        {
            var isActive = i == gunIndex;
            guns[i].SetActive(isActive);
            Debug.Log($"set active gun: {gunIndex}");
        }
    }
}
