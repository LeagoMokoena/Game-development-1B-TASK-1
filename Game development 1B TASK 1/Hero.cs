using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Hero : Character
    {
        public Hero(int _xPosition, int _yPosition, Tiletype type, char characterSymbol, int starthp, int Maximimuhp, int daMage) : base(_xPosition, _yPosition, type, characterSymbol, starthp, Maximimuhp, daMage)
        {
            Vision = new Tile[4];
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            bool canMove;
            canMove = checkSurroundings(move);
            switch (move)
            {
                case movement.Up:
                    if(canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Up;
                    }
                    break;
                case movement.Down:
                    if (canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Down;
                    }

                    break;
                case movement.Left:
                    if (canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Left;
                    }
                    break;
                case movement.Right:
                    if (canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Right;
                    }
                    break;
            }
            return move;
        }

        public override string ToString()
        {
            string playerInfo;
            if (equipWeapon == null)
            { 
                playerInfo = "Player Stats:\n" +
                "HP:" + HP +"/"+ MaxHp + "\n" +
                "Current Weapon: Bare Hands" + "\n" +
                "Weapon Range: 1" + "\n" +
                "Weapon Damage: 2" + "\n" +
                "[" + X + "," + Y + "]\n" +
                " Amount of gold: " + GoldPurse.Count + "\n";
            }
            else
            {
                playerInfo = "Player Stats:\n" +
                "HP:" + HP +"/"+ MaxHp + "\n" +
                "Current Weapon: " + equipWeapon.WeaponType + "\n" +
                "Weapon Range: " + equipWeapon.Range() +"\n" +
                "Weapon Damage: " + equipWeapon.Damage +"\n" +
                "[" + X + "," + Y + "]\n" +
                "Durability: " + equipWeapon.Durability +"\n" +
                " Amount of gold: " + GoldPurse.Count + "\n";
            }
            return playerInfo;
            throw new NotImplementedException();
        }

        public bool checkSurroundings(Character.movement movements)
        {
            bool playerMove;
            if (movements == Character.movement.Up)
            {
                if (Vision[0].tiletype == Tile.Tiletype.obstacle || Vision[0].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if (movements == Character.movement.Down)
            {
                if (Vision[3].tiletype == Tile.Tiletype.obstacle || Vision[3].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if (movements == Character.movement.Left)
            {
                if (Vision[1].tiletype == Tile.Tiletype.obstacle || Vision[1].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else
            {
                if (Vision[2].tiletype == Tile.Tiletype.obstacle || Vision[2].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            return playerMove;
        }
    }
}
