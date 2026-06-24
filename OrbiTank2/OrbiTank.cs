using Clockwork;
using Clockwork.Graphics;
using Clockwork.Windowing;

public class OrbiTank : Game
{
    public static OrbiTank Instance;
    private Scene activeScene;

    public OrbiTank()
    {
        Instance = this;

        Window.SetResizable(true);
        WindowRenderer.SetUnclipped(Colors.DarkGray);
        Window.Resize(800, 600);

        activeScene = new MenuScene();
    }

    public override void OnUpdate()
    {
        activeScene.Update();
    }

    public override void OnDraw()
    {
        activeScene.Draw();
    }

	public override void OnDrawGUI()
	{
        activeScene.DrawGUI();
	}

    public void Start()
    {
        activeScene = new GameScene();
    }
}
