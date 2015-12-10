package extra;

import java.util.Scanner;

public class GandalfsStash {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int gandalfMood = scanner.nextInt();
        scanner.nextLine();
        String[] text = scanner.nextLine().split("[\\W|_]+");

        for (String word : text) {
            gandalfMood += CalMood(word);
        }

        System.out.println(gandalfMood);
        System.out.println(Mood(gandalfMood));
    }

    public static int CalMood(String word) {
        word = word.toLowerCase();
        if (word.equals("cram")) {
            return 2;
        } else if (word.equals("lembas")) {
            return 3;
        } else if (word.equals("apple")) {
            return 1;
        } else if (word.equals("melon")) {
            return 1;
        } else if (word.equals("honeycake")) {
            return 5;
        } else if (word.equals("mushrooms")) {
            return -10;
        } else {
            return -1;
        }
    }

    public static String Mood(int mood) {
        if (mood < -5) {
            return "Angry";
        } else if (mood >= -5 && mood < -1) {
            return "Sad";
        } else if (mood >= 0 && mood <= 15) {
            return "Happy";
        } else {
            return "Special JavaScript mood";
        }
    }
}
