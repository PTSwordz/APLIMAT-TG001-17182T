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

        private CubeMesh lightCube = new CubeMesh()
        {
           // Acceleration = new Vector3(0.1f,0,0),
            Position = new Vector3(-25,0,0),
            Mass = 5
        };

        private CubeMesh medCube = new CubeMesh()
        {
            // Acceleration = new Vector3(0.1f,0,0),
            Position = new Vector3(-25, 0, 0),
            Mass = 10
        };

        private CubeMesh heavyCube = new CubeMesh()
        {
            // Acceleration = new Vector3(0.1f,0,0),
            Position = new Vector3(-25, 0, 0),
            Mass = 15
        };

        private Vector3 wind = new Vector3(1f, 0, 0);
        private Vector3 gravity = new Vector3(0.0f, -0.5f, 0.0f );
        public List<CubeMesh> cubelist = new List<CubeMesh>();
        #region OpenGl Initilization
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
           gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);

            gl.Color(0, 0, 1.0f);
            lightCube.Draw(gl);
            lightCube.ApplyForce(gravity);
            lightCube.ApplyForce(wind);



            gl.Color(1.0f, 0, 0);
            medCube.Draw(gl);
            medCube.ApplyForce(gravity);
            medCube.ApplyForce(wind);


            gl.Color(0, 1.0f, 0);
            heavyCube.Draw(gl);
            heavyCube.ApplyForce(gravity);
            heavyCube.ApplyForce(wind);

            if (lightCube.Position.x >= 25 )
            {
                lightCube.Velocity.x *= -1;
                
            }
            if (lightCube.Position.y >= 20 || lightCube.Position.y <= -15)
            {
                lightCube.Velocity.y *= -1;
                
            }
            if (medCube.Position.x >= 25 )
            {
                medCube.Velocity.x *= -1;
                
            }
            if (medCube.Position.y >= 20 || medCube.Position.y <= -15)
            {
                medCube.Velocity.y *= -1;
                
            }

            if (heavyCube.Position.x >= 25 )
            {
                heavyCube.Velocity.x *= -1;
                
            }
            if (heavyCube.Position.y >= 20 || heavyCube.Position.y <= -15)
            {
                heavyCube.Velocity.y *= -1;
               
            }


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
        #endregion

        #region MouseMove Method
        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(this);

        }
#endregion
    }
}
