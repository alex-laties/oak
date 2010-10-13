using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Oak.Audio
{
    /// <summary>
    /// Manages the loading, playing, and disposing of audio
    /// </summary>
    class AudioManager
    {   
        List<AudioInstance> instances;
        LinkedList<Cue> currentlyPlaying;
        float volume;

        /// <summary>
        /// Gets or sets the AudioEmitter.
        /// Can be used to change the emitter position.
        /// </summary>
        public AudioEmitter Emitter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AudioListener
        /// Can be used to change the listener position.
        /// </summary>
        public AudioListener Listener
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current volume level.
        /// Setting a new volume level will update all currently playing sounds as well as all future sounds.
        /// </summary>
        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                UpdateVolume();
            }
        }

        public AudioManager()
        {
            instances = new List<AudioInstance>();
            currentlyPlaying = new LinkedList<Cue>();
            Emitter = new AudioEmitter();
            Listener = new AudioListener();
            Emitter.Position = Vector3.Zero;
            Listener.Position = Vector3.Zero;
        }

        /// <summary>
        /// Loads a collection of sounds of the XACT audio format.
        /// Assumes that the filenames of the .xgs, .xsb, and .xwb have been unchanged from their default format.
        /// </summary>
        /// <param name="name">The name of the .xgs file, excluding the extension.</param>
        /// <param name="path">Path to the files (the .xgs, .xsb, and .xwb should be in the same directory)</param>
        /// <returns></returns>
        public bool AddSoundLibrary(string name, string path)
        {
            bool success;
            AudioInstance inst;
            inst = new AudioInstance(name, path);
            instances.Add(inst);
            success = true;

            return success;
        }

        public void PauseAll()
        {
            foreach (Cue cue in currentlyPlaying)
            {
                cue.Pause();
            }
        }

        public void PlayAll()
        {
            foreach (Cue cue in currentlyPlaying)
            {
                cue.Play();
            }
        }

        /// <summary>
        /// Lists all currently playing sounds to the in-game Console.
        /// CURRENTLY NOT WORKING!!!
        /// </summary>
        public void ListAllToConsole()
        {
            //TODO actually implement this method
        }

        public void ResumeAll()
        {
            foreach (Cue cue in currentlyPlaying)
            {
                cue.Resume();
            }
        }

        public void StopAll()
        {
            foreach (Cue cue in currentlyPlaying)
            {
                cue.Stop(AudioStopOptions.Immediate);
            }
        }

        private void UpdateVolume()
        {
            foreach(AudioInstance inst in instances)
            {
                inst.AudioEngine.GetCategory("Default").SetVolume(volume);
            }
        }

        public Cue PlaySound(string name)
        {
            Cue sound = FetchSound(name);
            sound.Disposing += new EventHandler(CueDisposed);
            sound.Apply3D(Listener, Emitter);
            currentlyPlaying.AddLast(sound);

            sound.Play();
            return sound;
        }

        /// <summary>
        /// Loads the sound into memory (via the ContentManager).
        /// Throws a ArgumentNullException if unable to find the sound.
        /// </summary>
        /// <param name="name">Name of the sound</param>
        /// <returns>The sound in question</returns>
        public Cue FetchSound(string name)
        {
            Cue temp = null;

            foreach (AudioInstance inst in instances)
            {
                try
                {
                    temp = inst.SoundBank.GetCue(name);
                }
                catch 
                {
                    temp = null;
                }
            }

            if (temp == null)
            {
                throw new ArgumentNullException(name, "The requested sound was not found");
            }

            return temp;
        }

        private void CueDisposed(object sender, EventArgs e)
        {
            Cue c = (Cue)sender;
            currentlyPlaying.Remove(c);
        }
    }
}
