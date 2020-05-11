using System;
using GXPEngine;

class MainMenuScreenArkanoid : GameObject
{
    StartButton _startButton;
    QuitButton _quitButton;
    Logo _arkanoidLogo;
    Overlay _overlay;

    private SoundChannel _backgroundMusicChannel;

    private LevelScreen _level;
    private String _levelFileName = "ArkanoidLevels/level1.tmx";

    private bool _isLevelLoaded;

    MainGame _game;
    public MainMenuScreenArkanoid(MainGame game) : base()
    {
        _arkanoidLogo = new Logo(game.width / 2, game.height / 2);
        AddChild(_arkanoidLogo);

        _startButton = new StartButton(game.width / 2 - 250, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new QuitButton(game.width / 2 - 250, game.height / 2 + 50);
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
                startGame();
                hideMenu();
                _backgroundMusicChannel.Stop();
            }
            else if (_quitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _game.SwitchRoom("Main");
                _backgroundMusicChannel.Stop();
            }
        }
    }

    private void hideMenu()
    {
        _arkanoidLogo.visible = false;
        _startButton.visible = false;
        _quitButton.visible = false;
        _overlay.visible = false;
    }

    private void startGame()
    {
        if (_isLevelLoaded == false)
        {

            _level = new LevelScreen(_levelFileName, this);
            game.AddChild(_level);
            _isLevelLoaded = true;

            this.LateDestroy();
        }
    }

    public void LoadNewLevel(String _nextLevel)
    {
        _level.LateDestroy();

        _level = new LevelScreen(_nextLevel, this);
        AddChild(_level);
    }

}
