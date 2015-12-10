package shape;

public class Triangle extends PlaneShape{
    private double A;
    private double B;
    private double C;

    public Triangle(Vertex2D a, Vertex2D b, Vertex2D c) {
        A = distanceBetweenVeteces(a, b);
    }

    public double getA() {
        return A;
    }

    public void setA(double a) {
        A = a;
    }

    public double getB() {
        return B;
    }

    public void setB(double b) {
        B = b;
    }

    public double getC() {
        return C;
    }

    public void setC(double c) {
        C = c;
    }

    @Override
    public double getPerimeter() {
        return this.getA() + this.getB() + this.getC();
    }

    @Override
    public double getArea() {
        double halfPerimeter = this.getPerimeter() / 2;
        return Math.sqrt((halfPerimeter - this.getA()) * (halfPerimeter - this.getB()) * (halfPerimeter - this.getC()));
    }

    @Override
    public String toString() {
        return String.format("Triangle{area=%.2f, perimeter=%.2f, A=%.2f, B=%.2f, C=%.2f, Vertices=%s}", this.getArea(), this.getPerimeter(), this.A, this.B, this.C, this.getVertexs());
    }

    private double distanceBetweenVeteces(Vertex2D a, Vertex2D b) {
        return Math.sqrt(Math.pow(b.getA() - a.getA(), 2) + Math.pow(a.getB() - a.getB(), 2));
    }
}
