using System;
using GXPEngine;

public class Shop : Sprite
{

    ImageButton _costume;
    ImageButton _giftcard;
    ImageButton _tshirt;
    ImageButton _plushie;
    ImageButton _foodVoucher;
    ImageButton _headphones;
    ImageButton _nintendoSwitch;
    ImageButton _xBox;
    ImageButton _playstation;

    ImageButton _order;
    ImageButton _back;

    ShopItem _costumeImg;
    ShopItem _giftcardImg;
    ShopItem _tShirtImg;
    ShopItem _plushieImg;
    ShopItem _foodVoucherImg;
    ShopItem _headphonesImg;
    ShopItem _nintendoImg;
    ShopItem _xBoxImg;
    ShopItem _playstationImg;

    readonly MainGame _game;

    public Shop(MainGame tempGame) : base("Sprites/ShopOverlay.png")
    {
        LoadInstances();
        LoadShopImages();

        SetPositions();

        AddToTheGame();
        AddImgToGame();

        _game = tempGame;

        SwitchProduct("Costume");
    }

    private void LoadInstances()
    {
        _costume = new ImageButton("Sprites/IngameCostume.png", 2, 1, "ShopItems/Costume.png", "", this);
        _giftcard = new ImageButton("Sprites/TenEuroGiftCard.png", 2, 1, "ShopItems/10EuroGift.png", "", this);
        _tshirt = new ImageButton("Sprites/TShirt.png", 2, 1, "ShopItems/TShirt.png", "", this);
        _plushie = new ImageButton("Sprites/Plushie.png", 2, 1, "ShopItems/Plushie.png", "", this);
        _foodVoucher = new ImageButton("Sprites/FoodDrinkVoucher.png", 2, 1, "ShopItems/FoodVoucher.png", "", this);
        _headphones = new ImageButton("Sprites/Headphones.png", 2, 1, "ShopItems/Headphones.png", "", this);
        _nintendoSwitch = new ImageButton("Sprites/NintendoSwitch.png", 2, 1, "ShopItems/Switch.png", "", this);
        _xBox = new ImageButton("Sprites/XboxOneX.png", 2, 1, "ShopItems/Xbox.png", "", this);
        _playstation = new ImageButton("Sprites/Playstation.png", 2, 1, "ShopItems/Playstation.png", "", this);

        _order = new ImageButton("Sprites/Order.png", 2, 1);
        _back = new ImageButton("Sprites/Back.png", 2, 1);
    }

    private void LoadShopImages()
    {
        _costumeImg = new ShopItem("ShopItems/Costume.png", "ShopDesc/Costume.txt");
        _giftcardImg = new ShopItem("ShopItems/10EuroGift.png", "ShopDesc/Giftcard.txt");
        _tShirtImg = new ShopItem("ShopItems/TShirt.png", "ShopDesc/TShirt.txt");
        _plushieImg = new ShopItem("ShopItems/Plushie.png", "ShopDesc/Plushie.txt");
        _foodVoucherImg = new ShopItem("ShopItems/FoodVoucher.png", "ShopDesc/FoodVoucher.txt");
        _headphonesImg = new ShopItem("ShopItems/Headphones.png", "ShopDesc/Headphones.txt");
        _nintendoImg = new ShopItem("ShopItems/Switch.png", "ShopDesc/Switch.txt");
        _xBoxImg = new ShopItem("ShopItems/Xbox.png", "ShopDesc/XBox.txt");
        _playstationImg = new ShopItem("ShopItems/Playstation.png", "ShopDesc/Playstation.txt");
    }

    private void SetPositions()
    {
        _costume.SetXY(265, 220);
        _giftcard.SetXY(265, 270);
        _tshirt.SetXY(265, 320);
        _plushie.SetXY(265, 370);
        _foodVoucher.SetXY(265, 420);
        _headphones.SetXY(265, 470);
        _nintendoSwitch.SetXY(265, 520);
        _xBox.SetXY(265, 570);
        _playstation.SetXY(265, 620);

        _order.SetXY(width - 225, height - 150);
        _back.SetXY(220, 125);
    }

    private void AddToTheGame()
    {
        AddChild(_costume);
        AddChild(_giftcard);
        AddChild(_tshirt);
        AddChild(_plushie);
        AddChild(_foodVoucher);
        AddChild(_headphones);
        AddChild(_nintendoSwitch);
        AddChild(_xBox);
        AddChild(_playstation);

        AddChild(_order);
        AddChild(_back);
    }

    private void AddImgToGame()
    {
        AddChild(_costumeImg);
        AddChild(_giftcardImg);
        AddChild(_tShirtImg);
        AddChild(_plushieImg);
        AddChild(_foodVoucherImg);
        AddChild(_headphonesImg);
        AddChild(_nintendoImg);
        AddChild(_xBoxImg);
        AddChild(_playstationImg);
    }

    void Update()
    {
        CheckForHover();
        CheckForClick();
    }

    private void CheckForHover()
    {
        _costume.BrighterOnHoverShop();
        _giftcard.BrighterOnHoverShop();
        _tshirt.BrighterOnHoverShop();
        _plushie.BrighterOnHoverShop();
        _foodVoucher.BrighterOnHoverShop();
        _headphones.BrighterOnHoverShop();
        _nintendoSwitch.BrighterOnHoverShop();
        _xBox.BrighterOnHoverShop();
        _playstation.BrighterOnHoverShop();

        _order.BrighterOnHover();
        _back.BrighterOnHover();
    }

    private void CheckForClick()
    {
        if (_back.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            _game.SwitchRoom("CloseShop");
        }
        ItemButtonsClick();

    }

    private void ItemButtonsClick()
    {
        if (_costume.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Costume");
        }
        if (_giftcard.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Giftcard");
        }
        if (_tshirt.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("TShirt");
        }
        if (_plushie.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Plushie");
        }
        if (_foodVoucher.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("FoodVoucher");
        }
        if (_headphones.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Headphones");
        }
        if (_nintendoSwitch.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Switch");
        }
        if (_xBox.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("XBox");
        }
        if (_playstation.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProduct("Playstation");
        }
    }

    public void DestroyShop()
    {
        _costume.LateDestroy();
        _giftcard.LateDestroy();
        _tshirt.LateDestroy();
        _plushie.LateDestroy();
        _foodVoucher.LateDestroy();
        _headphones.LateDestroy();
        _nintendoSwitch.LateDestroy();
        _xBox.LateDestroy();
        _playstation.LateDestroy();
    }

    private void SwitchProduct(string productToSwitchTo)
    {
        switch (productToSwitchTo)
        {
            default:
                CostumeVisible();
                break;
            case "Giftcard":
                GiftcardVisible();
                break;
            case "TShirt":
                TShirtVisible();
                break;
            case "Plushie":
                PlushieVisible();
                break;
            case "FoodVoucher":
                FoodVoucherVisible();
                break;
            case "Headphones":
                HeadphonesVisible();
                break;
            case "Switch":
                SwitchVisible();
                break;
            case "XBox":
                XBoxVisible();
                break;
            case "Playstation":
                PlaystationVisible();
                break;
        }
    }

    private void CostumeVisible()
    {
        _costumeImg.visible = true;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void GiftcardVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = true;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void TShirtVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = true;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void PlushieVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = true;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void FoodVoucherVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = true;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void HeadphonesVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = true;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void SwitchVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = true;
        _xBoxImg.visible = false;
        _playstationImg.visible = false;
    }

    private void XBoxVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = true;
        _playstationImg.visible = false;
    }

    private void PlaystationVisible()
    {
        _costumeImg.visible = false;
        _giftcardImg.visible = false;
        _tShirtImg.visible = false;
        _plushieImg.visible = false;
        _foodVoucherImg.visible = false;
        _headphonesImg.visible = false;
        _nintendoImg.visible = false;
        _xBoxImg.visible = false;
        _playstationImg.visible = true;
    }
}
