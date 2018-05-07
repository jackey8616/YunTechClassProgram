public enum Clazz {
    A("甲", 0), B("乙", 1), C("丙", 2);

    private String value;
    private int weight;
    Clazz(String val, int wei) {
        this.value = val;
        this.weight = wei;
    }

    public static Clazz valuesOf(String s) {
        if(s.toUpperCase().equals("甲"))
            return A;
        if(s.toUpperCase().equals("乙"))
            return B;
        if(s.toUpperCase().equals("丙"))
            return C;
        return null;
    }

    public String value() {
        return this.value;
    }
    public int weight() { return this.weight; }
}