using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PowerUp : Sprite
{
    private readonly Sound _powerUpSound;
    private SoundChannel _soundChannel;

    private readonly int _dropSpeed;

    public PowerUp(string _imageFileName, string _soundFileName, float _xPos, float _yPos, int _dropSpeedPowerUp) : base(_imageFileName)
    {
        this.x = _xPos;
        this.y = _yPos;
        this.scale = 0.5f;

        _dropSpeed = _dropSpeedPowerUp;

        _powerUpSound = new Sound(_soundFileName);
    }

    public void DestroyOnOutOfBounds()
    {
        MovePowerUp();

        if (y > game.height)
        {
            this.LateDestroy();
        }
    }

    public void MovePowerUp()
    {
        y += _dropSpeed;
    }

    public void PlaySoundOnCollision()
    {
        _soundChannel = _powerUpSound.Play();
        _soundChannel.Volume = 1f;
    }
}

