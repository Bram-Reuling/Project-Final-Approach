using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class PowerUpHealth : PowerUp
{
    public PowerUpHealth(float xPos, float yPos) : base("checkers.png", "ArkanoidSounds/poweruphealth.wav", xPos, yPos, 2)
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

