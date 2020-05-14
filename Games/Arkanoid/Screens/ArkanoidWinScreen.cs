using System;
using System.Drawing;
using GXPEngine;

class ArkanoidWinScreen : GameObject
{
    private ImageButton _mainMenuButton;
    private ImageButton _quitButton;

    private MainMenuScreenArkanoid _mainMenu;
    MainGame _game;

    private WinText _winText;

    private bool _isMainMenuLoaded;

    private SoundChannel _backgroundMusicChannel;

    public ArkanoidWinScreen(MainGame tempGame) : base()
    {
        _game = tempGame;
        _mainMenuButton = new ImageButton("Arkanoid Buttons/Menu.png", 2, 1);
        _mainMenuButton.scale = 0.6f;
        _mainMenuButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new ImageButton("Arkanoid Buttons/Exit.png", 2, 1);
        _quitButton.scale = 0.6f;
        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _winText = new WinText(game.width / 2, game.height / 2 - 150, _game.ticketsReceived);
        AddChild(_winText);

        _isMainMenuLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;
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

