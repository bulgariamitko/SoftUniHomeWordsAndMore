package shape;

import java.util.ArrayList;
import java.util.List;

public abstract class Shape {
    private List<Vertex> vertexs;

    public Shape() {
        this.vertexs = new ArrayList<Vertex>();
    }

    public List<Vertex> getVertexs() {
        return vertexs;
    }

    public void addVertices(Vertex... vertexes) {
        for (Vertex vertex : vertexes) {
            this.vertexs.add(vertex);
        }
    }
}
