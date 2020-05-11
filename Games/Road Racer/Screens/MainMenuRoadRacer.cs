using System;
using GXPEngine;

class MainMenuRoadRacer : GameObject
{
    private StartButton _startButton;
    private QuitButton _quitButton;
    private Logo _roadRaceLogo;
    private LevelRoadRacer _level;

    private bool _isLevelLoaded;

    MainGame _game;

    public MainMenuRoadRacer(MainGame game) : base()
    {
        _startButton = new StartButton(game.width / 2, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new QuitButton(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

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
                startGame();
                hideMenu();
                //_backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
            }
        }
    }

    private void hideMenu()
    {
        //_arkanoidLogo.visible = false;
        _startButton.visible = false;
        _quitButton.visible = false;
    }

    private void startGame()
    {
        if (_isLevelLoaded == false)
        {
            _level = new LevelRoadRacer();
            AddChild(_level);
            _isLevelLoaded = true;
        }
    }
}
