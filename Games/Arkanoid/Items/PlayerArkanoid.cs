using System;
using TiledMapParser;
//using System.Timers;
using GXPEngine;

class PlayerArkanoid : Sprite
{
    private int _moveSpeedPlayer;

    public int score;
    private int _lives;

    private LevelScreen _level;

    public PlayerArkanoid(TiledObject _obj, LevelScreen _levelInst) : base("assets/paddle.png")
    {
        this.scale = 0.2f;
        SetXY(_obj.X, _obj.Y);
        _moveSpeedPlayer = 12;

        _lives = _obj.GetIntProperty("lives");

        score = 0;

        _level = _levelInst;
    }

    void Update()
    {
        livesCheck();
        playerMove();
    }

    private void playerMove()
    {
        //Movement of Player

        //If the input is LEFT KEY then move left
        if (Input.GetKey(Key.LEFT))
        {
            x -= _moveSpeedPlayer;
        }

        //If the input is RIGHT KEY then move right
        if (Input.GetKey(Key.RIGHT))
        {
            x += _moveSpeedPlayer;
        }

        //Collision with walls
        if (x <= 0)
        {
            x = 0;
        }

        if (x >= game.width - this.width)
        {
            x = game.width - this.width;
        }
    }

    private void livesCheck()
    {
        if (_lives == 0)
        {
            _level.LoadDeathScreen();

        }
    }

    public int Lives()
    {
        return _lives;
    }

    public void MinLives()
    {
        _lives--;
    }

    public void PlusLives()
    {
        _lives++;
    }

    // Returns the height of player sprite
    public float Height()
    {
        return this.height;
    }

    // Returns the width of player sprite
    public float Width()
    {
        return this.width;
    }

    // Code for collisions with powerups
    void OnCollision(GameObject other)
    {
        if (other is PowerUpLarge)
        {
            this.scaleX = 0.3f;

            // Timer
            //System.Timers.Timer _powerUpTimer = new System.Timers.Timer(10000);
            //_powerUpTimer.Elapsed += timerOver;
            //_powerUpTimer.AutoReset = false;
            //_powerUpTimer.Enabled = true;
        } 
        else if (other is PowerUpHealth)
        {
            if (_lives < 3)
            {
                PlusLives();
            }
        }
    }

    //private void timerOver(object sender, ElapsedEventArgs e)
    //{
    //    this.scaleX = 0.2f;
    //}
}

