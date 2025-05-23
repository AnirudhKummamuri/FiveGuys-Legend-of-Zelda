﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using FiveGuysFixed.Animation;

namespace FiveGuysFixed.Enemies
{
    public class Tektike : Enemy
    {
        private int currentTime;
        private const int flightTime = 15, stillTime = 30;
        private Vector2 velocity;
        private Random rnd;

        public Tektike(Vector2 position, Texture2D enemyTexture)
            : base(position, new EnemySprite(enemyTexture, 16, 80, 16, 16, 2))
        {
            currentTime = 0;
            rnd = new Random();
            SetAI();
        }

        public override void Update(GameTime gameTime)
        {
            if (currentTime < flightTime)
            {
                Position += velocity;
            }
            else if (currentTime > flightTime + stillTime)
            {
                currentTime = -1;
                SetAI();
            }
            currentTime++;
            x = (int)Position.X;
            y = (int)Position.Y;

            // This is important for animation
            sprite.Update(gameTime);
        }

        private void SetAI()
        {
            int decide = rnd.Next(1, 5);
            switch (decide)
            {
                case 1:
                    velocity = new Vector2(0, 1);
                    break;
                case 2:
                    velocity = new Vector2(0, -1);
                    break;
                case 3:
                    velocity = new Vector2(1, 0);
                    break;
                case 4:
                    velocity = new Vector2(-1, 0);
                    break;
            }
        }
    }
}