package com.softuni.streamsfiles;

import java.io.*;
import java.util.ArrayList;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P07ZipArchive {
    public static void main(String[] args) {
        ArrayList<String> filesForArchive = new ArrayList<String>() {{
            add("res/words.txt");
            add("res/count-chars.txt");
            add("res/lines.txt");
        }};

        try (ZipOutputStream zos = new ZipOutputStream(
                new FileOutputStream("res/files.zip")
        )) {
            for (String filename : filesForArchive) {
                try (BufferedInputStream bis = new BufferedInputStream(
                        new FileInputStream(filename)
                )) {
                    int bytes;

                    zos.putNextEntry(new ZipEntry(filename));

                    while ((bytes = bis.read()) != -1) {
                        zos.write(bytes);
                    }

                    zos.closeEntry();
                }
            }

        } catch (FileNotFoundException fnfExeption) {
            fnfExeption.printStackTrace();
        } catch (IOException ioExeption) {
            ioExeption.printStackTrace();
        }
    }
}
