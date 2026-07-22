using Box2D;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Shapes;
using Clockwork.Utilities;
using System.Numerics;

public class Planet : Entity
{
	public Transform2D Transform = new();
	public Vector2 Position
	{
		get => Transform.Position;
		set => Transform.Position = value;
	}
	public float Rotation
	{
		get => Transform.Rotation;
		set => Transform.Rotation = value;
	}
	public readonly float Radius = 150;
	private Body body;
	private Shape shape;

	public Planet(GameScene gameScene, Vector2 position)
	{
		Position = position;

		// Define body
		BodyDef bodyDef = new()
		{
			Type = BodyType.Kinematic,
			Position = position
		};
		body = new(gameScene.Physics.World, bodyDef);

		// Define shape
		Circle circle = new(Vector2.Zero, Radius);
		ShapeDef shapeDef = new();
		shape = new(body, shapeDef, circle);
	}

	public override void OnDraw()
	{
		Primitives2D.DrawCircle(Position, Radius, Colors.Blue);
	}
}
