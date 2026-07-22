using Box2D;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Utilities;
using System.Numerics;

public class Tank : Entity
{
	private GameScene scene;
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
	private Sprite sprite;
	private Body body;
	private Shape shape;

	public Tank(GameScene gameScene, Vector2 position, float rotation) : base()
	{
		// Initialization
		scene = gameScene;
		Position = position;
		Rotation = rotation;

		// Load textures
		sprite = new("sprites/tank-body.png", position, rotation);
		sprite.Transform.Parent = Transform;
		sprite.Scale = Vector2.One * 5f;
		sprite.Offset = SpriteOffset.Center;

		// Define body
		BodyDef bodyDef = new()
		{
			Type = BodyType.Dynamic,
			Position = position
		};
		body = new(scene.Physics.World, bodyDef);

		// Define shape
		Polygon polygon = Polygon.MakeBox(sprite.HalfWidth, sprite.HalfHeight);
		ShapeDef shapeDef = new();
		shape = new(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		Transform.Position = body.Position;
		Transform.Rotation = body.Rotation;
	}

	public override void OnDraw()
	{
		sprite.Draw();
	}
}
