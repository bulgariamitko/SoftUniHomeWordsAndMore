package com.softuni.streamsfiles;

import java.io.*;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P08CSVDatabase {

    private static TreeMap<Integer, Student> students = new TreeMap<>();

    public static void main(String[] args) {
        String studentPath = "res/students.txt";
        String gradesPath = "res/grades.txt";
        Scanner scanner = new Scanner(System.in);
        try (BufferedReader studentReader = new BufferedReader(new FileReader(studentPath));
        BufferedReader gradesReader = new BufferedReader(new FileReader(gradesPath))) {
            String input;

            while ((input = studentReader.readLine()) != null) {
                String[] studentData = input.split(",");
                Integer id = Integer.parseInt(studentData[0]);
                String fullName = studentData[1] + " " + studentData[2];
                Integer age = Integer.parseInt(studentData[3]);
                String town = studentData[4];

                insertStudent(id, fullName, age, town);
            }

            while ((input = gradesReader.readLine()) != null) {
                String[] gradesData = input.split(",");
                Integer id = Integer.parseInt(gradesData[0]);

                for (int i = 1; i < gradesData.length; i++) {
                    String[] disciplineData = gradesData[i].split(" ");
                    String discipline = disciplineData[0];

                    for (int j = 1; j < disciplineData.length; j++) {
                        Double grade = Double.parseDouble(disciplineData[j]);
                        insertGradeById(id, discipline, grade);
                    }
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        while (true) {
            String command = scanner.nextLine();
            if (command.equals("End")) {
                break;
            }

            String[] commandArguments = command.split(" ");
            switch (commandArguments[0]) {
                case "Search-by-full-name":
                    String fullName = commandArguments[1] + " " + commandArguments[2];
                    searchByFullName(fullName);
                    break;
                case "Search-by-id":
                    Integer searchId = Integer.parseInt(commandArguments[1]);
                    searchByID(searchId);
                    break;
                case "Delete-by-id":
                    Integer delId = Integer.parseInt(commandArguments[1]);
                    deleteByID(delId);
                    break;
                case "Update-by-id":
                    Integer updateId = Integer.parseInt(commandArguments[1]);
                    updateById(updateId);
                    break;
                case "Insert-student":
                    String insertFullName = commandArguments[1] + " " + commandArguments[2];
                    Integer age = Integer.parseInt(commandArguments[3]);
                    String town = commandArguments[4];
                    for (int i = 5; i < commandArguments.length; i++) {
                        town += " " + commandArguments[i];
                    }
                    insertStudent(insertFullName, age, town);
                    break;
                case "Insert-grade-by-id":
                    Integer insertId = Integer.parseInt(commandArguments[1]);
                    String course = commandArguments[2];
                    Double grade = Double.parseDouble(commandArguments[3]);
                    insertGradeById(insertId, course, grade);
                    break;
            }
        }

        try(PrintWriter studentWriter = new PrintWriter(new FileWriter(studentPath));
        PrintWriter gradesWriter = new PrintWriter(new FileWriter(gradesPath))) {
            for (Integer id : students.keySet()) {
                Student student = students.get(id);
                String firstName = student.getFullName().split(" ")[0];
                String lastName = student.getFullName().split(" ")[1];
                studentWriter.format("%d,%s,%s,%d,%s%n", id, firstName, lastName, student.getAge(), student.getTown());
                gradesWriter.printf("%d", id);

                LinkedHashMap<String, ArrayList<Double>> grades = student.getGrades();
                for (String course : grades.keySet()) {
                    gradesWriter.printf(",%s", course);
                    for (int i = 0; i < grades.get(course).size(); i++) {
                        gradesWriter.printf(" %.2f", grades.get(course).get(i));
                    }
                }
                gradesWriter.format("%n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void insertGradeById(Integer id, String course, Double grade) {
        if (!students.containsKey(id)) {
            printNotFoundError();
        } else {
            students.get(id).setGrade(course, grade);
        }
    }

    private static void insertStudent(Integer id, String fullName, Integer age, String town) {
        students.put(id, new Student(fullName, age, town));
    }

    private static void insertStudent(String fullName, Integer age, String town) {
        Integer greatestId = students.lastKey();
        students.put(greatestId + 1, new Student(fullName, age, town));
    }

    private static void updateById(Integer id) {
        if (!students.containsKey(id)) {
            printNotFoundError();
        }
    }

    private static void deleteByID(Integer id) {
        if (!students.containsKey(id)) {
            printNotFoundError();
        } else {
            students.remove(id);
        }
    }

    private static void searchByID(Integer id) {
        if (!students.containsKey(id)) {
            printNotFoundError();
        } else {
            printStudent(id);
        }
    }

    private static void searchByFullName(String fullName) {
        boolean isFound = false;
        for (Integer id : students.keySet()) {
            if (students.get(id).getFullName().equals(fullName)) {
                isFound = true;
                printStudent(id);
                return;
            }
        }
    }

    private static void printStudent(Integer id) {
        Student student = students.get(id);
        String fullName = student.getFullName();
        Integer age = student.getAge();
        String town = student.getTown();

        System.out.println(fullName + " (age: " + age + " , town: " + town + ")");

        LinkedHashMap<String, ArrayList<Double>> grades = student.getGrades();
        for (String course : grades.keySet()) {
            System.out.println("# " + course + ":");
            for (int i = 0; i < grades.get(course).size() - 1; i++) {
                System.out.printf("%.2f", grades.get(course).get(i));
                System.out.printf("%.2f%n", grades.get(course).get(grades.get(course).size() - 1));
            }
        }
    }

    private static void printNotFoundError() {
        System.out.println("Student does not exist");
    }
}
