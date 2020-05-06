using System;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{

    private int _moveSpeed { get; set; }
    private int _moveSpeedY { get; set; }
    private int _animationDrawsBetweenFrames { get; set; }
    private int _step { get; set; }

    Vec2 _position;
    Vec2 _oldPosition { get; set; }
    Vec2 _velocity;


    public Player(float x, float y) : base("barry.png", 7, 1)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(x, y);
        _position = new Vec2(x, y);

        _moveSpeed = 5;
        _moveSpeedY = _moveSpeed;

        _animationDrawsBetweenFrames = 32;
        _step = 0;

    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Update()
    //------------------------------------------------------------------------------------------------------------------------
    void Update()
    {

        _oldPosition = _position;

        movement();
        updatePos();
        updateScreenPos();
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
        // UP
        if (Input.GetKey(Key.W))
        {
            _velocity.y = -_moveSpeedY;
        }

        // DOWN
        if (Input.GetKey(Key.S))
        {

            _velocity.y = _moveSpeedY;

        }

        // RIGHT
        if (Input.GetKey(Key.D))
        {

            _velocity.x = _moveSpeed;
            scaleX = 1;

        }

        // LEFT
        if (Input.GetKey(Key.A))
        {

            _velocity.x = -_moveSpeed;
            scaleX = -1;
        }

        noInputCheck();

        normalizeVelocity();
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
            //Collision collWithTile = collider.GetCollisionInfo(_other.collider);
            CollisionTile collTile = _other as CollisionTile;

            if (x + width + _velocity.x * _moveSpeed <= collTile.x + _moveSpeed)
            {
                //Console.WriteLine("TOP");
                //Console.WriteLine(collWithTile.normal.y);
                //_moveSpeedY = 0;
                _velocity.x = 0;
                Console.WriteLine("HIT");
            }
            //else if (collWithTile.normal.x < 0)
            //{
            //    //Console.WriteLine("RIGHT");
            //    //Console.WriteLine(collWithTile.normal.x);
            //    //_velocity.y = 0;

            //}
            //else if (collWithTile.normal.y > 0)
            //{
            //    //_moveSpeedY = 0;

            //}
            //else if (collWithTile.normal.x > 0)
            //{
            //    //_velocity.x = 0;
            //}
        }
    }
}
