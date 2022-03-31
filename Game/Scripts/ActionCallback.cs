using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnWard.Game.Scripts
{
     /// <summary>
    /// A callback that can be used to trigger scene changes.
    /// </summary>
    public interface ActionCallback
    {
        /// <summary>
        /// Called when we need to transition from one scene to the next.
        /// </summary>
        /// <param name="sceneName">The next scene.</param>
        void OnNext(string sceneName);
    }
}