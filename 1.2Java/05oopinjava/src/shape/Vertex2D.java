package shape;

public class Vertex2D extends Vertex {
    public Vertex2D(double a, double b) {
        super(a, b, 0);
    }

    @Override
    public String toString() {
        return String.format("Vertex2D:{%.2f,%.2f}", this.getA(), this.getB());
    }
}
