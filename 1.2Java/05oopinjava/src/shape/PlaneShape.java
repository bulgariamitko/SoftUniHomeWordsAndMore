package shape;

import Interfaces.AreaMeasureable;
import Interfaces.PerimeterMeasurable;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasureable {
    private double perimeter;
    public PlaneShape(Vertex2D... vertexs) {
        super.addVertices(vertexs);
        this.perimeter = this.getPerimeter();
    }

    @Override
    public double getPerimeter() {
        return 0;
    }

    public double getArea() {
        return 0;
    }

    public int compareTo(Object obj) {
        PlaneShape plane = (PlaneShape)obj;
        if(this.getPerimeter()>plane.getPerimeter()) {
            return 1;
        } else if(this.getPerimeter()<plane.getPerimeter()) {
            return -1;
        }else {
            return 0;
        }
    }
}
