using System;
using GXPEngine;

public class Timer : GameObject
{
    private int _time;
    private readonly Action _onTimeout;

    public Timer(int time, Action onTimeout)
    {
        _time = time;
        _onTimeout = onTimeout;
    }

    public void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            _onTimeout();
            Destroy();
        }
    }
}
