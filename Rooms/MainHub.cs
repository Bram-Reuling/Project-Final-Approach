using System;
using System.Drawing.Text;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

class MainHub : GameObject
{

	private string _fileName { get; set; }
	Player _player;

	public MainHub()
	{
		_fileName = @"Screens/MainHub/MainHub.tmx";

		Map _levelData = MapParser.ReadMap(_fileName);
		spawnCollisionTiles(_levelData);
		spawnBackgroundTiles(_levelData);
		spawnObjects(_levelData);
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnBackgroundTiles()
	//------------------------------------------------------------------------------------------------------------------------
	private void spawnBackgroundTiles(Map levelData)
	{
		// Check if there are layers
		if (levelData.Layers == null || levelData.Layers.Length == 0)
			return;

		// Setting the mainlayer to the first layer
		Layer mainLayer = levelData.Layers[0];

		short[,] tileNumbers = mainLayer.GetTileArray();

		for (int row = 0; row < mainLayer.Height; row++)
		{
			for (int col = 0; col < mainLayer.Width; col++)
			{
				int tileNumber = tileNumbers[col, row];
				if (tileNumber > 0)
				{
					BackgroundTile tile = new BackgroundTile("square.png", 1, 1);
					tile.SetFrame(tileNumber - 1);
					tile.x = col * tile.width + tile.width / 2;
					tile.y = row * tile.height + tile.height / 2;
					AddChild(tile);
				}
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnCollisionTiles()
	//------------------------------------------------------------------------------------------------------------------------
	private void spawnCollisionTiles(Map levelData)
	{
		// Check if there are layers
		if (levelData.Layers == null || levelData.Layers.Length == 0)
			return;

		// Setting the mainlayer to the first layer
		Layer mainLayer = levelData.Layers[1];

		short[,] tileNumbers = mainLayer.GetTileArray();

		for (int row = 0; row < mainLayer.Height; row++)
		{
			for (int col = 0; col < mainLayer.Width; col++)
			{
				int tileNumber = tileNumbers[col, row];
				if (tileNumber > 0)
				{
					CollisionTile tile = new CollisionTile("square.png", 1, 1);
					tile.SetFrame(tileNumber - 1);
					tile.x = col * tile.width + tile.width / 2;
					tile.y = row * tile.height + tile.height / 2;
					AddChild(tile);
				}
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnObjects()
	//------------------------------------------------------------------------------------------------------------------------
	private void spawnObjects(Map levelData)
	{
		if (levelData.ObjectGroups == null || levelData.ObjectGroups.Length == 0)
			return;

		ObjectGroup objectGroup = levelData.ObjectGroups[0];
		if (objectGroup.Objects == null || objectGroup.Objects.Length == 0)
			return;

		foreach (TiledObject obj in objectGroup.Objects)
		{
			switch (obj.Name)
			{
				case "Player":
					_player = new Player(obj.X, obj.Y);
					AddChild(_player);
					break;
				case "Door":
					DoorTile _door = new DoorTile("colors.png", 1, 1);
					_door.SetFrame(0);
					_door.x = obj.X + _door.width / 2;
					_door.y = obj.Y - _door.height / 2;
					AddChild(_door);
					break;
			}
		}
	}
}
