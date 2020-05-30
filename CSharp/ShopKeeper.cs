﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PewPew {
    public class ShopKeeper {
        public int game_default_width = 1280;
        public int game_default_height =  720;

        public string audio_music_menu { get; } = "Audio/Music/Menu";
        public string audio_music_theme1 { get; } = "Audio/Music/Theme1";
        public string audio_music_theme2 { get; } = "Audio/Music/Theme2";
        public string audio_music_theme3 { get; } = "Audio/Music/Theme3";

        public string audio_sound_damage { get; } = "Audio/Sound/Damage";
        public string audio_sound_explosion { get; } = "Audio/Sound/Explosion";
        public string audio_sound_pew { get; } = "Audio/Sound/Pew";
        public string audio_sound_pong1 { get; } = "Audio/Sound/Pong1";
        public string audio_sound_pong2 { get; } = "Audio/Sound/Pong2";

        public string graphic_background_meteorfield_up { get; } = "Graphics/Background/Meteorfield_Up";
        public string graphic_background_meteorfield_side { get; } = "Graphics/Background/Meteorfield_Side";
        public string graphic_background_planet_up { get; } = "Graphics/Background/Planet_Up";
        public string graphic_background_planet_side { get; } = "Graphics/Background/Planet_Side";
        public string graphic_background_starfield { get; } = "Graphics/Background/Starfield";
        public string graphic_background_title { get; } = "Graphics/Background/Title";
        public string graphic_hud_back { get; } = "Graphics/HUD/Back";
        public string graphic_hud_hitpoint1 { get; } = "Graphics/HUD/Hitpoint1";
        public string graphic_hud_hitpoint2 { get; } = "Graphics/HUD/Hitpoint2";
        public string graphic_hud_hitpoint3 { get; } = "Graphics/HUD/Hitpoint3";
        public string graphic_hud_hitpoint4 { get; } = "Graphics/HUD/Hitpoint4";
        public string graphic_hud_hud { get; } = "Graphics/HUD/HUD";
        public string graphic_hud_off { get; } = "Graphics/HUD/Off";
        public string graphic_hud_pause { get; } = "Graphics/HUD/Pause";
        public string graphic_hud_powerupdouble { get; } = "Graphics/HUD/PowerUpDouble";
        public string graphic_hud_powerupnormal { get; } = "Graphics/HUD/PowerUpNormal";
        public string graphic_hud_powerupring { get; } = "Graphics/HUD/PowerUpRing";
        public string graphic_hud_poweruptri { get; } = "Graphics/HUD/PowerUpTri";
        public string graphic_hud_powerupwide { get; } = "Graphics/HUD/PowerUpWide";
        public string graphic_menu_gamecardbasic { get; } = "Graphics/Menu/GameCardBasic";
        public string graphic_menu_gamecardblank { get; } = "Graphics/Menu/GameCardBlank";
        public string graphic_menu_gamecardmeteorshower { get; } = "Graphics/Menu/GameCardMeteorShower";
        public string graphic_menu_gamecardminobreaker { get; } = "Graphics/Menu/GameCardMinoBreaker";
        public string graphic_menu_gamecardoctanom { get; } = "Graphics/Menu/GameCardOctanom";
        public string graphic_menu_gamecardpong { get; } = "Graphics/Menu/GameCardPong";
        public string graphic_menu_gamecardringrace { get; } = "Graphics/Menu/GameCardRingRace";
        public string graphic_menu_iconblank { get; } = "Graphics/Menu/IconBlank";
        public string graphic_menu_iconmusicoff { get; } = "Graphics/Menu/IconMusicOff";
        public string graphic_menu_iconmusicon { get; } = "Graphics/Menu/IconMusicOn";
        public string graphic_menu_iconpchange { get; } = "Graphics/Menu/IconP-Change";
        public string graphic_menu_iconsoundoff { get; } = "Graphics/Menu/IconSoundOff";
        public string graphic_menu_iconsoundon { get; } = "Graphics/Menu/IconSoundOn";
        public string graphic_menu_iconstart { get; } = "Graphics/Menu/IconStart";
        public string graphic_menu_infocardbasic { get; } = "Graphics/Menu/InfoCardBasic";
        public string graphic_menu_infocardblank { get; } = "Graphics/Menu/InfoCardBlank";
        public string graphic_menu_infocardintroduction { get; } = "Graphics/Menu/InfoCardIntroduction";
        public string graphic_menu_infocardmeteorshower { get; } = "Graphics/Menu/InfoCardMeteorShower";
        public string graphic_menu_infocardminobreaker { get; } = "Graphics/Menu/InfoCardMinoBreaker";
        public string graphic_menu_infocardoctanom { get; } = "Graphics/Menu/InfoCardOctanom";
        public string graphic_menu_infocardpong { get; } = "Graphics/Menu/InfoCardPong";
        public string graphic_menu_infocardringrace { get; } = "Graphics/Menu/InfoCardRingRace";
        public string graphic_menu_selector { get; } = "Graphics/Menu/Selector";
        public string graphic_menu_bump { get; } = "Graphics/Menu/Bump";
        public string graphic_mino_air { get; } = "Graphics/Mino/MinoAir";
        public string graphic_mino_blank { get; } = "Graphics/Mino/MinoBlank";
        public string graphic_mino_dark { get; } = "Graphics/Mino/MinoDark";
        public string graphic_mino_earth { get; } = "Graphics/Mino/MinoEarth";
        public string graphic_mino_fire { get; } = "Graphics/Mino/MinoFire";
        public string graphic_mino_gold { get; } = "Graphics/Mino/MinoGold";
        public string graphic_mino_ice { get; } = "Graphics/Mino/MinoIce";
        public string graphic_mino_light { get; } = "Graphics/Mino/MinoLight";
        public string graphic_mino_metal { get; } = "Graphics/Mino/MinoMetal";
        public string graphic_mino_nature { get; } = "Graphics/Mino/MinoNature";
        public string graphic_mino_thunder { get; } = "Graphics/Mino/MinoThunder";
        public string graphic_mino_water { get; } = "Graphics/Mino/MinoWater";
        public string graphic_spritesheet_animationexplosion { get; } = "Graphics/Spritesheet/AnimationExplosion";
        public string graphic_spritesheet_animationshield { get; } = "Graphics/Spritesheet/AnimationShield";
        public string graphic_spritesheet_animationshot { get; } = "Graphics/Spritesheet/AnimationShot";
        public string graphic_spritesheet_objectmeteor { get; } = "Graphics/Spritesheet/ObjectMeteor";
        public string graphic_spritesheet_objectpowerup { get; } = "Graphics/Spritesheet/ObjectPowerUp";
        public string graphic_spritesheet_objectring { get; } = "Graphics/Spritesheet/ObjectRing";
        public string graphic_spritesheet_shipenemy { get; } = "Graphics/Spritesheet/ShipEnemy";
        public string graphic_spritesheet_shipoctanom { get; } = "Graphics/Spritesheet/ShipOctanom";
        public string graphic_spritesheet_shipplayer { get; } = "Graphics/Spritesheet/ShipPlayer";

        public Rectangle box_enemy_up_body { get; } = new Rectangle(12, 26, 38, 11);
        public Rectangle box_enemy_up_wing { get; } = new Rectangle(25, 20, 12, 23);
        public Rectangle box_enemy_side_body { get; } = new Rectangle(10, 25, 42, 11);
        public Rectangle box_enemy_side_wing { get; } = new Rectangle(32, 36, 11, 04);
        public Rectangle box_meteor_up { get; } = new Rectangle(25, 22, 13, 19);
        public Rectangle box_meteor_side { get; } = new Rectangle(21, 26, 21, 11);
        public Rectangle box_ball_up { get; } = new Rectangle(24, 20, 15, 23);
        public Rectangle box_ball_side { get; } = new Rectangle(20, 24, 23, 15);
        public Rectangle box_player_up_body { get; } = new Rectangle(11, 24, 44, 14);
        public Rectangle box_player_up_engine { get; } = new Rectangle(16, 18, 17, 26);
        public Rectangle box_player_side_body { get; } = new Rectangle(16, 27, 33, 10);
        public Rectangle box_player_side_down { get; } = new Rectangle(16, 33, 25, 07);
        public Rectangle box_player_side_front { get; } = new Rectangle(41, 32, 16, 05);
        public Rectangle box_player_side_tail { get; } = new Rectangle(08, 23, 14, 06);
        public Rectangle box_Powerup_body { get; } = new Rectangle(25, 25, 11, 11);
        public Rectangle box_shield_player_middle { get; } = new Rectangle(61, 23, 03, 18);
        public Rectangle box_shield_player_lower1 { get; } = new Rectangle(59, 42, 04, 10);
        public Rectangle box_shield_player_lower2 { get; } = new Rectangle(57, 51, 04, 10);
        public Rectangle box_shield_player_upper1 { get; } = new Rectangle(59, 13, 04, 10);
        public Rectangle box_shield_player_upper2 { get; } = new Rectangle(57, 03, 04, 10);
        public Rectangle box_shield_nemesis_middle { get; } = new Rectangle(00, 23, 03, 18);
        public Rectangle box_shield_nemesis_lower1 { get; } = new Rectangle(02, 42, 04, 10);
        public Rectangle box_shield_nemesis_lower2 { get; } = new Rectangle(04, 51, 04, 10);
        public Rectangle box_shield_nemesis_upper1 { get; } = new Rectangle(02, 13, 04, 10);
        public Rectangle box_shield_nemesis_upper2 { get; } = new Rectangle(04, 03, 04, 10);
        public Rectangle box_shot_normal { get; } = new Rectangle(13, 14, 05, 03);
        public Rectangle box_shot_double { get; } = new Rectangle(13, 14, 05, 03);
        public Rectangle box_shot_tri_straight { get; } = new Rectangle(13, 14, 05, 03);
        public Rectangle box_shot_tri_up { get; } = new Rectangle(14, 13, 04, 04);
        public Rectangle box_shot_tri_down { get; } = new Rectangle(14, 13, 04, 04);
        public Rectangle box_shot_wide_body { get; } = new Rectangle(17, 12, 07, 07);
        public Rectangle box_shot_wide_upper { get; } = new Rectangle(06, 08, 11, 05);
        public Rectangle box_shot_wide_lower { get; } = new Rectangle(06, 20, 11, 05);
        public Rectangle box_shot_wide_ring { get; } = new Rectangle(12, 12, 07, 07);
        public Rectangle box_mino { get; } = new Rectangle(00, 00, 64, 64);

        public Vector2 position_menu_01 { get; } = new Vector2(88, 21);
        public Vector2 position_menu_02 { get; } = new Vector2(44, 116);
        public Vector2 position_menu_03 { get; } = new Vector2(88, 210);
        public Vector2 position_menu_04 { get; } = new Vector2(44, 306);
        public Vector2 position_menu_05 { get; } = new Vector2(88, 400);
        public Vector2 position_menu_06 { get; } = new Vector2(44, 496);
        public Vector2 position_menu_card { get; } = new Vector2(860, 20);
        public Vector2 position_menu_start { get; } = new Vector2(860, 630);
        public Vector2 position_menu_option1 { get; } = new Vector2(710, 630);
        public Vector2 position_menu_option2 { get; } = new Vector2(560, 630);
        public Vector2 position_menu_option3 { get; } = new Vector2(410, 630);

        public int position_game_height_start { get; } = 80;
        public int position_game_height_end { get; } = 640;

        public Rectangle button_P_Change { get; } = new Rectangle(404, 659, 92, 46);
        public Rectangle button_pause { get; } = new Rectangle(787, 659, 92, 46);
        public Rectangle button_back { get; } = new Rectangle(36, 655, 68, 68);

        public int score_value_ship { get; } = 1;
        public int score_value_mino { get; } = 1;
        public int score_value_ring { get; } = 1;
        public int score_value_meteor { get; } = 5;
        public int score_value_player { get; } = 0;
        public int score_value_ball { get; } = 0;
        public int score_multibreak { get; } = 10;
        public int score_time { get; } = 500000;
        public int score_nomhit { get; } = 50;
        public int score_timehit { get; } = 4000;

        public double timer_ship_normal { get; } = 5000;
        public double timer_ship_double { get; } = 6000;
        public double timer_ship_tri { get; } = 7000;
        public double timer_ship_ring { get; } = 8000;
        public double timer_ship_wide { get; } = 9000;
        public double timer_meteor { get; } = 20000;
        public double timer_ring { get; } = 4000;
        public double timer_shot_normal { get; } = 280;
        public double timer_shot_double { get; } = 360;
        public double timer_shot_tri { get; } = 340;
        public double timer_shot_ring { get; } = 400;
        public double timer_shot_wide { get; } = 600;
        public double timer_mino { get; } = 750;
    }
}
