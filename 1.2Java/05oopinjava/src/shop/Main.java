package shop;

import java.time.DateTimeException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Product> products = new ArrayList<>();
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.Adult, new Date(2015, 4, 12));
        try {
            Customer pecata = new Customer("Pecata", 27, 44.00);
            PurchaseManager.proccessPurchase(cigars, pecata);
            products.add(cigars);
        } catch (IllegalAccessError e) {
            System.out.println(e.getMessage());
        } catch (DateTimeException time) {
            System.out.println(time.getMessage());
        } catch (ArithmeticException m) {
            System.out.println(m.getMessage());
        }

        try {
            Customer gopeto = new Customer("Gepeto", 18, 0.44);
            PurchaseManager.proccessPurchase(cigars, gopeto);
        } catch (IllegalAccessError e) {
            System.out.println(e.getMessage());
        } catch (DateTimeException time) {
            System.out.println(time.getMessage());
        } catch (ArithmeticException m) {
            System.out.println(m.getMessage());
        }

        FoodProduct voda = new FoodProduct("voda", 1.00, 33, AgeRestriction.None, new Date(2020, 1, 12));
        Computer comp = new Computer("Samsung", 1000.0, 10, AgeRestriction.None);
        FoodProduct dunner = new FoodProduct("Duner", 1.50, 100, AgeRestriction.None, new Date(2015, 11, 15));
        FoodProduct banichka = new FoodProduct("Banichka", 1.2, 15, AgeRestriction.None, new Date(2015, 11, 15));
        FoodProduct whiskey = new FoodProduct("John Walker", 30.90, 1400, AgeRestriction.Adult, new Date(2100, 12, 12));
        products.add(voda);
        products.add(comp);
        products.add(dunner);
        products.add(banichka);
        products.add(cigars);
        products.add(whiskey);

        System.out.println("--------------");
        System.out.println("Food Product with soonest expiration date:");
        try {
            products.stream().filter(x -> x instanceof FoodProduct).map(x -> (FoodProduct)x).sorted((a,b) -> a.compareTo(b)).limit(1).forEach(System.out::println);
            System.out.println("----------------");
            System.out.println("Products with adult age restriction order by price:");
            products.stream().filter(x -> x.getRestriction() == AgeRestriction.Adult).sorted((a,b) -> a.compareTo(b, AgeRestriction.Adult)).forEach(System.out::println);
        } catch (IllegalArgumentException arg) {
            System.out.println(arg.getMessage());
        }
    }
}
