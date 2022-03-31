using OnWard.Game.Casting;
using OnWard.Game.Scripts;
using OnWard.Game.Services;

namespace OnWard.Game.Directing
{
    /// <summary>
    /// A person who directs the game.
    /// </summary>
    public class Director : ActionCallback
    {
        private Cast cast;
        private Script script;
        private VideoService videoService;
        
        /// <summary>
        /// Constructs a new instance of Director using the given VideoService.
        /// </summary>
        /// <param name="videoService">The given VideoService.</param>
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
            this.cast = new Cast();
            this.script = new Script();
        }

        /// </inheritdoc>
        public void OnNext(string scene)
        {
            // sceneManager.PrepareScene(scene, cast, script);
        }
        
        /// <summary>
        /// Starts the game by running the main game loop for the given cast and script.
        /// </summary>
        public void StartGame(Cast cast, Script script)
        {
            this.cast = cast;
            this.script = script;
            
            ExecuteActions(Constants.INITIALIZE);
            ExecuteActions(Constants.LOAD);
            while (videoService.IsWindowOpen())
            {
                ExecuteActions(Constants.INPUT);
                ExecuteActions(Constants.UPDATE);
                ExecuteActions(Constants.OUTPUT);
            }
            ExecuteActions(Constants.UNLOAD);
            ExecuteActions(Constants.RELEASE);
        }

        private void ExecuteActions(string group)
        {
            List<Scripts.Action> actions = script.GetActions(group);
            foreach(Scripts.Action action in actions)
            {
                action.Execute(cast, script, this);
            }
        }
    }
}