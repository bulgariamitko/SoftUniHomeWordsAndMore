package extra;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class exam02 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        Pattern pattern = Pattern.compile("([A-Z][a-z]+)(.*?)([A-Z][a-z]*[A-Z])(.*?)([0-9]+)L");
        double liters = 0;

        while (!line.equals("OK KoftiShans")) {
            Matcher matcher = pattern.matcher(line);

            while (matcher.find()) {
                System.out.printf("%s brought %s liters of %s!%n", matcher.group(1), matcher.group(5), matcher.group(3).toLowerCase());
                liters += Double.parseDouble(matcher.group(5)) / 1000;
            }

            line = scanner.nextLine();
        }
        System.out.printf("%.3f softuni liters", liters);
    }
}
