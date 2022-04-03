using Raylib_cs;

namespace OnWard.Game.Services.RaylibService
{
    public class RaylibAudioService : AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> sounds 
            = new Dictionary<string, Raylib_cs.Sound>();
        
        /// <summary>
        /// Constructs a new RaylibAudioService.
        /// </summary>
        public RaylibAudioService()
        {
        }

        /// </inheritdoc>
        public void Initialize()
        {
            Raylib.InitAudioDevice();
        }

        /// </inheritdoc>
        public void LoadSounds(string directory)
        {
            List<string> filters = new List<string>() { "*.wav", "*.mp3", "*.acc", "*.wma" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Sound sound = Raylib.LoadSound(filepath);
                sounds[filepath] = sound;
            }
        }

        // private void LoadSounds(string path) 
        // {
        //     Raylib_cs.Sound sound = Raylib.LoadSound(path);
        //     sounds[path] = sound;
        // }
 
        /// </inheritdoc>
        public void PlaySound(Casting.Sound sound)
        {
                
           try {
                string filename = sound.GetFilename();
                //Determine whether to pull from the cache or load new
                if (!this.sounds.ContainsKey(filename))
                {
                    this.sounds[filename] = Raylib.LoadSound(filename);
                }

                // Play!
                Raylib.PlaySound(sounds[filename]);

            }
            catch (Exception e) {
                // In case path is not found...
                Console.WriteLine(e.Message);
            }
        }

        /// </inheritdoc>
        public void Release()
        {
            Raylib.CloseAudioDevice();
        }

        /// </inheritdoc>
        public void UnloadSounds()
        {
            foreach (string filepath in sounds.Keys)
            {
                Raylib_cs.Sound raylibSound = sounds[filepath];
                Raylib.UnloadSound(raylibSound);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter);
                results.AddRange(filepaths);
            }
            return results;
        }
    }
}