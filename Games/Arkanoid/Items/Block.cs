using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;

class Block : AnimationSprite
{

    private int _blockHealth;
    readonly private ArkanoidLevelScreen _level;

    readonly private bool _canBlockBeDestroyed;

    readonly private Sound _destroyableBlockSound;
    private SoundChannel _destroyableBlockChannel;

    public Block(ArkanoidLevelScreen _levelInst, TiledObject _obj) : base("ArkanoidSprites/Breakout-006-A.png", 5, 5)
    {
        SetXY(_obj.X, _obj.Y);
        _blockHealth = _obj.GetIntProperty("health");

        _level = _levelInst;

        _canBlockBeDestroyed = _obj.GetBoolProperty("canBeDestroyed");
        SetFrame(_obj.GetIntProperty("type"));

        _destroyableBlockSound = new Sound("ArkanoidSounds/BallHitBox.mp3");
    }

    void Update()
    {
        BlockHealthCheck();
    }

    private void BlockHealthCheck()
    {
        if (_blockHealth == 0)
        {
            DestroyBlock();
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

    private void DestroyBlock()
    {
        _level._blocks.Remove(this);
        GeneratePowerUp();

        this.LateDestroy();
    }

    private void GeneratePowerUp()
    {
        var _rnd = new Random();

        // Generate a random value between 0 and 200
        float _randomChangeOfDrop = _rnd.Next(0, 200);
        //Console.WriteLine(_randomChangeOfDrop);

        _level.DroppedItem(this.x, this.y, _randomChangeOfDrop);
    }
}
