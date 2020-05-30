using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace PewPew {
    public class Menu {
        private ContentManager Content;
        private ShopKeeper Shopkeeper;

        private float scaleX;
        private float scaleY;

        Texture2D grid_basic_texture;
        Vector2 grid_basic_position;
        Texture2D grid_ring_texture;
        Vector2 grid_ring_position;
        Texture2D grid_meteor_texture;
        Vector2 grid_meteor_position;
        Texture2D grid_octanom_texture;
        Vector2 grid_octanom_position;
        Texture2D grid_mino_texture;
        Vector2 grid_mino_position;
        Texture2D grid_pong_texture;
        Vector2 grid_pong_position;
        Texture2D grid_selector;
        Texture2D grid_bump;

        Vector2 infocard_position;
        Texture2D infocard_introduction;
        Texture2D infocard_basic;
        Texture2D infocard_ring;
        Texture2D infocard_meteor;
        Texture2D infocard_octanom;
        Texture2D infocard_mino;
        Texture2D infocard_pong;

        Texture2D button_start_texture;
        Vector2 button_start_position;

        Texture2D background_starfield;
        Texture2D background_title;
        int background_position = 0;
        int background_end;

        bool active_title        = true;
        bool active_card_basic   = false;
        bool active_card_ring    = false;
        bool active_card_meteor  = false;
        bool active_card_octanom = false;
        bool active_card_mino    = false;
        bool active_card_pong    = false;

        string last_card = "empty";

        Color[] TextureData;

        MouseState control_mouse_new;
        MouseState control_mouse_old;
        TouchCollection control_touch_new;
        TouchCollection control_touch_old;

        RenderTarget2D renderTarget;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;

        public Menu(ContentManager Content, ShopKeeper Shopkeeper, float core_screen_width_scale, float core_screen_height_scale) {
            // TODO: Complete member initialization
            this.Content = Content;
            this.Shopkeeper = Shopkeeper;
            this.scaleX = core_screen_width_scale;
            this.scaleY = core_screen_height_scale;
            TouchPanel.EnabledGestures = GestureType.Tap;
        }

        public void Load_Content(GraphicsDevice graphics, SpriteBatch spriteBatch) {
            this.graphicsDevice = graphics;
            this.spriteBatch = spriteBatch;
            grid_basic_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardbasic);
            grid_ring_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardringrace);
            grid_meteor_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardmeteorshower);
            grid_octanom_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardoctanom);
            grid_mino_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardminobreaker);
            grid_pong_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_gamecardpong);
            grid_selector = Content.Load<Texture2D>(Shopkeeper.graphic_menu_selector);
            grid_bump = Content.Load<Texture2D>(Shopkeeper.graphic_menu_bump);
            grid_basic_position = Shopkeeper.position_menu_01;
            grid_ring_position = Shopkeeper.position_menu_02;
            grid_meteor_position = Shopkeeper.position_menu_03;
            grid_octanom_position = Shopkeeper.position_menu_04;
            grid_mino_position = Shopkeeper.position_menu_05;
            grid_pong_position = Shopkeeper.position_menu_06;
            infocard_position = Shopkeeper.position_menu_card;
            infocard_introduction = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardintroduction);
            infocard_basic = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardbasic);
            infocard_ring = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardringrace);
            infocard_meteor = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardmeteorshower);
            infocard_octanom = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardoctanom);
            infocard_mino = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardminobreaker);
            infocard_pong = Content.Load<Texture2D>(Shopkeeper.graphic_menu_infocardpong);
            button_start_texture = Content.Load<Texture2D>(Shopkeeper.graphic_menu_iconstart);
            button_start_position = Shopkeeper.position_menu_start;
            background_starfield = Content.Load<Texture2D>(Shopkeeper.graphic_background_starfield);
            background_title = Content.Load<Texture2D>(Shopkeeper.graphic_background_title);
            background_end = Shopkeeper.game_default_width;
            renderTarget = new RenderTarget2D(graphicsDevice, Shopkeeper.game_default_width, Shopkeeper.game_default_height);
            TextureData = new Color[(int)(grid_bump.Width) * (int)(grid_bump.Height)];
            grid_bump.GetData(TextureData);
        }

        public void Unload_Content() {
        }

        public void Resize(float x, float y) {
            scaleX = x;
            scaleY = y;
        }

        public string update(GameTime gameTime) {
            control_mouse_new = Mouse.GetState();
            control_touch_new = TouchPanel.GetState();
            if(control_mouse_new.LeftButton == ButtonState.Pressed && control_mouse_old.LeftButton == ButtonState.Released) {
                if(active_title) {
                    active_title = false;
                } else {
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_basic_position.X, (int)grid_basic_position.Y)) {
                        last_card = "basic";
                        if(active_card_basic) {
                            active_card_basic = false;
                        } else {
                            active_card_basic = true;
                            active_card_mino = false;
                            active_card_pong = false;
                        }
                    }
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_ring_position.X, (int)grid_ring_position.Y)) {
                        last_card = "ring";
                        if(active_card_ring) {
                            active_card_ring = false;
                        } else {
                            active_card_ring = true;
                            active_card_mino = false;
                            active_card_pong = false;
                        }
                    }
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_meteor_position.X, (int)grid_meteor_position.Y)) {
                        last_card = "meteor";
                        if(active_card_meteor) {
                            active_card_meteor = false;
                        } else {
                            active_card_meteor = true;
                            active_card_mino = false;
                            active_card_pong = false;
                        }
                    }
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_octanom_position.X, (int)grid_octanom_position.Y)) {
                        last_card = "octanom";
                        if(active_card_octanom) {
                            active_card_octanom = false;
                        } else {
                            active_card_octanom = true;
                            active_card_mino = false;
                            active_card_pong = false;
                        }
                    }
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_mino_position.X, (int)grid_mino_position.Y)) {
                        last_card = "mino";
                        if(active_card_mino) {
                            active_card_mino = false;
                        } else {
                            active_card_basic = false;
                            active_card_ring = false;
                            active_card_meteor = false;
                            active_card_octanom = false;
                            active_card_mino = true;
                            active_card_pong = false;
                        }
                    }
                    if(Collision(control_mouse_new.Position.X, control_mouse_new.Position.Y, (int)grid_pong_position.X, (int)grid_pong_position.Y)) {
                        last_card = "pong";
                        if(active_card_pong) {
                            active_card_pong = false;
                        } else {
                            active_card_basic = false;
                            active_card_ring = false;
                            active_card_meteor = false;
                            active_card_octanom = false;
                            active_card_mino = false;
                            active_card_pong = true;
                        }
                    }
                    if(button_start_position.X * scaleX < control_mouse_new.Position.X && control_mouse_new.Position.X < button_start_position.X * scaleX + button_start_texture.Width * scaleX && button_start_position.Y < control_mouse_new.Position.Y * scaleY && control_mouse_new.Position.Y < button_start_position.Y * scaleY + button_start_texture.Height * scaleY) {
                        if(active_card_basic || active_card_ring || active_card_mino || active_card_pong)
                            return "start";
                    }
                }
            }
            while(TouchPanel.IsGestureAvailable) {
                var gesture = TouchPanel.ReadGesture();
                if(gesture.GestureType == GestureType.Tap) {
                    if(active_title) {
                        active_title = false;
                    } else {
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_basic_position.X, (int)grid_basic_position.Y)) {
                            last_card = "basic";
                            if(active_card_basic) {
                                active_card_basic = false;
                            } else {
                                active_card_basic = true;
                                active_card_mino = false;
                                active_card_pong = false;
                            }
                        }
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_ring_position.X, (int)grid_ring_position.Y)) {
                            last_card = "ring";
                            if(active_card_ring) {
                                active_card_ring = false;
                            } else {
                                active_card_ring = true;
                                active_card_mino = false;
                                active_card_pong = false;
                            }
                        }
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_meteor_position.X, (int)grid_meteor_position.Y)) {
                            last_card = "meteor";
                            if(active_card_meteor) {
                                active_card_meteor = false;
                            } else {
                                active_card_meteor = true;
                                active_card_mino = false;
                                active_card_pong = false;
                            }
                        }
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_octanom_position.X, (int)grid_octanom_position.Y)) {
                            last_card = "octanom";
                            if(active_card_octanom) {
                                active_card_octanom = false;
                            } else {
                                active_card_octanom = true;
                                active_card_mino = false;
                                active_card_pong = false;
                            }
                        }
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_mino_position.X, (int)grid_mino_position.Y)) {
                            last_card = "mino";
                            if(active_card_mino) {
                                active_card_mino = false;
                            } else {
                                active_card_basic = false;
                                active_card_ring = false;
                                active_card_meteor = false;
                                active_card_octanom = false;
                                active_card_mino = true;
                                active_card_pong = false;
                            }
                        }
                        if(Collision((int)gesture.Position.X, (int)gesture.Position.Y, (int)grid_pong_position.X, (int)grid_pong_position.Y)) {
                            last_card = "pong";
                            if(active_card_pong) {
                                active_card_pong = false;
                            } else {
                                active_card_basic = false;
                                active_card_ring = false;
                                active_card_meteor = false;
                                active_card_octanom = false;
                                active_card_mino = false;
                                active_card_pong = true;
                            }
                        }
                        if(button_start_position.X < (int)gesture.Position.X / scaleX && (int)gesture.Position.X / scaleX < button_start_position.X + button_start_texture.Width && button_start_position.Y < (int)gesture.Position.Y / scaleY && (int)gesture.Position.Y / scaleY < button_start_position.Y + button_start_texture.Height) {
                            if(active_card_basic || active_card_ring || active_card_mino || active_card_pong)
                                return "start";
                        }
                    }
                }
            }

            background_position++;
            if(background_position >= background_end) background_position = 0;
            control_mouse_old = control_mouse_new;
            control_touch_old = control_touch_new;
            return "null";
        }

        public void Draw(GameTime gameTime) {
            graphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(background_starfield, new Rectangle(-background_position, 0, background_starfield.Width, background_starfield.Height), Color.White);
            spriteBatch.Draw(background_starfield, new Rectangle(-background_position + background_end, 0, background_starfield.Width, background_starfield.Height), Color.White);
            if(active_title) {
                spriteBatch.Draw(background_title, new Rectangle(0, 0, background_starfield.Width, background_starfield.Height), Color.White);
            } else {
                spriteBatch.Draw(grid_basic_texture, new Rectangle((int)grid_basic_position.X, (int)grid_basic_position.Y, grid_basic_texture.Width, grid_basic_texture.Height), Color.White);
                spriteBatch.Draw(grid_ring_texture, new Rectangle((int)grid_ring_position.X, (int)grid_ring_position.Y, grid_ring_texture.Width, grid_ring_texture.Height), Color.White);
                spriteBatch.Draw(grid_meteor_texture, new Rectangle((int)grid_meteor_position.X, (int)grid_meteor_position.Y, grid_meteor_texture.Width, grid_meteor_texture.Height), Color.White);
                spriteBatch.Draw(grid_octanom_texture, new Rectangle((int)grid_octanom_position.X, (int)grid_octanom_position.Y, grid_octanom_texture.Width, grid_octanom_texture.Height), Color.White);
                spriteBatch.Draw(grid_mino_texture, new Rectangle((int)grid_mino_position.X, (int)grid_mino_position.Y, grid_mino_texture.Width, grid_mino_texture.Height), Color.White);
                spriteBatch.Draw(grid_pong_texture, new Rectangle((int)grid_pong_position.X, (int)grid_pong_position.Y, grid_pong_texture.Width, grid_pong_texture.Height), Color.White);
                if(active_card_basic || active_card_ring || active_card_mino || active_card_pong) {
                    spriteBatch.Draw(button_start_texture, new Rectangle((int)button_start_position.X, (int)button_start_position.Y, button_start_texture.Width, button_start_texture.Height), Color.White);
                } else {
                    spriteBatch.Draw(button_start_texture, new Rectangle((int)button_start_position.X, (int)button_start_position.Y, button_start_texture.Width, button_start_texture.Height), Color.Gray);
                }
                if(active_card_basic) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_basic_position.X, (int)grid_basic_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(active_card_ring) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_ring_position.X, (int)grid_ring_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(active_card_meteor) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_meteor_position.X, (int)grid_meteor_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(active_card_octanom) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_octanom_position.X, (int)grid_octanom_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(active_card_mino) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_mino_position.X, (int)grid_mino_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(active_card_pong) spriteBatch.Draw(grid_selector, new Rectangle((int)grid_pong_position.X, (int)grid_pong_position.Y, grid_selector.Width, grid_selector.Height), Color.White);
                if(last_card == "basic") {
                    spriteBatch.Draw(infocard_basic, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_basic.Width, infocard_basic.Height), Color.White);
                } else if(last_card == "ring") {
                    spriteBatch.Draw(infocard_ring, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_ring.Width, infocard_ring.Height), Color.White);
                } else if(last_card == "meteor") {
                    spriteBatch.Draw(infocard_meteor, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_meteor.Width, infocard_meteor.Height), Color.White);
                } else if(last_card == "octanom") {
                    spriteBatch.Draw(infocard_octanom, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_octanom.Width, infocard_octanom.Height), Color.White);
                } else if(last_card == "mino") {
                    spriteBatch.Draw(infocard_mino, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_mino.Width, infocard_mino.Height), Color.White);
                } else if(last_card == "pong") {
                    spriteBatch.Draw(infocard_pong, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_pong.Width, infocard_pong.Height), Color.White);
                } else {
                    spriteBatch.Draw(infocard_introduction, new Rectangle((int)infocard_position.X, (int)infocard_position.Y, infocard_introduction.Width, infocard_introduction.Height), Color.White);
                }
            }
            spriteBatch.End();
            graphicsDevice.SetRenderTarget(null);
        }

        public RenderTarget2D Get_RenderTarget() {
            return renderTarget;
        }

        public bool Get_Active(string s) {
            if(s == "basic") return active_card_basic;
            if(s == "ring") return active_card_ring;
            if(s == "meteor") return active_card_meteor;
            if(s == "octanom") return active_card_octanom;
            if(s == "mino") return active_card_mino;
            if(s == "pong") return active_card_pong;
            return false;
        }

        private bool Collision(int mouseX, int mouseY, int hexX, int hexY) {
            if(hexX * scaleX < mouseX && mouseX < hexX * scaleX + grid_bump.Width * scaleX && hexY * scaleY < mouseY && mouseY < hexY * scaleY + grid_bump.Height * scaleY) {
                if(TextureData[(int)(mouseX / scaleX - hexX) * (int)(mouseY / scaleY - hexY)] == Color.Black) {
                    return true;
                }
            }
            return false;

        }
    }
}
