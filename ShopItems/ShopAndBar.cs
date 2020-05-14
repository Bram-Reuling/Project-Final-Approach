using System;
using GXPEngine;

public class ShopAndBar : Sprite
{

    private ImageButton _costume;
    private ImageButton _giftcard;
    private ImageButton _tshirt;
    private ImageButton _plushie;
    private ImageButton _foodVoucher;
    private ImageButton _headphones;
    private ImageButton _nintendoSwitch;
    private ImageButton _xBox;
    private ImageButton _playstation;

    private ImageButton _order;
    private ImageButton _backShop;

    private ShopItem _costumeImg;
    private ShopItem _giftcardImg;
    private ShopItem _tShirtImg;
    private ShopItem _plushieImg;
    private ShopItem _foodVoucherImg;
    private ShopItem _headphonesImg;
    private ShopItem _nintendoImg;
    private ShopItem _xBoxImg;
    private ShopItem _playstationImg;

    private ImageButton _beer;
    private ImageButton _cubaLibre;
    private ImageButton _juice;
    private ImageButton _margarita;
    private ImageButton _soda;
    private ImageButton _water;
    private ImageButton _wine;

    private ShopItem _beerImg;
    private ShopItem _cubaLibreImg;
    private ShopItem _juiceImg;
    private ShopItem _margaritaImg;
    private ShopItem _sodaImg;
    private ShopItem _waterImg;
    private ShopItem _wineImg;

    private ImageButton _backBar;

    readonly private MainGame _game;

    readonly private bool _isShop;

    public ShopAndBar(MainGame tempGame, bool isShop, string overlay) : base(overlay)
    {

        _isShop = isShop;
        _game = tempGame;

        if (_isShop)
        {
            LoadInstancesShop();
            LoadShopImages();
            SetPositionsShop();
            AddToTheGameShop();
            AddImgToGameShop();
            SwitchProductShop("Costume");
        }

        if (!_isShop)
        {
            LoadInstancesBar();
            LoadBarImages();
            SetPositionsBar();
            AddToTheGameBar();
            AddImgToGameBar();
            SwitchProductBar("Beer");
        }

    }

    void Update()
    {
        if (_isShop)
        {
            CheckForHoverShop();
            CheckForClickShop();
        }

        if (!_isShop)
        {
            CheckForHoverBar();
            CheckForClickBar();
        }
    }

    private void LoadInstancesBar()
    {
        _beer = new ImageButton("Sprites/Beer.png", 2, 1);
        _cubaLibre = new ImageButton("Sprites/CubaLibre.png", 2, 1);
        _juice = new ImageButton("Sprites/Juice.png", 2, 1);
        _margarita = new ImageButton("Sprites/Margarita.png", 2, 1);
        _soda = new ImageButton("Sprites/Soda.png", 2, 1);
        _water = new ImageButton("Sprites/Water.png", 2, 1);
        _wine = new ImageButton("Sprites/Wine.png", 2, 1);

        _order = new ImageButton("Sprites/Order.png", 2, 1);
        _backBar = new ImageButton("Sprites/Back.png", 2, 1);
    }

    private void LoadBarImages()
    {
        _beerImg = new ShopItem("ShopItems/Beer.png", "ShopDesc/Beer.txt");
        _cubaLibreImg = new ShopItem("ShopItems/CubaLibre.png", "ShopDesc/CubaLibre.txt");
        _juiceImg = new ShopItem("ShopItems/Juice.png", "ShopDesc/Juice.txt");
        _margaritaImg = new ShopItem("ShopItems/Margarita.png", "ShopDesc/Margarita.txt");
        _sodaImg = new ShopItem("ShopItems/Soda.png", "ShopDesc/Soda.txt");
        _waterImg = new ShopItem("ShopItems/Water.png", "ShopDesc/Water.txt");
        _wineImg = new ShopItem("ShopItems/Wine.png", "ShopDesc/Wine.txt");
    }

    private void SetPositionsBar()
    {
        _beer.SetXY(265, 220);
        _cubaLibre.SetXY(265, 270);
        _juice.SetXY(265, 320);
        _margarita.SetXY(265, 370);
        _soda.SetXY(265, 420);
        _water.SetXY(265, 470);
        _wine.SetXY(265, 520);

        _order.SetXY(width - 225, height - 150);
        _backBar.SetXY(220, 125);
    }

    private void AddToTheGameBar()
    {
        AddChild(_beer);
        AddChild(_cubaLibre);
        AddChild(_juice);
        AddChild(_margarita);
        AddChild(_soda);
        AddChild(_water);
        AddChild(_wine);

        AddChild(_order);
        AddChild(_backBar);
    }

    private void AddImgToGameBar()
    {
        AddChild(_beerImg);
        AddChild(_cubaLibreImg);
        AddChild(_juiceImg);
        AddChild(_margaritaImg);
        AddChild(_sodaImg);
        AddChild(_waterImg);
        AddChild(_wineImg);
    }

    public void DestroyBar()
    {
        _beer.LateDestroy();
        _cubaLibre.LateDestroy();
        _juice.LateDestroy();
        _margarita.LateDestroy();
        _soda.LateDestroy();
        _water.LateDestroy();
        _wine.LateDestroy();
    }

    private void SwitchProductBar(string productToSwitchTo)
    {
        switch (productToSwitchTo)
        {
            default:
                BeerVisible();
                break;
            case "CubaLibre":
                CubaLibreVisible();
                break;
            case "Juice":
                JuiceVisible();
                break;
            case "Margarita":
                MargaritaVisible();
                break;
            case "Soda":
                SodaVisible();
                break;
            case "Water":
                WaterVisible();
                break;
            case "Wine":
                WineVisible();
                break;
        }
    }

    private void BeerVisible()
    {
        _beerImg.visible = true;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = false;
        _margaritaImg.visible = false;
        _sodaImg.visible = false;
        _waterImg.visible = false;
        _wineImg.visible = false;
    }

    private void CubaLibreVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = true;
        _juiceImg.visible = false;
        _margaritaImg.visible = false;
        _sodaImg.visible = false;
        _waterImg.visible = false;
        _wineImg.visible = false;
    }

    private void JuiceVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = true;
        _margaritaImg.visible = false;
        _sodaImg.visible = false;
        _waterImg.visible = false;
        _wineImg.visible = false;
    }

    private void MargaritaVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = false;
        _margaritaImg.visible = true;
        _sodaImg.visible = false;
        _waterImg.visible = false;
        _wineImg.visible = false;
    }

    private void SodaVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = false;
        _margaritaImg.visible = false;
        _sodaImg.visible = true;
        _waterImg.visible = false;
        _wineImg.visible = false;
    }

    private void WaterVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = false;
        _margaritaImg.visible = false;
        _sodaImg.visible = false;
        _waterImg.visible = true;
        _wineImg.visible = false;
    }

    private void WineVisible()
    {
        _beerImg.visible = false;
        _cubaLibreImg.visible = false;
        _juiceImg.visible = false;
        _margaritaImg.visible = false;
        _sodaImg.visible = false;
        _waterImg.visible = false;
        _wineImg.visible = true;
    }

    private void CheckForHoverBar()
    {
        _beer.BrighterOnHoverShop();
        _cubaLibre.BrighterOnHoverShop();
        _juice.BrighterOnHoverShop();
        _margarita.BrighterOnHoverShop();
        _soda.BrighterOnHoverShop();
        _water.BrighterOnHoverShop();
        _wine.BrighterOnHoverShop();

        _order.BrighterOnHover();
        _backBar.BrighterOnHover();
    }

    private void CheckForClickBar()
    {
        if (_backBar.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            _game.SwitchRoom("CloseBar");
        }
        ItemButtonsClickBar();

    }

    private void ItemButtonsClickBar()
    {
        if (_beer.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("Beer");
        }
        if (_cubaLibre.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("CubaLibre");
        }
        if (_juice.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("Juice");
        }
        if (_margarita.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            Console.WriteLine("YEET");
            SwitchProductBar("Margarita");
        }
        if (_soda.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("Soda");
        }
        if (_water.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("Water");
        }
        if (_wine.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductBar("Wine");
        }
    }

    private void LoadInstancesShop()
    {
        _costume = new ImageButton("Sprites/IngameCostume.png", 2, 1);
        _giftcard = new ImageButton("Sprites/TenEuroGiftCard.png", 2, 1);
        _tshirt = new ImageButton("Sprites/TShirt.png", 2, 1);
        _plushie = new ImageButton("Sprites/Plushie.png", 2, 1);
        _foodVoucher = new ImageButton("Sprites/FoodDrinkVoucher.png", 2, 1);
        _headphones = new ImageButton("Sprites/Headphones.png", 2, 1);
        _nintendoSwitch = new ImageButton("Sprites/NintendoSwitch.png", 2, 1);
        _xBox = new ImageButton("Sprites/XboxOneX.png", 2, 1);
        _playstation = new ImageButton("Sprites/Playstation.png", 2, 1);

        _order = new ImageButton("Sprites/Order.png", 2, 1);
        _backShop = new ImageButton("Sprites/Back.png", 2, 1);
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

    private void SetPositionsShop()
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
        _backShop.SetXY(220, 125);
    }

    private void AddToTheGameShop()
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
        AddChild(_backShop);
    }

    private void AddImgToGameShop()
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

    private void CheckForHoverShop()
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
        _backShop.BrighterOnHover();
    }

    private void CheckForClickShop()
    {
        if (_backShop.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            _game.SwitchRoom("CloseShop");
        }
        ItemButtonsClickShop();

    }

    private void ItemButtonsClickShop()
    {
        if (_costume.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Costume");
        }
        if (_giftcard.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Giftcard");
        }
        if (_tshirt.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("TShirt");
        }
        if (_plushie.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Plushie");
        }
        if (_foodVoucher.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("FoodVoucher");
        }
        if (_headphones.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Headphones");
        }
        if (_nintendoSwitch.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Switch");
        }
        if (_xBox.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("XBox");
        }
        if (_playstation.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButton(0))
        {
            SwitchProductShop("Playstation");
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

    private void SwitchProductShop(string productToSwitchTo)
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
