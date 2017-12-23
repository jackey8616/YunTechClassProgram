package tw.edu.yuntech;

import java.util.LinkedList;

public class Point {

    public String pointName;
    public LinkedList<Point> childPoint = new LinkedList<Point>();
    public Point predecessor = null;
    public int discoverTime = 0, finishTime = 0;

    public Point(String name) {
        this.pointName = name;
        this.discoverTime = 0;
        this.finishTime = 0;
    }

    public void insertPath(Point ... points) {
        for(Point p: points)
            childPoint.add(p);
    }

    public String toString() {
        return this.pointName;
    }

    public Point depthNext() {
        for(Point p : childPoint) {
            if(p.discoverTime == 0 && p.finishTime == 0) {
                childPoint.remove(p);
                return p;
            }
        }
        return null;
    }

}
