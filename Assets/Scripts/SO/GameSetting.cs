using System;
using UDEV.SPM;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New GameSetting", menuName = "Assets/BB/Create GameSetting")]

public class GameSetting : ScriptableObject
{
    public int ballsLimitOnScrene;
    [PoolerKeys(target = PoolerTarget.NONE)]
    public List<String> ballPoolKeys;

}
