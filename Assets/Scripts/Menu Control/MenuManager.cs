using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private CurrentCharacter _currentCharacter;
    [SerializeField] private List<MenuWindow> _menuWindows = new List<MenuWindow>();

    private string _activeMenuName;
    private string _lastMenuName;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _activeMenuName = "loading";
    }

    public void OpenWindow(string windowName)
    {
        _lastMenuName = _activeMenuName;
        _activeMenuName = windowName;
        
        WindowTurnOn(windowName, true);
    }
    
    public void CloseWindow(string windowName)
    {
        WindowTurnOn(windowName, false);
    }

    private void WindowTurnOn(string windowName, bool value)
    {
        var windowsToTurnInverse = _menuWindows.Where(windowToFind => !windowName.Equals(windowToFind.Name));
        var window = _menuWindows.Find(windowToFind => windowName.Equals(windowToFind.Name));
        
        window.TurnOn(value);
        
        foreach (var w in windowsToTurnInverse)
        {
            w.TurnOn(!value);
        }
    }
    
    public void OpenRoomCreationMenu()
    {
        Instance.OpenWindow("createRoom");
    }

    public void OpenCharacterSelectionMenu()
    {
        Instance.OpenWindow("characterMenu");
    }

    public void OpenRoomListMenu()
    {
        Instance.OpenWindow("findRoom");
    }

    public void Back()
    {
        Instance.OpenWindow(_lastMenuName);
        
        if(_lastMenuName == "characterMenu")
            _photonView.RPC("SetPlayerCharacterInfo", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.NickName, _currentCharacter.Info.Name);
    }
    
    public void BackToMainMenu()
    {
        Instance.OpenWindow("mainMenu");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
