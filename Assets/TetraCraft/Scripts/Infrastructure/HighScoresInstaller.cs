using Zenject;

public class HighScoresInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ProjectContext projectContext = new ProjectContext();
        projectContext.Container.Resolve<HighscoreEntry>();
    }
}
