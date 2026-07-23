using System.Numerics;

public interface ISatellite
{
	public float Mass { get; }
	public Vector2 Position { get; }
	public Vector2 GravityForce { get; set; }
}
