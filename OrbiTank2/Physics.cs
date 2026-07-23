using Clockwork;
using Box2D;
using System.Numerics;

public class Physics : Entity
{
	public World World;

	public Physics()
	{
		Core.LengthUnitsPerMeter = 512;
		WorldDef worldDef = new();
		World = new(worldDef);
	}

	public override void OnUpdate()
	{
		World.Step();
	}
}
