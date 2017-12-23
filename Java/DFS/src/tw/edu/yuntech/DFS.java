package tw.edu.yuntech;

import java.util.HashMap;

public class DFS {

    private static int time = 0;
    private static HashMap<String, Point> tree = new HashMap<>();

    private static void initPoints() {
        for(Point p : new Point[] {
                new Point("A"),  new Point("B"),  new Point("C"),  new Point("D"),  new Point("E"),
                new Point("F"),  new Point("G"),  new Point("H")}) {
            tree.put(p.toString(), p);
        }
        tree.get("A").insertPath(new Point[] { tree.get("B"), tree.get("C"), tree.get("D") });
        tree.get("B").insertPath(new Point[] { tree.get("A"), tree.get("E") });
        tree.get("C").insertPath(new Point[] { tree.get("A"), tree.get("H") });
        tree.get("D").insertPath(new Point[] { tree.get("A"), tree.get("F"), tree.get("G") });
        tree.get("E").insertPath(new Point[] { tree.get("B"), tree.get("H") });
        tree.get("F").insertPath(new Point[] { tree.get("D"), tree.get("H") });
        tree.get("G").insertPath(new Point[] { tree.get("D"), tree.get("H") });
        tree.get("H").insertPath(new Point[] { tree.get("E"), tree.get("C"), tree.get("F"), tree.get("G")});
    }

    public static void printPoints() {
        String print1 = (tree.get("A").toString());
        boolean keepPrint = true;
        int i = 1;
        while(keepPrint && i++ > 0) {
            keepPrint = false;
            for(Point p : tree.values())
                if(p.discoverTime == i || p.finishTime == i) {
                    print1 += (" -> " + p.toString());
                    keepPrint = true;
                }
        }
        System.out.println(print1);
    }

    public static void main(String[] args) {
        initPoints();
        DFS(tree.get("A"));
        printPoints();
    }

    public static void DFS(Point start) {
        Point next = start.depthNext();
        if(next != null) {
            start.discoverTime = ++time;
            next.predecessor = start;
            DFS(next);
            start.finishTime = ++time;
        } else {
            Point previousNext = start.predecessor.depthNext();
            if (previousNext != null) {
                start.discoverTime = ++time;
                start.finishTime = ++time;
                previousNext.predecessor = start.predecessor;
                DFS(previousNext);
            } else {
                start.discoverTime = ++time;
                start.finishTime = ++time;
            }
        }
    }

}
