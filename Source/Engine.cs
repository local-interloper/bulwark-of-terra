using BulwarkOfTerra.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BulwarkOfTerra;

public class Engine : Game
{
    public static SpriteFont DefaultFont;
    public static GraphicsDeviceManager GraphicsDeviceManager;
    public static GraphicsDevice GraphicsDevice;
    public static SpriteBatch SpriteBatch;
    private static AbstractScene _currentScene;
    public static ContentManager ContentManager;

    public Engine()
    {
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        GraphicsDeviceManager.PreferredBackBufferWidth = 800;
        GraphicsDeviceManager.PreferredBackBufferHeight = 800;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        ContentManager = Content;
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        DefaultFont = Content.Load<SpriteFont>("fonts/default");
    }

    protected override void Initialize()
    {
        base.Initialize();
        GraphicsDevice = GraphicsDeviceManager.GraphicsDevice;
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        SetScene(new MenuScene());
    }

    public static void SetScene(AbstractScene scene)
    {
        _currentScene = scene;
        _currentScene.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        InputSystem.Update();
        _currentScene.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDeviceManager.GraphicsDevice.Clear(Color.Black);
        _currentScene.Draw(gameTime);
    }
}