package com.softuni.streamsfiles;

import java.io.Serializable;

public class Course implements Serializable {
    private String name;
    private int numberOfStudents;

    public Course(String name, int numberOfStudents) {
        this.setName(name);
        this.setNumberOfStudents(numberOfStudents);
    }

    public Course () {
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setNumberOfStudents(int numberOfStudents) {
        this.numberOfStudents = numberOfStudents;
    }

    public int getNumberOfStudents() {
        return numberOfStudents;
    }
}
