public enum Clazz {
    A(0), B(1), C(2);

    private int value;
    Clazz(int val) {
        this.value = val;
    }

    public static Clazz valueOf(int i) {
        switch(i) {
            case 0:
                return A;
            case 1:
                return B;
            case 2:
                return C;
            default:
                return null;
        }
    }

    public int value() {
        return this.value;
    }
}