using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class PowerUpHealth : PowerUp
{
    public PowerUpHealth(float xPos, float yPos) : base("Sprites/Ticket.png", "ArkanoidSounds/HealthBoi.mp3", xPos, yPos, 2)
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

