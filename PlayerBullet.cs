using Microsoft.Xna.Framework;
using System;

public class PlayerBullet : GameObject
{
    float speed = 0;
    public ProjectileState playerBulletState = ProjectileState.NotFlying;
    public PlayerBullet(Sprite sprite, Transform transform) : base(sprite, transform)
    {
        this.sprite = sprite;
        this.transform = transform;
        speed = -1;

    }
    public PlayerBullet(Sprite sprite, Transform transform, float speed) : base(sprite, transform)
    {
        this.transform = transform;
        this.sprite = sprite;
        this.speed = speed;
    }
    public void Update(GameTime gameTime)
    {
        Move(new Vector2(0, speed));
        Deactivate();
    }
    public void Deactivate()
    {
        if (sprite.Bounds.Bottom < 0)
        {
            playerBulletState = ProjectileState.NotFlying;
        }
    }


}
public enum ProjectileState
{
    NotFlying,
    Flying
}
