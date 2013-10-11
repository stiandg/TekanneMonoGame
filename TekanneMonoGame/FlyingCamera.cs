using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekanne
{
    public class FlyingCamera
    {
        Vector3 Position;
        Vector3 Rotation;

        Matrix RotationMatrix;

        public Matrix View;

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
                Rotation.X += deltaTime;
            else if (keyboardState.IsKeyDown(Keys.Down))
                Rotation.X -= deltaTime;

            if (keyboardState.IsKeyDown(Keys.Left))
                Rotation.Y += deltaTime;
            else if (keyboardState.IsKeyDown(Keys.Right))
                Rotation.Y -= deltaTime;

            RotationMatrix = Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, 0f);

            if (keyboardState.IsKeyDown(Keys.W))
                Position += Vector3.TransformNormal(Vector3.Forward, RotationMatrix) * deltaTime * 10f;
            else if (keyboardState.IsKeyDown(Keys.S))
                Position += Vector3.TransformNormal(Vector3.Backward, RotationMatrix) * deltaTime * 10f;

            if (keyboardState.IsKeyDown(Keys.A))
                Position += Vector3.TransformNormal(Vector3.Left, RotationMatrix) * deltaTime * 10f;
            else if (keyboardState.IsKeyDown(Keys.D))
                Position += Vector3.TransformNormal(Vector3.Right, RotationMatrix) * deltaTime * 10f;

            if (keyboardState.IsKeyDown(Keys.LeftShift))
                Position += Vector3.Up * deltaTime * 10f;
            else if (keyboardState.IsKeyDown(Keys.LeftControl))
                Position += Vector3.Down * deltaTime * 10f;

            View = Matrix.CreateLookAt(Position, Position + Vector3.TransformNormal(Vector3.Forward, RotationMatrix), Vector3.Up);
        }
    }
}
