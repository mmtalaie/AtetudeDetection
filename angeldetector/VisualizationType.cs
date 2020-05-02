using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angeldetector
{
    enum VisualizationType
    {
        // Hightlight glyph with border only
        BorderOnly,
        // Hightlight glyph with border and put its name in the center
        Name,
        // Substitue glyph with its image
        Image,
        // Show 3D model over the glyph
        Model
    }
}
