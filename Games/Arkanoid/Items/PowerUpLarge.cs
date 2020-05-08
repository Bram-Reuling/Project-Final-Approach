using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class PowerUpLarge : PowerUp
{
    public PowerUpLarge(float xPos, float yPos) : base("circle.png", "sounds/poweruplarge.wav", xPos, yPos, 2)
    {
    }

    void Update()
    {
        MovePowerUp();
        DestroyOnOutOfBounds();
    }

    void OnCollision(GameObject other)
    {
        if (other is PlayerArkanoid)
        {
            PlaySoundOnCollision();
            this.LateDestroy();
        }
    }
}

