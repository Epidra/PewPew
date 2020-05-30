using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace PewPew {
    public class Stage {
        private ContentManager Content;
        private ShopKeeper Shopkeeper;
        private float scaleX;
        private float scaleY;

        Texture2D background_starfield_texture;
        int background_starfield_position;
        Texture2D background_planet_texture_up;
        Texture2D background_planet_texture_side;
        int background_planet_position;
        Texture2D background_meteorfield_texture_up;
        Texture2D background_meteorfield_texture_side;
        int background_meteorfield_position;
        int background_end;

        SoundEffect sound_damage;
        SoundEffect sound_explosion;
        SoundEffect sound_pew;
        SoundEffect sound_pong1;
        SoundEffect sound_pong2;

        Vector3 ring_lastPosition;

        bool P_Change = false;

        Texture2D hud_back;
        Texture2D hud_hitpoint1;
        Texture2D hud_hitpoint2;
        Texture2D hud_hitpoint3;
        Texture2D hud_hitpoint4;
        Texture2D hud_hud;
        Texture2D hud_off;
        Texture2D hud_pause;
        Texture2D hud_powerupdouble;
        Texture2D hud_powerupnormal;
        Texture2D hud_powerupring;
        Texture2D hud_poweruptri;
        Texture2D hud_powerupwide;

        Texture2D mino_air;
        Texture2D mino_blank;
        Texture2D mino_dark;
        Texture2D mino_earth;
        Texture2D mino_fire;
        Texture2D mino_gold;
        Texture2D mino_ice;
        Texture2D mino_light;
        Texture2D mino_metal;
        Texture2D mino_nature;
        Texture2D mino_thunder;
        Texture2D mino_water;

        Texture2D spritesheet_explosion;
        Texture2D spritesheet_shield;
        Texture2D spritesheet_shot;
        Texture2D spritesheet_meteor;
        Texture2D spritesheet_powerup;
        Texture2D spritesheet_ring;
        Texture2D spritesheet_enemy;
        Texture2D spritesheet_octanom;
        Texture2D spritesheet_player;

        Rectangle box_enemy_up_body;
        Rectangle box_enemy_up_wing;
        Rectangle box_enemy_side_body;
        Rectangle box_enemy_side_wing;
        Rectangle box_meteor_up;
        Rectangle box_meteor_side;
        Rectangle box_ball_up;
        Rectangle box_ball_side;
        Rectangle box_player_up_body;
        Rectangle box_player_up_engine;
        Rectangle box_player_side_body;
        Rectangle box_player_side_down;
        Rectangle box_player_side_front;
        Rectangle box_player_side_tail;
        Rectangle box_Powerup_body;
        Rectangle box_shield_player_middle;
        Rectangle box_shield_player_lower1;
        Rectangle box_shield_player_lower2;
        Rectangle box_shield_player_upper1;
        Rectangle box_shield_player_upper2;
        Rectangle box_shield_nemesis_middle;
        Rectangle box_shield_nemesis_lower1;
        Rectangle box_shield_nemesis_lower2;
        Rectangle box_shield_nemesis_upper1;
        Rectangle box_shield_nemesis_upper2;
        Rectangle box_shot_normal;
        Rectangle box_shot_double;
        Rectangle box_shot_tri_straight;
        Rectangle box_shot_tri_up;
        Rectangle box_shot_tri_down;
        Rectangle box_shot_wide_body;
        Rectangle box_shot_wide_upper;
        Rectangle box_shot_wide_lower;
        Rectangle box_shot_wide_ring;
        Rectangle box_mino;

        Entity player;
        Entity ball;
        Entity nemesis;
        Entity shield_player;
        Entity shield_nemesis;
        List<Entity> shipyard   = new List<Entity>();
        List<Entity> shotlist   = new List<Entity>();
        List<Entity> explosions = new List<Entity>();

        int field_upper_end;
        int field_lower_end;

        bool active_mode_basic   = false;
        bool active_mode_ring    = false;
        bool active_mode_meteor  = false;
        bool active_mode_octanom = false;
        bool active_mode_mino    = false;
        bool active_mode_pong    = false;
        bool active_power_normal = true;
        bool active_power_double = false;
        bool active_power_tri    = false;
        bool active_power_ring   = false;
        bool active_power_wide   = false;
        bool active_pause        = false;
        bool active_gameover     = false;
        bool active_heal         = false;

        double timer_ship_normal;
        double timer_ship_double;
        double timer_ship_tri;
        double timer_ship_ring;
        double timer_ship_wide;
        double timer_meteor;
        double timer_ring;
        double timer_shot_normal;
        double timer_shot_double;
        double timer_shot_tri;
        double timer_shot_ring;
        double timer_shot_wide;
        double timer_mino;
        double timer_ship_normal_last;
        double timer_ship_double_last;
        double timer_ship_tri_last;
        double timer_ship_ring_last;
        double timer_ship_wide_last;
        double timer_meteor_last;
        double timer_ring_last;
        double timer_shot_last;
        double timer_mino_last;
        double timer_temp;

        Rectangle button_P_Change;
        Rectangle button_pause;
        Rectangle button_back;

        System.Random random = new System.Random();

        KeyboardState control_keyboard_new;
        KeyboardState control_keyboard_old;
        MouseState control_mouse_new;
        MouseState control_mouse_old;
        TouchCollection control_touch;

        RenderTarget2D renderTarget;

        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;

        int score_result;
        int score_time;
        int score_nomhit;
        int score_timehit;
        int score_multibreak;
        int score_hitcounter;
        int score_multi;
        int score_pong_player;
        int score_pong_nemesis;

        int mino_movement;

        SpriteFont font_score;

        public Stage(ContentManager Content, ShopKeeper Shopkeeper, float core_screen_width_scale, float core_screen_height_scale) {
            this.Content = Content;
            this.Shopkeeper = Shopkeeper;
            this.scaleX = core_screen_width_scale;
            this.scaleY = core_screen_height_scale;
        }

        public void Resize(float x, float y) {
            scaleX = x;
            scaleY = y;
        }

        public void Load_Content(GraphicsDevice GraphicsDevice, SpriteBatch spriteBatch) {

            this.graphicsDevice = GraphicsDevice;
            this.spriteBatch = spriteBatch;

            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.FreeDrag;

            background_starfield_texture = Content.Load<Texture2D>(Shopkeeper.graphic_background_starfield);
            background_planet_texture_up = Content.Load<Texture2D>(Shopkeeper.graphic_background_planet_up);
            background_planet_texture_side = Content.Load<Texture2D>(Shopkeeper.graphic_background_planet_side);
            background_meteorfield_texture_up = Content.Load<Texture2D>(Shopkeeper.graphic_background_meteorfield_up);
            background_meteorfield_texture_side = Content.Load<Texture2D>(Shopkeeper.graphic_background_meteorfield_side);
            background_end = Shopkeeper.game_default_width;
            hud_back = Content.Load<Texture2D>(Shopkeeper.graphic_hud_back);
            hud_hitpoint1 = Content.Load<Texture2D>(Shopkeeper.graphic_hud_hitpoint1);
            hud_hitpoint2 = Content.Load<Texture2D>(Shopkeeper.graphic_hud_hitpoint2);
            hud_hitpoint3 = Content.Load<Texture2D>(Shopkeeper.graphic_hud_hitpoint3);
            hud_hitpoint4 = Content.Load<Texture2D>(Shopkeeper.graphic_hud_hitpoint4);
            hud_hud = Content.Load<Texture2D>(Shopkeeper.graphic_hud_hud);
            hud_off = Content.Load<Texture2D>(Shopkeeper.graphic_hud_off);
            hud_pause = Content.Load<Texture2D>(Shopkeeper.graphic_hud_pause);
            hud_powerupdouble = Content.Load<Texture2D>(Shopkeeper.graphic_hud_powerupdouble);
            hud_powerupnormal = Content.Load<Texture2D>(Shopkeeper.graphic_hud_powerupnormal);
            hud_powerupring = Content.Load<Texture2D>(Shopkeeper.graphic_hud_powerupring);
            hud_poweruptri = Content.Load<Texture2D>(Shopkeeper.graphic_hud_poweruptri);
            hud_powerupwide = Content.Load<Texture2D>(Shopkeeper.graphic_hud_powerupwide);
            //mino_air = Content.Load<Texture2D>(Shopkeeper.graphic_mino_air);
            //mino_blank = Content.Load<Texture2D>(Shopkeeper.graphic_mino_blank);
            //mino_dark = Content.Load<Texture2D>(Shopkeeper.graphic_mino_dark);
            //mino_earth = Content.Load<Texture2D>(Shopkeeper.graphic_mino_earth);
            //mino_fire = Content.Load<Texture2D>(Shopkeeper.graphic_mino_fire);
            //mino_gold = Content.Load<Texture2D>(Shopkeeper.graphic_mino_gold);
            //mino_ice = Content.Load<Texture2D>(Shopkeeper.graphic_mino_ice);
            //mino_light = Content.Load<Texture2D>(Shopkeeper.graphic_mino_light);
            //mino_metal = Content.Load<Texture2D>(Shopkeeper.graphic_mino_metal);
            //mino_nature = Content.Load<Texture2D>(Shopkeeper.graphic_mino_nature);
            //mino_thunder = Content.Load<Texture2D>(Shopkeeper.graphic_mino_thunder);
            //mino_water = Content.Load<Texture2D>(Shopkeeper.graphic_mino_water);
            spritesheet_explosion = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_animationexplosion);
            spritesheet_shield = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_animationshield);
            spritesheet_shot = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_animationshot);
            spritesheet_meteor = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_objectmeteor);
            spritesheet_powerup = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_objectpowerup);
            spritesheet_ring = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_objectring);
            spritesheet_enemy = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_shipenemy);
            spritesheet_octanom = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_shipoctanom);
            spritesheet_player = Content.Load<Texture2D>(Shopkeeper.graphic_spritesheet_shipplayer);
            sound_damage = Content.Load<SoundEffect>(Shopkeeper.audio_sound_damage);
            sound_explosion = Content.Load<SoundEffect>(Shopkeeper.audio_sound_explosion);
            sound_pew = Content.Load<SoundEffect>(Shopkeeper.audio_sound_pew);
            sound_pong1 = Content.Load<SoundEffect>(Shopkeeper.audio_sound_pong1);
            sound_pong2 = Content.Load<SoundEffect>(Shopkeeper.audio_sound_pong2);
            renderTarget = new RenderTarget2D(graphicsDevice, Shopkeeper.game_default_width, Shopkeeper.game_default_height);
            box_enemy_up_body = Shopkeeper.box_enemy_up_body;
            box_enemy_up_wing = Shopkeeper.box_enemy_up_wing;
            box_enemy_side_body = Shopkeeper.box_enemy_side_body;
            box_enemy_side_wing = Shopkeeper.box_enemy_side_wing;
            box_meteor_up = Shopkeeper.box_meteor_up;
            box_meteor_side = Shopkeeper.box_meteor_side;
            box_ball_up = Shopkeeper.box_ball_up;
            box_ball_side = Shopkeeper.box_ball_side;
            box_player_up_body = Shopkeeper.box_player_up_body;
            box_player_up_engine = Shopkeeper.box_player_up_engine;
            box_player_side_body = Shopkeeper.box_player_side_body;
            box_player_side_down = Shopkeeper.box_player_side_down;
            box_player_side_front = Shopkeeper.box_player_side_front;
            box_player_side_tail = Shopkeeper.box_player_side_tail;
            box_Powerup_body = Shopkeeper.box_Powerup_body;
            box_shield_player_middle = Shopkeeper.box_shield_player_middle;
            box_shield_player_lower1 = Shopkeeper.box_shield_player_lower1;
            box_shield_player_lower2 = Shopkeeper.box_shield_player_lower2;
            box_shield_player_upper1 = Shopkeeper.box_shield_player_upper1;
            box_shield_player_upper2 = Shopkeeper.box_shield_player_upper2;
            box_shield_nemesis_middle = Shopkeeper.box_shield_nemesis_middle;
            box_shield_nemesis_lower1 = Shopkeeper.box_shield_nemesis_lower1;
            box_shield_nemesis_lower2 = Shopkeeper.box_shield_nemesis_lower2;
            box_shield_nemesis_upper1 = Shopkeeper.box_shield_nemesis_upper1;
            box_shield_nemesis_upper2 = Shopkeeper.box_shield_nemesis_upper2;
            box_shot_normal = Shopkeeper.box_shot_normal;
            box_shot_double = Shopkeeper.box_shot_double;
            box_shot_tri_straight = Shopkeeper.box_shot_tri_straight;
            box_shot_tri_up = Shopkeeper.box_shot_tri_up;
            box_shot_tri_down = Shopkeeper.box_shot_tri_down;
            box_shot_wide_body = Shopkeeper.box_shot_wide_body;
            box_shot_wide_upper = Shopkeeper.box_shot_wide_upper;
            box_shot_wide_lower = Shopkeeper.box_shot_wide_lower;
            box_shot_wide_ring = Shopkeeper.box_shot_wide_ring;
            box_mino = Shopkeeper.box_mino;
            field_upper_end = Shopkeeper.position_game_height_start;
            field_lower_end = Shopkeeper.position_game_height_end;
            background_starfield_position = 0;
            background_planet_position = 0;
            background_meteorfield_position = 0;
            score_result = 0;
            score_multi = 1;
            score_hitcounter = 0;
            score_pong_player = 0;
            score_pong_nemesis = 0;
            score_time = Shopkeeper.score_time;
            score_nomhit = Shopkeeper.score_nomhit;
            score_timehit = Shopkeeper.score_timehit;
            score_multibreak = Shopkeeper.score_multibreak;
            timer_ship_normal = Shopkeeper.timer_ship_normal;
            timer_ship_double = Shopkeeper.timer_ship_double;
            timer_ship_tri = Shopkeeper.timer_ship_tri;
            timer_ship_ring = Shopkeeper.timer_ship_ring;
            timer_ship_wide = Shopkeeper.timer_ship_wide;
            timer_meteor = Shopkeeper.timer_meteor;
            timer_ring = Shopkeeper.timer_ring;
            timer_shot_normal = Shopkeeper.timer_shot_normal;
            timer_shot_double = Shopkeeper.timer_shot_double;
            timer_shot_tri = Shopkeeper.timer_shot_tri;
            timer_shot_ring = Shopkeeper.timer_shot_ring;
            timer_shot_wide = Shopkeeper.timer_shot_wide;
            timer_mino = Shopkeeper.timer_mino;
            timer_ship_normal_last = 0;
            timer_ship_double_last = 0;
            timer_ship_tri_last = 0;
            timer_ship_ring_last = 0;
            timer_ship_wide_last = 0;
            timer_meteor_last = 0;
            timer_ring_last = 0;
            timer_shot_last = 0;
            timer_mino_last = 0;
            button_P_Change = Shopkeeper.button_P_Change;
            button_pause = Shopkeeper.button_pause;
            button_back = Shopkeeper.button_back;
            ring_lastPosition = new Vector3(0, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2);
            mino_movement = 32;
            player = new Entity("player", "player", 4, Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            nemesis = new Entity("nemesis", "nemesis", 4, Shopkeeper.game_default_width - Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            ball = new Entity("ball", "ball", 1, Shopkeeper.game_default_width / 2, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            shield_player = new Entity("shield", "player", 1, Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            shield_nemesis = new Entity("shield", "nemesis", 1, Shopkeeper.game_default_width - Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            font_score = Content.Load<SpriteFont>("Fonts/FontScore");
        }

        public void Unload_Content() {
        }

        public string update(GameTime gameTime) {
            control_keyboard_new = Keyboard.GetState();
            control_mouse_new = Mouse.GetState();
            control_touch = TouchPanel.GetState();

            // Keyboard: Return to Menu
            if(control_keyboard_new.IsKeyDown(Keys.Escape) && control_keyboard_old.IsKeyUp(Keys.Escape)) {
                return "menu";
            }

            // Keyboard: Pause
            if(control_keyboard_new.IsKeyDown(Keys.Enter) && control_keyboard_old.IsKeyUp(Keys.Enter) && !active_gameover) {
                if(!active_pause) {
                    active_pause = true;
                } else {
                    active_pause = false;
                }
            }

            // Mouse: Return To Menu
            if(control_mouse_new.LeftButton == ButtonState.Pressed && control_mouse_old.LeftButton == ButtonState.Released && active_gameover) {
                return "menu";
            }

            // HUD Button: P-Change (Mouse)
            if(control_mouse_new.LeftButton == ButtonState.Pressed && control_mouse_old.LeftButton == ButtonState.Released && !active_mode_pong && !active_mode_mino && !active_gameover) {
                if(button_P_Change.X * scaleX < control_mouse_new.Position.X && control_mouse_new.Position.X < button_P_Change.X * scaleX + button_P_Change.Width * scaleX && button_P_Change.Y * scaleY < control_mouse_new.Position.Y && control_mouse_new.Position.Y < button_P_Change.Y * scaleY + button_P_Change.Height * scaleY) {
                    if(P_Change) {
                        P_Change = false;
                    } else {
                        P_Change = true;
                    }
                }
            }

            //HUD Button: Pause (Mouse)
            if(control_mouse_new.LeftButton == ButtonState.Pressed && control_mouse_old.LeftButton == ButtonState.Released && !active_gameover) {
                if(button_pause.X * scaleX < control_mouse_new.Position.X && control_mouse_new.Position.X < button_pause.X * scaleX + button_pause.Width * scaleX && button_pause.Y * scaleY < control_mouse_new.Position.Y && control_mouse_new.Position.Y < button_pause.Y * scaleY + button_pause.Height * scaleY) {
                    if(active_pause) {
                        active_pause = false;
                    } else {
                        active_pause = true;
                    }
                }
            }

            //HUD Button: Pause (Mouse)
            if(control_mouse_new.LeftButton == ButtonState.Pressed && control_mouse_old.LeftButton == ButtonState.Released && !active_gameover && active_pause) {
                if(button_back.X * scaleX < control_mouse_new.Position.X && control_mouse_new.Position.X < button_back.X * scaleX + button_back.Width * scaleX && button_back.Y * scaleY < control_mouse_new.Position.Y && control_mouse_new.Position.Y < button_back.Y * scaleY + button_back.Height * scaleY) {
                    return "menu";
                }
            }

            // Touch Input
            while(TouchPanel.IsGestureAvailable) {
                var gesture = TouchPanel.ReadGesture();
                switch(gesture.GestureType) {
                    case GestureType.Tap:
                        if(active_gameover) {
                            return "menu";
                        }

                        // HUD Button: P-Change (Touch)
                        if(!active_mode_pong && !active_mode_mino && !active_gameover && !active_pause) {
                            if(button_P_Change.X * scaleX < gesture.Position.X && gesture.Position.X < button_P_Change.X * scaleX + button_P_Change.Width * scaleX && button_P_Change.Y * scaleY < gesture.Position.Y && gesture.Position.Y < button_P_Change.Y * scaleY + button_P_Change.Height * scaleY) {
                                if(P_Change) {
                                    P_Change = false;
                                } else {
                                    P_Change = true;
                                }
                            }
                        }

                        //HUD Button: Pause (Touch)
                        if(!active_gameover) {
                            if(button_pause.X * scaleX < gesture.Position.X && gesture.Position.X < button_pause.X * scaleX + button_pause.Width * scaleX && button_pause.Y * scaleY < gesture.Position.Y && gesture.Position.Y < button_pause.Y * scaleY + button_pause.Height * scaleY) {
                                if(active_pause) {
                                    active_pause = false;
                                } else {
                                    active_pause = true;
                                }
                            }
                        }

                        //HUD Button: Pause (Touch)
                        if(active_pause && !active_gameover) {
                            if(button_back.X * scaleX < gesture.Position.X && gesture.Position.X < button_back.X * scaleX + button_back.Width * scaleX && button_back.Y * scaleY < gesture.Position.Y && gesture.Position.Y < button_back.Y * scaleY + button_back.Height * scaleY) {
                                return "menu";
                            }
                        }

                        break;

                    // Touch: Player Ship Control
                    case GestureType.FreeDrag:
                        if(!active_mode_mino && !active_mode_octanom && !active_mode_pong && gesture.Position.Y > field_upper_end && gesture.Position.Y < field_lower_end * scaleY && !active_gameover && !active_pause) {
                            player.Set_Pos_X(gesture.Position.X / scaleX - 16 * player.Get_Distance(P_Change) + 200);
                        }
                        if(!P_Change) {
                            if(gesture.Position.Y > field_upper_end && gesture.Position.Y < field_lower_end * scaleY) {
                                player.Set_Pos_Y(gesture.Position.Y / scaleY - 16 * player.Get_Distance(P_Change));
                            }
                        } else {
                            if(gesture.Position.Y > field_upper_end && gesture.Position.Y < field_lower_end * scaleY) {
                                player.Set_Pos_Z(gesture.Position.Y / scaleY - 16 * player.Get_Distance(P_Change));
                            }
                        }
                        if(active_mode_basic && gesture.Position.Y > field_upper_end && gesture.Position.Y < field_lower_end * scaleY) {
                            Spawn_Shot(gameTime.TotalGameTime.TotalMilliseconds);
                        }
                        break;
                }
            }

            if(!active_pause) {
                if(!active_gameover) {

                    // Keyboard: Movind Up/Down
                    if(control_keyboard_new.IsKeyDown(Keys.Up)) {
                        if(!P_Change) {
                            if(player.Get_Pos_Y() > field_upper_end)
                                player.Set_Pos_Y(player.Get_Pos_Y() - 3);
                        } else {
                            if(player.Get_Pos_Z() > field_upper_end)
                                player.Set_Pos_Z(player.Get_Pos_Z() - 3);
                        }
                    } else if(control_keyboard_new.IsKeyDown(Keys.Down)) {
                        if(!P_Change) {
                            if(player.Get_Pos_Y() < field_lower_end)
                                player.Set_Pos_Y(player.Get_Pos_Y() + 3);
                        } else {
                            if(player.Get_Pos_Z() < field_lower_end)
                                player.Set_Pos_Z(player.Get_Pos_Z() + 3);
                        }
                    }

                    // Keyboard: Moving Right/Left
                    if(control_keyboard_new.IsKeyDown(Keys.Left) && !active_mode_mino && !active_mode_octanom && !active_mode_pong) {
                        player.Set_Pos_X(player.Get_Pos_X() - 3);
                    } else if(control_keyboard_new.IsKeyDown(Keys.Right) && !active_mode_mino && !active_mode_octanom && !active_mode_pong) {
                        player.Set_Pos_X(player.Get_Pos_X() + 3);
                    }

                    // Keyboard: Shooting
                    if(control_keyboard_new.IsKeyDown(Keys.Space) && active_mode_basic) {
                        Spawn_Shot(gameTime.TotalGameTime.TotalMilliseconds);
                    }

                    // Keyboard: P-Change
                    if(control_keyboard_new.IsKeyDown(Keys.RightControl) && control_keyboard_old.IsKeyUp(Keys.RightControl) && !active_mode_mino && !active_mode_pong) {
                        player.Set_Vel_Y(0);
                        player.Set_Vel_Z(0);
                        if(!P_Change) {
                            P_Change = true;
                        } else {
                            P_Change = false;
                        }
                    }

                    // Mouse: Player Ship Control
                    if(control_mouse_new.LeftButton == ButtonState.Pressed) {
                        if(!active_mode_mino && !active_mode_octanom && !active_mode_pong && control_mouse_new.Position.Y > field_upper_end && control_mouse_new.Position.Y < field_lower_end * scaleY) {
                            player.Set_Pos_X(control_mouse_new.Position.X / scaleX - 16 * player.Get_Distance(P_Change));
                        }
                        if(!P_Change) {
                            if(control_mouse_new.Position.Y > field_upper_end && control_mouse_new.Position.Y < field_lower_end * scaleY) {
                                player.Set_Pos_Y(control_mouse_new.Position.Y / scaleY - 16 * player.Get_Distance(P_Change));
                            }
                        } else {
                            if(control_mouse_new.Position.Y > field_upper_end && control_mouse_new.Position.Y < field_lower_end * scaleY) {
                                player.Set_Pos_Z(control_mouse_new.Position.Y / scaleY - 16 * player.Get_Distance(P_Change));
                            }
                        }
                        if(active_mode_basic && control_mouse_new.Position.Y > field_upper_end && control_mouse_new.Position.Y < field_lower_end * scaleY) {
                            Spawn_Shot(gameTime.TotalGameTime.TotalMilliseconds);
                        }
                    }

                    // Mouse: P-Change
                    if(control_mouse_new.RightButton == ButtonState.Pressed && control_mouse_old.RightButton == ButtonState.Released && !active_mode_mino && !active_mode_pong) {
                        player.Set_Vel_Y(0);
                        player.Set_Vel_Z(0);
                        if(!P_Change) {
                            P_Change = true;
                        } else {
                            P_Change = false;
                        }
                    }
                }



                // Update Cycle

                // Update Background
                background_starfield_position = background_starfield_position + 1 * score_multi;
                background_planet_position = background_planet_position + 2 * score_multi;
                background_meteorfield_position = background_meteorfield_position + 3 * score_multi;
                if(background_starfield_position >= background_end) background_starfield_position = 0;
                if(background_planet_position >= background_end) background_planet_position = 0;
                if(background_meteorfield_position >= background_end) background_meteorfield_position = 0;

                // Spawn Stuff
                if(active_mode_basic) {
                    Spawn_Ship(gameTime.TotalGameTime.TotalMilliseconds);
                }
                if(active_mode_meteor) {
                    Spawn_Meteor(gameTime.TotalGameTime.TotalMilliseconds);
                }
                if(active_mode_ring) {
                    Spawn_Ring(gameTime.TotalGameTime.TotalMilliseconds);
                }
                if(active_mode_mino) {
                    Spawn_Mino(gameTime.TotalGameTime.TotalMilliseconds);
                }

                //Update Entites
                player.Update(scaleX, scaleY);
                nemesis.Update(scaleX, scaleY);
                ball.Update(scaleX, scaleY);
                shield_player.Update(scaleX, scaleY);
                shield_nemesis.Update(scaleX, scaleY);
                foreach(Entity x in shipyard) {
                    x.Update(scaleX, scaleY);
                }
                foreach(Entity x in shotlist) {
                    x.Update(scaleX, scaleY);
                }
                foreach(Entity x in shipyard) {
                    if(x.Get_Pos_X() < -64) {
                        shipyard.Remove(x);
                        break;
                    }
                }
                foreach(Entity e in explosions) {
                    if(e.Get_HP() > 15) {
                        explosions.Remove(e);
                        break;
                    }
                }
                if(active_mode_pong) {
                    if(ball.Get_Pos_Z() < nemesis.Get_Pos_Z()) {
                        nemesis.Set_Pos_Z(nemesis.Get_Pos_Z() - 2);
                    }
                    if(ball.Get_Pos_Z() > nemesis.Get_Pos_Z()) {
                        nemesis.Set_Pos_Z(nemesis.Get_Pos_Z() + 2);
                    }
                }
                if(ball.Get_Pos_X() < 0) {
                    Reset_Ball();
                    if(active_mode_pong) {
                        score_pong_nemesis++;
                    } else {
                        player.Set_HP(player.Get_HP() - 1);
                    }
                }
                if(ball.Get_Pos_X() > Shopkeeper.game_default_width && ball.Get_Vel_X() > 0) {
                    if(active_mode_pong) {
                        score_pong_player++;
                        Reset_Ball();
                    } else {
                        ball.Set_Vel_X(ball.Get_Vel_X() * -1);
                    }
                }

                // Collision Course
                if(!active_gameover) {
                    foreach(Entity x in shotlist) {
                        if(x.Get_Pos_X() > Shopkeeper.game_default_width + 32) {
                            shotlist.Remove(x);
                            break;
                        }
                        if(x.Get_Pos_Y() < 0 || x.Get_Pos_Z() < 0 || x.Get_Pos_Y() > Shopkeeper.game_default_height || x.Get_Pos_Z() > Shopkeeper.game_default_height) {
                            shotlist.Remove(x);
                            break;
                        }
                    }
                    bool tempbreak = false;
                    foreach(Entity x in shipyard) {
                        if(x.Get_ID() == "ring") {
                            int temp = RingCollision(x);
                            if(temp == 1) {
                                x.Set_HP(1);
                                player.Set_IsHit(true);
                                score_time = score_time - score_timehit;
                                EquipPowerUp("normal");
                                if(active_mode_octanom) {
                                    player.Set_Pos_X(player.Get_Pos_X() - score_nomhit / 2);
                                }
                            }
                            if(temp == 2) {
                                x.Set_HP(2);
                                score_result = score_result + x.Get_Value() * score_multi;
                                score_hitcounter++;
                                if(active_mode_octanom) {
                                    player.Set_Pos_X(player.Get_Pos_X() + score_nomhit / 8);
                                }
                            }
                        } else if(x.Get_ID() == "powerup") {
                            bool temp;
                            temp = CollisionCourseBasic(x, player);
                            if(temp) {
                                EquipPowerUp(x.Get_ID_Sub());
                                shipyard.Remove(x);
                                break;
                            }
                        } else if(x.Get_ID() == "ship") {
                            bool temp;
                            temp = CollisionCourseBasic(x, player);
                            if(temp) {
                                if(active_mode_ring && active_mode_octanom) {
                                    score_time = score_time - score_timehit / 4;
                                    player.Set_Pos_X(player.Get_Pos_X() - 5);
                                } else if(active_mode_ring) {
                                    score_time = score_time - score_timehit / 4;
                                } else if(active_mode_octanom) {
                                    player.Set_Pos_X(player.Get_Pos_X() - score_nomhit);
                                } else {
                                    player.Change_HP(-1);
                                }
                                EquipPowerUp("normal");
                                player.Set_IsHit(true);
                                explosions.Add(new Entity("explosion", "explosion", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                sound_explosion.Play();
                                shipyard.Remove(x);
                                break;
                            }
                            foreach(Entity z in shotlist) {
                                temp = CollisionCourseBasic(x, z);
                                if(temp) {
                                    x.Change_HP(-1);
                                    x.Set_IsHit(true);
                                    if(x.Get_HP() == 0) {
                                        int r = random.Next(8);
                                        if(r == 0) {
                                            if(active_heal && player.Get_HP() < 4) {
                                                shipyard.Add(new Entity("powerup", "heal", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                                active_heal = false;
                                            } else {
                                                if(x.Get_ID_Sub() != "normal")
                                                    shipyard.Add(new Entity("powerup", x.Get_ID_Sub(), 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                            }
                                        }
                                        explosions.Add(new Entity("explosion", "explosion", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                        sound_explosion.Play();
                                        player.Set_Pos_X(player.Get_Pos_X() + score_nomhit / 4);
                                        if(active_mode_ring) {
                                            score_time = score_time + score_timehit / 4;
                                        }
                                        score_result = score_result + x.Get_Value() * score_multi;
                                        score_hitcounter++;
                                        shipyard.Remove(x);
                                        tempbreak = true;
                                    }
                                    shotlist.Remove(z);
                                    break;
                                }
                            }
                            if(tempbreak) break;
                        } else if(x.Get_ID() == "mino") {
                            int temp;
                            temp = CollisionCourseMino(player, x);
                            if(temp == 11 || temp == 22) {
                                player.Change_HP(-1);
                                explosions.Add(new Entity("explosion", "explosion", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                sound_explosion.Play();
                                shipyard.Remove(x);
                                break;
                            }
                            temp = CollisionCourseMino(ball, x);
                            if(temp == 11) { // up
                                ball.Set_Vel_Z(ball.Get_Vel_Z() * -1);
                                if(ball.Get_Vel_Z() == 0) {
                                    if(0 == random.Next(2)) {
                                        ball.Set_Vel_Z(ball.Get_Vel_X());
                                    } else {
                                        ball.Set_Vel_Z(ball.Get_Vel_X() * -1);
                                    }
                                }
                                score_result = score_result + x.Get_Value() * score_multi;
                                score_hitcounter++;
                                explosions.Add(new Entity("explosion", "explosion", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                sound_explosion.Play();
                                shipyard.Remove(x);
                                break;
                            }
                            if(temp == 22) { // side
                                ball.Set_Vel_X(ball.Get_Vel_X() * -1);
                                if(ball.Get_Vel_Z() == 0) {
                                    if(0 == random.Next(2)) {
                                        ball.Set_Vel_Z(ball.Get_Vel_X());
                                    } else {
                                        ball.Set_Vel_Z(ball.Get_Vel_X() * -1);
                                    }
                                }
                                score_result = score_result + x.Get_Value() * score_multi;
                                score_hitcounter++;
                                explosions.Add(new Entity("explosion", "explosion", 1, x.Get_Pos_X(), x.Get_Pos_Y(), x.Get_Pos_Z(), x.Get_Vel_X(), x.Get_Vel_Y(), x.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                                sound_explosion.Play();
                                shipyard.Remove(x);
                                break;
                            }
                        }
                    }
                    int tempBall;
                    if(ball.Get_Vel_X() < 0 && (active_mode_mino || active_mode_pong)) {
                        tempBall = CollisionCourseMino(ball, player);
                        if(tempBall == -2) {
                            ball.Set_Vel_X(+4);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(-6);
                            sound_pong1.Play();
                        }
                        if(tempBall == -1) {
                            ball.Set_Vel_X(+7);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(-3);
                            sound_pong1.Play();
                        }
                        if(tempBall == 0) {
                            ball.Set_Vel_X(+9);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(0);
                            sound_pong1.Play();
                        }
                        if(tempBall == +1) {
                            ball.Set_Vel_X(+7);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(+3);
                            sound_pong1.Play();
                        }
                        if(tempBall == +2) {
                            ball.Set_Vel_X(+4);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(+6);
                            sound_pong1.Play();
                        }
                    }
                    if(ball.Get_Vel_X() > 0 && active_mode_pong) {
                        tempBall = CollisionCourseMino(ball, nemesis);
                        if(tempBall == -2) {
                            ball.Set_Vel_X(-4);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(-6);
                            sound_pong2.Play();
                        }
                        if(tempBall == -1) {
                            ball.Set_Vel_X(-7);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(-3);
                            sound_pong2.Play();
                        }
                        if(tempBall == 0) {
                            ball.Set_Vel_X(-9);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(0);
                            sound_pong2.Play();
                        }
                        if(tempBall == +1) {
                            ball.Set_Vel_X(-7);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(+3);
                            sound_pong2.Play();
                        }
                        if(tempBall == +2) {
                            ball.Set_Vel_X(-4);
                            ball.Set_Vel_Y(0);
                            ball.Set_Vel_Z(+6);
                            sound_pong2.Play();
                        }
                    }
                }
            }

            if(player.Get_HP() <= 0 && !active_gameover) {
                explosions.Add(new Entity("explosion", "explosion", 1, player.Get_Pos_X(), player.Get_Pos_Y(), player.Get_Pos_Z(), player.Get_Vel_X(), player.Get_Vel_Y(), player.Get_Vel_Z(), field_upper_end, field_lower_end, 1));
                sound_explosion.Play();
                active_gameover = true;
            }

            if(score_hitcounter >= score_multibreak + score_multi) {
                score_hitcounter = 0;
                score_multi++;
                if(!active_mode_octanom && !active_mode_ring)
                    active_heal = true;
                foreach(Entity x in shipyard) {
                    if(x.Get_ID() == "ring")
                        x.Set_Vel_X(-2 * score_multi);
                }
            }

            if(active_mode_ring) {
                double t = gameTime.TotalGameTime.TotalMilliseconds - timer_temp;
                score_time = score_time - (int)t;
                if(score_time <= 0) {
                    player.Set_HP(0);
                    score_time = 0;
                }
                timer_temp = gameTime.TotalGameTime.TotalMilliseconds;
            }
            if(active_mode_octanom) {
                if(player.Get_Pos_X() < Shopkeeper.game_default_width / 8 * 2) {
                    player.Set_HP(0);
                }
            }

            control_keyboard_old = control_keyboard_new;
            control_mouse_old = control_mouse_new;
            return "null";
        }

        public void Draw(GameTime gameTime) {
            graphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(background_starfield_texture, new Rectangle(-background_starfield_position, 0, background_starfield_texture.Width, background_starfield_texture.Height), Color.White);
            spriteBatch.Draw(background_starfield_texture, new Rectangle(-background_starfield_position + background_end, 0, background_starfield_texture.Width, background_starfield_texture.Height), Color.White);
            if(active_mode_ring) {
                if(P_Change) {
                    spriteBatch.Draw(background_planet_texture_up, new Rectangle(-background_planet_position, 0, background_planet_texture_up.Width, background_planet_texture_up.Height), Color.White);
                    spriteBatch.Draw(background_planet_texture_up, new Rectangle(-background_planet_position + background_end, 0, background_planet_texture_up.Width, background_planet_texture_up.Height), Color.White);
                } else {
                    spriteBatch.Draw(background_planet_texture_side, new Rectangle(-background_planet_position, 0, background_planet_texture_side.Width, background_planet_texture_side.Height), Color.White);
                    spriteBatch.Draw(background_planet_texture_side, new Rectangle(-background_planet_position + background_end, 0, background_planet_texture_side.Width, background_planet_texture_side.Height), Color.White);
                }
            }
            if(active_mode_meteor) {
                if(P_Change) {
                    spriteBatch.Draw(background_meteorfield_texture_up, new Rectangle(-background_meteorfield_position, 0, background_meteorfield_texture_up.Width, background_meteorfield_texture_up.Height), Color.White);
                    spriteBatch.Draw(background_meteorfield_texture_up, new Rectangle(-background_meteorfield_position + background_end, 0, background_meteorfield_texture_up.Width, background_meteorfield_texture_up.Height), Color.White);
                } else {
                    spriteBatch.Draw(background_meteorfield_texture_side, new Rectangle(-background_meteorfield_position, 0, background_meteorfield_texture_side.Width, background_meteorfield_texture_side.Height), Color.White);
                    spriteBatch.Draw(background_meteorfield_texture_side, new Rectangle(-background_meteorfield_position + background_end, 0, background_meteorfield_texture_side.Width, background_meteorfield_texture_side.Height), Color.White);
                }
            }

            for(int p = 1; p < 5; p = p * 2) {
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "ring" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i;
                        Color color;
                        if(E.Get_HP() == 1) { color = Color.Red; } else if(E.Get_HP() == 2) { color = Color.Green; } else { color = Color.White; }
                        if(!P_Change) { i = 0; y = E.Get_Pos_Y(); } else { i = 0; y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_ring, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "powerup" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i = Get_PowerUp_Sprite_ID(E.Get_ID_Sub());
                        Color color;
                        if(E.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_powerup, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
                if(player.Get_ID() == "player" && !active_gameover && player.Get_Distance(P_Change) == p) {
                    float x = player.Get_Pos_X();
                    float y;
                    int i;
                    Color color;
                    if(player.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                    if(!P_Change) { i = 1; y = player.Get_Pos_Y(); } else { i = 0; y = player.Get_Pos_Z(); }
                    spriteBatch.Draw(spritesheet_player, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * player.Get_Distance(P_Change), 16 * player.Get_Distance(P_Change)), player.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                    if(player.Get_IsHit()) player.Set_IsHit(false);
                    if(active_mode_mino || active_mode_pong)
                        spriteBatch.Draw(spritesheet_shield, new Vector2(x, y), new Rectangle(1, 1, 64, 64), color, 0.0f, new Vector2(16 * player.Get_Distance(P_Change), 16 * player.Get_Distance(P_Change)), player.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                }
                if(nemesis.Get_ID() == "nemesis" && active_mode_pong && nemesis.Get_Distance(P_Change) == p) {
                    float x = nemesis.Get_Pos_X();
                    float y;
                    int i;
                    if(!P_Change) { i = 1; y = nemesis.Get_Pos_Y(); } else { i = 0; y = nemesis.Get_Pos_Z(); }
                    spriteBatch.Draw(spritesheet_player, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), Color.AntiqueWhite, 0.0f, new Vector2(16 * nemesis.Get_Distance(P_Change), 16 * nemesis.Get_Distance(P_Change)), nemesis.Get_Distance(P_Change), SpriteEffects.FlipHorizontally, 0.0f);
                    if(nemesis.Get_IsHit()) nemesis.Set_IsHit(false);
                    spriteBatch.Draw(spritesheet_shield, new Vector2(x, y), new Rectangle(1, 2 + 64, 64, 64), Color.MediumVioletRed, 0.0f, new Vector2(16 * nemesis.Get_Distance(P_Change), 16 * nemesis.Get_Distance(P_Change)), nemesis.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                }
                if(ball.Get_ID() == "ball" && (active_mode_mino || active_mode_pong) && ball.Get_Distance(P_Change) == p) {
                    float x = ball.Get_Pos_X();
                    float y;
                    int i;
                    Color color;
                    if(ball.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                    if(!P_Change) { i = 1; y = ball.Get_Pos_Y(); } else { i = 1; y = ball.Get_Pos_Z(); }
                    spriteBatch.Draw(spritesheet_meteor, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * ball.Get_Distance(P_Change), 16 * ball.Get_Distance(P_Change)), ball.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                    if(ball.Get_IsHit()) ball.Set_IsHit(false);
                }
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "ship" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i = Get_Object_Sprite_ID(E.Get_ID_Sub());
                        Color color;
                        if(E.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_enemy, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
                foreach(Entity S in shotlist) {
                    if(S.Get_ID() == "shot" && S.Get_Distance(P_Change) == p) {
                        float x = S.Get_Pos_X();
                        float y;
                        int i = Get_Shot_Sprite_ID(S.Get_ID_Sub());
                        Color color;
                        if(S.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = S.Get_Pos_Y(); } else { y = S.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_shot, new Vector2(x, y), new Rectangle(1, 1 + i + (32 * i), 32, 32), color, 0.0f, new Vector2(8 * S.Get_Distance(P_Change), 8 * S.Get_Distance(P_Change)), S.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(S.Get_IsHit()) S.Set_IsHit(false);
                    }
                }
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "meteor" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i = 0;
                        Color color;
                        if(E.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_meteor, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "mino" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        Color color;
                        if(E.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(Get_Mino_Sprite(E.Get_ID_Sub()), new Vector2(x, y), new Rectangle(0, 0, 32, 32), color, 0.0f, new Vector2(8 * E.Get_Distance(P_Change), 8 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
                foreach(Entity E in explosions) {
                    if(E.Get_ID() == "explosion" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i = E.Get_HP();
                        if(i == 0) i = 0;
                        if(i == 1) i = 0;
                        if(i == 2) i = 1;
                        if(i == 3) i = 1;
                        if(i == 4) i = 2;
                        if(i == 5) i = 2;
                        if(i == 6) i = 3;
                        if(i == 7) i = 3;
                        if(i == 8) i = 4;
                        if(i == 9) i = 4;
                        if(i == 10) i = 5;
                        if(i == 11) i = 5;
                        if(i == 12) i = 6;
                        if(i == 13) i = 6;
                        if(i == 14) i = 7;
                        if(i == 15) i = 7;
                        Color color;
                        if(E.Get_IsHit()) { color = Color.Black; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_explosion, new Vector2(x, y), new Rectangle(1 + i + (64 * i), 1, 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                        E.Change_HP(1);
                    }
                }
                foreach(Entity E in shipyard) {
                    if(E.Get_ID() == "ring" && E.Get_Distance(P_Change) == p) {
                        float x = E.Get_Pos_X();
                        float y;
                        int i = 1;
                        Color color;
                        if(E.Get_HP() == 1) { color = Color.Red; } else if(E.Get_HP() == 2) { color = Color.Green; } else { color = Color.White; }
                        if(!P_Change) { y = E.Get_Pos_Y(); } else { y = E.Get_Pos_Z(); }
                        spriteBatch.Draw(spritesheet_ring, new Vector2(x, y), new Rectangle(1, 1 + i + (64 * i), 64, 64), color, 0.0f, new Vector2(16 * E.Get_Distance(P_Change), 16 * E.Get_Distance(P_Change)), E.Get_Distance(P_Change), SpriteEffects.None, 0.0f);
                        if(E.Get_IsHit()) E.Set_IsHit(false);
                    }
                }
            }
            if(active_mode_octanom) {
                float x = 0;
                float y = Shopkeeper.game_default_height/2;
                int i;
                if(P_Change) { i = 0; } else { i = 1; }
                Color color = Color.White;
                spriteBatch.Draw(spritesheet_octanom, new Vector2(x, y), new Rectangle(1, 1 + 1 * i + 32 * i, 32, 32), color, 0.0f, new Vector2(16 * 1, 16 * 1), 20, SpriteEffects.None, 0.0f);
            }

            if(active_pause)
                spriteBatch.Draw(hud_pause, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);

            spriteBatch.Draw(hud_hud, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            Color tempcolor;
            if(active_mode_ring || active_mode_octanom || active_mode_pong) {
                tempcolor = Color.DarkSlateGray;
            } else {
                tempcolor = Color.White;
            }
            if(player.Get_HP() == 4) {
                spriteBatch.Draw(hud_hitpoint1, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint2, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint3, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint4, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
            }
            if(player.Get_HP() == 3) {
                spriteBatch.Draw(hud_hitpoint1, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint2, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint3, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
            }
            if(player.Get_HP() == 2) {
                spriteBatch.Draw(hud_hitpoint1, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
                spriteBatch.Draw(hud_hitpoint2, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
            }
            if(player.Get_HP() == 1) {
                spriteBatch.Draw(hud_hitpoint1, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), tempcolor);
            }
            if(active_mode_mino || active_mode_pong)
                spriteBatch.Draw(hud_off, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_power_normal)
                spriteBatch.Draw(hud_powerupnormal, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_power_double)
                spriteBatch.Draw(hud_powerupdouble, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_power_tri)
                spriteBatch.Draw(hud_poweruptri, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_power_ring)
                spriteBatch.Draw(hud_powerupring, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_power_wide)
                spriteBatch.Draw(hud_powerupwide, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);
            if(active_pause)
                spriteBatch.Draw(hud_back, new Rectangle(0, 0, hud_hud.Width, hud_hud.Height), Color.White);

            if(!active_mode_pong)
                spriteBatch.DrawString(font_score, "" + score_result, new Vector2(Shopkeeper.game_default_width / 2 - font_score.MeasureString("" + score_result).Length() / 2, 675), Color.White);
            spriteBatch.DrawString(font_score, "" + score_multi + "x", new Vector2(Shopkeeper.game_default_width / 2 - font_score.MeasureString("" + score_result + "x").Length() / 2, 640), Color.White);
            if(active_mode_ring)
                spriteBatch.DrawString(font_score, "" + score_time / 1000, new Vector2(Shopkeeper.game_default_width / 2 - font_score.MeasureString("" + score_time / 1000).Length() / 2, 610), Color.White);
            if(active_mode_pong)
                spriteBatch.DrawString(font_score, score_pong_player + " : " + score_pong_nemesis, new Vector2(Shopkeeper.game_default_width / 2 - font_score.MeasureString(score_pong_player + " : " + score_pong_nemesis).Length() / 2, 675), Color.White);

            spriteBatch.End();
            graphicsDevice.SetRenderTarget(null);
        }

        public RenderTarget2D Get_RenderTarget() {
            return renderTarget;
        }

        public void Start(bool _basic, bool _ring, bool _meteor, bool _octanom, bool _mino, bool _pong) {
            this.active_mode_basic = _basic;
            this.active_mode_ring = _ring;
            this.active_mode_meteor = _meteor;
            this.active_mode_octanom = _octanom;
            this.active_mode_mino = _mino;
            this.active_mode_pong = _pong;
            score_result = 0;
            score_multi = 1;
            score_hitcounter = 0;
            score_pong_player = 0;
            score_pong_nemesis = 0;
            timer_ship_normal_last = 0;
            timer_ship_double_last = 0;
            timer_ship_tri_last = 0;
            timer_ship_ring_last = 0;
            timer_ship_wide_last = 0;
            timer_meteor_last = 0;
            timer_ring_last = 0;
            timer_shot_last = 0;
            timer_mino_last = 0;
            timer_temp = 0;
            ring_lastPosition = new Vector3(0, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2);
            mino_movement = 1;
            player = new Entity("player", "player", 4, Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            nemesis = new Entity("nemesis", "nemesis", 4, Shopkeeper.game_default_width - Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            ball = new Entity("ball", "ball", 1, Shopkeeper.game_default_width / 2, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            shield_player = new Entity("shield", "player", 1, Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            shield_nemesis = new Entity("shield", "nemesis", 1, Shopkeeper.game_default_width - Shopkeeper.game_default_width / 8, Shopkeeper.game_default_height / 2, Shopkeeper.game_default_height / 2, 0, 0, 0, field_upper_end, field_lower_end, 10);
            active_power_normal = true;
            active_power_double = false;
            active_power_tri = false;
            active_power_ring = false;
            active_power_wide = false;
            active_pause = false;
            active_gameover = false;
            if(active_mode_mino || active_mode_pong) {
                P_Change = true;
            } else {
                P_Change = false;
            }
            shipyard.RemoveRange(0, shipyard.Count);
            shotlist.RemoveRange(0, shotlist.Count);
            explosions.RemoveRange(0, explosions.Count);
            if(active_mode_mino) {
                Spawn_Mino_Start();
            }
            if(active_mode_mino || active_mode_pong) {
                ball.Set_Vel_X(-4);
            }
            if(active_mode_octanom) {
                player.Set_Pos_X(Shopkeeper.game_default_width / 8 * 3);
            }
        }

        public void Spawn_Shot(double time) {
            int x = 16*player.Get_Distance(P_Change);
            int y =  8*player.Get_Distance(P_Change);
            int z =  8*player.Get_Distance(P_Change);
            if(!active_mode_mino && !active_mode_pong) {
                if(active_power_normal && time > timer_shot_last + timer_shot_normal) {
                    shotlist.Add(new Entity("shot", "normal", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 10, 0, 0, field_upper_end, field_lower_end, 1));
                    timer_shot_last = time;
                    sound_pew.Play();
                }
                if(active_power_double && time > timer_shot_last + timer_shot_double) {
                    if(P_Change) {
                        shotlist.Add(new Entity("shot", "double", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z - 10, 10, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "double", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z + 10, 10, 0, 0, field_upper_end, field_lower_end, 1));
                    } else {
                        shotlist.Add(new Entity("shot", "double", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y - 15, player.Get_Pos_Z() + z, 10, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "double", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y + 15, player.Get_Pos_Z() + z, 10, 0, 0, field_upper_end, field_lower_end, 1));
                    }
                    timer_shot_last = time;
                    sound_pew.Play();
                }
                if(active_power_tri && time > timer_shot_last + timer_shot_tri) {
                    if(P_Change) {
                        shotlist.Add(new Entity("shot", "tri_up", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 10, 0, -8, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "tri_straight", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 12, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "tri_down", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 10, 0, +8, field_upper_end, field_lower_end, 1));
                    } else {
                        shotlist.Add(new Entity("shot", "tri_up", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 10, -8, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "tri_straight", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 12, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "tri_down", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 10, +8, 0, field_upper_end, field_lower_end, 1));
                    }
                    timer_shot_last = time;
                    sound_pew.Play();
                }
                if(active_power_ring && time > timer_shot_last + timer_shot_ring) {
                    if(P_Change) {
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, 0, +9, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, 0, 0, +9, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, 0, +9, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, 0, -9, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, 0, 0, -9, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, 0, -9, field_upper_end, field_lower_end, 1));
                    } else {
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, +9, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, 0, +9, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, +9, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, 0, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, -9, -9, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, 0, -9, 0, field_upper_end, field_lower_end, 1));
                        shotlist.Add(new Entity("shot", "ring", 1, player.Get_Pos_X() + x, player.Get_Pos_Y() + x, player.Get_Pos_Z() + z, +9, -9, 0, field_upper_end, field_lower_end, 1));
                    }
                    timer_shot_last = time;
                    sound_pew.Play();
                }
                if(active_power_wide && time > timer_shot_last + timer_shot_wide) {
                    shotlist.Add(new Entity("shot", "wide", 5, player.Get_Pos_X() + x, player.Get_Pos_Y() + y, player.Get_Pos_Z() + z, 6, 0, 0, field_upper_end, field_lower_end, 1));
                    timer_shot_last = time;
                    sound_pew.Play();
                }
            }
        }

        public void Spawn_Ship(double time) {
            if(time > timer_ship_normal_last + timer_ship_normal / score_multi + (random.Next(100) - score_multi)) {
                shipyard.Add(new Entity("ship", "normal", 2, Shopkeeper.game_default_width + 15, field_upper_end + random.Next(field_lower_end - field_upper_end), field_upper_end + random.Next(field_lower_end - field_upper_end), -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                timer_ship_normal_last = (int)time;
            }
            if(time > timer_ship_double_last + timer_ship_double / score_multi + (random.Next(200) - score_multi)) {
                int temp = random.Next(4);
                int tempY = field_upper_end + random.Next(field_lower_end - field_upper_end);
                int tempZ = field_upper_end + random.Next(field_lower_end - field_upper_end);
                if(!P_Change) {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY, tempZ - 30, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY, tempZ + 30, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                    } else {
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY - 30, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY + 30, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                    }
                } else {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY - 30, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY + 30, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                    } else {
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY, tempZ - 30, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "double", 2, Shopkeeper.game_default_width + 15, tempY, tempZ + 30, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                    }
                }
                timer_ship_double_last = (int)time;
            }
            if(time > timer_ship_tri_last + timer_ship_tri / score_multi + (random.Next(200) - score_multi)) {
                int temp = random.Next(4);
                int tempY = field_upper_end + random.Next(field_lower_end - field_upper_end);
                int tempZ = field_upper_end + random.Next(field_lower_end - field_upper_end);
                if(!P_Change) {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2 - 80, tempZ, -score_multi, +score_multi, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2 + 80, tempZ, -score_multi, -score_multi, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 1) {
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2, tempZ, -score_multi, -score_multi, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height / 2, tempZ, -score_multi, +score_multi, 0, field_upper_end, field_lower_end, 1));
                    }
                } else {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2 - 80, -score_multi, 0, +score_multi, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2 + 80, -score_multi, 0, score_multi, field_upper_end, field_lower_end, 1));
                    } else if(temp == 1) {
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2, -score_multi, 0, -score_multi, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "tri", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height / 2, -score_multi, 0, +score_multi, field_upper_end, field_lower_end, 1));
                    }
                }

                timer_ship_tri_last = (int)time;
            }
            if(time > timer_ship_ring_last + timer_ship_ring / score_multi + (random.Next(200) - score_multi)) {
                int tempY = field_upper_end + random.Next(field_lower_end - field_upper_end);
                int tempZ = field_upper_end + random.Next(field_lower_end - field_upper_end);
                if(!P_Change) {
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width, -15, -15, -score_multi * 2, +score_multi, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 10, -25, -25, -score_multi * 2, +score_multi * 2, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 20, -35, -35, -score_multi * 2, +score_multi * 2, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 30, -45, -45, -score_multi * 2, +score_multi * 3, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 40, -55, -55, -score_multi * 2, +score_multi * 3, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_width + 15, -score_multi * 2, -score_multi, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 10, Shopkeeper.game_default_width + 25, Shopkeeper.game_default_width + 25, -score_multi * 2, -score_multi * 2, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 20, Shopkeeper.game_default_width + 35, Shopkeeper.game_default_width + 35, -score_multi * 2, -score_multi * 2, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 30, Shopkeeper.game_default_width + 45, Shopkeeper.game_default_width + 45, -score_multi * 2, -score_multi * 3, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 40, Shopkeeper.game_default_width + 55, Shopkeeper.game_default_width + 55, -score_multi * 2, -score_multi * 3, 0, field_upper_end, field_lower_end, 1));
                } else {
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width, -15, -15, -score_multi * 2, 0, +score_multi, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 10, -25, -25, -score_multi * 2, 0, +score_multi * 2, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 20, -35, -35, -score_multi * 2, 0, +score_multi * 2, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 30, -45, -45, -score_multi * 2, 0, +score_multi * 3, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 40, -55, -55, -score_multi * 2, 0, +score_multi * 3, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_width + 15, -score_multi * 2, 0, -score_multi, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 10, Shopkeeper.game_default_width + 25, Shopkeeper.game_default_width + 25, -score_multi * 2, 0, -score_multi * 2, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 20, Shopkeeper.game_default_width + 35, Shopkeeper.game_default_width + 35, -score_multi * 2, 0, -score_multi * 2, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 30, Shopkeeper.game_default_width + 45, Shopkeeper.game_default_width + 45, -score_multi * 2, 0, -score_multi * 3, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("ship", "ring", 2, Shopkeeper.game_default_width + 40, Shopkeeper.game_default_width + 55, Shopkeeper.game_default_width + 55, -score_multi * 2, 0, -score_multi * 3, field_upper_end, field_lower_end, 1));
                }

                timer_ship_ring_last = (int)time;
            }
            if(time > timer_ship_wide_last + timer_ship_wide / score_multi + (random.Next(200) - score_multi)) {
                int temp = random.Next(4);
                int tempY = field_upper_end + random.Next(field_lower_end - field_upper_end);
                int tempZ = field_upper_end + random.Next(field_lower_end - field_upper_end);
                if(!P_Change) {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, tempZ, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, tempZ, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, tempZ, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, tempZ, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, tempZ, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 1) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 2) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 3) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    }
                } else {
                    if(temp == 0) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, tempY, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 1) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 2) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    } else if(temp == 3) {
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 1 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 2 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 3 / 6, Shopkeeper.game_default_height * 3 / 6, -score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 2 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 4 / 6, Shopkeeper.game_default_height * 4 / 6, -score_multi + 1, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 1 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                        shipyard.Add(new Entity("ship", "wide", 2, Shopkeeper.game_default_width + 15, Shopkeeper.game_default_height * 5 / 6, Shopkeeper.game_default_height * 5 / 6, -score_multi + 2, 0, 0, field_upper_end, field_lower_end, 1));
                    }
                }
                timer_ship_wide_last = (int)time;
            }
        }

        public void Spawn_Meteor(double time) {
            if(time > timer_meteor_last + timer_meteor / score_multi + random.Next(1000) / score_multi) {
                shipyard.Add(new Entity("meteor", "meteor", 2, Shopkeeper.game_default_width + 15, field_upper_end + random.Next(field_lower_end - field_upper_end), field_upper_end + random.Next(field_lower_end - field_upper_end), -score_multi * 2, 0, 0, field_upper_end, field_lower_end, 5));
                timer_meteor_last = (int)time;
            }
        }

        public void Spawn_Ring(double time) {
            if(time > timer_ring_last + timer_ring / score_multi - score_multi * 5) {
                int y = 20 + random.Next(score_multi) + score_multi;
                int z = 20 + random.Next(score_multi) + score_multi;
                if(0 == random.Next(2)) y = y * -1;
                if(0 == random.Next(2)) z = z * -1;
                y = y + (int)ring_lastPosition.Y;
                z = z + (int)ring_lastPosition.Z;
                if(y < field_upper_end) y = field_upper_end;
                if(z < field_upper_end) z = field_upper_end;
                if(y + 32 > field_lower_end) y = field_lower_end - 48;
                if(z + 32 > field_lower_end) z = field_lower_end - 48;
                shipyard.Add(new Entity("ring", "ring", 0, Shopkeeper.game_default_width + 15, y, z, -2 * score_multi, 0, 0, field_upper_end, field_lower_end, 1));
                ring_lastPosition = new Vector3(0, y, z);
                timer_ring_last = (int)time;
            }
        }

        public void Spawn_Mino(double time) {
            if(time > timer_mino_last + timer_mino - 700 * score_multi) {
                mino_movement--;
                foreach(Entity x in shipyard) {
                    if(x.Get_ID() == "mino") {
                        x.Set_Pos_X(x.Get_Pos_X() - 1);
                    }
                }
                timer_mino_last = time;
            }
            if(mino_movement == 0) {
                shipyard.Add(new Entity("mino", "blank", 1, Shopkeeper.game_default_width + 240, 360, field_upper_end, 0, 0, 0, field_upper_end, field_lower_end, 1));
                shipyard.Add(new Entity("mino", "blank", 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * 9, 0, 0, 0, field_upper_end, field_lower_end, 1));
                if(0 == random.Next(3)) {
                    Create_Tetromino();
                }
                mino_movement = 64;
            }
        }

        private void Create_Tetromino() {
            int color = random.Next(10);
            int type  = random.Next(7);
            int position = random.Next(4)+3;
            int rotation = random.Next(4);
            if(type == 0) { // O
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 1) { // T
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 2) { // Z
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 3) { // S
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 4) { // I
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 5) { // J
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
            if(type == 6) { // L
                if(rotation == 0) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 1) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position + 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 2) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 - 128, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
                if(rotation == 3) {
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240 + 64, 360, field_upper_end + 64 * position, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 64, 0, 0, 0, field_upper_end, field_lower_end, 1));
                    shipyard.Add(new Entity("mino", Mino_Name(color), 1, Shopkeeper.game_default_width + 240, 360, field_upper_end + 64 * position - 128, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
        }

        private void Spawn_Mino_Start() {
            int x = Shopkeeper.game_default_width - 64;
            int z = field_upper_end;
            for(int i = 0; i < 3; i++) {
                int temp = random.Next(10);
                for(int j = 0; j < 10; j++) {
                    shipyard.Add(new Entity("mino", Mino_Name(temp), 1, x + 64 * i, 360, z + 64 * j, 0, 0, 0, field_upper_end, field_lower_end, 1));
                }
            }
        }

        private string Mino_Name(int i) {
            if(i == 0) return "fire";
            if(i == 1) return "air";
            if(i == 2) return "thunder";
            if(i == 3) return "water";
            if(i == 4) return "ice";
            if(i == 5) return "earth";
            if(i == 6) return "metal";
            if(i == 7) return "nature";
            if(i == 8) return "light";
            if(i == 9) return "dark";
            return "blank";
        }

        private int Get_Object_Sprite_ID(string s) {
            if(s == "ring" && P_Change) return 0;
            if(s == "ring" && !P_Change) return 1;
            if(s == "normal" && P_Change) return 2;
            if(s == "normal" && !P_Change) return 3;
            if(s == "double" && P_Change) return 4;
            if(s == "double" && !P_Change) return 5;
            if(s == "wide" && P_Change) return 6;
            if(s == "wide" && !P_Change) return 7;
            if(s == "tri" && P_Change) return 8;
            if(s == "tri" && !P_Change) return 9;
            if(s == "player" && P_Change) return 0;
            if(s == "player" && !P_Change) return 1;
            return 1;
        }

        private int Get_Shot_Sprite_ID(string s) {
            if(s == "normal") return 0;
            if(s == "double") return 1;
            if(s == "tri_up") return 2;
            if(s == "tri_straight") return 3;
            if(s == "tri_down") return 4;
            if(s == "wide") return 5;
            if(s == "ring") return 6;
            return 1;
        }

        private int Get_PowerUp_Sprite_ID(string s) {
            if(s == "normal") return 0;
            if(s == "double") return 1;
            if(s == "tri") return 2;
            if(s == "wide") return 3;
            if(s == "ring") return 4;
            if(s == "heal") return 5;
            return 1;
        }

        private Texture2D Get_Mino_Sprite(string s) {
            if(s == "blank") return mino_blank;
            if(s == "fire") return mino_fire;
            if(s == "air") return mino_air;
            if(s == "thunder") return mino_thunder;
            if(s == "water") return mino_water;
            if(s == "ice") return mino_ice;
            if(s == "earth") return mino_earth;
            if(s == "metal") return mino_metal;
            if(s == "nature") return mino_nature;
            if(s == "light") return mino_light;
            if(s == "dark") return mino_dark;
            if(s == "gold") return mino_gold;
            return mino_blank;
        }

        private bool CollisionCourseBasic(Entity e1, Entity e2) { // e1 - Enemy, PowerUp, Meteor  |  e2 - Shield, Mino

            if(e1.Get_Distance(P_Change) != e2.Get_Distance(P_Change)) {
                return false;
            }

            int k1; if(e1.Get_ID() == "shot") { k1 = 1; } else { k1 = 2; }
            int k2; if(e2.Get_ID() == "shot") { k2 = 1; } else { k2 = 2; }
            int x1 = (int)e1.Get_Pos_X();
            int x2 = (int)e2.Get_Pos_X();
            int y1; if(!P_Change) { y1 = (int)e1.Get_Pos_Y(); } else { y1 = (int)e1.Get_Pos_Z(); }
            int y2; if(!P_Change) { y2 = (int)e2.Get_Pos_Y(); } else { y2 = (int)e2.Get_Pos_Z(); }
            Rectangle r1 = new Rectangle(x1, y1, 32*k1, 32*k1);
            Rectangle r2 = new Rectangle(x2, y2, 32*k2, 32*k2);
            Rectangle r0 = new Rectangle();
            r0 = Rectangle.Intersect(r1, r2);
            if(!r0.IsEmpty) {
                int v1 = 0 - 4*k1*e1.Get_Distance(P_Change);
                int v2 = 0 - 4*k2*e2.Get_Distance(P_Change);
                int w1 = e1.Get_Distance(P_Change);
                int w2 = e2.Get_Distance(P_Change);
                Rectangle r1_1 = new Rectangle(0,0,0,0);
                Rectangle r1_2 = new Rectangle(0,0,0,0);
                Rectangle r2_1 = new Rectangle(0,0,0,0);
                Rectangle r2_2 = new Rectangle(0,0,0,0);
                Rectangle r2_3 = new Rectangle(0,0,0,0);
                Rectangle r2_4 = new Rectangle(0,0,0,0);
                if(e1.Get_ID() == "ship") {
                    if(P_Change) {
                        r1_1 = new Rectangle(x1 + box_enemy_up_body.X + v1, y1 + box_enemy_up_body.Y + v1, box_enemy_up_body.Width * w1, box_enemy_up_body.Height * w1);
                        r1_2 = new Rectangle(x1 + box_enemy_up_wing.X + v1, y1 + box_enemy_up_wing.Y + v1, box_enemy_up_wing.Width * w1, box_enemy_up_wing.Height * w1);
                    } else {
                        r1_1 = new Rectangle(x1 + box_enemy_side_body.X + v1, y1 + box_enemy_side_body.Y + v1, box_enemy_side_body.Width * w1, box_enemy_side_body.Height * w1);
                        r1_2 = new Rectangle(x1 + box_enemy_side_wing.X + v1, y1 + box_enemy_side_wing.Y + v1, box_enemy_side_wing.Width * w1, box_enemy_side_wing.Height * w1);
                    }
                }
                if(e1.Get_ID() == "powerup") {
                    r1_1 = new Rectangle(x1 + box_Powerup_body.X + v1, y1 + box_Powerup_body.Y + v1, box_Powerup_body.Width * w1, box_Powerup_body.Height * w1);
                }
                if(e1.Get_ID() == "meteor") {
                    r1_1 = new Rectangle(x1 + box_meteor_up.X + v1, y1 + box_meteor_up.Y + v1, box_meteor_up.Width * w1, box_meteor_up.Height * w1);
                    r1_2 = new Rectangle(x1 + box_meteor_side.X + v1, y1 + box_meteor_side.Y + v1, box_meteor_side.Width * w1, box_meteor_side.Height * w1);
                }
                if(e2.Get_ID() == "player") {
                    if(P_Change) {
                        r2_1 = new Rectangle(x2 + box_player_up_body.X + v2, y2 + box_player_up_body.Y + v2, box_player_up_body.Width * w2, box_player_up_body.Height * w2);
                        r2_2 = new Rectangle(x2 + box_player_up_engine.X + v2, y2 + box_player_up_engine.Y + v2, box_player_up_engine.Width * w2, box_player_up_engine.Height * w2);
                    } else {
                        r2_1 = new Rectangle(x2 + box_player_side_body.X + v2, y2 + box_player_side_body.Y + v2, box_player_side_body.Width * w2, box_player_side_body.Height * w2);
                        r2_2 = new Rectangle(x2 + box_player_side_down.X + v2, y2 + box_player_side_down.Y + v2, box_player_side_down.Width * w2, box_player_side_down.Height * w2);
                        r2_3 = new Rectangle(x2 + box_player_side_front.X + v2, y2 + box_player_side_front.Y + v2, box_player_side_front.Width * w2, box_player_side_front.Height * w2);
                        r2_4 = new Rectangle(x2 + box_player_side_tail.X + v2, y2 + box_player_side_tail.Y + v2, box_player_side_tail.Width * w2, box_player_side_tail.Height * w2);
                    }
                }
                if(e2.Get_ID() == "shot") {
                    if(e2.Get_ID_Sub() == "normal") { r2_1 = new Rectangle(x2 + box_shot_normal.X + v2, y2 + box_shot_normal.Y + v2, box_shot_normal.Width * w2, box_shot_normal.Height * w2); }
                    if(e2.Get_ID_Sub() == "double") { r2_1 = new Rectangle(x2 + box_shot_double.X + v2, y2 + box_shot_double.Y + v2, box_shot_double.Width * w2, box_shot_double.Height * w2); }
                    if(e2.Get_ID_Sub() == "tri_straight") { r2_1 = new Rectangle(x2 + box_shot_tri_straight.X + v2, y2 + box_shot_tri_straight.Y + v2, box_shot_tri_straight.Width * w2, box_shot_tri_straight.Height * w2); }
                    if(e2.Get_ID_Sub() == "tri_up") { r2_1 = new Rectangle(x2 + box_shot_tri_up.X + v2, y2 + box_shot_tri_up.Y + v2, box_shot_tri_up.Width * w2, box_shot_tri_up.Height * w2); }
                    if(e2.Get_ID_Sub() == "tri_down") { r2_1 = new Rectangle(x2 + box_shot_tri_down.X + v2, y2 + box_shot_tri_down.Y + v2, box_shot_tri_down.Width * w2, box_shot_tri_down.Height * w2); }
                    if(e2.Get_ID_Sub() == "wide") {
                        r2_1 = new Rectangle(x2 + box_shot_wide_body.X + v2, y2 + box_shot_wide_body.Y + v2, box_shot_wide_body.Width * w2, box_shot_wide_body.Height * w2);
                        r2_2 = new Rectangle(x2 + box_shot_wide_upper.X + v2, y2 + box_shot_wide_upper.Y + v2, box_shot_wide_upper.Width * w2, box_shot_wide_upper.Height * w2);
                        r2_3 = new Rectangle(x2 + box_shot_wide_lower.X + v2, y2 + box_shot_wide_lower.Y + v2, box_shot_wide_lower.Width * w2, box_shot_wide_lower.Height * w2);
                    }
                    if(e2.Get_ID_Sub() == "ring") { r2_1 = new Rectangle(x2 + box_shot_wide_ring.X + v2, y2 + box_shot_wide_ring.Y + v2, box_shot_wide_ring.Width * w2, box_shot_wide_ring.Height * w2); }
                }

                r0 = Rectangle.Intersect(r1_1, r2_1);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_1, r2_2);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_1, r2_3);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_1, r2_4);
                if(!r0.IsEmpty) return true;

                r0 = Rectangle.Intersect(r1_2, r2_1);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_2, r2_2);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_2, r2_3);
                if(!r0.IsEmpty) return true;
                r0 = Rectangle.Intersect(r1_2, r2_4);
                if(!r0.IsEmpty) return true;
            }

            return false;
        }

        private int CollisionCourseMino(Entity e1, Entity e2) { // e1 - Ball, Ship  |  e2 - Shield, Mino

            if(e1.Get_Distance(P_Change) != e2.Get_Distance(P_Change)) {
                return 99;
            }

            int k1 = 2;
            int k2 = 2;
            int x1 = (int)e1.Get_Pos_X();
            int x2 = (int)e2.Get_Pos_X();
            int y1; if(!P_Change) { y1 = (int)e1.Get_Pos_Y(); } else { y1 = (int)e1.Get_Pos_Z(); }
            int y2; if(!P_Change) { y2 = (int)e2.Get_Pos_Y(); } else { y2 = (int)e2.Get_Pos_Z(); }
            Rectangle r1 = new Rectangle(x1, y1, 32*k1, 32*k1);
            Rectangle r2 = new Rectangle(x2, y2, 32*k2, 32*k2);
            Rectangle r0 = new Rectangle();
            r0 = Rectangle.Intersect(r1, r2);
            if(!r0.IsEmpty) {
                int v1 = 0 - 4*k1*e1.Get_Distance(P_Change);
                int v2 = 0 - 4*k2*e2.Get_Distance(P_Change);
                int w1 = e1.Get_Distance(P_Change);
                int w2 = e2.Get_Distance(P_Change);
                Rectangle r1_1 = new Rectangle(0,0,0,0);
                Rectangle r1_2 = new Rectangle(0,0,0,0);
                Rectangle r1_3 = new Rectangle(0,0,0,0);
                Rectangle r1_4 = new Rectangle(0,0,0,0);
                Rectangle r1_5 = new Rectangle(0,0,0,0);
                Rectangle r2_1 = new Rectangle(0,0,0,0);
                Rectangle r2_2 = new Rectangle(0,0,0,0);
                Rectangle r2_3 = new Rectangle(0,0,0,0);
                Rectangle r2_4 = new Rectangle(0,0,0,0);
                Rectangle r2_5 = new Rectangle(0,0,0,0);
                if(e1.Get_ID() == "ball") {
                    r1_1 = new Rectangle(x1 + box_ball_up.X + v1, y1 + box_ball_up.Y + v1, box_ball_up.Width * w1, box_ball_up.Height * w1);
                    r1_2 = new Rectangle(x1 + box_ball_side.X + v1, y1 + box_ball_side.Y + v1, box_ball_side.Width * w1, box_ball_side.Height * w1);
                }
                if(e1.Get_ID_Sub() == "player") {
                    r1_1 = new Rectangle(x1 + box_player_up_body.X + v1, y1 + box_player_up_body.Y + v1, box_player_up_body.Width * w1, box_player_up_body.Height * w1);
                    r1_2 = new Rectangle(x1 + box_player_up_engine.X + v1, y1 + box_player_up_engine.Y + v1, box_player_up_engine.Width * w1, box_player_up_engine.Height * w1);
                }
                if(e2.Get_ID_Sub() == "player") {
                    r2_1 = new Rectangle(x2 + box_shield_player_upper2.X + v2, y2 + box_shield_player_upper2.Y + v2, box_shield_player_upper2.Width * w2, box_shield_player_upper2.Height * w2);
                    r2_2 = new Rectangle(x2 + box_shield_player_upper1.X + v2, y2 + box_shield_player_upper1.Y + v2, box_shield_player_upper1.Width * w2, box_shield_player_upper1.Height * w2);
                    r2_3 = new Rectangle(x2 + box_shield_player_middle.X + v2, y2 + box_shield_player_middle.Y + v2, box_shield_player_middle.Width * w2, box_shield_player_middle.Height * w2);
                    r2_4 = new Rectangle(x2 + box_shield_player_lower1.X + v2, y2 + box_shield_player_lower1.Y + v2, box_shield_player_lower1.Width * w2, box_shield_player_lower1.Height * w2);
                    r2_5 = new Rectangle(x2 + box_shield_player_lower2.X + v2, y2 + box_shield_player_lower2.Y + v2, box_shield_player_lower2.Width * w2, box_shield_player_lower2.Height * w2);
                }
                if(e2.Get_ID_Sub() == "nemesis") {
                    r2_1 = new Rectangle(x2 + box_shield_nemesis_upper2.X + v2, y2 + box_shield_nemesis_upper2.Y + v2, box_shield_nemesis_upper2.Width * w2, box_shield_nemesis_upper2.Height * w2);
                    r2_2 = new Rectangle(x2 + box_shield_nemesis_upper1.X + v2, y2 + box_shield_nemesis_upper1.Y + v2, box_shield_nemesis_upper1.Width * w2, box_shield_nemesis_upper1.Height * w2);
                    r2_3 = new Rectangle(x2 + box_shield_nemesis_middle.X + v2, y2 + box_shield_nemesis_middle.Y + v2, box_shield_nemesis_middle.Width * w2, box_shield_nemesis_middle.Height * w2);
                    r2_4 = new Rectangle(x2 + box_shield_nemesis_lower1.X + v2, y2 + box_shield_nemesis_lower1.Y + v2, box_shield_nemesis_lower1.Width * w2, box_shield_nemesis_lower1.Height * w2);
                    r2_5 = new Rectangle(x2 + box_shield_nemesis_lower2.X + v2, y2 + box_shield_nemesis_lower2.Y + v2, box_shield_nemesis_lower2.Width * w2, box_shield_nemesis_lower2.Height * w2);
                }
                if(e2.Get_ID() == "mino") {
                    r2_1 = new Rectangle(x2 + box_mino.X + v2, y2 + box_mino.Y + v2, box_mino.Width * w2, box_mino.Height * w2);
                }
                if(e2.Get_ID() == "player" || e2.Get_ID() == "nemesis") {
                    r0 = Rectangle.Intersect(r1_1, r2_1);
                    if(!r0.IsEmpty) return -2;
                    r0 = Rectangle.Intersect(r1_1, r2_2);
                    if(!r0.IsEmpty) return -1;
                    r0 = Rectangle.Intersect(r1_1, r2_3);
                    if(!r0.IsEmpty) return 0;
                    r0 = Rectangle.Intersect(r1_1, r2_4);
                    if(!r0.IsEmpty) return +1;
                    r0 = Rectangle.Intersect(r1_1, r2_5);
                    if(!r0.IsEmpty) return +2;

                    r0 = Rectangle.Intersect(r1_2, r2_1);
                    if(!r0.IsEmpty) return -2;
                    r0 = Rectangle.Intersect(r1_2, r2_2);
                    if(!r0.IsEmpty) return -1;
                    r0 = Rectangle.Intersect(r1_2, r2_3);
                    if(!r0.IsEmpty) return 0;
                    r0 = Rectangle.Intersect(r1_2, r2_4);
                    if(!r0.IsEmpty) return +1;
                    r0 = Rectangle.Intersect(r1_2, r2_5);
                    if(!r0.IsEmpty) return +2;
                }
                if(e2.Get_ID() == "mino")
                    r0 = Rectangle.Intersect(r1_1, r2_1);
                if(!r0.IsEmpty) return 11; // up
                r0 = Rectangle.Intersect(r1_2, r2_1);
                if(!r0.IsEmpty) return 22; // side
            }

            return 99;
        }

        private int RingCollision(Entity e) {

            if(e.Get_HP() != 0) {
                return 0;
            }

            if(player.Get_Pos_X() + 5 > e.Get_Pos_X()) {
                if(!P_Change) {
                    if(e.Get_Pos_Y() + 5 < player.Get_Pos_Y() + 32 && player.Get_Pos_Y() + 32 < e.Get_Pos_Y() + 64 - 5 && player.Get_Distance(P_Change) == e.Get_Distance(P_Change)) {
                        return 2;
                    } else {
                        return 1;
                    }
                } else {
                    if(e.Get_Pos_Z() + 5 < player.Get_Pos_Z() + 32 && player.Get_Pos_Z() + 32 < e.Get_Pos_Z() + 64 - 5 && player.Get_Distance(P_Change) == e.Get_Distance(P_Change)) {
                        return 2;
                    } else {
                        return 1;
                    }
                }
            }

            return 0;
        }

        private void EquipPowerUp(string s) {
            if(s == "heal") {
                if(player.Get_HP() < 4)
                    player.Set_HP(player.Get_HP() + 1);
            } else {
                active_power_normal = false;
                active_power_double = false;
                active_power_tri = false;
                active_power_ring = false;
                active_power_wide = false;
                if(s == "normal") active_power_normal = true;
                if(s == "double") active_power_double = true;
                if(s == "tri") active_power_tri = true;
                if(s == "ring") active_power_ring = true;
                if(s == "wide") active_power_wide = true;
            }

        }

        private void Reset_Ball() {
            ball.Set_Pos_X(Shopkeeper.game_default_width / 2);
            ball.Set_Pos_Y(Shopkeeper.game_default_height / 2);
            ball.Set_Pos_Z(Shopkeeper.game_default_height / 2);
            ball.Set_Vel_X(-3);
            ball.Set_Vel_Y(0);
            ball.Set_Vel_Z(0);
        }
    }
}
