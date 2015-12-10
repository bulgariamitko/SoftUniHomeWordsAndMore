package extra;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class UserLogs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        Map<String, LinkedHashMap<String, Integer>> ips = new TreeMap<>();

        while (!line.equals("end")) {
            Pattern pattern = Pattern.compile("IP=([\\d|.|:|A-Za-z]+)\\s*message='([A-Za-z&.!]+)*'\\s*user=(\\w+)");
            Matcher matcher = pattern.matcher(line);
            if (matcher.find()) {
                String ip = matcher.group(1);
                String message = matcher.group(2);
                String user = matcher.group(3);

                if (!ips.containsKey(user)) {
                    ips.put(user, new LinkedHashMap<>());
                }
                if (!ips.get(user).containsKey(ip)) {
                    ips.get(user).put(ip, 0);
                }
                Integer currectValue = ips.get(user).get(ip);
                ips.get(user).put(ip, currectValue + 1);
            }

            line = scanner.nextLine();
        }

        StringBuilder outout = new StringBuilder();
        for(String username : ips.keySet()){
            outout.append(String.format("%s: %n", username));
            int currentIndex = 0;
            for(String userip : ips.get(username).keySet()){
                if (currentIndex < ips.get(username).size() -1) {
                    outout.append(String.format("%s => %d, ", userip, ips.get(username).get(userip)));
                } else {
                    outout.append(String.format("%s => %d.%n", userip, ips.get(username).get(userip)));
                }
                currentIndex++;
            }
        }

        System.out.println(outout.toString().trim());
    }
}