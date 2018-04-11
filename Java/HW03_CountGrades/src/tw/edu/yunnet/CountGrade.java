package tw.edu.yunnet;

import java.util.*;

public class CountGrade {

    public static final void main(String[] args) {
        System.out.println("Do not input less than 4 grades.");
        Scanner s = new Scanner(System.in);
        ArrayList<Student> grades = new ArrayList<Student>(Arrays.asList(stringArr2StudentArr(s.nextLine().split(" "))));
        s.close();

        System.out.println("Grades: ");
        for(Student ss : grades)
            System.out.println(ss.toString());
        Collections.sort(grades);
        System.out.println("Sorted: ");
        for(Student ss : grades)
            System.out.println(ss.toString());
        Student[] arr = grades.toArray(new Student[grades.size()]);
        for(int i = 0; i < arr.length; ++i) {
            if (i % (arr.length / 4) == 0)
                System.out.println("Interpreter " + (i / (arr.length / 4) + 1) + ": ");
            System.out.println(arr[i].toString());
        }
    }

    private static Student[] stringArr2StudentArr(String[] str) {
        Student[] result = new Student[str.length];
        for(int i = 0; i < str.length; ++i)
            result[i] = new Student(("M" + (i < 10 ? "0" : "") + (i + 1)) ,Integer.parseInt(str[i]));
        return result;
    }

}
