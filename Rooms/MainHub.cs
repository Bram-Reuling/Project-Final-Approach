using TiledMapParser;

class MainHub : Hub
{

	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	public MainHub(MainGame _game) : base("checkers.png", 1, 1, "square.png", 1, 1, "colors.png", 1, 1, _game)
	{
		_fileName = @"Screens/MainHub/MainHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData);
		SpawnObjects(_levelData);

		_firstInstance = false;
	}
}
