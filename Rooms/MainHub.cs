using GXPEngine;
using TiledMapParser;

class MainHub : Hub
{

	private string FileName { get; set; }
	public bool FirstInstance { get; set; }

	private readonly bool _displayTut;

	private ConversationBox _c;
	private readonly MainGame _game;
	private readonly TicketDisplay _tickets;
	private readonly Clock _clock;
	private readonly ShopKeeper _shopKeeper;

	ShopAndBar _shop;

	public MainHub(MainGame tempGame) : base("Sprites/MainHub.png", 32, 24, "Sprites/MainHub.png", 32, 24, "colors.png", 1, 1, tempGame)
	{
		FileName = @"Screens/MainHub/MainHub.tmx";

		Map _levelData = MapParser.ReadMap(FileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData, true);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		_game = tempGame;
		_displayTut = _game.DisplayTutorial;

		_tickets = new TicketDisplay(_game);
		AddChild(_tickets);

		_clock = new Clock();
		AddChild(_clock);

		if (_displayTut)
		{
			_c = new ConversationBox("Text/Tutorial.txt", this);
			AddChild(_c);
		}

		FirstInstance = false;

		_shopKeeper = new ShopKeeper();
		AddChild(_shopKeeper);
	}

	public void DeleteTut()
	{
		_game.DisplayTutorial = false;
		_c.LateDestroy();
		_c = null;
	}

	public void OpenShop()
	{
		if (_shop == null)
		{
			_shop = new ShopAndBar(_game, true, "Sprites/ShopOverlay.png");
			LateAddChild(_shop);
		}
	}

	public void CloseShop()
	{
		_shop.DestroyShop();
		_shop.LateDestroy();
		_shop = null;
	}
}
