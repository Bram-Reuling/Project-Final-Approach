using System;
using System.Drawing;
using GXPEngine;

class DeathScreenRoad : GameObject
{
    private ImageButton _mainMenuButton;
    private ImageButton _quitButton;

    private MainMenuRoadRacer _mainMenu;
    MainGame _game;

    private DeathText _deathText;

    private bool _isMainMenuLoaded;

    private SoundChannel _backgroundMusicChannel;

    public DeathScreenRoad(MainGame tempGame) : base()
    {
        _mainMenuButton = new ImageButton("Road Racer Buttons/Menu.png", 2, 1);
        _mainMenuButton.scale = 0.6f;
        _mainMenuButton.SetXY(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new ImageButton("Road Racer Buttons/Exit.png", 2, 1);
        _quitButton.scale = 0.6f;
        _quitButton.SetXY(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150);
        AddChild(_deathText);

        _isMainMenuLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/EndLmao.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.2f;

        _game = tempGame;
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
                //toMainMenu();
                //hideMenu();
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
            _mainMenu = new MainMenuRoadRacer(game as MainGame);
            game.AddChild(_mainMenu);
            _isMainMenuLoaded = true;
            this.LateDestroy();
        }
    }
}

