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
       // private List<CubeMesh> cubeList = new List<CubeMesh>();
        private CubeMesh myCube = new CubeMesh(0, 20, 0);
        private Liquid ocean = new Liquid(0, 0, 100, 50, 0.8f);

        

        private Randomizer planetMass = new Randomizer(1, 4);
        private Randomizer planetColor = new Randomizer(0, 1);
        private Randomizer xPos = new Randomizer(-50, 50);
        private Randomizer yPos = new Randomizer(-40, 40);

        private List<Attractor> starList = new List<Attractor>();
        //private List<Attractor> planetList = new List<Attractor>();

        //private Attractor Planet = new Attractor();
        // private Attractor AllStar = new Attractor();
        public MainWindow()
        {
            InitializeComponent();

         
            for (int i = 0; i <= 30; i++)
            {
                starList.Add(new Attractor()
                {
                    Position = new Vector3((int)xPos.GenerateInt(), (int)yPos.GenerateInt(), 0),
                    Mass = planetMass.GenerateInt()
                    
                });
            }
         

        }

      

     

        private Vector3 wind = new Vector3(1f, 0, 0);
        private Vector3 gravity = new Vector3(0.0f, -0.5f, 0.0f );
        public List<CubeMesh> starlist = new List<CubeMesh>();
        #region OpenGl Initilization
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
           gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -100.0f);
          //  gl.Color(0, 0f, 1.0f, 0.0f);
           // Planet.Draw(gl);
            //Planet.Scale = new Vector3(Planet.Mass, Planet.Mass, Planet.Mass);
            
            
            foreach (Attractor Star in starList)
            {
                gl.Color(planetColor.GenerateDouble(), planetColor.GenerateDouble(), planetColor.GenerateDouble());
                
               
                foreach (Attractor Planet in starList)
                {
                    Planet.Scale = new Vector3(Planet.Mass, Planet.Mass, Planet.Mass);
                    Planet.Draw(gl);

                    if (Planet != Star)
                    {
                        Star.ApplyForce(Planet.CalculateAttraction(Star));
                    }

                }
            }

            


            /*  foreach (CubeMesh cube in cubeList)
              {
                  gl.Color(1.0f, 1.0f, 1.0f);
                  cube.Scale = new Vector3( cube.Mass / 2,  cube.Mass / 2,  cube.Mass / 2);
                  cube.Draw(gl);
                  cube.ApplyGravity();
                  cube.ApplyForce(new Vector3(0.1f, 0, 0));

                  if (cube.Position.y <= -40)
                  {
                      cube.Position.y = -40;
                      cube.Velocity.y *= -1;
                  }

                  if (ocean.Contains(cube))
                  {
                      var dragForce = ocean.CalculateDragForce(cube);
                      cube.ApplyForce(dragForce);
                  }
              }


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
        #endregion

        #region MouseMove Method
        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(this);

        }
#endregion
    }
}
