using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TekanneMonoGame
{
    public class TekanneMonoGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Model teapot;
        Matrix projection;
        Matrix view;

        float rotationX;

        public TekanneMonoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            teapot = Content.Load<Model>(@"teapot");
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000f);
            view = Matrix.CreateLookAt(Vector3.Backward * 50f, Vector3.Zero, Vector3.Down);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            rotationX += (float)gameTime.ElapsedGameTime.TotalSeconds * MathHelper.TwoPi;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (var mesh in teapot.Meshes)
            {
                foreach (var meshPart in mesh.MeshParts)
                {
                    var effect = (meshPart.Effect as BasicEffect);
                    effect.Projection = projection;
                    effect.View = view;
                }

                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
