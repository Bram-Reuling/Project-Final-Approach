using System;
using System.Drawing;
using GXPEngine;

class ArkanoidDeathScreen : GameObject
{
    private ImageButton _mainMenuButton;
    private ImageButton _quitButton;

    private MainMenuScreenArkanoid _mainMenu;
    MainGame _game;

    private DeathText _deathText;

    private bool _isMainMenuLoaded;

    private SoundChannel _backgroundMusicChannel;

    public ArkanoidDeathScreen(MainGame tempGame) : base()
    {
        _mainMenuButton = new ImageButton("Arkanoid Buttons/Menu.png", 2, 1);
        _mainMenuButton.scale = 0.6f;
        _mainMenuButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new ImageButton("Arkanoid Buttons/Exit.png", 2, 1);
        _quitButton.scale = 0.6f;
        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150);
        AddChild(_deathText);

        _isMainMenuLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;
        _game = tempGame;
    }

    void Update()
    {
        mouseInputButtons();
        _mainMenuButton.BrighterOnHover();
        _quitButton.BrighterOnHover();
    }

    // Checks for mouse input for the buttons.
    private void mouseInputButtons()
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

