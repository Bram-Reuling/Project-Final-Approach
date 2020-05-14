using GXPEngine;
using System.Drawing;
public class QuitButton : Button
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
        // TODO: make this go back to the main hub
        System.Environment.Exit(0);
    }
}