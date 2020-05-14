using GXPEngine;
using System.Drawing;
public class StartButton : Button
{
    public StartButton(int _xPos, int _yPos) : base(200, 50, 24, "START")
    {
        SetXY(_xPos, _yPos);
    }

    void Update()
    {
        BrighterOnHover();
    }
}

