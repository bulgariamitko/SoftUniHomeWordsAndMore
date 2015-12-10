package com.softuni.streamsfiles;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Dimitar on 27.10.2015 ã..
 */
public class Temp {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        Pattern pattern = Pattern.compile("([a-zA-Z\\s*]+)\\s@([a-zA-Z\\s*]+)\\s(\\d+)\\s(\\d+)");

        String line = input.nextLine();
        LinkedHashMap<String, LinkedHashMap<String, Integer>> venues = new LinkedHashMap<>();

        while (!line.equals("End")) {
            Matcher matcher = pattern.matcher(line);
            if (matcher.find()) {
                String singer = matcher.group(1);
                String venue = matcher.group(2);
                Integer ticketsPrice = Integer.parseInt(matcher.group(3));
                Integer ticketsCount = Integer.parseInt(matcher.group(4));

                if (!venues.containsKey(venue)) {
                    venues.put(venue, new LinkedHashMap<>());
                }
                if (!venues.get(venue).containsKey(singer)) {
                    venues.get(venue).put(singer, 0);
                }

                venues.get(venue).put(singer, venues.get(venue).get(singer) + (ticketsPrice * ticketsCount));
            }
            line = input.nextLine();
        }

        for (Map.Entry<String, LinkedHashMap<String, Integer>> entry : venues.entrySet()) {
            System.out.println(entry.getKey());

            entry.getValue().entrySet().stream().sorted((t1, t2) -> t2.getValue().compareTo(t1.getValue())).forEach(innerEntry -> {
                System.out.printf("#  %s -> %d\n", innerEntry.getKey(), innerEntry.getValue());
            });
        }
    }
}
