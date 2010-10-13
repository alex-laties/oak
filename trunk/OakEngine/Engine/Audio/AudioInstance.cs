using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace Oak.Audio
{
    class AudioInstance
    {
        /// <summary>
        /// Wrapper for XACT .xap packages
        /// Allows access to Sound and Wave Banks
        /// </summary>
        string name;
        AudioEngine eng;
        SoundBank sb;
        WaveBank wb;

        public string Path
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public AudioEngine AudioEngine
        {
            get
            {
                return eng;
            }
        }

        public SoundBank SoundBank
        {
            get
            {
                return sb;
            }
        }

        public WaveBank WaveBank
        {
            get
            {
                return wb;
            }
        }


        public AudioInstance(string name, string path)
        {
            this.name = name;
            this.Path = path;
            Initialize();
        }

        void Initialize()
        {
            eng = new AudioEngine(Path + name + ".xgs");
            sb = new SoundBank(eng, Path + name + " Sound Bank.xsb");
            wb = new WaveBank(eng, Path + name + " Wave Bank.xwb");
        }

        public Cue GetCue(string cueName)
        {
            return sb.GetCue(cueName);
        }
    }
}
