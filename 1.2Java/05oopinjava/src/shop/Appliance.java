package shop;

import java.time.Period;

public class Appliance extends ElectricProducts {
    public Appliance(String name, Double price, Integer quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction, Period.ofMonths(6));
    }

    public void reevaluatePrice() {
        if (this.getQuantity() < 50) {
            this.setPrice(this.getPrice() - this.getPrice() * 1.05);
        }
    }

    @Override
    public String toString() {
        return String.format("Appliance {name= %s, price= %.2f, quantity= %d, restrictions= %s}", this.getName(), this.getPrice(), this.getQuantity(), this.getRestriction());
    }
}
