using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Draw2D;
using System.Numerics;

public class Tank : Sprite
{
	public Tank(Vector2 position, float rotation) : base(position, rotation)
	{
		LoadTexture("sprites/tank-body.png");
	}
}
