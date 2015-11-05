package com.softuni.streamsfiles;

import java.io.*;
import java.util.ArrayList;

/**
 * To run this Class you need to press Ctrl+Alt+F10!!!
 */
public class P05ArrayList {
    public static void main(String[] args) {
        String path = "res/doubles.list";
        ArrayList<Double> list = new ArrayList<Double>() {{
            add(0.55);
            add(5.55);
            add(7.77);
            add(8.88);
            add(4.78);
            add(121.121);
        }};

        try (ObjectOutputStream outputStream = new ObjectOutputStream(new FileOutputStream(path))) {
            outputStream.writeObject(list);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        list.clear();

        try (ObjectInputStream inputStream = new ObjectInputStream(new BufferedInputStream(new FileInputStream(path)))) {
            list = (ArrayList<Double>) inputStream.readObject();
            System.out.println(list);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
