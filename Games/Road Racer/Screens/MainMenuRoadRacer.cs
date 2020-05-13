using System;
using System.Drawing;
using GXPEngine;

class MainMenuRoadRacer : GameObject
{
    private ImageButton _startButton;
    private ImageButton _quitButton;
    private Logo _roadRaceLogo;
    private LevelRoadRacer _level;

    private Overlay _overlay;

    private bool _isLevelLoaded;

    MainGame _game;

    public MainMenuRoadRacer(MainGame game) : base()
    {

        _roadRaceLogo = new Logo(game.width / 2, game.height / 2, "RoadRacerSprites/logo.png");
        AddChild(_roadRaceLogo);

        _startButton = new ImageButton("Road Racer Buttons/Start.png", 2, 1);
        _startButton.scale = 0.6f;
        _startButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new ImageButton("Road Racer Buttons/Exit.png", 2, 1);
        _quitButton.scale = 0.6f;
        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _overlay = new Overlay();
        AddChild(_overlay);

        _isLevelLoaded = false;

        _game = game;
    }

    void Update()
    {
        mouseInputButtons();
    }

    private void mouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("RLevel");
                //_backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
            }
        }
    }
}
