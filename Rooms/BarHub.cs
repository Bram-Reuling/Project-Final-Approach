using TiledMapParser;

public class BarHub : Hub
{
	
	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	MainGame _game;
	TicketDisplay _tickets;
	Clock _clock;

	DJ _dj;
	BarMan _barMan;

	public BarHub(MainGame tempGame) : base("Sprites/Bar.png", 32, 24, "Sprites/Bar.png", 32, 24, "colors.png", 1, 1, tempGame)
	{
		_fileName = @"Screens/BarHub/BarHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData, false);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		_firstInstance = false;

		_game = tempGame;

		_tickets = new TicketDisplay(_game);
		AddChild(_tickets);

		_clock = new Clock();
		AddChild(_clock);

		_dj = new DJ();
		LateAddChild(_dj);

		_barMan = new BarMan();
		LateAddChild(_barMan);
	}
}
