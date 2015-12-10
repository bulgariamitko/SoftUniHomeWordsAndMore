package shop;

import java.time.Period;

public class Computer extends ElectricProducts {
    public Computer(String name, Double price, Integer quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction, Period.ofMonths(24));
    }

    private void reevalueatePrice() {
        if (this.getQuantity() > 1000) {
            this.setPrice(this.getPrice() - this.getPrice() * 0.9);
        }
    }
}
