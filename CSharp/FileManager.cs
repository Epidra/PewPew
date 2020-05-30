using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace PewPew {
    class FileManager {

        public int  coins = 0;
        public int  rolling_horizontal = 0;
        public int  rolling_vertical = 0;
        public int  system_brightness = 100;
        public int  system_music_volume = 100;
        public bool system_music_active = true;
        public int  system_sound_volume = 100;
        public bool system_sound_active = true;

        public bool[] minos_active = new bool[11];
        public int [] minos_energy = new int [11];

        public FileManager() {
            
        }

        public void Initialize() {
            for(int i = 0; i < 11; i++) {
                minos_active[i] = false;
                minos_energy[i] = 0;
            }
        }

    }
}
