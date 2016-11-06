using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MazeBlazeMk3
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // STOP!!!
        // CREATE A NEW TEXT FILE TO TEST FILEREADER CLASS!

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font, menuFont, buttonFont;

        double timer, startTime;

        string difficulty;
        private const string contentFilePath = "C:/Users/user/Documents/Programming/C#/Projects/MazeBlazeMk3/LevelPack/Levels/";

        int lives, rank, coinsCollected; // coinsCollected: number of gold coins collected on third repetition of game levels

        Rectangle screenRectangle;

        Button playButton, instructionButton, loadButton, exitButton, backButton1, backButton2, resumeButton, saveButton, mainButton;
        Button easy, medium, hard, ridiculous;

        Map level11, level12, level13, level14, level15, level16;
        Map level21, level22, level23, level24, level25, level26, level27;
        Map level31, level32, level33, level34, level35, level36, level37, level38;
        Map level41, level42, level43, level44, level45, level46, level47, level48, level49;
        Map level51, level52, level53, level54, level55, level56, level57, level58, level59, level510;

        Ball ball;

        enum GameState
        {
            StartMenu,
            Difficulty,
            Instructions,
            Load,
            Playing,
            Pause,
            LevelFailed,
            LevelSuccess,
            AllLevelsBeaten,
        }

        GameState currentGameState;

        enum LevelState
        {
            L11,
            L12,
            L13,
            L14,
            L15,
            L16,
            L21,
            L22,
            L23,
            L24,
            L25,
            L26,
            L27,
            L31,
            L32,
            L33,
            L34,
            L35,
            L36,
            L37,
            L38,
            L41,
            L42,
            L43,
            L44,
            L45,
            L46,
            L47,
            L48,
            L49,
            L51,
            L52,
            L53,
            L54,
            L55,
            L56,
            L57,
            L58,
            L59,
            L510,
            NoLevel,
        }

        LevelState currentLevelState;
        Map currentLevel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1184;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();
            screenRectangle = new Rectangle(0, 0, (int)graphics.PreferredBackBufferWidth, (int)graphics.PreferredBackBufferHeight);
            this.Window.Title = "Maze Blaze Mk 3.0";
            IsMouseVisible = true;
            Tile.Content = Content;
        }

        protected override void Initialize()
        {
            level11 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level11/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level11/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level11/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level11/collectCoins.txt"), 60, new Vector2(8, 104), new Vector2(1152, 320));

            level12 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level12/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level12/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level12/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level12/collectCoins.txt"), 90, new Vector2(552, 328), new Vector2(640, 320));

            level13 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level13/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level13/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level13/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level13/collectCoins.txt"), 90, new Vector2(1064, 104), new Vector2((4 * 32) - 64, (5 * 32) - 32));
            /*
            level14 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level14/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level14/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level14/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level14/collectCoins.txt"), 90, new Vector2(), new Vector2());

            level15 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level15/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level15/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level15/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level15/collectCoins.txt"), 90, new Vector2(), new Vector2());

            level16 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level16/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level16/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level16/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level16/collectCoins.txt"), 90, new Vector2(), new Vector2());

            level21 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level21/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level21/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level21/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level21/collectCoins.txt"), 120, new Vector2(), new Vector2());

            level22 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level22/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level22/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level22/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level22/collectCoins.txt"), 120, new Vector2(), new Vector2());

            /*level23 = new Map(FileReader.GetArrayFromFile(contentFilePath + "Level23/bricks.txt"),
                              FileReader.GetArrayFromFile(contentFilePath + "Level23/colorCoins.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level23/spikes.txt"),
                              FileReader.GetBoolFromFile(contentFilePath + "Level23/spikes.txt);*/

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            buttonFont = Content.Load<SpriteFont>("Images/Other/buttonFont");
            font = Content.Load<SpriteFont>("Images/Other/font");
            menuFont = Content.Load<SpriteFont>("Images/Other/menuFont");

            playButton = new Button(graphics.GraphicsDevice, "PLAY GAME", new Vector2(480, 300), buttonFont);
            instructionButton = new Button(graphics.GraphicsDevice, "INSTRUCTIONS", new Vector2(480, 380), buttonFont);
            loadButton = new Button(graphics.GraphicsDevice, "LOAD GAME", new Vector2(480, 460), buttonFont);
            exitButton = new Button(graphics.GraphicsDevice, "EXIT", new Vector2(480, 540), buttonFont);

            backButton1 = new Button(graphics.GraphicsDevice, "BACK", new Vector2(1004, 580), buttonFont);
            backButton2 = new Button(graphics.GraphicsDevice, "BACK", new Vector2(1004, 580), buttonFont);

            resumeButton = new Button(graphics.GraphicsDevice, "RESUME", new Vector2(480, 300), buttonFont);
            saveButton = new Button(graphics.GraphicsDevice, "SAVE GAME", new Vector2(480, 380), buttonFont);
            mainButton = new Button(graphics.GraphicsDevice, "MAIN MENU", new Vector2(480, 460), buttonFont);

            easy = new Button(graphics.GraphicsDevice, "EASY", new Vector2(480, 300), buttonFont);
            medium = new Button(graphics.GraphicsDevice, "MEDIUM", new Vector2(480, 380), buttonFont);
            hard = new Button(graphics.GraphicsDevice, "HARD", new Vector2(480, 460), buttonFont);
            ridiculous = new Button(graphics.GraphicsDevice, "RIDICULOUS", new Vector2(480, 540), buttonFont);

            ball = new Ball(screenRectangle, Content.Load<Texture2D>("Images/Other/ball"));
        }

        protected override void UnloadContent()
        {
        }

        protected double DetermineRankMultiplier(int rank)
        {
            if (rank == 1)
            {
                return 1;
            }

            else if (rank == 4)
            {
                return 1.5;
            }

            else
            {
                return 1.25;
            }
        }

        protected double DetermineDifficultyMultiplier(string difficulty)
        {
            if (difficulty == "EASY")
            {
                return 1.25;
            }

            else if (difficulty == "HARD")
            {
                return 0.75;
            }

            else if (difficulty == "RIDICULOUS")
            {
                return 0.5;
            }

            else
            {
                return 1;
            }
        }

        // For resetting game ready for new level
        private void Reset(Map inLevel, Vector2 startPosition)
        {
            ball.BallColor = Color.White;
            ball.SetPosition(startPosition);
            startTime = inLevel.GetLevelTime() * DetermineDifficultyMultiplier(difficulty) * DetermineRankMultiplier(rank);
            timer = startTime;

            // Used to skip coin resetting part in earlier parts of the game
            if (rank > 2)
            {
                coinsCollected = 0;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            switch(currentGameState)
            {
                case GameState.StartMenu:
                    playButton.Update();
                    instructionButton.Update();
                    loadButton.Update();
                    exitButton.Update();

                    if (this.IsActive)
                    {
                        if (playButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            playButton.SetIsClicked(false);
                            rank = 1; // Change back to 1 when finished with producing levels!
                            coinsCollected = 0;
                            level11.GenerateLevel(rank);
                            ball.BallColor = Color.White;
                            ball.SetPosition(new Vector2(8, 104));
                            currentLevel = level11;
                            currentLevelState = LevelState.L11;
                            currentGameState = GameState.Difficulty;
                        }

                        if (instructionButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            instructionButton.SetIsClicked(false);
                            currentGameState = GameState.Instructions;
                        }

                        if (loadButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            loadButton.SetIsClicked(false);
                            currentGameState = GameState.Load;
                        }

                        if (exitButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            this.Exit();
                        }
                    }
                    break;

                case GameState.Difficulty:
                    easy.Update();
                    medium.Update();
                    hard.Update();
                    ridiculous.Update();

                    if (this.IsActive)
                    {
                        if (easy.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            difficulty = easy.GetButtonText();
                            startTime = level11.GetLevelTime() * DetermineDifficultyMultiplier(difficulty) * DetermineRankMultiplier(rank);
                            timer = startTime;
                            lives = 7;
                            easy.SetIsClicked(false);
                            currentGameState = GameState.Playing;
                        }

                        if (medium.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            difficulty = medium.GetButtonText();
                            startTime = level11.GetLevelTime() * DetermineDifficultyMultiplier(difficulty) * DetermineRankMultiplier(rank);
                            timer = startTime;
                            lives = 5;
                            medium.SetIsClicked(false);
                            currentGameState = GameState.Playing;
                        }

                        if (hard.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            difficulty = hard.GetButtonText();
                            startTime = level11.GetLevelTime() * DetermineDifficultyMultiplier(difficulty) * DetermineRankMultiplier(rank);
                            timer = startTime;
                            lives = 3;
                            hard.SetIsClicked(false);
                            currentGameState = GameState.Playing;
                        }

                        if (ridiculous.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            difficulty = ridiculous.GetButtonText();
                            startTime = level11.GetLevelTime() * DetermineDifficultyMultiplier(difficulty) * DetermineRankMultiplier(rank);
                            timer = startTime;
                            lives = 1;
                            ridiculous.SetIsClicked(false);
                            currentGameState = GameState.Playing;
                        }
                    }
                    break;

                case GameState.Instructions:
                    backButton1.Update();

                    if (this.IsActive)
                    {
                        if (backButton1.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            backButton1.SetIsClicked(false);
                            currentGameState = GameState.StartMenu;
                        }
                    }
                    break;

                case GameState.Load:
                    backButton2.Update();

                    if (this.IsActive)
                    {
                        if (backButton2.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            backButton2.SetIsClicked(false);
                            currentGameState = GameState.StartMenu;
                        }
                    }
                    break;

                case GameState.Pause:
                    resumeButton.Update();
                    saveButton.Update();
                    mainButton.Update();

                    if (this.IsActive)
                    {
                        if (resumeButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            resumeButton.SetIsClicked(false);
                            currentGameState = GameState.Playing;
                        }

                        if (mainButton.IsClicked() && Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            mainButton.SetIsClicked(false);
                            currentGameState = GameState.StartMenu;
                        }
                    }
                    break;

                case GameState.LevelFailed:
                    if (this.IsActive == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            if (lives <= 0)
                            {
                                currentGameState = GameState.StartMenu;
                            }

                            else
                            {
                                Reset(currentLevel, currentLevel.GetStartPosition());

                                currentGameState = GameState.Playing;
                            }
                        }
                    }
                    break;

                case GameState.LevelSuccess:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        currentGameState = GameState.Playing;
                    break;

                case GameState.AllLevelsBeaten:
                    break;

                case GameState.Playing:
                    ball.Update();

                    timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (timer <= 0)
                    {
                        lives -= 1;
                        currentGameState = GameState.LevelFailed;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        currentGameState = GameState.Pause;

                    switch(currentLevelState)
                    {
                        case LevelState.L11:
                            foreach (Brick brick in level11.GetBrickList())
                                ball.BrickCollision(brick);
                            foreach (ColorCoin coin in level11.GetColorList())
                                ball.CoinCollision(coin);

                            foreach (Spike spike in level11.GetSpikeList())
                            {
                                if (ball.SpikeCollision(spike))
                                {
                                    lives -= 1;
                                    currentGameState = GameState.LevelFailed;
                                }
                            }

                            foreach (CollectCoin coin in level11.GetCollectList())
                            {
                                if (ball.CoinCollision(coin))
                                {
                                    coin.IsVisible = false;
                                }
                            }

                            for (byte b = 0; b < level11.GetCollectList().Count; b++)
                            {
                                if (!(level11.GetCollectList()[b].IsVisible))
                                {
                                    coinsCollected += 1;
                                    level11.RemoveCoin(b);
                                    b--;
                                }
                            }

                            if (ball.GetBallRectangle().Intersects(level11.GetFlag().Rectangle))
                            {
                                currentLevel = level12;
                                currentGameState = GameState.LevelSuccess;
                                currentLevelState = LevelState.L12;
                                level12.GenerateLevel(rank);
                                Reset(level12, level12.GetStartPosition());
                            }

                            break;

                        case LevelState.L12:
                            foreach (Brick brick in level12.GetBrickList())
                                ball.BrickCollision(brick);
                            foreach (ColorCoin coin in level12.GetColorList())
                                ball.CoinCollision(coin);

                            foreach (Spike spike in level12.GetSpikeList())
                            {
                                if (ball.SpikeCollision(spike))
                                {
                                    lives -= 1;
                                    currentGameState = GameState.LevelFailed;
                                }
                            }

                            foreach (CollectCoin coin in level12.GetCollectList())
                            {
                                if (ball.CoinCollision(coin))
                                {
                                    coin.IsVisible = false;
                                }
                            }

                            for (byte b = 0; b < level12.GetCollectList().Count; b++)
                            {
                                if (!(level12.GetCollectList()[b].IsVisible))
                                {
                                    coinsCollected += 1;
                                    level12.RemoveCoin(b);
                                    b--;
                                }
                            }

                            if (ball.GetBallRectangle().Intersects(level12.GetFlag().Rectangle))
                            {
                                currentLevel = level13;
                                currentGameState = GameState.LevelSuccess;
                                currentLevelState = LevelState.L13;
                                level13.GenerateLevel(rank);
                                Reset(level13, level13.GetStartPosition());
                            }
                            break;

                        case LevelState.L13:

                            foreach (Brick brick in level13.GetBrickList())
                                ball.BrickCollision(brick);
                            foreach (ColorCoin coin in level13.GetColorList())
                                ball.CoinCollision(coin);

                            foreach (Spike spike in level13.GetSpikeList())
                            {
                                if (ball.SpikeCollision(spike))
                                {
                                    lives -= 1;
                                    currentGameState = GameState.LevelFailed;
                                }
                            }

                            foreach (CollectCoin coin in level13.GetCollectList())
                            {
                                if (ball.CoinCollision(coin))
                                {
                                    coin.IsVisible = false;
                                }
                            }

                            for (byte b = 0; b < level13.GetCollectList().Count; b++)
                            {
                                if (!(level11.GetCollectList()[b].IsVisible))
                                {
                                    coinsCollected += 1;
                                    level11.RemoveCoin(b);
                                    b--;
                                }
                            }

                            if (ball.GetBallRectangle().Intersects(level13.GetFlag().Rectangle))
                            {
                                currentLevel = level14;
                                currentGameState = GameState.LevelSuccess;
                                currentLevelState = LevelState.L14;
                                //level14.GenerateLevel(rank);
                                Reset(level14, level14.GetStartPosition());
                            }

                            break;

                        case LevelState.L14:
                            break;

                        case LevelState.L15:
                            break;

                        case LevelState.L16:
                            break;

                        case LevelState.L21:
                            break;

                        case LevelState.L22:
                            break;

                        case LevelState.L23:
                            break;

                        case LevelState.L24:
                            break;

                        case LevelState.L25:
                            break;

                        case LevelState.L26:
                            break;

                        case LevelState.L27:
                            break;

                        case LevelState.L31:
                            break;

                        case LevelState.L32:
                            break;

                        case LevelState.L33:
                            break;

                        case LevelState.L34:
                            break;

                        case LevelState.L35:
                            break;

                        case LevelState.L36:
                            break;

                        case LevelState.L37:
                            break;

                        case LevelState.L38:
                            break;

                        case LevelState.L41:
                            break;

                        case LevelState.L42:
                            break;

                        case LevelState.L43:
                            break;

                        case LevelState.L44:
                            break;

                        case LevelState.L45:
                            break;

                        case LevelState.L46:
                            break;

                        case LevelState.L47:
                            break;

                        case LevelState.L48:
                            break;

                        case LevelState.L49:
                            break;

                        case LevelState.L51:
                            break;

                        case LevelState.L52:
                            break;

                        case LevelState.L53:
                            break;

                        case LevelState.L54:
                            break;

                        case LevelState.L55:
                            break;

                        case LevelState.L56:
                            break;

                        case LevelState.L57:
                            break;

                        case LevelState.L58:
                            break;

                        case LevelState.L59:
                            break;

                        case LevelState.L510:
                            break;
                    }

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.StartMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("Images/Menu/MENU INTERFACE game"), new Vector2(0, 0), Color.White);
                    playButton.Draw(spriteBatch);
                    instructionButton.Draw(spriteBatch);
                    loadButton.Draw(spriteBatch);
                    exitButton.Draw(spriteBatch);
                    break;

                case GameState.Difficulty:
                    GraphicsDevice.Clear(new Color(0, 51, 154));
                    spriteBatch.DrawString(menuFont, "CHOOSE DIFFICULTY", new Vector2(176, 4), Color.White);

                    easy.Draw(spriteBatch);
                    medium.Draw(spriteBatch);
                    hard.Draw(spriteBatch);
                    ridiculous.Draw(spriteBatch);
                    break;

                case GameState.Instructions:
                    spriteBatch.Draw(Content.Load<Texture2D>("Images/Menu/INSTRUCTIONS WITH GRAPHICS"), new Vector2(0, 0), Color.White);
                    backButton1.Draw(spriteBatch);
                    break;

                case GameState.Load:
                    GraphicsDevice.Clear(new Color(0, 51, 154));
                    spriteBatch.DrawString(menuFont, "LOAD GAME", new Vector2(320, 4), Color.White);

                    backButton2.Draw(spriteBatch);
                    break;

                case GameState.Pause:
                    GraphicsDevice.Clear(new Color(0, 51, 154));
                    spriteBatch.DrawString(menuFont, "GAME PAUSED", new Vector2(256, 4), Color.White);

                    resumeButton.Draw(spriteBatch);
                    saveButton.Draw(spriteBatch);
                    mainButton.Draw(spriteBatch);
                    break;

                case GameState.LevelFailed:
                    GraphicsDevice.Clear(new Color(0, 51, 154));
                    spriteBatch.DrawString(menuFont, "YOU DIED", new Vector2(312, 4), Color.White);

                    if (lives <= 0)
                    {
                        spriteBatch.DrawString(font, "ALL YOUR LIVES ARE GONE!", new Vector2(312, 300), Color.White);
                        spriteBatch.DrawString(font, "GAME OVER", new Vector2(312, 330), Color.White);
                        spriteBatch.DrawString(font, "PRESS ENTER TO RETURN TO THE MAIN MENU", new Vector2(312, 390), Color.White);
                    }

                    else
                    {
                        spriteBatch.DrawString(font, "YOU HAVE " + lives.ToString() + " LIVES LEFT", new Vector2(312, 300), Color.White);
                        spriteBatch.DrawString(font, "PRESS ENTER TO CONTINUE", new Vector2(312, 360), Color.White);
                    }
                    break;

                case GameState.LevelSuccess:
                    GraphicsDevice.Clear(new Color(0, 51, 154));
                    spriteBatch.DrawString(menuFont, "LEVEL COMPLETE", new Vector2(200, 4), Color.White);

                    spriteBatch.DrawString(font, "PRESS ENTER TO CONTINUE", new Vector2(312, 360), Color.White);
                    break;

                case GameState.AllLevelsBeaten:
                    break;

                case GameState.Playing:
                    switch (currentLevelState)
                    {
                        case LevelState.L11:
                            level11.Draw(spriteBatch);
                            break;

                        case LevelState.L12:
                            level12.Draw(spriteBatch);
                            break;

                        case LevelState.L13:
                            level13.Draw(spriteBatch);
                            break;

                        case LevelState.L14:
                            break;

                        case LevelState.L15:
                            break;

                        case LevelState.L16:
                            break;

                        case LevelState.L21:
                            break;

                        case LevelState.L22:
                            break;

                        case LevelState.L23:
                            break;

                        case LevelState.L24:
                            break;

                        case LevelState.L25:
                            break;

                        case LevelState.L26:
                            break;

                        case LevelState.L27:
                            break;

                        case LevelState.L31:
                            break;

                        case LevelState.L32:
                            break;

                        case LevelState.L33:
                            break;

                        case LevelState.L34:
                            break;

                        case LevelState.L35:
                            break;

                        case LevelState.L36:
                            break;

                        case LevelState.L37:
                            break;

                        case LevelState.L38:
                            break;

                        case LevelState.L41:
                            break;

                        case LevelState.L42:
                            break;

                        case LevelState.L43:
                            break;

                        case LevelState.L44:
                            break;

                        case LevelState.L45:
                            break;

                        case LevelState.L46:
                            break;

                        case LevelState.L47:
                            break;

                        case LevelState.L48:
                            break;

                        case LevelState.L49:
                            break;

                        case LevelState.L51:
                            break;

                        case LevelState.L52:
                            break;

                        case LevelState.L53:
                            break;

                        case LevelState.L54:
                            break;

                        case LevelState.L55:
                            break;

                        case LevelState.L56:
                            break;

                        case LevelState.L57:
                            break;

                        case LevelState.L58:
                            break;

                        case LevelState.L59:
                            break;

                        case LevelState.L510:
                            break;
                    }

                    ball.Draw(spriteBatch);

                    spriteBatch.DrawString(font, "LIVES: " + lives.ToString(), new Vector2(4, 0), Color.White);
                    
                    if (timer <= 15)
                    {
                        spriteBatch.DrawString(font, "TIME LEFT  " + ((int)timer / 60).ToString() + " : " + (timer % 60).ToString("00"), new Vector2(954, 0), Color.Red);
                    }

                    else
                    {
                        spriteBatch.DrawString(font, "TIME LEFT  " + ((int)timer / 60).ToString() + " : " + (timer % 60).ToString("00"), new Vector2(954, 0), Color.White);
                    }

                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
