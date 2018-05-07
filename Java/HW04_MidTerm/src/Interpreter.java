public enum Interpreter {
    A("A"), B("B"), C("C"), D("D"), E("E");

    String s;

    public static Interpreter valuesOf(int i) {
        if(i <= 100 && i >= 90)
            return A;
        else if(i <= 89 && i >= 80)
            return B;
        else if(i <= 79 && i >= 70)
            return C;
        else if(i <= 69 && i >= 60)
            return D;
        else if(i <= 59)
            return E;
        else
            return null;
    }

    public static Interpreter valuesOf(String s) {
        if(s.equals("A"))
            return A;
        else if(s.equals("B"))
            return B;
        else if(s.equals("C"))
            return C;
        else if(s.equals("D"))
            return D;
        else if(s.equals("E"))
            return E;
        else
            return null;
    }

    Interpreter(String s) {
        this.s = s;
    }

    public void printS() {
        System.out.println(s);
    }
}