using System;
using System.Drawing;
using GXPEngine;

class DeathScreenRoad : GameObject
{
    private readonly ImageButton _mainMenuButton;
    private readonly ImageButton _quitButton;
    private readonly MainGame _game;

    private readonly DeathText _deathText;


    private readonly SoundChannel _backgroundMusicChannel;

    public DeathScreenRoad(MainGame tempGame) : base()
    {
        _game = tempGame;
        _mainMenuButton = new ImageButton("Road Racer Buttons/Menu.png", 2, 1)
        {
            scale = 0.6f
        };

        _mainMenuButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new ImageButton("Road Racer Buttons/Exit.png", 2, 1)
        {
            scale = 0.6f
        };

        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150, _game.ticketsReceived);
        AddChild(_deathText);

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.2f;


    }

    void Update()
    {
        MouseInputButtons();
        _mainMenuButton.BrighterOnHover();
        _quitButton.BrighterOnHover();
    }

    // Checks for mouse input for the buttons.
    private void MouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_mainMenuButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Race");
                _backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                MainGame _game = game as MainGame;
                _game.SwitchRoom("Main");
                _backgroundMusicChannel.Stop();

                this.LateDestroy();
            }
        }
    }
}

