package shape;

import Interfaces.AreaMeasureable;
import Interfaces.VolumeMeasureable;

public abstract class SpaceShape extends Shape implements AreaMeasureable, VolumeMeasureable{
    public SpaceShape(Vertex3D... vertexs) {
        super.addVertices(vertexs);
    }

    public double getVolume() {
        return 0;
    }

    public double getArea() {
        return 0;
    }
}
