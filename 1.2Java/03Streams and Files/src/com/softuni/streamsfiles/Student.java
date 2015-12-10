package com.softuni.streamsfiles;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.LinkedHashMap;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class Student implements Serializable {
    private String fullName;
    private int age;
    private String town;
    private LinkedHashMap<String, ArrayList<Double>> grades = new LinkedHashMap<>();

    public Student(String fullName, int age, String town) {
        this.setFullName(fullName);
        this.setAge(age);
        this.setTown(town);
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getFullName() {
        return fullName;
    }


    public void setAge(int age) {
        this.age = age;
    }

    public int getAge() {
        return age;
    }

    public void setTown(String town) {
        this.town = town;
    }

    public String getTown() {
        return town;
    }

    public void setGrade(String course, double grade) {
        if (!this.grades.containsKey(course)) {
            this.grades.put(course, new ArrayList<>());
        }
        this.grades.get(course).add(grade);
    }

    public ArrayList<Double> getGrades(String course) {
        return this.grades.get(course);
    }

    public LinkedHashMap<String, ArrayList<Double>> getGrades() {
        return this.grades;
    }
}
