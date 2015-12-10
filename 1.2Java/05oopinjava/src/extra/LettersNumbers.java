package extra;

import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LettersNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] text = scanner.nextLine().split("[\\s]+");
        double sum = 0;
        double sum2 = 0;
        List<Double> numbers = new LinkedList<>();

        for (String word : text) {
            // Create a Pattern object
            Pattern r = Pattern.compile("([a-zA-Z])([\\d]+)([a-zA-Z])");

            // Now create matcher object.
            Matcher m = r.matcher(word);
            if (m.find()) {
                char firstLetter = m.group(1).charAt(0);
                Integer num = Integer.parseInt(m.group(2));
                char lastLetter = m.group(3).charAt(0);
                double firstInt = Character.toLowerCase(firstLetter) - 'a' + 1;
                double lastInt = Character.toLowerCase(lastLetter) - 'a' + 1;

                if (Character.isUpperCase(firstLetter)) {
                    sum += num / firstInt;
                } else {
                    sum += num * firstInt;
                }
                if (Character.isUpperCase(lastLetter)) {
                    sum -= lastInt;
                } else {
                    sum += lastInt;
                }
                sum2 += sum;
                sum = 0;
            }
        }
        System.out.printf("%.2f%n", sum2);
    }
}
