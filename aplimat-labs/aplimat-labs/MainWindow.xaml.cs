using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplimat_labs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        
        }

        private CubeMesh mover = new CubeMesh(-25, 0, 0);
        private Vector3 acceleration = new Vector3(0.01f, 0, 0);
      
     

        private Vector3 mousePos = new Vector3();
        private Vector3 myVector = new Vector3();
        
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
           gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);


            mover.Draw(gl);
            mover.Velocity +=acceleration;
            mover.Velocity.Clamp(2.0f);

            bool Bounce = false;

            if  (mover.Position.x >= 25)
            {
                Bounce = true;
                mover.Velocity.x *= -1f;
                acceleration = new Vector3(0.10f, 0, 0);
                
            }

            else if (mover.Position.x == 0)
            {
                Bounce = false;
                mover.Velocity.x -= -1f;
            }

            if (Bounce == true && mover.Velocity.x >= 0)
            {
                mover.Velocity.x = 0;
                mover.Position.x = -15;
                Bounce = false;
                
                //acceleration = new Vector3(-0.05f, 0, 0);
            }


            gl.DrawText(20, 20, 1, 0, 0, "Arial", 25, mover.Velocity.x + "  ");






           // mousePos.Normalize();
           // mousePos *= 10;

            //myCube.Draw(gl);
            //myCube.Position += velocity * speed; 
           /* gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(30.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 0 , 0);
            gl.Vertex(mousePos.x, mousePos.y,0);
            gl.End();


            gl.Color(1.0f, 1.0f, 1.0f);
            gl.LineWidth(5.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 0, 0);
            gl.Vertex(mousePos.x, mousePos.y, 0);
            gl.End();

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(30.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 5, 0);
            gl.Vertex(mousePos.x, mousePos.y, 0);
            gl.End();


            gl.Color(1.0f, 1.0f, 1.0f);
            gl.LineWidth(5.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 5, 0);
            gl.Vertex(mousePos.x, mousePos.y, 0);
            gl.End();



            */
            

            /*
            Point position = PointToScreen(Mouse.GetPosition(this);
            myVector.x = (float)position.X;
            myVector.y = (float)position.Y;

            */
           
           
            /*
                        gl.Color(0.0f, 1.0f, 0.0f);
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                      //  gl.Vertex(0, 0);
                        gl.Vertex(a.x, a.y);
                        gl.Vertex(b.x, b.y);
                        gl.End();

                        gl.Color(0.0f, 0.0f, 1.0f);
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Vertex(b.x, b.y);
                        gl.Vertex(0, 0);

                        gl.End();
                        */
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);
           
            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(this);

            mousePos.x = (float)pos.X - (float)Width / 2.0f;
            mousePos.y = (float)pos.Y - (float)Height / 2.0f;

            mousePos.y = -mousePos.y;

            // mousePos = new Vector3(e.GetPosition(this).X, e.GetPosition(this).Y, 0);

            //mousePos.x = (float)mousePos.x - (float)Width / 2.0f;
            //mousePos.y = (float)mousePos.y - (float)Height / 2.0f;

            Console.WriteLine("mouse X : " + mousePos.x + "mouse Y:" + mousePos.y);
        }
    }
}
