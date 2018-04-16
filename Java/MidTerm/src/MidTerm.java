import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Scanner;

public class MidTerm {

    public static void main(String[] args) {

        ArrayList<Student> students = new ArrayList<Student>();
        Scanner s = new Scanner(System.in);
        for(int i = 0; i < 15; ++i) {
            String[] in = s.nextLine().split(" ");
            Interpreter interpreter = null;
            try {
                int score = Integer.parseInt(in[2]);
                interpreter = Interpreter.valuesOf(score);
            } catch(Exception e) {
                interpreter = Interpreter.valuesOf(in[2]);
            }
            students.add(new Student(in[0], Clazz.valueOf(Integer.parseInt(in[1])), interpreter, in[3].toUpperCase().equals("F") ? Sex.Famale : Sex.Male));
        }
        s.close();

        System.out.println("(1) Class: \nID\tClass\tScore\tSex");
        Collections.sort(students, new Comparator<Student>(){
            public int compare(Student o1, Student o2){
                if(o1.getClazz() == o2.getClazz())
                    return 0;
                return o1.getClazz().value() < o2.getClazz().value() ? -1 : 1;
            }
        });
        for(Student student : students)
            System.out.println(student.toString());

        System.out.println("(2) Score: \nID\tClass\tScore\tSex");
        Collections.sort(students, new Comparator<Student>(){
            public int compare(Student o1, Student o2){
                if(o1.getScore() == o2.getScore())
                    return 0;
                return o1.getScore().s.charAt(0) < o2.getScore().s.charAt(0) ? -1 : 1;
            }
        });
        for(Student student : students)
            System.out.println(student.toString());

        System.out.println("(3) Class and Score: \nID\tClass\tScore\tSex");
        Collections.sort(students, new Comparator<Student>(){
            public int compare(Student o1, Student o2){
                if(o1.getClazz() == o2.getClazz())
                    return o1.getScore().compareTo(o2.getScore());
                return o1.getClazz().value() < o2.getClazz().value() ? -1 : 1;
            }
        });
        for(Student student : students)
            System.out.println(student.toString());

    }


}