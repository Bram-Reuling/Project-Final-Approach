using TiledMapParser;

class ArkanoidHub : Hub
{

	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	public ArkanoidHub(MainGame _game) : base("checkers.png", 1, 1, "square.png", 1, 1, "colors.png", 1, 1, _game)
	{
		_fileName = @"Screens/BarHub/BarHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData);
		SpawnObjects(_levelData);

		_firstInstance = false;
	}
}