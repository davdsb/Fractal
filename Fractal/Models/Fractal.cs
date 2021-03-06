﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    public static class Fractal
    {
        /// <summary>
        /// Create a fractal on a base shape from a model
        /// </summary>
        public static void CreateFractal(Model model, NPoint shape, int iteration)
        {
            // Fractal's number of iterations
            for (int i = 0; i < iteration; i++)
            {
                // apply model to each vertice
                for (NPoint current = shape.Next; current?.Next != null && current != shape/*Support non-closed shapes*/; current++ )
                {
                    // Apply the pattern between the two points
                    model.ApplyModel(current.Previous, current);
                }
            }
        }
    }
}
