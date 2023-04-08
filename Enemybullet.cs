using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class EnemyBullet : GameObject
{
    public float speed;
    public ProjectileState currentProjectileState = ProjectileState.NotFlying;

    public EnemyBullet(Sprite sprite, Transform transform) : base(sprite, transform)
    {
        this.sprite = sprite;
        this.transform = transform;
        this.speed = 1f;

    }
    public EnemyBullet(Sprite sprite, Transform transform, float speed) : base(sprite, transform)
    {
        this.sprite = sprite;
        this.transform = transform;
        this.speed = speed;

    }
    public new void Update(GameTime gameTime)
    {
        Move(new(0, speed));
        Deactivate();
    }
    public void Deactivate()
    {
        if (currentProjectileState == ProjectileState.Flying && sprite.Bounds.Top > 720)
        {
            currentProjectileState = ProjectileState.NotFlying;
        }
    }


}

