﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Testing_Chamber
{
    public abstract class BaseViewport
    {
        protected BaseViewport(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public GraphicsDevice GraphicsDevice { get; private set; }

        public Viewport Viewport
        {
            get { return GraphicsDevice.Viewport; }
        }

        public abstract int VirtualWidth { get; }
        public abstract int VirtualHeight { get; }
        public abstract int ViewportWidth { get; }
        public abstract int ViewportHeight { get; }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(0, 0, VirtualWidth, VirtualHeight);
            }
        }

        public Point Center
        {
            get { return BoundingRectangle.Center; }
        }

        public abstract Matrix GetScaleMatrix();

        public Point PointToScreen(Point point)
        {
            return PointToScreen(point.X, point.Y);
        }

        public virtual Point PointToScreen(int x, int y)
        {
            var scaleMatrix = GetScaleMatrix();
            var invertedMatrix = Matrix.Invert(scaleMatrix);
            return Vector2.Transform(new Vector2(x, y), invertedMatrix).ToPoint();
        }

        public virtual void Reset()
        {
        }
    }
}
