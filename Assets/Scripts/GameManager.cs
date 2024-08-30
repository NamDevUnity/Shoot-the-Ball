using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GunController m_gunPrefab;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        ViewPortUtil.GetWorldPos();
        //Instantiate(m_gunPrefab);
    }
}
