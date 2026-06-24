using Box2D;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using System.Numerics;

public class Tank : Sprite
{
	private GameScene scene;
	private Body body;
	private Shape shape;

	public Tank(GameScene gameScene, Vector2 position, float rotation) : base(position, rotation)
	{
		// Load textures
		LoadTexture("sprites/tank-body.png");

		// Set scene
		scene = gameScene;

		// Define body
		BodyDef bodyDef = new();
		bodyDef.Type = BodyType.Dynamic;
		bodyDef.Position = position;
		body = new(scene.Physics.World, bodyDef);

		// Define shape
		Polygon polygon = Polygon.MakeBox(HalfWidth, HalfHeight);
		ShapeDef shapeDef = new();
		shape = new(body, shapeDef, polygon);
	}

	public override void OnUpdate()
	{
		Transform.Position = body.Position;
		Transform.Rotation = body.Rotation;
	}
}
