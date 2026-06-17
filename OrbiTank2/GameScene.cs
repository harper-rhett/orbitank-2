using Clockwork;
using Clockwork.Utilities;
using System.Numerics;
using Clockwork.Shapes;

public class GameScene : Scene
{
	public GameScene()
	{
		Tank tank = AddEntity(new Tank(new Vector2(Engine.HalfGameWidth, Engine.HalfGameHeight), 0));
		tank.Scale = Vector2.One * 5f;
		tank.Offset = SpriteOffset.Center;
	}
}
