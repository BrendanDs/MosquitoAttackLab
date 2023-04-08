using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Enemy : GameObject
{
    public Enemy(Sprite sprite, Transform tranform) : base(sprite, tranform)
    {
        this.sprite = sprite;
        this.transform = tranform;
    }
    /*public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(sprite.SpriteSheet, new Rectangle(transform.Position.ToPoint(), sprite.Bounds.Size), null, Color.White, 0,
			Vector2.Zero, SpriteEffects.FlipVertically, 0);
    }*/
}
