package com.softuni.streamsfiles;

import java.io.*;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P03CountChars {
    public static void main(String[] args) {
        String path = "res/words.txt";
        String newFilePath = "res/count-chars.txt";
        Integer vowels = 0;
        Integer consonants = 0;
        Integer punctuation = 0;
        try {
            BufferedReader br = new BufferedReader(new FileReader(path));
            String line;
            while ((line = br.readLine()) != null) {
                for (int i = 0; i < line.length(); i++) {
                    if (line.charAt(i) == 'a' || line.charAt(i) == 'e' || line.charAt(i) == 'i' || line.charAt(i) == 'o' || line.charAt(i) == 'u') {
                        vowels++;
                    } else if (line.charAt(i) == '!' || line.charAt(i) == ',' || line.charAt(i) == '.' || line.charAt(i) == '?') {
                        punctuation++;
                    } else if (line.charAt(i) == ' ') {
                        continue;
                    } else {
                        consonants++;
                    }
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (PrintWriter pw = new PrintWriter(
                new FileWriter(newFilePath)
        )){
            pw.println("Vowels: " + vowels);
            pw.println("Consonants: " + consonants);
            pw.println("Punctuation: " + punctuation);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
