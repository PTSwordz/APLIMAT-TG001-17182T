using aplimat_labs.Models;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs
{
    class Liquid
    {
        public float drag; // Cdrag
        public float x, y;
        public float width, depth;

        public Liquid(float x, float y, float width,  float depth , float drag)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.depth = depth;
            this.drag = drag;
        }

        public void Draw(OpenGL gl, byte r = 28, byte g = 120, byte b = 186)

        {
            gl.Color(r, g, b);
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(x - width, y, 0);
            gl.Vertex(x + width, y, 0);
            gl.Vertex(x + width, y - depth, 0);
            gl.Vertex(x - width, y - depth, 0);
           
            gl.End();
            
        }
        /*
             * checks if position is movable
             * is inside the actual liquid
             * 
             */

        public bool Contains(Movable movable) {

            var pos = movable.Position;

            return pos.x > this.x - this.width &&
                pos.x < this.x + this.width &&
                    pos.y < this.y;

            }


        /*
             * Calculates the drag force with the formula:
             * FD = v^2 * drag * vdirection* -1
             * 
             */
        public Vector3 CalculateDragForce(Movable movable)
        {
            // Magnitude  = coefficient of drag * speed squared
            var speed = movable.Velocity.GetMagnitude();
            var dragMangitude = this.drag * speed * speed;

            // direction is inverse of velocity
            var dragForce = movable.Velocity;
            dragForce *= -1;


            // scale according to its magnitude
            dragForce.Normalize();
            dragForce *= dragMangitude;

            return dragForce;

        }
    }
}
