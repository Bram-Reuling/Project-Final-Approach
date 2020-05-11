using TiledMapParser;

class BarHub : Hub
{
	
	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	public BarHub(MainGame _game) : base("Sprites/Bar.png", 32, 24, "Sprites/Bar.png", 32, 24, "colors.png", 1, 1, _game)
	{
		_fileName = @"Screens/BarHub/BarHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnBackgroundTiles(_levelData);
		SpawnCollisionTiles(_levelData);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		_firstInstance = false;
	}
}
