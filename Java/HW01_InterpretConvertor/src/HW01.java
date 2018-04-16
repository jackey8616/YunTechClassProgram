package tw.edu.yuntech;

import java.util.Scanner;

public class HW01 {

    public static Interpreter[] inter = {
            new Interpreter("A", 100, 90),
            new Interpreter("B", 89, 80),
            new Interpreter("C", 79, 70),
            new Interpreter("D", 69, 60),
            new Interpreter("E", 59, 0)
    };

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        while(true){
            System.out.print("Input: ");
            String input = scanner.next();
            if(input.equals("-1")) {
                break;
            } else {
                boolean match = false;
                for(Interpreter each : inter) {
                    if(each.s.equals(input.toUpperCase())) {
                        each.printG();
                        match = true;
                    } else if (isNumber(input) && each.include(input)){
                        each.printS();
                        match = true;
                    }
                }
                if(!match)
                    System.out.println("No matching result.");
            }
        }
        scanner.close();
    }

    public static boolean isNumber(String s) {
        try {
            int num = Integer.valueOf(s);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

}
