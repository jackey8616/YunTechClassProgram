package tw.edu.yunnet;

public class Student implements Comparable {

    private String name;
    private int score;

    public Student(String name, int score) {
        this.name = name;
        this.score = score;
    }

    @Override
    public String toString() {
        return "Name: " + this.name + ", Grade: " + this.score;
    }

    @Override
    public int compareTo(Object o) {
        return ((Student) o).score - this.score;
    }
}
