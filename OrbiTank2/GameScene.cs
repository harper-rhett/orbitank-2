using Clockwork;
using Clockwork.Utilities;
using System.Numerics;
using Box2D;
using Clockwork.Graphics.Draw2D;

public class GameScene : Scene
{
	public Physics Physics = new();

	public GameScene()
	{
		AddEntity(Physics);

		Tank tank = new Tank(this, new Vector2(Engine.HalfGameWidth, Engine.HalfGameHeight), 0);
		AddEntity(tank);
	}
}
