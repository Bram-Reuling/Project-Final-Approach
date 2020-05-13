using GXPEngine;
using TiledMapParser;

class MainHub : Hub
{

	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	bool _displayTut;

	ConversationBox _c;
	MainGame _game;
	TicketDisplay _tickets;
	Clock _clock;
	ShopKeeper _shopKeeper;

	Shop _shop;

	public MainHub(MainGame tempGame) : base("Sprites/MainHub.png", 32, 24, "Sprites/MainHub.png", 32, 24, "colors.png", 1, 1, tempGame)
	{
		_fileName = @"Screens/MainHub/MainHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData, true);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		_game = tempGame;
		_displayTut = _game._displayTutorial;

		_tickets = new TicketDisplay(_game);
		AddChild(_tickets);

		_clock = new Clock();
		AddChild(_clock);

		if (_displayTut)
		{
			_c = new ConversationBox("Text/Tutorial.txt", this);
			AddChild(_c);
		}

		_firstInstance = false;

		//_shop = new Shop();
		//AddChild(_shop);

		_shopKeeper = new ShopKeeper();
		AddChild(_shopKeeper);
	}

	public void DeleteTut()
	{
		_game._displayTutorial = false;
		_c.LateDestroy();
		_c = null;
	}
}
