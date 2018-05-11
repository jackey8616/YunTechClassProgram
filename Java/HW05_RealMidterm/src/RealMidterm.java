import java.io.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class RealMidterm {

    private static ArrayList<Student> students = new ArrayList<Student>();

    public static final void main(String[] args) {
        try {
            InputStreamReader isr = new InputStreamReader(new FileInputStream("./RealMidterm.txt"), "UTF-8");
            OutputStreamWriter osw = new OutputStreamWriter(new FileOutputStream("./RealMidTerm.out.txt"), "UTF-8");
            BufferedReader br = new BufferedReader(isr);
            BufferedWriter bw = new BufferedWriter(osw);

            String output = "";
            int count = Integer.parseInt(br.readLine());

            for (int i = 0; i < count; ++i) {
                String[] in = br.readLine().split(" ");
                Clazz clazz = Clazz.valuesOf(in[0]);
                Sex sex = in[3].equals("女") ? Sex.Famale : in[3].equals("男") ? Sex.Male : null;
                Interpreter interpreter = null;
                try {
                    int score = Integer.parseInt(in[4]);
                    interpreter = Interpreter.valuesOf(score);
                } catch (Exception e) {
                    interpreter = Interpreter.valuesOf(in[4]);
                }
                if(clazz == null || sex == null || interpreter == null) {
                    System.out.println("Error Value you idot!" + clazz + "/" + in[1] + "/" + in[2] + "/" + sex + "/" + interpreter);
                } else {
                    students.add(new Student(clazz, in[1], in[2], sex, interpreter));
                }
            }
            System.out.println("Class and Score: \nClass\tID\tName\tSex\tScore");
            Collections.sort(students, new Comparator<Student>() {
                public int compare(Student o1, Student o2) {
                    if (o1.getClazz() == o2.getClazz())
                        return o1.getScore().compareTo(o2.getScore());
                    return o1.getClazz().weight() < o2.getClazz().weight() ? -1 : 1;
                }
            });
            for (Student student : students)
                output += student.toString() + "\r\n";
            System.out.println(output);

            br.close();
            isr.close();

            bw.write(output);
            bw.close();
            osw.close();

        }catch (Exception e) {
            e.printStackTrace();
        }
    }

}
