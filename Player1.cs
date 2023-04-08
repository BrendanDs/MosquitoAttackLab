using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MosqAttack;
using System;
using System.Security.AccessControl;

public class Player : GameObject
{

    Transform transform;
    Sprite spriteSheet;
    Controls playerControls;
    // Projectiles
    // References to GameObject
    Vector2 playerPosition;
    Vector2 playerDirection;

    float playerSpeed;
    int currentPlayerHealth;
    int maxPlayerHealth;

    int currentPlayerAmmo;
    int maxPlayerAmmo;
    float fireRate;

    bool leftPressed, rightPressed, firePressed;

    PlayerState currentPlayerState = PlayerState.Alive;

    public Player(Sprite sprite, Transform transform, Controls controls) : base(sprite, transform)
    {
        this.transform = transform;
        this.sprite = sprite;
        this.playerControls = controls;

        playerSpeed = 4f;
    }
    public void Update(GameTime gameTime)
    {
        switch (currentPlayerState)
        {
            case PlayerState.Alive:
                PlayerInput(playerControls);
                PlayerMove();
                PlayerFire();
                break;
            case PlayerState.Dying:
                break;
            case PlayerState.Dead:
                break;
            default:
                break;
        }

    }

    public void PlayerInput(Controls controls)
    {
        switch (controls.inputType)
        {
            case ControlType.KB:
                rightPressed = Keyboard.GetState().IsKeyDown((Keys)controls.positiveDirection);
                leftPressed = Keyboard.GetState().IsKeyDown((Keys)controls.negativeDirection);
                firePressed = Keyboard.GetState().IsKeyDown((Keys)controls.wasFirePressedThisFrame);
                break;
        }
    }
    public void PlayerMove()
    {
        if (leftPressed == rightPressed)
        {
            transform.Direction = Vector2.Zero;
        }
        else
        {
            if (rightPressed)
            {
                transform.Direction = new Vector2(1, 0);

            }
            else
            {
                transform.Direction = new Vector2(-1, 0);
            }
        }
        Move(transform.Direction * playerSpeed);
    }

    public void PlayerFire()
    {
        if (firePressed)
        {
            //fire bullets
        }
    }


}
public struct Controls
{
    public Controls(Keys posEnum, Keys negEnum, Keys fireEnum)
    {
        this.positiveDirection = (int)posEnum;
        this.negativeDirection = (int)negEnum;
        this.wasFirePressedThisFrame = (int)fireEnum;
        this.inputType = ControlType.KB;
        this.PlayerIndex = 0;
    }
    public int positiveDirection;
    public int negativeDirection;
    public int wasFirePressedThisFrame;
    public ControlType inputType;
    public int PlayerIndex;

}
public enum PlayerUpgradeState
{
    None,
}
public enum PlayerState
{
    Alive,
    Dying,
    Dead
}
public enum ControlType
{
    None = 0,
    KB = 1
}
