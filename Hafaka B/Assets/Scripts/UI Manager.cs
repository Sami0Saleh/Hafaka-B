using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _viewScreen;
    [SerializeField] GameObject _workersListScreen;
    [SerializeField] GameObject _scannerScreen;
    [SerializeField] GameObject _guardScreen;
    [SerializeField] GameObject _sniperScreen;

    public void OpenWorkersList()
    {
        _viewScreen.SetActive(false);
        _workersListScreen.SetActive(true);
    }
    public void CloseWorkersList()
    {
        _viewScreen.SetActive(true);
        _workersListScreen.SetActive(false);
    }
    public void OpenScanner()
    {
        _viewScreen.SetActive(false);
        _scannerScreen.SetActive(true);
    }
    public void CloseScanner()
    {
        _viewScreen.SetActive(true);
        _scannerScreen.SetActive(false);
    }
    public void OpenGuard()
    {
        _viewScreen.SetActive(false);
        _guardScreen.SetActive(true);
    }
    public void CloseGuard()
    {
        _viewScreen.SetActive(true);
        _guardScreen.SetActive(false);
    }
    public void OpenSniper()
    {
        _viewScreen.SetActive(false);
        _sniperScreen.SetActive(true);
    }
    public void CloseSniper()
    {
        _viewScreen.SetActive(true);
        _sniperScreen.SetActive(false);
    }
    public void OpenList(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void CloseList(GameObject panel)
    {
        panel.SetActive(false);
    }
}
