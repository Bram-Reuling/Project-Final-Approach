using System.Drawing;
using GXPEngine;
class MainMenuButton : Button
{
    public MainMenuButton(int _xPos, int _yPos) : base(200, 50, 24, "MAIN MENU")
    {
        SetXY(_xPos, _yPos);
    }
    void Update()
    {
        BrighterOnHover();
    }
}

