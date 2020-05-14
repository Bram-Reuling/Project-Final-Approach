using System;
using System.Drawing;
using GXPEngine;

class MainMenuScreenArkanoid : GameObject
{
    readonly ImageButton _startButton;
    readonly ImageButton _quitButton;
    readonly Logo _arkanoidLogo;
    readonly Overlay _overlay;

    readonly private SoundChannel _backgroundMusicChannel;

    readonly MainGame _game;
    public MainMenuScreenArkanoid(MainGame game) : base()
    {
        _arkanoidLogo = new Logo(game.width / 2, game.height / 2, "ArkanoidSprites/logo.png");
        AddChild(_arkanoidLogo);

        _startButton = new ImageButton("Arkanoid Buttons/Start.png", 2, 1)
        {
            scale = 0.6f
        };

        _startButton.SetXY(game.width / 2 - 250, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new ImageButton("Arkanoid Buttons/Exit.png", 2, 1)
        {
            scale = 0.6f
        };
        _quitButton.SetXY(game.width / 2 - 250, game.height / 2 + 50);
        AddChild(_quitButton);

        _overlay = new Overlay();
        AddChild(_overlay);

        Sound backgroundMusic = new Sound("ArkanoidSounds/MenuSound.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;

        _game = game;
    }

    void Update()
    {
        MouseInputButtons();
        _startButton.BrighterOnHover();
        _quitButton.BrighterOnHover();
    }

    // Checks for a mouse button press on the button
    private void MouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (_game.tickets - 5 > 0)
                {
                    _game.SwitchRoom("ALevelOne");
                    _backgroundMusicChannel.Stop();
                }
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
                _backgroundMusicChannel.Stop();
            }
        }
    }

#pragma warning disable IDE0060 // Remove unused parameter
    public void LoadNewLevel(String _nextLevel)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        //_level.LateDestroy();

        //_level = new ArkanoidLevelScreen(_nextLevel);
        //AddChild(_level);
    }

}
