using TiledMapParser;

class MainHub : Hub
{

	private string _fileName { get; set; }
	public bool _firstInstance { get; set; }

	public MainHub(MainGame _game) : base("Sprites/MainHub.png", 32, 24, "Sprites/MainHub.png", 32, 24, "colors.png", 1, 1, _game)
	{
		_fileName = @"Screens/MainHub/MainHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		SpawnCollisionTiles(_levelData);
		SpawnBackgroundTiles(_levelData);
		SpawnObjects(_levelData);
		SpawnOverlapTiles(_levelData);

		_firstInstance = false;
	}
}
