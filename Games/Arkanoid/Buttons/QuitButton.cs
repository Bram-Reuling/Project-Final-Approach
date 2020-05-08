using GXPEngine;
using System.Drawing;
class QuitButton : Button
{
    public QuitButton(int _xPos, int _yPos) : base (200, 50, 24, "QUIT")
    {
        SetXY(_xPos, _yPos);
    }

    void Update()
    {
        BrighterOnHover();
    }

    public void QuitGame()
    {
        System.Environment.Exit(0);
    }
}