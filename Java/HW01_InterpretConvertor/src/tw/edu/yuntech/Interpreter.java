package tw.edu.yuntech;

public class Interpreter {

    String s;
    int upper;
    int lower;

    public Interpreter(String s, int upper, int lower) {
        this.s = s;
        this.upper = upper;
        this.lower = lower;
    }

    public boolean include(String number) {
        int num = Integer.valueOf(number);
        return this.upper >= num ? this.lower <= num ? true : false : false;
    }

    public void printS() {
        System.out.println(s);
    }

    public void printG() {
        System.out.println(upper + " ~ " + lower);
    }
}
