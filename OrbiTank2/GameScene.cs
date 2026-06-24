using Clockwork;
using Clockwork.Utilities;
using System.Numerics;
using Clockwork.Shapes;
using Box2D;

public class GameScene : Scene
{
	public Physics Physics = new();

	public GameScene()
	{
		AddEntity(Physics);

		Tank tank = new Tank(this, new Vector2(Engine.HalfGameWidth, Engine.HalfGameHeight), 0);
		tank.Scale = Vector2.One * 5f;
		tank.Offset = SpriteOffset.Center;
		AddEntity(tank);
	}
}
