using Clockwork;

internal class MenuScene : Scene
{
    public MenuScene()
    {
        AddEntity(new MenuManager());
    }
}
