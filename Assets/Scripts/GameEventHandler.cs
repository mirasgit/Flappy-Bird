using System;
using UnityEngine;

public static class GameEventHandler 
{
    public static event Action OnFlap;
    public static event Action OnScore;
    public static event Action OnDie;

    public static void RaiseFlap()
    {
        OnFlap?.Invoke();
    }

    public static void RaiseScore()
    {
        OnScore?.Invoke();
    }

    public static void RaiseDie()
    {
        OnDie?.Invoke();
    }
}
