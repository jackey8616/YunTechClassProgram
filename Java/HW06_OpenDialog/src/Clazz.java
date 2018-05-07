public enum Clazz {
    A("��", 0), B("�A", 1), C("��", 2);

    private String value;
    private int weight;
    Clazz(String val, int wei) {
        this.value = val;
        this.weight = wei;
    }

    public static Clazz valuesOf(String s) {
        if(s.toUpperCase().equals("��"))
            return A;
        if(s.toUpperCase().equals("�A"))
            return B;
        if(s.toUpperCase().equals("��"))
            return C;
        return null;
    }

    public String value() {
        return this.value;
    }
    public int weight() { return this.weight; }
}