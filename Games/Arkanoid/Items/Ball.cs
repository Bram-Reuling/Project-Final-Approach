using System;
using TiledMapParser;
using GXPEngine;
using GXPEngine.Core; // For Collision

class Ball : Sprite
{
    // Variables for moveSpeed of the ball. There are two variable sets for the movespeed.
    // This has to do with the timer at the beginning at the game.
    private float _moveSpeedX;
    private float _moveSpeedY;

    // I use these variables for the properties of the ball in Tiled
    private readonly int _ballSpeedX;
    private readonly int _ballSpeedY;

    // The starting X and Y position of the ball. The X and Y inherit the properties X and Y of the ball in Tiled 
    private readonly float xPos;
    private readonly float yPos;

    // Declaring the Block and Player variables, so that I can call certain methods from those to classes in the Ball Class.
    private readonly PlayerArkanoid _player;

    // Constructor that needs an instance of type Block, a TiledObject instance and a Level instance.
    // Again this is used so I can call certain methods from those classes and get property information of Ball from Tiled.
    public Ball(TiledObject _obj, PlayerArkanoid _playerInst) : base("ArkanoidSprites/ball.png", addCollider: true)
    {
        // Scales the sprite of Ball to 25% of its original width and height.
        this.scale = 0.25f;

        // Sets the X and Y pos of ball to X and Y values defined in Tiled.
        xPos = _obj.X;
        yPos = _obj.Y;
        SetXY(xPos, yPos);


        _moveSpeedX = 0;
        _moveSpeedY = 0;

        _ballSpeedX = -_obj.GetIntProperty("speedX");
        _ballSpeedY = -_obj.GetIntProperty("speedY");

        _player = _playerInst;
    }

    public void BallReset()
    {
        SetXY(xPos, yPos);
        _moveSpeedX = _ballSpeedX;
        _moveSpeedY = _ballSpeedY;
    }

    void Update()
    {
        UpdateBallPosition();

        CollisionWithWalls();
    }

    private void CollisionWithWalls()
    {
        //Collision with walls
        if (x <= 0)
        {
            _moveSpeedX *= -1;
        }

        if (x >= game.width - this.width)
        {
            _moveSpeedX *= -1;
        }

        if (y < 0)
        {
            _moveSpeedY *= -1;
        }

        if (y > game.height - this.height)
        {
            _player.MinLives();
            BallReset();
        }
    }

    private void UpdateBallPosition()
    {
        // Updating the x and y pos with the movespeed
        x += _moveSpeedX;
        y += _moveSpeedY;
    }

    void OnCollision(GameObject _other)
    {
        // Checking if the GameObject that is passing through this method is a GameObject of type Player
        if (_other is PlayerArkanoid)
        {
            //CollisionWithPlayer(_other);
            CollisionChecker(_other, false);
        }

        // Checking if the GameObject that is passing through this method is a GameObject of type Block
        if (_other is Block)
        {
            //CollisionWithBlock(_other);
            CollisionChecker(_other, true);
        }
    }

    private void CollisionChecker(GameObject _other, bool _isBlock)
    {
        Collision collWithBlockInfo = collider.GetCollisionInfo(_other.collider);

        if (collWithBlockInfo.normal.y < 0)
        {
            _moveSpeedY = -Mathf.Abs(_moveSpeedY);
        }
        else if (collWithBlockInfo.normal.x < 0)
        {
            _moveSpeedX = -Mathf.Abs(_moveSpeedX);
        }
        else if (collWithBlockInfo.normal.y > 0)
        {
            _moveSpeedY = Mathf.Abs(_moveSpeedY);

        }
        else if (collWithBlockInfo.normal.x > 0)
        {
            _moveSpeedX = Mathf.Abs(_moveSpeedX);
        }

        if (_isBlock)
        {
            Block blockHit = (Block)_other;
            blockHit.GotHit();
        }

        if (!_isBlock)
        {
            PlayerArkanoid playerHit = (PlayerArkanoid)_other;
            playerHit.GotHit();
        }
    }
}
