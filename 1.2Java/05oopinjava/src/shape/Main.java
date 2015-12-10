package shape;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        Vertex2D a = new Vertex2D(11, 3);
        Vertex2D b = new Vertex2D(-4, -4);
        Vertex2D c = new Vertex2D(30, 30);
        Vertex3D point1 = new Vertex3D(-3, -3, -3);
        Vertex3D point2 = new Vertex3D(10, 9, 8);
        Vertex3D point3 = new Vertex3D(0, 1, 0);

        double height = 22;
        double width = 10;
        double radius = 10;
        double dept = 25;
        Triangle triangle = new Triangle(a, b, c);
        Rectangle rectangle = new Rectangle(b, height, width);
        Circle circle = new Circle(c, 5);
        Sphere sphere = new Sphere(radius, point1);

        Cuboid cuboid = new Cuboid(height, width, dept, point2);
        SquarePyramid squarePyramid = new SquarePyramid(point3, width, height);
        Shape[] shapes = new Shape[6];
        shapes[0] = triangle;
        shapes[1] = rectangle;
        shapes[2] = circle;
        shapes[3] = sphere;
        shapes[4] = cuboid;
        shapes[5] = squarePyramid;

        for (int i = 0; i < shapes.length; i++) {
            System.out.println(shapes[i]);
        }

        List<Shape> list = new ArrayList<>();
        Collections.addAll(list, shapes);
        System.out.println("------");
        System.out.println("Shapes with volumes over 40");
        list.stream().filter(x -> x instanceof SpaceShape).map(x -> (SpaceShape)x).filter(x -> x.getVolume() > 40).forEach(System.out::println);
        System.out.println("------");
        System.out.println("Plane Shapes ordered by perimeter");
        list.stream().filter(x -> x instanceof PlaneShape).map(x -> (PlaneShape)x).sorted((x1, x2) -> x1.compareTo(x2)).forEach(System.out::println);
    }
}
