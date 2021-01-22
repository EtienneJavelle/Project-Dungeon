using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Player : Character
    {
        public Vector2Int Position;
        public Vector2Int LastPosition;
        public int maxHP;
        public List<Item> Inventory { get; private set; }
        int _selectedItem = 0; 
        public int TotalGold { get; set; }// a destroy


        public Player(int HealthPoint, int Strength) : base(HealthPoint, Strength)
        {
            this.maxHP = HealthPoint;
            this.Inventory = new List<Item>();
        }

        public bool Move(Vector2Int direction, Dungeon dungeon)
        {
            Vector2Int tmp = this.Position + direction;
            if (tmp.x >= 0 && tmp.y >= 0)
            {
                if (tmp.x <= dungeon.MaxFloorSize.x && tmp.y <= dungeon.MaxFloorSize.y)
                {
                    if (dungeon.DungeonMaps[dungeon.Floor].ResetMap[tmp.x, tmp.y] != 'O')
                    {
                        this.LastPosition = this.Position;
                        this.Position += direction;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Run()
        {
            Console.WriteLine("Fuit !");
            this.TotalGold = TotalGold / 2;// destroy 
            this.Position = this.LastPosition;
        }

        public override string ToString()
        {
            return "Vous avez " + this.HealthPoint + " points de vie.\r\nForce " + this.Strength + ".\r\nArmure " + this.Armor  +".\r\nOr : " + this.TotalGold + ".";
        }

        public void Sleep()
        {
            Console.WriteLine("DODO");
            this.HealthPoint = maxHP;
        }

        public void AddItem(Item item)
        {
            this.Inventory.Add(item);
        }

        internal void ShowInventory()
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Console.WriteLine("Votre Inventaire :");
                if (this.Inventory.Count == 0)
                {
                    Console.WriteLine("Inventaire vide");
                    input = Console.ReadKey().Key;
                }
                else
                {
                    for (int i = 0; i < this.Inventory.Count; i++)
                    {
                        if (i == this._selectedItem) Console.Write("=>");
                        else Console.Write("  ");
                        Console.WriteLine(Inventory[i].Name + " " + Inventory[i].Amount);
                    }
                    input = Console.ReadKey().Key;

                    switch (input)
                    {
                        case ConsoleKey.DownArrow:
                            this._selectedItem = Math.Clamp(++this._selectedItem, 0, this.Inventory.Count - 1);
                            break;
                        case ConsoleKey.UpArrow:
                            this._selectedItem = Math.Clamp(--this._selectedItem, 0, this.Inventory.Count - 1);
                            break;
                        case ConsoleKey.Enter:
                            this.Inventory[this._selectedItem].effet(this);
                            if (this.Inventory[this._selectedItem].isEquipment == false) //destroy 
                            this.Inventory.RemoveAt(this._selectedItem);
                            break;
                        default:
                            break;
                    }
                }
            } while (input!=ConsoleKey.Enter&&input!=ConsoleKey.Escape);
        }
    }
}
