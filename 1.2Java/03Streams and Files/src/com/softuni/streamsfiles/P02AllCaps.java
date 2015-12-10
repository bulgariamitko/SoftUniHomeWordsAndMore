package com.softuni.streamsfiles;

import java.io.*;
import java.util.ArrayList;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P02AllCaps {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<>();
        String filePath = "res/lines2.txt";

        try (BufferedReader br = new BufferedReader(
                new FileReader(filePath)
        )) {
            String str;
            while ((str = br.readLine()) != null) {
                list.add(str.toUpperCase());
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (PrintWriter pw = new PrintWriter(
                new FileWriter(filePath)
        )) {
            for (String str : list) {
                pw.println(str);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
