using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;



namespace MosquitoAttackLab
{
    public class Game1 : Game
    {
        new Rectangle rectangle;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D playerCannon;

        Player playerOne;
        List<Player> playerList = new List<Player>();
        List<Controls> playerControlList = new List<Controls>();
        Controls playerControls;

        //GameObject testObject;
        Sprite playerSprite;
        Sprite enemySprite;
        Transform enemyTransform;
        Transform playerTransform;


        List<Enemy> enemyList = new List<Enemy>();
        Texture2D enemyTexture;
        int EnemyCount = 5;

        List<PlayerBullet> playerBulletList = new List<PlayerBullet>();
        Texture2D playerBulletTexture;
        Sprite playerBulletSprite;
        Transform playerBulletTransform;
        int playerBulletPoolSize = 10;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;

        }

        protected override void Initialize()
        {
            playerControlList.Add(new Controls(Keys.D, Keys.A, Keys.W));
            playerControlList.Add(new Controls(Keys.Right, Keys.Left, Keys.Up));
            playerControlList.Add(new Controls(Keys.NumPad6, Keys.NumPad4, Keys.NumPad8));

            base.Initialize();

            playerTransform = new Transform();
            playerSprite = new Sprite(playerCannon, playerCannon.Bounds, 1);
            for (int i = 0; i < 3; i++)
            {
                Player newPlayer = new Player(playerSprite, playerTransform, playerControlList[i]);
                newPlayer.Move(new Vector2(0, i * 32));

                playerList.Add(newPlayer);
            }

            enemySprite = new Sprite(enemyTexture, enemyTexture.Bounds, 1);
            enemyTransform = new Transform();
            for (int enemyIndex = 0; enemyIndex < enemyList.Count; enemyIndex++)
            {
                Enemy newEnemy = new Enemy(enemySprite, enemyTransform);
                newEnemy.Move(new Vector2(enemyIndex * 42, 10));

                enemyList.Add(newEnemy);
            }
            playerBulletSprite = new Sprite(enemyTexture, enemyTexture.Bounds, 0.4f);
            playerBulletTransform = new Transform();
            for (int bulletIndex = 0; bulletIndex < enemyList.Count; bulletIndex++)
            {
                PlayerBullet newPlayerBullet = new PlayerBullet(playerBulletSprite, playerBulletTransform);
                playerBulletList.Add(newPlayerBullet);
            }
            // TODO: Add your initialization logic here
            //playerControls = new Controls(GamePad.GetState(0).DPad.Right == ButtonState.Pressed, GamePad.GetState(0).DPad.Left == ButtonState.Pressed,
            //    GamePad.GetState(0).Buttons.A == ButtonState.Pressed);
            //base.Initialize();
            //playerOne = new Player(playerCannonTexture,Vector2.Zero,playerControls);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerCannon = Content.Load<Texture2D>("Cannon");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            enemyTexture = Content.Load<Texture2D>("Mosquito");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < playerBulletList.Count; i++)
                {
                    if (playerBulletList[i].playerBulletState == ProjectileState.NotFlying)
                    {
                        playerBulletList[i].transform.Position = Mouse.GetState().Position.ToVector2();
                        playerBulletList[i].playerBulletState = ProjectileState.Flying;
                        break;

                    }
                }
            }


            foreach (PlayerBullet bullet in playerBulletList)
            {
                if (bullet.playerBulletState == ProjectileState.Flying)
                {
                    //player.transform.TranslatePosition(new Vector2(1, 0));
                    bullet.Update(gameTime);
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (PlayerBullet bullet in playerBulletList)
            {

            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach (PlayerBullet bullet in playerBulletList)
            {
                if (bullet.playerBulletState == ProjectileState.Flying)
                {
                    bullet.Draw(_spriteBatch);
                }
            }

            foreach (Player player in playerList)
            {
                player.Draw(_spriteBatch);
            }
            foreach (Enemy enemy in enemyList)
            {

                enemy.Draw(_spriteBatch);

            }
            //_spriteBatch.Draw(playerCannonTexture, playerCannonTexture.Bounds, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}