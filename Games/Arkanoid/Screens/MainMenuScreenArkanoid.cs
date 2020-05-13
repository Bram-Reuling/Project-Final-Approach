using System;
using System.Drawing;
using GXPEngine;

class MainMenuScreenArkanoid : GameObject
{
    ImageButton _startButton;
    ImageButton _quitButton;
    Logo _arkanoidLogo;
    Overlay _overlay;

    private SoundChannel _backgroundMusicChannel;

    private ArkanoidLevelScreen _level;
    private String _levelFileName = "ArkanoidLevels/level1.tmx";

    private bool _isLevelLoaded;

    MainGame _game;
    public MainMenuScreenArkanoid(MainGame game) : base()
    {
        _arkanoidLogo = new Logo(game.width / 2, game.height / 2, "ArkanoidSprites/logo.png");
        AddChild(_arkanoidLogo);

        _startButton = new ImageButton("Arkanoid Buttons/Start.png", 2, 1);
        _startButton.scale = 0.6f;
        _startButton.SetXY(game.width / 2 - 250, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new ImageButton("Arkanoid Buttons/Exit.png", 2, 1);
        _quitButton.scale = 0.6f;
        _quitButton.SetXY(game.width / 2 - 250, game.height / 2 + 50);
        AddChild(_quitButton);

        _overlay = new Overlay();
        AddChild(_overlay);

        _isLevelLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/MenuSound.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.2f;

        _game = game;
    }

    void Update()
    {
        mouseInputButtons();
    }

    // Checks for a mouse button press on the button
    private void mouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("ALevelOne");
                _backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
                _backgroundMusicChannel.Stop();
            }
        }
    }

    public void LoadNewLevel(String _nextLevel)
    {
        //_level.LateDestroy();

        //_level = new ArkanoidLevelScreen(_nextLevel);
        //AddChild(_level);
    }

}
