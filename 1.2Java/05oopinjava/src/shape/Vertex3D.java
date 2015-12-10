package shape;

public class Vertex3D extends Vertex {
    public Vertex3D(double a, double b, double c) {
        super(a, b, 0);
    }

    @Override
    public String toString() {
        return String.format("Vertex3D: {%.2f,%.2f,%.2f}", this.getA(), this.getB(), this.getC());
    }
}
