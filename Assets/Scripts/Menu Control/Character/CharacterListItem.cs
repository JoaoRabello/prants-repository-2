using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _characterNameLabel;
    [SerializeField] private TMP_Text _characterDetailsLabel;
    [SerializeField] private CharacterInfo _characterInfo;

    private void Start()
    {
        _characterNameLabel.text = _characterInfo.Name;
    }
}
