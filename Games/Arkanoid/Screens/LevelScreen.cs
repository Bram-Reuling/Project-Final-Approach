using GXPEngine;
using TiledMapParser;
using System;
//using System.Timers;

class LevelScreen : GameObject
{
    // Declaring variables for items Block, Player and Ball to pass in the constructor of each class
    // so that they can use eachothers methods.
    private Block _block;
    private PlayerArkanoid _player;
    private Ball _ball;

    private MainMenuScreen _mainMenu; 
    private DeathScreen _deathScreen; 

    private int _maxScore; // Total points you can get per level
    private String _nextLevel; 

    //private System.Timers.Timer _levelStartTimer; 

    private SoundChannel _backgroundMusicChannel; 

    public LevelScreen(string filename, MainMenuScreen _menuInst) 
    {
        Map leveldata = MapParser.ReadMap(filename); // Reads the data of the .tmx file
        spawnObjects(leveldata); // Calls SpawnObjects method to spawn the objects from the .tmx file in the level.

        _mainMenu = _menuInst; // Sets variable of type MainMenuScreen to an instance of the class

        //----------------------------------------------------------------------------------------
        //  Creates an timer for four seconds which activates at te beginning of the level
        //  and calls the function _timerOver at the end of the timer. 
        //----------------------------------------------------------------------------------------
        //_levelStartTimer = new System.Timers.Timer(4000);
        //_levelStartTimer.Elapsed += startLevel;
        //_levelStartTimer.AutoReset = false;
        //_levelStartTimer.Enabled = true;

        // Plays an audio file as background music
        Sound backgroundMusic = new Sound("sounds/backgroundmusic2.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 0.1f;
    }

    void Update()
    {
        loadNewLevelOnMaxScore();
    }

    //private void startLevel(object sender, ElapsedEventArgs e)
    //{
    //    // Activates the ball
    //    _ball.BallReset();
    //}

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
            _nextLevel = "levels/level1.tmx";

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
        // Stops the background music
        _backgroundMusicChannel.Stop();

        // Creates new instance of DeathScreen
        _deathScreen = new DeathScreen();
        _mainMenu.AddChild(_deathScreen);

        // Destroys current level
        destroyCurrentLevel();
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

