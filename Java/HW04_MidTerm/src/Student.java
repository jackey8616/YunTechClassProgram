public class Student {

    private String id;
    private Clazz clazz;
    private Interpreter score;
    private Sex sex;

    public Student(String id, Clazz clazz, Interpreter score, Sex sex) {
        this.id = id;
        this.clazz = clazz;
        this.score = score;
        this.sex = sex;
    }

    public String getId() { return this.id; }
    public Clazz getClazz() { return this.clazz; }
    public Interpreter getScore() { return this.score; }
    public Sex getSex() { return this.sex; }

    @Override
    public String toString() {
        return this.id + "\t\t" + this.clazz + "\t" + this.score + "\t" + this.sex;
    }

}
