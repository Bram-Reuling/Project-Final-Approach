using System;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{
    private CollisionPoint _pointUP;
    private CollisionPoint _pointDown;
    private CollisionPoint _pointRight;
    private CollisionPoint _pointLeft;
    private const int SPEED = 7;
    private int _moveSpeed { get; set; }
    private int _moveSpeedY { get; set; }
    private int _animationDrawsBetweenFrames { get; set; }
    private int _step { get; set; }

    Vec2 _position;
    Vec2 _oldPosition { get; set; }
    Vec2 _velocity;

    //private float _dX;
    //private float _dY;

    private float _centerX;
    private float _centerY;


    public Player(float x, float y) : base("barry.png", 7, 1)
    {
        //SetOrigin(width / 2, height / 2);
        SetXY(x, y);
        _position = new Vec2(x, y);

        _moveSpeed = 5;
        _moveSpeedY = _moveSpeed;

        _animationDrawsBetweenFrames = 32;
        _step = 0;
        _pointUP = new CollisionPoint("PointHorizontal.png", this.width / 2, -SPEED);
        _pointDown = new CollisionPoint("PointHorizontal.png", this.width / 2, this.height + SPEED);
        _pointLeft = new CollisionPoint("PointVertical.png", -SPEED, this.height / 2);
        _pointRight = new CollisionPoint("PointVertical.png", this.width + SPEED, this.height / 2);
        AddChild(_pointUP);
        AddChild(_pointDown);
        AddChild(_pointRight);
        AddChild(_pointLeft);

    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Update()
    //------------------------------------------------------------------------------------------------------------------------
    void Update()
    {

        _oldPosition = _position;

        movement();
        //updatePos();
        updateScreenPos();

        _centerX = x + width / 2;
        _centerY = y + height / 2;


        _MoveCallc();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														updatePos()
    //------------------------------------------------------------------------------------------------------------------------
    private void updatePos()
    {
        x = _position.x;
        y = _position.y;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														updateScreenPos()
    //------------------------------------------------------------------------------------------------------------------------
    private void updateScreenPos()
    {
        // Euler integration
        _position += _velocity;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														movement()
    //------------------------------------------------------------------------------------------------------------------------
    private void movement()
    {
        _velocity.x = 0;
        _velocity.y = 0;
        if (Input.GetKey(Key.A))
        {
            _velocity.x = -1;
            Mirror(true, false);
        }
        if (Input.GetKey(Key.D))
        {
            _velocity.x = 1;
            Mirror(false, false);
        }
        if (Input.GetKey(Key.W))
        {
            _velocity.y = -1;
        }
        if (Input.GetKey(Key.S))
        {
            _velocity.y = 1;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														normalizeVelocity()
    //------------------------------------------------------------------------------------------------------------------------
    private void normalizeVelocity()
    {
        // Normalize the velocity to have the same movement on diagonal as non-diagonal
        _velocity.Normalize();
        _velocity *= _moveSpeed;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														noInputCheck()
    //------------------------------------------------------------------------------------------------------------------------
    private void noInputCheck()
    {
        // If the input is nothing than don't move
        if (!Input.GetKey(Key.W) && !Input.GetKey(Key.S) && !Input.GetKey(Key.D) && !Input.GetKey(Key.A))
        {
            _velocity.x = 0;
            _velocity.y = 0;
        }

    }

    void OnCollision(GameObject _other)
    {
        if (_other is CollisionTile)
        {

            if (_other is CollisionTile)
            {
                CollisionTile colltile = _other as CollisionTile;
                if (x + width + _velocity.x * SPEED <= colltile.x + SPEED)
                {
                    _velocity.x = 0;

                }
                else if (x + _velocity.x * SPEED >= colltile.x + colltile.width - SPEED)
                {
                    _velocity.x = 0;
                }
                if (y + height + _velocity.y * SPEED <= colltile.y + SPEED)
                {
                    _velocity.y = 0;
                }
                else if (y + _velocity.y * SPEED >= colltile.y + height - SPEED)
                {
                    _velocity.y = 0;
                }
            }
        }
    }

    private void _MoveCallc()
    {
        if (_pointUP.isColliding)
        {
            if (_velocity.y < 0)
            {
                _velocity.y = 0;
            }
        }
        if (_pointDown.isColliding)
        {
            if (_velocity.y > 0)
            {
                _velocity.y = 0;
            }
        }
        if (_pointRight.isColliding)
        {
            if (_velocity.x > 0)
            {
                _velocity.x = 0;
            }
        }
        if (_pointLeft.isColliding)
        {
            if (_velocity.x < 0)
            {
                _velocity.x = 0;
            }
        }
        _pointLeft.isColliding = false;
        _pointRight.isColliding = false;
        _pointUP.isColliding = false;
        _pointDown.isColliding = false;
        x += _velocity.x * SPEED;
        y += _velocity.y * SPEED;
    }

}
