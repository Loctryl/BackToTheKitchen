using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISocketable
{
    void SocketOn();
    void SocketOff();
}

public class Sockatable : MonoBehaviour, ISocketable
{
    [SerializeField] private UnityEvent socketOn;
    [SerializeField] private UnityEvent socketOff;
    
    public void SocketOn()
    {
        socketOn.Invoke();
    }

    public void SocketOff()
    {
        socketOff.Invoke();
    }
}
