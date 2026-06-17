using System.Numerics;
using Clockwork;
using Clockwork.Graphics;
using Clockwork.Graphics.Text;
using Clockwork.Input;

// Entity control and properties live here

internal class MenuManager : Entity
{
    private string text = "ENTER to Start Game";
    private Vector2 position;
    private const int fontSize = 50;
    private const float bobSpeed = 4f;

    public MenuManager()
    {
        int width = Text.MeasureWidth(text, fontSize);
        position = new(
            Engine.HalfGameWidth - width / 2,
            Engine.HalfGameHeight - fontSize / 2
        );
    }

    public override void OnUpdate()
    {
        if (Keyboard.IsKeyPressed(KeyboardKey.Enter)) OrbiTank.Instance.Start();
    }

    public override void OnDraw()
    {
        float yOffset = (int)(float.Sin(Scene.Time * bobSpeed) * (fontSize / 2f));
        Vector2 offset = new(0, yOffset);
        Text.Draw(text, position + offset, fontSize, Colors.White);
    }
}
