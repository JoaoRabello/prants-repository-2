using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField] private List<MenuWindow> _menuWindows = new List<MenuWindow>();

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
    
    public void OpenWindow(string windowName)
    {
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

    public void BackToMainMenu()
    {
        Instance.OpenWindow("mainMenu");
    }
}
