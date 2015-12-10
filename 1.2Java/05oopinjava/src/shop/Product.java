package shop;

import Interfaces.Buyable;

public abstract class Product implements Buyable{
    private String name;
    private Double price;
    private Integer quantity;
    private Integer age;
    private AgeRestriction restriction;

    public Product(String name, Double price, Integer quantity, AgeRestriction restriction) throws ArithmeticException {
        if (price < 0) {
            throw new ArithmeticException("Price cannot be negative!");
        }
        if (quantity < 0) {
            throw new ArithmeticException("Quantity cannot be negative!");
        }
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.restriction = restriction;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) throws ArithmeticException {
        if (price < 0){
            throw new ArithmeticException("Price cannot be negative!");
        }
        this.price = price;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) throws ArithmeticException {
        if (quantity < 0){
            throw new ArithmeticException("Quantity cannot be negative!");
        }
        this.quantity = quantity;
    }

    public AgeRestriction getRestriction() {
        return restriction;
    }

    public void setRestriction(AgeRestriction restriction) {
        this.restriction = restriction;
    }

    public int compareTo(Product product, AgeRestriction restriction) {
        return 0;
    }

    @Override
    public String toString() {
        return String.format("Product{name= %s, price= %d, quantity= %d, restrictions= %s}", this.name, this.price, this.quantity, this.restriction);
    }
}
