package shop;

public class Customer {
    private String name;
    private int age;
    private Double balance;

    public Customer(String name, int age, Double balance) {
        if (age < 0) {
            throw new ArithmeticException("Age cannot be negative!");
        }

        this.name = name;
        this.age = age;
        this.balance = balance;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        if (age < 0) {
            throw new ArithmeticException("Age cannot be negative!");
        }
        this.age = age;
    }

    public Double getBalance() {
        return balance;
    }

    public void setBalance(Double balance) {
        this.balance = balance;
    }
}
