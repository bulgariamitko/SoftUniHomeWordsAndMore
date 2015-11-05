package com.softuni.streamsfiles;

import java.io.*;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P06CustomObject {
    public static void main(String[] args) {
        String path = "res/course.class";
        try (ObjectOutputStream output = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(path)))){
            Course course = new Course("Java Fundamentals", 300);
            output.writeObject(course);
        } catch (IOException e) {
            e.printStackTrace();
        }

        try(ObjectInputStream input = new ObjectInputStream(new BufferedInputStream(new FileInputStream(path)))) {
            Course newCourse = (Course) input.readObject();
            System.out.println(newCourse);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
