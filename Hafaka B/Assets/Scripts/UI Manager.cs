using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _viewScreen;
    [SerializeField] GameObject _workersListScreen;
    [SerializeField] GameObject _scannerScreen;
    [SerializeField] GameObject _guardScreen;
    [SerializeField] GameObject _sniperScreen;
    [SerializeField] List<Button> _buttons;

    [SerializeField] GameObject[] Panels;

    public bool IsAScreenOpen 
    { 
        get
        {
            return !_viewScreen.activeSelf;
        }
    }

    public void OpenWorkersList()
    {
        if (GameManager.Instance.IsGameOver) return;
        _workersListScreen.SetActive(true);
        _scannerScreen.SetActive(false);
        _viewScreen.SetActive(false);
        _guardScreen.SetActive(false);
        _sniperScreen.SetActive(false);
    }
    public void CloseWorkersList()
    {
        _workersListScreen.SetActive(false);
        _viewScreen.SetActive(true);
    }
    public void OpenScanner()
    {
        if (GameManager.Instance.IsGameOver) return;
        _scannerScreen.SetActive(true);
        _workersListScreen.SetActive(false);
        _guardScreen.SetActive(false);
        _sniperScreen.SetActive(false);
    }
    public void CloseScanner()
    {
        _scannerScreen.SetActive(false);
    }
    public void OpenGuard()
    {
        if (GameManager.Instance.IsGameOver) return;
        _workersListScreen.SetActive(false);
        _scannerScreen.SetActive(false);
        _sniperScreen.SetActive(false);
        _guardScreen.SetActive(true);
    }
    public void CloseGuard()
    {
        _viewScreen.SetActive(true);
        _guardScreen.SetActive(false);
    }
    public void OpenSniper()
    {
        if (GameManager.Instance.IsGameOver) return;
        _viewScreen.SetActive(false);
        _workersListScreen.SetActive(false);
        _scannerScreen.SetActive(false);
        _guardScreen.SetActive(false);
        _sniperScreen.SetActive(true);
    }
    public void CloseSniper()
    {
        _viewScreen.SetActive(true);
        _sniperScreen.SetActive(false);
    }
    public void OpenList(GameObject panel)
    {
        if (GameManager.Instance.IsGameOver) return;
        foreach (GameObject pan in Panels)
        {
            if (pan != panel && pan.active)
            { pan.SetActive(false); }
        }
        panel.SetActive(true);
    }
    public void CloseList(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void CloseAllAndDeactivate()
    {
        CloseAll();
        DeactivateAllButtons();
    }

    private void CloseAll()
    {
        CloseSniper();
        CloseGuard();
        CloseScanner();
        CloseWorkersList();
    }

    private void DeactivateAllButtons()
    {
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseAll();
        if (IsAScreenOpen) return; // a screen is already open, can't open another one unless player closes first
        if (Input.GetKeyDown(KeyCode.Alpha1))
            OpenWorkersList();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            OpenScanner();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            OpenGuard();
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            OpenSniper();
    }
}
