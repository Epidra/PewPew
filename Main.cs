using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;

namespace PewPew {
    public class Main : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static ShopKeeper Shopkeeper = new ShopKeeper();
        Menu MenuManager;
        Stage StageManager;

        Song theme0;
        Song theme1;
        Song theme2;
        Song theme3;

        /** <summary> If the Menu is active </summary> **/
        bool menu_active  = true;

        int screen_width  = Shopkeeper.game_default_width;
        float screen_width_scale = 0.00F;
        int screen_height = Shopkeeper.game_default_height;
        float screen_height_scale = 0.00F;

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            screen_width_scale = ((float)this.Window.ClientBounds.Width / (float)screen_width);
            screen_height_scale = ((float)this.Window.ClientBounds.Height / (float)screen_height);
            StageManager = new Stage(Content, Shopkeeper, screen_width_scale, screen_height_scale);
            MenuManager = new Menu(Content, Shopkeeper, screen_width_scale, screen_height_scale);
            theme0 = Content.Load<Song>(Shopkeeper.audio_music_menu);
            theme1 = Content.Load<Song>(Shopkeeper.audio_music_theme1);
            theme2 = Content.Load<Song>(Shopkeeper.audio_music_theme2);
            theme3 = Content.Load<Song>(Shopkeeper.audio_music_theme3);
            //this.IsMouseVisible = true;

            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MenuManager.Load_Content(GraphicsDevice, spriteBatch);
            StageManager.Load_Content(GraphicsDevice, spriteBatch);
            JukeBox("menu");
        }


        protected override void UnloadContent() {
            MenuManager.Unload_Content();
            StageManager.Unload_Content();
        }


        protected override void Update(GameTime gameTime) {
            string temp;
            if(menu_active) {
                temp = MenuManager.update(gameTime);
            } else {
                temp = StageManager.update(gameTime);
            }

            if(temp == "start") {
                StageManager.Start(MenuManager.Get_Active("basic"), MenuManager.Get_Active("ring"), MenuManager.Get_Active("meteor"), MenuManager.Get_Active("octanom"), MenuManager.Get_Active("mino"), MenuManager.Get_Active("pong"));
                menu_active = false;
                JukeBox("stage");
            }
            if(temp == "menu") {
                menu_active = true;
                JukeBox("menu");
            }
            if(temp == "sound") {

            }
            if(temp == "music") {

            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(menu_active) {
                MenuManager.Draw(gameTime);
                spriteBatch.Begin();
                spriteBatch.Draw(MenuManager.Get_RenderTarget(), new Rectangle(0, 0, (int)Window.ClientBounds.Width, (int)Window.ClientBounds.Height), Color.White);
                spriteBatch.End();
            } else {
                StageManager.Draw(gameTime);
                spriteBatch.Begin();
                spriteBatch.Draw(StageManager.Get_RenderTarget(), new Rectangle(0, 0, (int)Window.ClientBounds.Width, (int)Window.ClientBounds.Height), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void JukeBox(string s) {
            MediaPlayer.Stop();
            if(s == "menu") {
                MediaPlayer.Play(theme0);
            } else if(s == "stage") {
                System.Random random = new System.Random();
                int temp = random.Next(3);
                if(temp == 0) MediaPlayer.Play(theme1);
                if(temp == 1) MediaPlayer.Play(theme2);
                if(temp == 2) MediaPlayer.Play(theme3);
            }
        }

    }
}