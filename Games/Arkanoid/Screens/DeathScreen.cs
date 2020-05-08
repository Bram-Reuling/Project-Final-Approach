using System;
using GXPEngine;

class DeathScreen : GameObject
{
    private MainMenuButton _mainMenuButton;
    private QuitButton _quitButton;

    private MainMenuScreenArkanoid _mainMenu;

    private DeathText _deathText;

    private bool _isMainMenuLoaded;

    public DeathScreen() : base()
    {
        _mainMenuButton = new MainMenuButton(game.width / 2, game.height / 2 - 50);
        AddChild(_mainMenuButton);

        _quitButton = new QuitButton(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _deathText = new DeathText(game.width / 2, game.height / 2 - 150);
        AddChild(_deathText);

        _isMainMenuLoaded = false;
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
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _quitButton.QuitGame();
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
            _mainMenu = new MainMenuScreenArkanoid();
            AddChild(_mainMenu);
            _isMainMenuLoaded = true;
        }
    }
}

