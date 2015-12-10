package extra;

import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class exam04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        Pattern pattern = Pattern.compile("\\{\"Project\":\\s*\\[\"(\\w+)\"],\\s*\"Type\":\\s*\\[\"(Critical|Warning)\"],\\s*\"Message\":\\s*\\[\"([a-zA-Z0-9 ]+)\"]}");
        TreeMap<String, TreeMap<String, Integer>> projects = new TreeMap<>();


        while (!line.equals("END")) {
            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                String projectName = matcher.group(1);
                String error = matcher.group(2);
                String msg = matcher.group(3);

                if (!projects.containsKey(projectName)) {
                    projects.put(projectName, new TreeMap<>());
                }
                if (!projects.get(projectName).containsKey(error)) {
                    projects.get(projectName).put(error, 0);
                } else {
                    int num = projects.get(projectName).get(error);
                    projects.get(projectName).put(error, num + 1);
                }
            }
            line = scanner.nextLine();
        }

        for (String error : projects.keySet()) {
            System.out.printf("%s: %n", error);

            System.out.printf("Total Errors: %d%n", projects.get(error).size());

            for (String message : projects.get(error).keySet()){
                if (message.equals("Critical")) {
                    System.out.printf("%s: %d%n", message, projects.get("Critical").get(message));
                }
                //System.out.println(message.equals("Critical"));
            }
        }
    }
}
