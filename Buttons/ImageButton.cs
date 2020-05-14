using System;
using GXPEngine;

class ImageButton : AnimationSprite
{

    string _productImg;
    string _productText;

	public ImageButton(string filename, int cols, int rows) : base(filename, cols, rows)
	{
        SetOrigin(width / 2, height / 2);
	}

    public ImageButton(string filename, int cols, int rows, string productImg, string productText, ShopAndBar tempshop) : base(filename, cols, rows)
    {
        SetOrigin(width / 2, height / 2);

        _productImg = productImg;
        _productText = productText;
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

    public void BrighterOnHoverShop()
    {
        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            SetFrame(0);
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
