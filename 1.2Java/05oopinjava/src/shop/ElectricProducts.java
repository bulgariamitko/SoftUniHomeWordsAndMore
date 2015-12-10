package shop;

import java.time.Period;

public class ElectricProducts extends Product {
    private Period guaranteePeriod;

    public ElectricProducts(String name, Double price, Integer quantity, AgeRestriction restriction, Period guaranteePeriod) {
        super(name, price, quantity, restriction);
        this.guaranteePeriod = guaranteePeriod;
    }

    public Period getGuaranteePeriod() {
        return guaranteePeriod;
    }

    public void setGuaranteePeriod(Period guaranteePeriod) {
        this.guaranteePeriod = guaranteePeriod;
    }

    public int compareTo(Object o) {
        Product product = (Product)o;
        if (product.getPrice() > this.getPrice()) {
            return  -1;
        } else if (product.getPrice() < this.getPrice()) {
            return 1;
        } else {
            return 0;
        }
    }

    public int compareTo(Product product, AgeRestriction restriction) {
        if (product.getPrice() > this.getPrice()){
            return -1;
        } else if (product.getPrice() < this.getPrice()) {
            return 1;
        } else {
            return 0;
        }
    }
}
