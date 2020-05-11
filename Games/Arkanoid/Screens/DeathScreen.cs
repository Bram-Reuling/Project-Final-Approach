using System;
using GXPEngine;

class DeathScreen : GameObject
{
    private MainMenuButton _mainMenuButton;
    private QuitButton _quitButton;

    private MainMenuScreenArkanoid _mainMenu;

    private DeathText _deathText;

    private bool _isMainMenuLoaded;

    private SoundChannel _backgroundMusicChannel;

    public DeathScreen() : base()
    {
        _mainMenuButton = new MainMenuButton(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new QuitButton(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150);
        AddChild(_deathText);

        _isMainMenuLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.2f;
    }

    void Update()
    {
        mouseInputButtons();
    }

    // Checks for mouse input for the buttons.
    private void mouseInputButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_mainMenuButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                toMainMenu();
                hideMenu();
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

    private void hideMenu()
    {
        _mainMenuButton.visible = false;
        _quitButton.visible = false;
        _deathText.visible = false;
    }

    private void toMainMenu()
    {
        if (_isMainMenuLoaded == false)
        {
            _mainMenu = new MainMenuScreenArkanoid(game as MainGame);
            game.AddChild(_mainMenu);
            _isMainMenuLoaded = true;
            this.LateDestroy();
        }
    }
}

