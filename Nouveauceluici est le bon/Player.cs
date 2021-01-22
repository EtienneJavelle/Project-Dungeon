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
        public int TotalGold { get; set; }




        public Player(int HealthPoint, int Strength) : base(HealthPoint, Strength)
        {
            this.maxHP = HealthPoint;
            this.Inventory = new List<Item>();
            this.Name = "Vous ";
        }

        internal void GainHealth(int amount)
        {
            this.HealthPoint = Math.Min(this.HealthPoint + amount, this.maxHP);
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
            this.TotalGold = TotalGold / 2;
            this.Position = this.LastPosition;
        }

        public override string ToString()
        {
            return "Vous avez " + this.HealthPoint + " points de vie. Force " + this.Strength + ". Armure " + this.Armor + ". Arme " + this.Weapon + ". Or " + this.TotalGold + ".";
        }

        public void Sleep()
        {
            this.HealthPoint = maxHP;
            Console.WriteLine("Vous dormez et recuperez tous vos PV");
            Console.ReadKey();
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
                            if (this.Inventory[this._selectedItem].isEquipment == false)
                                this.Inventory.RemoveAt(this._selectedItem);
                            break;
                        default:
                            break;
                    }
                }
            } while (input != ConsoleKey.Enter && input != ConsoleKey.Escape);
        }

        public void GainExp(int amount)
        {
            this.Experience += amount;
            Console.WriteLine(amount + " experience gagnée");
            Console.ReadKey();
            if (this.Experience >= this.Level * 20)
            {
                this.Experience -= this.Level * 20;
                this.LevelUp();
            }
        }

        private void LevelUp()
        {
            this.Level++;
            float rnd = new Random().Next(1, 11);

            Console.WriteLine("Level UP !");
            Console.Write("Pv Max : ");
            LevelUpStats(ref this.maxHP, rnd);
            Console.Write("Armure : ");
            LevelUpStats(ref this.Armor, rnd);
            Console.Write("Force : ");
            LevelUpStats(ref this.Strength, rnd);

            Console.ReadKey();

        }

        private void LevelUpStats(ref int value, float rnd)
        {
            Console.Write(value + " => ");
            value += (int)MathF.Ceiling(value * (rnd / 100));
            Console.WriteLine(value);
        }
    }
}
