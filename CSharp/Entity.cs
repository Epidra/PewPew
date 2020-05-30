using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PewPew {
    class Entity {
        float posX = 0.00F;
        float posY = 0.00F;
        float posZ = 0.00F;
        float velX = 0.00F;
        float velY = 0.00F;
        float velZ = 0.00F;
        int value = 0;
        int hp = 0;
        string id     = "null";
        string id_sub = "null";
        int border_upper;
        int border_lower;
        int border_near;
        int border_far;
        bool is_hit;
        int viewY;
        int viewZ;

        public Entity(string _id, string _idsub, int _hp, float _pX, float _pY, float _pZ, float _vX, float _vY, float _vZ, int _bup, int _bdown, int _value) {
            id = _id;
            id_sub = _idsub;
            hp = _hp;
            posX = _pX;
            posY = _pY;
            posZ = _pZ;
            velX = _vX;
            velY = _vY;
            velZ = _vZ;
            value = _value;
            border_upper = _bup;
            border_lower = _bdown;
            int temp = (border_lower - border_upper) / 3;
            border_near = temp + border_upper;
            border_far = temp + temp + border_upper;
            is_hit = false;
            viewY = 2;
            viewZ = 2;

        }

        public void Update(float scaleX, float scaleY) {
            posX += velX;
            posY += velY;
            posZ += velZ;
            if(id_sub != "ring" && id_sub != "explosion" && id_sub != "tri_up" && id_sub != "tri_down") {
                if(posY < border_upper && velY < 0)
                    velY = velY * -1;
                if(posY > border_lower && velY > 0)
                    velY = velY * -1;
                if(posZ < border_upper && velZ < 0)
                    velZ = velZ * -1;
                if(posZ > border_lower && velZ > 0)
                    velZ = velZ * -1;
            }
            if(posY < border_near) {
                viewY = 4;
            } else if(posY > border_far) {
                viewY = 1;
            } else {
                viewY = 2;
            }
            if(posZ < border_near) {
                viewZ = 1;
            } else if(posZ > border_far) {
                viewZ = 4;
            } else {
                viewZ = 2;
            }
        }

        public string Get_ID() { return id; }
        public string Get_ID_Sub() { return id_sub; }
        public float Get_Pos_X() { return posX; }
        public float Get_Pos_Y() { return posY; }
        public float Get_Pos_Z() { return posZ; }
        public float Get_Vel_X() { return velX; }
        public float Get_Vel_Y() { return velY; }
        public float Get_Vel_Z() { return velZ; }
        public int Get_HP() { return hp; }
        public int Get_Value() { return value; }
        public void Set_Pos_X(float i) { posX = i; }
        public void Set_Pos_Y(float i) { posY = i; }
        public void Set_Pos_Z(float i) { posZ = i; }
        public void Set_Vel_X(float i) { velX = i; }
        public void Set_Vel_Y(float i) { velY = i; }
        public void Set_Vel_Z(float i) { velZ = i; }
        public void Set_HP(int i) { hp = i; }
        public void Change_HP(int i) { hp = hp + i; }
        public bool Get_IsHit() { return is_hit; }
        public void Set_IsHit(bool b) { is_hit = b; }

        public int Get_Distance(bool p) {
            if(p) {
                return viewY;
            } else {
                return viewZ;
            }
        }
    }
}
