package shop;

import java.time.DateTimeException;
import java.util.Date;

public class PurchaseManager {
    public static void proccessPurchase(Product product, Customer customer) throws IllegalAccessError, DateTimeException, ArithmeticException {
        if (product.getRestriction() == AgeRestriction.Adult && customer.getAge() < 18) {
            throw new IllegalAccessError("You are too young to buy this product!");
        }
        if (product.getRestriction() == AgeRestriction.Teenager && customer.getAge() < 13) {
            throw  new IllegalAccessError("You are too young to buy this product!");
        }
        if (product.getQuantity() < 1) {
            throw new ArithmeticException("This product is out of stock!");
        }
        if (product instanceof FoodProduct) {
            FoodProduct food = (FoodProduct)product;
            if (food.getExpirationDate().after(new Date())) {
                throw new DateTimeException("This product is expired!");
            }
        }
        double price = product.getPrice();

        if (customer.getBalance() - price >= 0) {
            customer.setBalance(customer.getBalance() - price);
            product.setQuantity(product.getQuantity() - 1);
        } else {
            throw  new ArithmeticException("You do not have enough money to buy this product!");
        }
    }
}
