using System;
using GXPEngine;

public class Timer : GameObject
{
    private int _time;
    private Action _onTimeout;

    public Timer(int time, Action onTimeout)
    {
        _time = time;
        _onTimeout = onTimeout;
    }

    public void Update()
    {
        _time -= Time.deltaTime;
        //Console.WriteLine(_time);
        if (_time <= 0)
        {
            _onTimeout();
            Destroy();
        }
    }
}
