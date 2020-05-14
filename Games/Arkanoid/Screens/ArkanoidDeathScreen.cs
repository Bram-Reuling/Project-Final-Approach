using System;
using System.Drawing;
using GXPEngine;

public class ArkanoidDeathScreen : GameObject
{
    readonly private ImageButton _mainMenuButton;
    readonly private ImageButton _quitButton;
    readonly private MainGame _game;

    readonly private DeathText _deathText;

    readonly private SoundChannel _backgroundMusicChannel;

    public ArkanoidDeathScreen(MainGame tempGame) : base()
    {
        _game = tempGame;
        _mainMenuButton = new ImageButton("Arkanoid Buttons/Menu.png", 2, 1)
        {
            scale = 0.6f
        };

        _mainMenuButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new ImageButton("Arkanoid Buttons/Exit.png", 2, 1)
        {
            scale = 0.6f
        };

        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150, _game.ticketsReceived);
        AddChild(_deathText);

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;
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
                _game.SwitchRoom("Arkanoid");
                _backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
                _backgroundMusicChannel.Stop();

                this.LateDestroy();
            }
        }
    }
}

