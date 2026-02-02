namespace VTuberManagementSimulator
{
    public interface IScene
    {
        void Enter();
        void Update();
        void Exit();
    }

    public interface ISceneManager
    {
        void ChangeScene(IScene scene);
        void Update();
    }

    public class SceneManager : ISceneManager
    {
        private IScene currentScene;

        public void ChangeScene(IScene scene)
        {
            currentScene?.Exit();
            currentScene = scene;
            currentScene.Enter();
        }

        public void Update()
        {
            currentScene?.Update();
        }
    }
}