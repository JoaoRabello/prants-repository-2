using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private GameObject _windowHolder;
    [SerializeField] private Transform _windowParent;
    
    public int Id;
    public string Name;

    public void TurnOn(bool value)
    {
        _windowHolder.SetActive(value);
    }
}
