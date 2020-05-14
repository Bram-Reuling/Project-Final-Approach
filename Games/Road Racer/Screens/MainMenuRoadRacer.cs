using System;
using System.Drawing;
using GXPEngine;

class MainMenuRoadRacer : GameObject
{
    readonly private ImageButton _startButton;
    readonly private ImageButton _quitButton;
    readonly private Logo _roadRaceLogo;

    readonly private Overlay _overlay;

    readonly MainGame _game;

    public MainMenuRoadRacer(MainGame game) : base()
    {

        _roadRaceLogo = new Logo(game.width / 2, game.height / 2, "RoadRacerSprites/logo.png");
        AddChild(_roadRaceLogo);

        _startButton = new ImageButton("Road Racer Buttons/Start.png", 2, 1)
        {
            scale = 0.6f
        };

        _startButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new ImageButton("Road Racer Buttons/Exit.png", 2, 1)
        {
            scale = 0.6f
        };

        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _overlay = new Overlay();
        AddChild(_overlay);

        _game = game;
    }

    void Update()
    {
        MouseInputButtons();
        _startButton.BrighterOnHover();
        _quitButton.BrighterOnHover();
    }

    private void MouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (_game.tickets - 5 > 0)
                {
                    _game.SwitchRoom("RLevel");
                    //_backgroundMusicChannel.Stop();
                }
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
            }
        }
    }
}
