using Box2D;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Input;
using Clockwork.Utilities;
using System.Numerics;

public class Tank : Entity, ISatellite
{
	private GameScene gameScene;
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

	private const float density = 0.1f;

	public float Mass => body.Mass;
	public Vector2 GravityForce { get; set; } = Vector2.Zero;

	public Tank(GameScene gameScene, Vector2 position, float rotation) : base()
	{
		// Initialization
		this.gameScene = gameScene;
		Position = position;
		Rotation = rotation;

		// Load textures
		sprite = new("sprites/tank-body.png", Vector2.Zero, rotation);
		sprite.Transform.Parent = Transform;
		sprite.Scale = Vector2.One * 4f;
		sprite.Offset = SpriteOffset.Center;

		// Define body
		BodyDef bodyDef = new(type: BodyType.Dynamic, position: Position);
		body = new(gameScene.Physics.World, bodyDef);
		gameScene.Satellites.Add(this);

		// Define shape
		Polygon polygon = Polygon.MakeBox(sprite.HalfWidth, sprite.HalfHeight);
		ShapeDef shapeDef = new();
		shapeDef.Density = density;
		shape = new(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		// Apply physical positions to drawn positions
		Transform.Position = body.Position;
		Transform.Rotation = float.RadiansToDegrees(body.Rotation);

		if (Keyboard.IsKeyDown(KeyboardKey.Right))
		{
			body.ApplyForceToCenter(Transform.Right * 200000f, true);
		}

		// Apply gravity
		body.ApplyForceToCenter(GravityForce, true);
		GravityForce = Vector2.Zero;
	}

	public override void OnDraw()
	{
		sprite.Draw();
	}
}
