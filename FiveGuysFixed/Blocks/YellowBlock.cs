﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveGuysFixed.Animation;
using FiveGuysFixed.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FiveGuysFixed.Blocks
{
    internal class YellowBlock : Block
    {
        public YellowBlock(Texture2D texture, int x, int y) : base(texture, 354, 81, x, y)
        {
        }
    }
}