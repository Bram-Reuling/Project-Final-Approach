using System;
using GXPEngine;

class ImageButton : AnimationSprite
{
	public ImageButton(string filename, int cols, int rows) : base(filename, cols, rows)
	{
        SetOrigin(width / 2, height / 2);
	}

    void Update()
    {
    }

    public void BrighterOnHover()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(1);
        }
        else
        {
            SetFrame(0);
        }
    }

    public void BrighterOnHoverOther(string imageFile, string textFile)
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(0);
            if (Input.GetMouseButton(0))
            {
                
            }
        }
        else
        {
            SetFrame(1);
        }
    }

    public void BrighterOnHoverBack()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(0);
            if (Input.GetMouseButton(0))
            {

            }
        }
        else
        {
            SetFrame(1);
        }
    }

    public void ExitMode()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            System.Environment.Exit(0);
        }
    }
}
