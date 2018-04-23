import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Scanner;

public class RealMidterm {

    private static ArrayList<Student> students = new ArrayList<Student>();

    public static final void main(String[] args) {
        try {
            //FileReader fr = new FileReader("C:/Users/clode/Desktop/RealMidterm.txt");
            InputStreamReader fr = new InputStreamReader(new FileInputStream("./RealMidterm.txt"), "UTF-8");
            //Scanner s = new Scanner(fr);
            BufferedReader s = new BufferedReader(fr);
            int count = Integer.parseInt(s.readLine());
            //int count = s.nextInt();
            for (int i = 0; i < count; ++i) {
                //String str = s.nextLine();
                String str = s.readLine();

                String[] in = str.split(" ");
                Interpreter interpreter = null;
                try {
                    int score = Integer.parseInt(in[4]);
                    interpreter = Interpreter.valuesOf(score);
                } catch (Exception e) {
                    interpreter = Interpreter.valuesOf(in[4]);
                }
                students.add(new Student(Clazz.valuesOf(in[0]), in[1], in[2], in[3].toUpperCase().equals("女") ? Sex.Famale : Sex.Male, interpreter));

            }
            System.out.println("(3) Class and Score: \nClass\tID\tName\tSex\tScore");
            Collections.sort(students, new Comparator<Student>() {
                public int compare(Student o1, Student o2) {
                    if (o1.getClazz() == o2.getClazz())
                        return o1.getScore().compareTo(o2.getScore());
                    return o1.getClazz().weight() < o2.getClazz().weight() ? -1 : 1;
                }
            });
            for (Student student : students)
                System.out.println(student.toString());


        }catch (Exception e) {
            e.printStackTrace();
        }
    }

}
