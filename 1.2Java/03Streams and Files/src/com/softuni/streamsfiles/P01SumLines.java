package com.softuni.streamsfiles;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */

public class P01SumLines {
    public static void main(String[] args) {
        try {
            BufferedReader br = new BufferedReader(new FileReader("res/lines.txt"));
            String line;
            while ((line = br.readLine()) != null) {
                int sum = 0;
                for (int i = 0; i < line.length(); i++) {
                    sum += line.charAt(i);
                }
                System.out.println(sum);
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
