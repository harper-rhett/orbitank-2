using Clockwork;
using Clockwork.Graphics.Cameras;
using System.Numerics;

public class GameScene : Scene
{
	public Physics Physics = new();

	public GameScene()
	{
		AddEntity(Physics);

		Vector2 spawnPosition = new Vector2(Engine.HalfGameWidth, Engine.HalfGameHeight);
		Tank tank = new Tank(this, spawnPosition, 0);
		AddEntity(tank);
	}
}
