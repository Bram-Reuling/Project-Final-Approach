using System;
using GXPEngine;

class MainMenuScreenArkanoid : GameObject
{
    StartButton _startButton;
    QuitButton _quitButton;
    Logo _arkanoidLogo;

    private SoundChannel _backgroundMusicChannel;

    private LevelScreen _level;
    private String _levelFileName = "ArkanoidLevels/level1.tmx";

    private bool _isLevelLoaded;
    public MainMenuScreenArkanoid() : base()
    {
        _arkanoidLogo = new Logo(game.width / 2, game.height / 2 - 200);
        AddChild(_arkanoidLogo);

        _startButton = new StartButton(game.width / 2, game.height / 2 - 50);
        AddChild(_startButton);

        _quitButton = new QuitButton(game.width / 2, game.height / 2 + 50);
        AddChild(_quitButton);

        _isLevelLoaded = false;

        Sound backgroundMusic = new Sound("ArkanoidSounds/backgroundmusic.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.1f;
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
                _quitButton.QuitGame();
            }
        }
    }

    private void hideMenu()
    {
        _arkanoidLogo.visible = false;
        _startButton.visible = false;
        _quitButton.visible = false;
    }

    private void startGame()
    {
        if (_isLevelLoaded == false)
        {
            _level = new LevelScreen(_levelFileName, this);
            AddChild(_level);
            _isLevelLoaded = true;
        }
    }

    public void LoadNewLevel(String _nextLevel)
    {
        _level.LateDestroy();

        _level = new LevelScreen(_nextLevel, this);
        AddChild(_level);
    }

}
