public enum Sex {
    Male("M"), Famale("F");

    private String value;

    Sex(String s) {
        this.value = s;
    }

    public static Sex valuesOf(String s) {
        if(s.equals("M"))
            return Male;
        else if(s.equals("F"))
            return Famale;
        else
            return null;
    }

}
