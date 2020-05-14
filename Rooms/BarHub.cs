using TiledMapParser;

public class BarHub : Hub
{
	
	private string FileName { get; set; }
	public bool FirstInstance { get; set; }

	private readonly MainGame _game;
	private readonly TicketDisplay _tickets;
	private readonly Clock _clock;

	private readonly DJ _dj;
	private readonly BarMan _barMan;
	private readonly DevilNPC _devil;
	private readonly CatManNPC _cat;

	private ShopAndBar _bar;

	public BarHub(MainGame tempGame) : base("Sprites/Bar.png", 32, 24, "Sprites/Bar.png", 32, 24, "colors.png", 1, 1, tempGame)
	{
		FileName = @"Screens/BarHub/BarHub.tmx";

		Map _levelData = MapParser.ReadMap(FileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData, false);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		FirstInstance = false;

		_game = tempGame;

		_tickets = new TicketDisplay(_game);
		AddChild(_tickets);

		_clock = new Clock();
		AddChild(_clock);

		_dj = new DJ();
		LateAddChild(_dj);

		_barMan = new BarMan();
		LateAddChild(_barMan);

		_devil = new DevilNPC();
		LateAddChild(_devil);

		_cat = new CatManNPC();
		LateAddChild(_cat);
	}

	public void OpenBar()
	{
		if (_bar == null)
		{
			_bar = new ShopAndBar(_game, false, "Sprites/BarOverlay.png");
			LateAddChild(_bar);
		}
	}

	public void CloseShop()
	{
		_bar.DestroyBar();
		_bar.LateDestroy();
		_bar = null;
	}
}
