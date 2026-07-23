using Box2D;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using Clockwork.Shapes;
using Clockwork.Utilities;
using System.Numerics;

public class Planet : Entity
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
	public readonly float Radius = 150;

	private const float density = 500f;
	private float mass => density * float.Pi * Radius * Radius;

	private Body body;
	private Shape shape;

	public Planet(GameScene gameScene, Vector2 position)
	{
		this.gameScene = gameScene;
		Position = position;
		UpdateLayer = -1;

		// Define body
		BodyDef bodyDef = new(type: BodyType.Kinematic, position: Position);
		body = new(gameScene.Physics.World, bodyDef);

		// Define shape
		Circle circle = new(Vector2.Zero, Radius);
		ShapeDef shapeDef = new();
		shapeDef.Density = density;
		shape = new(body, shapeDef, circle);
	}

	public override void OnUpdate()
	{
		foreach (ISatellite satellite in gameScene.Satellites)
		{
			Vector2 force = GetGravityForce(Position, mass, satellite.Position, satellite.Mass);
			satellite.GravityForce += force;
		}
	}

	private static Vector2 GetGravityForce(Vector2 planetPosition, float planetMass, Vector2 satellitePosition, float satelliteMass)
	{
		Vector2 satelliteToPlanet = planetPosition - satellitePosition;
		float distanceSquared = satelliteToPlanet.LengthSquared();
		float distanceCubed = distanceSquared * float.Sqrt(distanceSquared);
		float forceOverDistance = planetMass * satelliteMass / distanceCubed;
		return satelliteToPlanet * forceOverDistance;
	}

	public override void OnDraw()
	{
		Primitives2D.DrawCircle(Position, Radius, Colors.Blue);
	}
}
