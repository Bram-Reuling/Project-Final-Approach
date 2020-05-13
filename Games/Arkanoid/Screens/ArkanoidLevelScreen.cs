using GXPEngine;
using TiledMapParser;
using System;
using System.Timers;

class ArkanoidLevelScreen : GameObject
{
    // Declaring variables for items Block, Player and Ball to pass in the constructor of each class
    // so that they can use eachothers methods.
    private Block _block;
    private PlayerArkanoid _player;
    private Ball _ball;

    private MainMenuScreenArkanoid _mainMenu; 
    private ArkanoidDeathScreen _deathScreen;

    MainGame _game;

    private int _maxScore; // Total points you can get per level
    private String _nextLevel; 

    private System.Timers.Timer _levelStartTimer; 

    private SoundChannel _backgroundMusicChannel;

    private bool _isLevelStarted;

    Overlay _overlay;

    public ArkanoidLevelScreen(string filename, MainGame tempGame) 
    {
        Map leveldata = MapParser.ReadMap(filename); // Reads the data of the .tmx file
        spawnObjects(leveldata); // Calls SpawnObjects method to spawn the objects from the .tmx file in the level.

        //_mainMenu = _menuInst; // Sets variable of type MainMenuScreen to an instance of the class

        // Plays an audio file as background music
        Sound backgroundMusic = new Sound("ArkanoidSounds/LevelStart.mp3", false, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.1f;
        _isLevelStarted = false;

        _game = tempGame;
    }

    void Update()
    {
        loadNewLevelOnMaxScore();

        if (_backgroundMusicChannel.IsPlaying == false)
        {
            if (!_isLevelStarted)
            {
                startLevel();
                _isLevelStarted = true;
            }
        }
    }

    private void startLevel()
    {
        // Activates the ball
        _ball.BallReset();
    }

    // Adds all the points of the blocks to _maxScore
    public void TotalScore(int _points)
    {
        _maxScore += _points;
    }

    // Spawns all the objects from the object layer from Tiled
    private void spawnObjects(Map leveldata)
    {
        if (leveldata.ObjectGroups == null || leveldata.ObjectGroups.Length == 0) // Check if there are ObjectGroups in the level data
            return;

        ObjectGroup objectGroup = leveldata.ObjectGroups[0];
        if (objectGroup.Objects == null || objectGroup.Objects.Length == 0) // Check if there are objects in the groups
            return;

        _nextLevel = objectGroup.GetStringProperty("NextLevel"); // Gives the _nextLevel variable the file name of the next level 
        Console.WriteLine(_nextLevel);
        if (_nextLevel == null)
            _nextLevel = "ArkanoidLevels/level1.tmx";

        objectCheck(objectGroup);
    }

    // Checks which object is being loaded from Tiled and creates the appropriate instance for it.
    private void objectCheck(ObjectGroup objectGroup)
    {
        foreach (TiledObject obj in objectGroup.Objects)
        {
            switch (obj.Name)
            {
                case "Player":
                    // Creating the player
                    _player = new PlayerArkanoid(obj, this);
                    //Console.WriteLine(_player);
                    AddChild(_player);
                    break;
                case "Block":
                    _block = new Block(this, obj, _player);
                    AddChild(_block);
                    break;
                case "Ball":
                    // Creating the ball
                    _ball = new Ball(_block, obj, _player);
                    AddChild(_ball);
                    _overlay = new Overlay();
                    AddChild(_overlay);
                    break;
                case "Score":
                    // Creating the HUD element: Score
                    Score score = new Score(_player, obj);
                    AddChild(score);
                    break;
                case "Lives":
                    // Creating the HUD element: Lives
                    Lives playerLives = new Lives(_player, obj);
                    AddChild(playerLives);
                    break;
            }
        }

    }

    // Loads the death screen if the player has no lives anymore
    public void LoadDeathScreen()
    {

        _game.SwitchRoom("ADeath");
        // Stops the background music
        _backgroundMusicChannel.Stop();

        // Creates new instance of DeathScreen
        //_deathScreen = new ArkanoidDeathScreen();
        //game.AddChild(_deathScreen);

        // Destroys current level
        //destroyCurrentLevel();
    }

    private void destroyCurrentLevel()
    {
        this.LateDestroy();
    }

    private void loadNewLevelOnMaxScore()
    {
        if (_player.score >= _maxScore)
        {
            _backgroundMusicChannel.Stop();
            _mainMenu.LoadNewLevel(_nextLevel);
        }
    }

    // Random generator for the power ups
    public void DroppedItem(float _xPosItem, float _yPosItem, float _rndChance)
    {
        if (_rndChance < 50)
        {
            var _rnd = new Random();
            float _randomChangeOfDrop = _rnd.Next(0, 200);
            if (_randomChangeOfDrop < 20)
            {
                PowerUpHealth _powerUpHealth = new PowerUpHealth(_xPosItem, _yPosItem);
                LateAddChild(_powerUpHealth);
            } 
            else
            {
                PowerUpLarge _powerUpLarge = new PowerUpLarge(_xPosItem, _yPosItem);
                LateAddChild(_powerUpLarge);
            }
        }
    }
}

