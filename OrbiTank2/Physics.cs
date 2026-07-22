using Clockwork;
using Box2D;
using System.Numerics;

public class Physics : Entity
{
	public World World;

	public Physics()
	{
		WorldDef worldDef = new(Vector2.UnitY * 60);
		World = new(worldDef);
	}

	public override void OnUpdate()
	{
		World.Step();
	}
}
