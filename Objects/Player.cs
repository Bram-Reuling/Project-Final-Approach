using System;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{
    private readonly CollisionPoint _pointUP;
    private readonly CollisionPoint _pointDown;
    private readonly CollisionPoint _pointRight;
    private readonly CollisionPoint _pointLeft;
    private const int SPEED = 3;
    private int moveSpeed;

    private bool _dance;

    private int GetMoveSpeed()
    {
        return moveSpeed;
    }

    private void SetMoveSpeed(int value)
    {
        moveSpeed = value;
    }

    private int AnimationDrawsBetweenFrames { get; set; }
    private int Step { get; set; }

    private Vec2 _position;
    private Vec2 oldPosition;

    private Vec2 GetOldPosition()
    {
        return oldPosition;
    }

    private void SetOldPosition(Vec2 value)
    {
        oldPosition = value;
    }

    private Vec2 _velocity;

    private readonly MainGame _game;

    private bool _activityIsLoading;
    Hub _hub;

    public Player(float x, float y, MainGame tempGame, Hub _tempHub) : base("Sprites/Packy.png", 6, 18)
    {
        SetXY(x, y);
        _position = new Vec2(x, y);

        SetMoveSpeed(5);

        AnimationDrawsBetweenFrames = 3;
        Step = 0;
        _pointUP = new CollisionPoint("PointHorizontal.png", this.width / 2, SPEED);
        _pointDown = new CollisionPoint("PointHorizontal.png", this.width / 2, this.height + SPEED);
        _pointLeft = new CollisionPoint("PointVertical.png", SPEED, this.height / 2 + SPEED);
        _pointRight = new CollisionPoint("PointVertical.png", this.width - SPEED, this.height / 2 + SPEED);
        AddChild(_pointUP);
        AddChild(_pointDown);
        AddChild(_pointRight);
        AddChild(_pointLeft);

        SetFrame(0);

        _game = tempGame;

        _activityIsLoading = false;

        _hub = _tempHub;

        _dance = false;

    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Update()
    //------------------------------------------------------------------------------------------------------------------------
    void Update()
    {

        SetOldPosition(_position);

        movement();
        updateScreenPos();
        noInputCheck();
        moveCalc();

        _hub._aArkanoid.visible = false;
        _hub._aRoadRacer.visible = false;
        _hub._dance.visible = false;
        _hub._shopBox.visible = false;
        _hub._barBox.visible = false;
        _hub._noTickets.visible = false;

        danceAnim();
    }

    private void danceAnim()
    {
        if (Input.GetKey(Key.R) && _dance == false)
        {
            _dance = true;
        }

        if (_dance)
        {
            Step++;
            if (Step > AnimationDrawsBetweenFrames)
            {
                if (currentFrame <= 41 || currentFrame >= 105)
                {
                    SetFrame(42);
                }

                if (currentFrame >= 42 && currentFrame <= 105)
                {
                    NextFrame();
                    Step = 0;
                }
            }
        }
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
            WalkAnimLeftRight();
            _dance = false;
        }
        if (Input.GetKey(Key.D))
        {
            _velocity.x = 1;
            WalkAnimLeftRight();
            Mirror(true, false);
            _dance = false;
        }
        if (Input.GetKey(Key.W))
        {
            _velocity.y = -1;
            WalkAnimUp();
            _dance = false;
        }
        if (Input.GetKey(Key.S))
        {
            _velocity.y = 1;
            WalkAnimDown();
            _dance = false;
        }

        normalizeVelocity();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														WalkAnimUp()
    //------------------------------------------------------------------------------------------------------------------------
    private void WalkAnimUp()
    {
        if (currentFrame < 30 || currentFrame > 40)
        {
            SetFrame(30);
        }

        if (currentFrame <= 41 && currentFrame > 29)
        {
            Step++;
            if (Step > AnimationDrawsBetweenFrames)
            {
                NextFrame();
                Step = 0;
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														WalkAnimDown()
    //------------------------------------------------------------------------------------------------------------------------
    private void WalkAnimDown()
    {
        if (currentFrame < 18 || currentFrame > 28)
        {
            SetFrame(18);
        }

        if (currentFrame <= 29 && currentFrame > 17)
        {
            Step++;
            if (Step > AnimationDrawsBetweenFrames)
            {
                NextFrame();
                Step = 0;
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														WalkAnimLeftRight()
    //------------------------------------------------------------------------------------------------------------------------
    private void WalkAnimLeftRight()
    {
        Mirror(false, false);
        if (currentFrame < 6 || currentFrame > 16)
        {
            SetFrame(6);
        }

        if (currentFrame <= 17 && currentFrame > 5)
        {
            Step++;
            if (Step > AnimationDrawsBetweenFrames)
            {
                NextFrame();
                Step = 0;
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														normalizeVelocity()
    //------------------------------------------------------------------------------------------------------------------------
    private void normalizeVelocity()
    {
        // Normalize the velocity to have the same movement on diagonal as non-diagonal
        _velocity.Normalize();
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
            if (!_dance)
            {
                if (currentFrame <= 5)
                {
                    Step++;
                    if (Step > AnimationDrawsBetweenFrames)
                    {
                        NextFrame();
                        Step = 0;
                    }
                }
                if (currentFrame > 5)
                {
                    SetFrame(0);
                }
            }
        }

    }

    //------------------------------------------------------------------------------------------------------------------------
    //														OnCollision()
    //------------------------------------------------------------------------------------------------------------------------
    void OnCollision(GameObject _other)
    {
        collisionTile(_other);
        collisionDoor(_other);
        collisionActivity(_other);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														collisionDoor()
    //------------------------------------------------------------------------------------------------------------------------
    private void collisionDoor(GameObject other)
    {
        if (other is DoorTile)
        {
            DoorTile dTile = other as DoorTile;
            _game.SwitchRoom(dTile.Goto);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														collisionActivity()
    //------------------------------------------------------------------------------------------------------------------------
    private void collisionActivity(GameObject other)
    {
        if (other is ActivityTile)
        {
            ActivityTile aTile = other as ActivityTile;

            string activity = aTile.Activity;

            ShowActivityBox(activity);

            if (Input.GetKey('E'))
            {
                if (!_activityIsLoading)
                {
                    _game.SwitchRoom(activity);
                    _activityIsLoading = true;
                }
            }

            if (!Input.GetKey('E'))
            {
                _activityIsLoading = false;
            }

        }
    }

    private void ShowActivityBox(string activity)
    {
        if (activity == "Arkanoid")
        {
            if (_game.tickets - 5 > 0)
            {
                _hub._aArkanoid.visible = true;
            }
            else
            {
                _hub._noTickets.visible = true;
            }
        }

        if (activity == "Race")
        {
            if (_game.tickets - 5 > 0)
            {
                _hub._aRoadRacer.visible = true;
            }
            else
            {
                _hub._noTickets.visible = true;
            }
        }

        if (activity == "Dance")
        {
            _hub._dance.visible = true;
        }

        if (activity == "OpenShop")
        {
            _hub._shopBox.visible = true;
        }

        if (activity == "OpenBar")
        {
            _hub._barBox.visible = true;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														collisionTile()
    //------------------------------------------------------------------------------------------------------------------------
    private void collisionTile(GameObject _other)
    {
        if (_other is CollisionTile)
        {
            CollisionTile colltile = _other as CollisionTile;
            ResolveCollision(colltile);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														ResolveCollision()
    //------------------------------------------------------------------------------------------------------------------------
    private void ResolveCollision(CollisionTile colltile)
    {
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

    //------------------------------------------------------------------------------------------------------------------------
    //														moveCalc()
    //------------------------------------------------------------------------------------------------------------------------
    private void moveCalc()
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
        movingStuff();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														movingStuff()
    //------------------------------------------------------------------------------------------------------------------------
    private void movingStuff()
    {
        _pointLeft.isColliding = false;
        _pointRight.isColliding = false;
        _pointUP.isColliding = false;
        _pointDown.isColliding = false;
        x += _velocity.x * SPEED;
        y += _velocity.y * SPEED;
    }
}
