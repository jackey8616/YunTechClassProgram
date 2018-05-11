public class Student {

    private String id;
    private String name;
    private Clazz clazz;
    private Interpreter score;
    private Sex sex;

    public Student(Clazz clazz, String id, String name, Sex sex, Interpreter score) {
        this.clazz = clazz;
        this.name = name;
        this.id = id;
        this.sex = sex;
        this.score = score;
    }

    public String getId() { return this.id; }
    public Clazz getClazz() { return this.clazz; }
    public Interpreter getScore() { return this.score; }
    public Sex getSex() { return this.sex; }

    @Override
    public String toString() {
        return this.clazz.value() + "\t" + this.id + "\t" + this.name + "\t" + (this.sex.values().equals("F") ? "女" : "男") + "\t" + this.score;
    }

}
