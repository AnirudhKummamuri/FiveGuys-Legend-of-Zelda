using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FiveGuysFixed.Blocks;
using FiveGuysFixed.Common;
using FiveGuysFixed.Enemies;
using FiveGuysFixed.GameStates;
using FiveGuysFixed.Items;
using FiveGuysFixed.Projectiles;
using FiveGuysFixed.Weapons___Items;
using Microsoft.Xna.Framework;

namespace FiveGuysFixed.RoomHandling
{
    public class RoomContents
    {
        public List<IBlock> Blocks { get; private set; }
        public List<IEnemy> Enemies { get; private set; }
        public List<IItem> Items { get; set; }
        public List<IProjectile> Projectiles { get; set; }

        public Dictionary<Dir, int> Neighbors;


        public RoomContents()
        {
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Projectiles = new List<IProjectile>();
        }

        public RoomContents(XmlNode roomNode, Dictionary<Dir, int> Neighbors)
        {
            this.Neighbors = Neighbors;
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Projectiles = new List<IProjectile>();
            XmlNodeList itemNodes = roomNode.SelectNodes("Objects/Item");
            foreach (XmlNode itemNode in itemNodes)
            {

                string type = itemNode.Attributes["type"].Value;
                int x = int.Parse(itemNode.Attributes["x"].Value);
                int y = int.Parse(itemNode.Attributes["y"].Value);

                if (type == "BluePotion")
                {
                    Items.Add(
                        new BluePotion(GameState.contentLoader.bluePotionTexture, x, y)
                    );
                }

                if (type == "Bomb")
                {
                    Items.Add(
                        new Bomb(GameState.contentLoader.bombTexture, x, y)
                    );
                }

                if (type == "Food")
                {
                    Items.Add(
                        new Food(GameState.contentLoader.foodTexture, x, y)
                    );
                }

                if (type == "GreenRupee")
                {
                    Items.Add(
                        new GreenRupee(GameState.contentLoader.rupeeTexture, x, y)
                    );
                }

                if (type == "RedPotion")
                {
                    Items.Add(
                        new RedPotion(GameState.contentLoader.redPotionTexture, x, y)
                    );
                }

                if (type == "RedRupee")
                {
                    Items.Add(
                        new RedRupee(GameState.contentLoader.rupeeTexture, x, y)
                    );
                }
            }


            // Load Blocks
            XmlNodeList blockNodes = roomNode.SelectNodes("Objects/Block");
            foreach (XmlNode blockNode in blockNodes)
            {

                string type = blockNode.Attributes["type"].Value;
                int x = int.Parse(blockNode.Attributes["x"].Value);
                int y = int.Parse(blockNode.Attributes["y"].Value);

                if (type == "Wall")
                {
                    Blocks.Add(
                        new Wall(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "Floor")
                {
                    Blocks.Add(
                        new Floor(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "TopDoorOpen")
                {
                    Blocks.Add(
                        new TopDoorOpen(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "TopDoorClose")
                {
                    Blocks.Add(
                        new TopDoorClose(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "LeftDoorOpen")
                {
                    Blocks.Add(
                        new LeftDoorOpen(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "LeftDoorClose")
                {
                    Blocks.Add(
                        new LeftDoorClose(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "RightDoorOpen")
                {
                    Blocks.Add(
                        new RightDoorOpen(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "RightDoorClose")
                {
                    Blocks.Add(
                        new RightDoorClose(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "BottomDoorOpen")
                {
                    Blocks.Add(
                        new BottomDoorOpen(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "BottomDoorClose")
                {
                    Blocks.Add(
                        new BottomDoorClose(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "ClearBlock")
                {
                    Blocks.Add(
                        new ClearBlock(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "BlueBlock")
                {
                    Blocks.Add(
                        new BlueBlock(GameState.contentLoader.blockTexture, x, y)
                    );
                }

                if (type == "GreenBlock")
                {
                    Blocks.Add(
                        new GreenBlock(GameState.contentLoader.greenBlockTexture, x, y)
                    );
                }

                if (type == "TreeBlock")
                {
                    Blocks.Add(
                        new TreeBlock(GameState.contentLoader.treeBlockTexture, x, y)
                    );
                }

                if (type == "WhiteBlock")
                {
                    Blocks.Add(
                        new WhiteBlock(GameState.contentLoader.whiteBlockTexture, x, y)
                    );
                }

                if (type == "YellowBlock")
                {
                    Blocks.Add(
                        new YellowBlock(GameState.contentLoader.yellowBlockTexture, x, y)
                    );
                }
            }

            // Load Enemies
            XmlNodeList enemyNodes = roomNode.SelectNodes("Objects/Enemy");
            foreach (XmlNode enemyNode in enemyNodes)
            {
                string type = enemyNode.Attributes["type"].Value;
                int x = int.Parse(enemyNode.Attributes["x"].Value);
                int y = int.Parse(enemyNode.Attributes["y"].Value);

                if (type == "Aquamentus")
                {
                    Enemies.Add(new Aquamentus(
                        new Vector2(x, y),
                        new EnemySprite(GameState.contentLoader.BossTexture, 0, 0, 32, 32, 2),
                        new EnemySprite(GameState.contentLoader.BossTexture, 32, 0, 32, 32, 2),
                        Projectiles  // Give access to the projectile list
                    ));
                }
                if (type == "Gel")
                {
                    Enemies.Add(
                        new Gel(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Pass texture directly
                        )
                    );
                }


                if (type == "Goriya")
                {
                    Enemies.Add(
                        new Goriya(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture,
                            GameState.contentLoader.weaponTexture, // Use the weapons texture
                            Projectiles // Share the room's projectile list
                        )
                    );
                }
                if (type == "Keese")
                {
                    Enemies.Add(
                        new Keese(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Uses the enemy sprite sheet
                        )
                    );
                }
                if (type == "Moblin")
                {
                    Enemies.Add(
                        new Moblin(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Uses the enemy sprite sheet
                        )
                    );
                }
                if (type == "Octorok")
                {
                    Enemies.Add(
                        new Octorok(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Uses the enemy sprite sheet
                        )
                    );
                }
                if (type == "Stalfos")
                {
                    Enemies.Add(
                        new Stalfos(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Uses the enemy sprite sheet
                        )
                    );
                }
                if (type == "Tektike")
                {
                    Enemies.Add(
                        new Tektike(
                            new Vector2(x, y),
                            GameState.contentLoader.enemyTexture // Uses the enemy sprite sheet
                        )
                    );
                }
            }
        }

        public void Clear()
        {
            Blocks.Clear();
            Enemies.Clear();
            Items.Clear();
            Projectiles.Clear();
        }
    }

}
