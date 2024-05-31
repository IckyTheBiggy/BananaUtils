using System;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    
    private Tugboat _tugboat;

    private void Start()
    {
        if (TryGetComponent(out Tugboat _t))
            _tugboat = _t;
        else
        {
            Debug.LogError("Couldnt find tugboat");
            return;
        }
    }

    public void StartServer()
    {
        _tugboat.StartConnection(true);
        _tugboat.StartConnection(false);
        
        _ui.SetActive(false);
    }

    public void StartClient()
    {
        _tugboat.StartConnection(false);
        
        _ui.SetActive(false);
    }
}
