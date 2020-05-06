using TiledMapParser;

class BarHub : Hub
{
	
	private string _fileName { get; set; }

	public BarHub(MainGame _game) : base("checkers.png", 1, 1, "square.png", 1, 1, "colors.png", 1, 1, _game)
	{
		_fileName = @"Screens/BarHub/BarHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData);
		SpawnObjects(_levelData);
	}
}
