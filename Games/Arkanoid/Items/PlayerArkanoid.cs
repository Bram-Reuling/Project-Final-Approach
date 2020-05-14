using System;
using TiledMapParser;
using System.Timers;
using GXPEngine;

class PlayerArkanoid : Sprite
{
    readonly private int _moveSpeedPlayer;

    public int score;
    private int _lives;

    readonly private ArkanoidLevelScreen _level;

    readonly private Sound _playerHitSound;
    private SoundChannel _playerHitChannel;

    readonly MainGame _game;

    public PlayerArkanoid(TiledObject _obj, ArkanoidLevelScreen _levelInst, MainGame tempGame) : base("ArkanoidSprites/paddle.png")
    {
        this.scale = 0.2f;
        SetXY(_obj.X, _obj.Y);
        _moveSpeedPlayer = 12;

        _lives = _obj.GetIntProperty("lives");

        score = 0;

        _level = _levelInst;

        _playerHitSound = new Sound("ArkanoidSounds/BallHitPaddle.mp3");

        _game = tempGame;
        _game.ticketsReceived = 0;
    }

    void Update()
    {
        LivesCheck();
        PlayerMove();
    }

    private void PlayerMove()
    {
        //Movement of Player

        //If the input is LEFT KEY then move left
        if (Input.GetKey(Key.A))
        {
            x -= _moveSpeedPlayer;
        }

        //If the input is RIGHT KEY then move right
        if (Input.GetKey(Key.D))
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

    private void LivesCheck()
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

            LateAddChild(new Timer(10000, TimerOver));
        } 
        else if (other is PowerUpHealth)
        {
            if (_lives < 3)
            {
                PlusLives();
            }

            _game.AddTickets(5);
            _game.ticketsReceived += 5;
        }
    }

    private void TimerOver()
    {
        this.scaleX = 0.2f;
    }

    public void GotHit()
    {
        _playerHitChannel = _playerHitSound.Play();
        _playerHitChannel.Volume = 1f;
    }
}

