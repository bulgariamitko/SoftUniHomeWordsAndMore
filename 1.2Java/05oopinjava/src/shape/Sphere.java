package shape;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(double radius, Vertex3D... vertexs) {
        super(vertexs);
        this.radius = radius;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public double getVolume() {
        return (4d / 3d) * Math.PI * Math.pow(this.radius, 3);
    }

    @Override
    public double getArea() {
        return 4d * Math.PI * Math.pow(this.radius, 2);
    }

    @Override
    public String toString() {
        return String.format("Sphere {Radius=%.2f, Volume=%.2f, Area=%.2f, Vertexes=%s}", this.radius, this.getVolume(), this.getArea(), this.getVertexs());
    }
}
