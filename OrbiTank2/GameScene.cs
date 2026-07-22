using Clockwork;
using Clockwork.Graphics.Cameras;
using System.Numerics;

public class GameScene : Scene
{
	public Physics Physics = new();

	public GameScene()
	{
		AddEntity(Physics);

		Vector2 tankSpawnPosition = new(Engine.HalfGameWidth, 0);
		Tank tank = new(this, tankSpawnPosition, 0);
		AddEntity(tank);

		Vector2 planetSpawnPosition = new(Engine.HalfGameWidth, Engine.HalfGameHeight);
		Planet planet = new(this, planetSpawnPosition);
		AddEntity(planet);
	}
}
