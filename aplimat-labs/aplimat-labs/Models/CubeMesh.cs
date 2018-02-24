using aplimat_labs.Models;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs
{
    public class CubeMesh : Movable 
    {
        

        public CubeMesh()
        {
            this.Position = new Vector3();
        }

        public CubeMesh(float x, float y, float z)
        {
            this.Position = new Vector3(x, y, z);
        }

        public CubeMesh(Vector3 newPos)
        {
            this.Position = newPos;
        }

        public void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //Front face
            gl.Vertex(this.Position.x - 0.5f, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5f, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y - 0.5f, this.Position.z + 0.5f);
            //Right face
            gl.Vertex(this.Position.x + 0.5f, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y - 0.5f, this.Position.z - 0.5f);
            //Back face
            gl.Vertex(this.Position.x - 0.5f, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x - 0.5f, this.Position.y - 0.5f, this.Position.z - 0.5f);
            //Left face
            gl.Vertex(this.Position.x - 0.5f, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5f, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.End();
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //Top face
            gl.Vertex(this.Position.x - 0.5f, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5f, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.End();
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //Bottom face
            gl.Vertex(this.Position.x - 0.5f, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5f, this.Position.y - 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5f, this.Position.y - 0.5f, this.Position.z - 0.5f);
            gl.End();


            UpdateMotion();

        }

        

        private void UpdateMotion()
        {
            this.Velocity += this.Acceleration;
            this.Position += this.Velocity;
            this.Acceleration *= 0;

        }

        
    }
}
