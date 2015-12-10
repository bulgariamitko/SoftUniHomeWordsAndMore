package com.softuni.streamsfiles;

import java.io.*;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P04CopyFile {
    public static void main(String[] args) {
        String original = "res/image.jpg";
        String duplicate = "res/my-copied-picture.jpg";
        try {
            BufferedInputStream inputStream = new BufferedInputStream(new FileInputStream(original));
            BufferedOutputStream outputStream = new BufferedOutputStream(new FileOutputStream(duplicate));
            Integer i;
            while ((i = inputStream.read()) != -1) {
                outputStream.write(i);
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
