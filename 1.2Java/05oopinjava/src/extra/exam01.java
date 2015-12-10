package extra;

import java.util.Scanner;

public class exam01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numOfPeople = Integer.parseInt(scanner.nextLine());
        int loop = Integer.parseInt(scanner.nextLine());
        int allBeds = 0;
        int allFood = 0;
        for (int i = 0; i < loop; i++) {
            String[] varibles = scanner.nextLine().split("\\s+");
            String tentOrRoom = varibles[0].toLowerCase();
            Integer numOfTentsOrRooms = Integer.parseInt(varibles[1]);
            String classIt = varibles[2].toLowerCase();

            if (tentOrRoom.equals("tents")) {
                if (classIt.equals("firstclass")) {
                    allBeds += numOfTentsOrRooms * 3;
                } else if (classIt.equals("normal")) {
                    allBeds += numOfTentsOrRooms * 2;
                }
            }

            if (tentOrRoom.equals("rooms")) {
                if (classIt.equals("single")) {
                    allBeds += numOfTentsOrRooms * 1;
                } else if (classIt.equals("double")) {
                    allBeds += numOfTentsOrRooms * 2;
                } else if (classIt.equals("triple")) {
                    allBeds += numOfTentsOrRooms * 3;
                }
            }

            if (tentOrRoom.equals("food")) {
                if (classIt.equals("musaka")) {
                    allFood += numOfTentsOrRooms * 2;
                }
            }
        }
        int bedsLeft = allBeds - numOfPeople;
        int foodLeft = allFood - numOfPeople;

        if (foodLeft < 0) {
            System.out.printf("Some people are freezing cold. Beds needed: %d%n", Math.abs(bedsLeft));
        } else {
            System.out.printf("Everyone is happy and sleeping well. Beds left: %d%n", bedsLeft);
        }
        if (bedsLeft < 0) {
            System.out.printf("People are starving. Meals needed: %d%n", Math.abs(foodLeft));
        } else {
            System.out.printf("Nobody left hungry. Meals left: %d%n", foodLeft);
        }
    }
}