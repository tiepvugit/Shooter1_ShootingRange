using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : Singleton<PlayerUi>
{
    [SerializeField]
    private List<AutoFade> _scratchs;

    public void ShowScratch(int index) => _scratchs[index].Show();

}
