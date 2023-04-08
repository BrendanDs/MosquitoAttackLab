using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameObject
{

    public Sprite sprite;
    public Transform transform;

    public GameObject(Sprite sprite, Transform transform)
    {
        this.sprite = sprite;
        this.transform = transform;
    }

    public bool OnCollide(Rectangle otherBounds)
    {
        return sprite.Bounds.Intersects(otherBounds);
    }
    public void Move(Vector2 offset)
    {
        transform.TranslatePosition(offset);
        sprite.UpdateBounds(transform);
    }
    public void Update(GameTime gameTime)
    {

        //transform.CheckBounds(sprite);
        //Move();
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch);
    }



}

public struct Transform
{
    public void TranslatePosition(Vector2 offsetVector)
    {
        Position += offsetVector;
    }

    public Transform(Vector2 position, Vector2 direction, float rotation)
    {
        this.Position = position;
        this.Direction = direction;
        this.Rotation = rotation;
    }

    public Vector2 Position;
    public Vector2 Direction;
    public float Rotation;
}

public struct Sprite
{
    public Texture2D SpriteSheet;
    public Rectangle Bounds;
    public float Scale;

    public Sprite(Texture2D texture, Rectangle bounds, float scale)
    {
        this.SpriteSheet = texture;
        this.Bounds = bounds;
        this.Scale = scale;
    }

    public void Draw(SpriteBatch spritebatch)
    {
        spritebatch.Draw(SpriteSheet, Bounds, Color.White);
    }

    public void UpdateBounds(Transform transform)
    {

        Bounds = new Rectangle(transform.Position.ToPoint(), Bounds.Size);
    }
}
