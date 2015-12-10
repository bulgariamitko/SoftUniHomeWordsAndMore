package shape;

public class Rectangle extends PlaneShape {
    private Vertex2D vertex;
    private double width;
    private double height;

    public Rectangle(Vertex2D vertex, double width, double height) {
        super(vertex);
        this.width = width;
        this.height = height;
    }

    public Vertex2D getVertex() {
        return vertex;
    }

    public void setVertex(Vertex2D vertex) {
        this.vertex = vertex;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    @Override
    public double getPerimeter() {
        return 2 * (this.width + this.height);
    }

    @Override
    public double getArea() {
        return this.height * this.width;
    }

    @Override
    public String toString() {
        return String.format("Rectangle {area=%.2f, perimeter=%.2f, Height=%.2f, Width=%.2f, Vertices=%s}", this.getArea(), this.getPerimeter(), this.height, this.width, this.getVertexs());
    }
}
