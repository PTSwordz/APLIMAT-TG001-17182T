using aplimat_labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Utilities
{
    public class Attractor : CubeMesh
    {
        public float G = 1f;

        public Vector3 CalculateAttraction(Movable movable)
        {
            var force = this.Position - movable.Position;
            var distance = force.GetMagnitude();

            distance = Utils.ConstrainFloat(distance, 5, 25);

            force.Normalize();

            var strength = (this.G * movable.Mass) / (distance * distance); 

            force *= strength;

            return force;

        }
    }
}
