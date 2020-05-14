using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;

class Block : AnimationSprite
{

    private int _blockHealth;
    private ArkanoidLevelScreen _level;
    private PlayerArkanoid _player;

    private bool _canBlockBeDestroyed;
    private int _points;

    private Sound _destroyableBlockSound;
    private SoundChannel _destroyableBlockChannel;

    public Block(ArkanoidLevelScreen _levelInst, TiledObject _obj, PlayerArkanoid _playerInst) : base("ArkanoidSprites/Breakout-006-A.png", 5, 5)
    {
        SetXY(_obj.X, _obj.Y);
        _blockHealth = _obj.GetIntProperty("health");

        _level = _levelInst;
        _player = _playerInst;

        Console.WriteLine(_playerInst);

        _canBlockBeDestroyed = _obj.GetBoolProperty("canBeDestroyed");
        SetFrame(_obj.GetIntProperty("type"));
        _points = _obj.GetIntProperty("points");

        _level.TotalScore(_points);

        _destroyableBlockSound = new Sound("ArkanoidSounds/BallHitBox.mp3");
    }

    void Update()
    {
        blockHealthCheck();
    }

    private void blockHealthCheck()
    {
        if (_blockHealth == 0)
        {
            //_player.score += _points;

            destroyBlock();
        }
    }

    public void GotHit()
    {
        if (_canBlockBeDestroyed)
        {
            _destroyableBlockChannel = _destroyableBlockSound.Play();
            _destroyableBlockChannel.Volume = 0.1f;
            _blockHealth--;
        }
    }

    private void destroyBlock()
    {
        _level._blocks.Remove(this);
        generatePowerUp();

        this.LateDestroy();
    }

    private void generatePowerUp()
    {
        var _rnd = new Random();

        // Generate a random value between 0 and 200
        float _randomChangeOfDrop = _rnd.Next(0, 200);
        //Console.WriteLine(_randomChangeOfDrop);

        _level.DroppedItem(this.x, this.y, _randomChangeOfDrop);
    }
}
