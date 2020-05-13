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

	public Shop() : base("Sprites/ShopOverlay.png")
	{
		LoadInstances();

		SetPositions();

		AddToTheGame();
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

	private void LoadInstances()
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
		_back = new ImageButton("Sprites/Back.png", 2, 1);
	}

	void Update()
	{
		CheckForHover();
	}

	private void CheckForHover()
	{
		_costume.BrighterOnHoverOther("","");
		_giftcard.BrighterOnHoverOther("", "");
		_tshirt.BrighterOnHoverOther("", "");
		_plushie.BrighterOnHoverOther("", "");
		_foodVoucher.BrighterOnHoverOther("", "");
		_headphones.BrighterOnHoverOther("", "");
		_nintendoSwitch.BrighterOnHoverOther("", "");
		_xBox.BrighterOnHoverOther("", "");
		_playstation.BrighterOnHoverOther("", "");

		_order.BrighterOnHoverBack();
		_back.BrighterOnHoverBack();
	}
}
