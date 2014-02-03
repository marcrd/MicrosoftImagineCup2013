using BEPUphysics.Collidables;
using BEPUphysics.Collidables.MobileCollidables;
using BEPUphysics.Entities.Prefabs;
using BEPUphysics.MathExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BEPUphysics.Entities;
using BEPUphysics;
using BEPUphysics.DataStructures;
using BEPUphysics.NarrowPhaseSystems.Pairs;
using Imaginecup2013.Setup;
using Imaginecup2013.Physics;
using Imaginecup2013.Input;
using Imaginecup2013.Rendering;

namespace Imaginecup2013 
{
    public class Leoni : Microsoft.Xna.Framework.Game 
    {
        /* Constants / Basic Information */
        public const string version = "0.0.1";
        public int screenSizeWidth = 800;
        public int screenSizeHeight = 600;

        /* Global Variables */
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Space space;
        public Camera Camera;
        public Sphere cameraBox;

        /* Effects */
        public Effect simpleEffect;
        public Effect textureEffect;
        public Effect postEffect;
        public Effect shadowEffect;

        /* Fonts */
        public SpriteFont fogFont;

        /* Input */
        public KeyboardState KeyboardState;
        public MouseState MouseState;        

        /* Render Targets and Maps*/
        public RenderTarget2D baseTarget;
        public Texture2D baseMap;
        public RenderTarget2D depthTarget;
        public Texture2D depthMap;

        /* Lighting info */
        public Vector3 lightPos;
        public Matrix lightsView;
        public Matrix lightProjection;
        public Matrix lightProjectionMatrix;
        public bool isShadowMapping = false;

        public Leoni()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenSizeWidth;
            graphics.PreferredBackBufferHeight = screenSizeHeight;
            Content.RootDirectory = "Content";
        }
       
        protected override void Initialize()
        {
            //Setup render targets
            baseTarget = new RenderTarget2D(graphics.GraphicsDevice, 1024, 1024, true, graphics.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24);
            depthTarget = new RenderTarget2D(graphics.GraphicsDevice, 1024, 1024, true, graphics.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24);
            
            //Setup the camera.
            Camera = new Camera(this, new Vector3(0, 3, 10), 5);
           
            //New World
            space = new Space();

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            //Used to draw textures
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Effects and fonts
            InitializeLoader.load(this);

            //Load and initilize the world
            InitializeWorld.setup(this);            
        }      

      
        protected override void UnloadContent(){}

       
        protected override void Update(GameTime gameTime)
        {
            //Handle input
            UpdateInput.update(this);

            //Update physics engine
            UpdatePhysics.update(this, gameTime);

            base.Update(gameTime);
        }

        
       
        protected override void Draw(GameTime gameTime)
        {
            isShadowMapping = true;

            //Draw basic scene
            SetupScene.draw(this, depthTarget);
            
            //Trigger all drawing data
            base.Draw(gameTime);//Look at EntityModel and StaticModel for code;

            //Save scene to map
            depthMap = SaveScene.save(this, depthTarget);

            //Draw regular scene
            isShadowMapping = false;
            SetupScene.draw(this, baseTarget);
            base.Draw(gameTime);
            baseMap = SaveScene.save(this, baseTarget);

            //Draw to screen
            DrawScene.draw(this, baseMap);            
        }
    }
}
