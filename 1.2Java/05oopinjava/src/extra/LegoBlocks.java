package extra;

import java.util.Scanner;

public class LegoBlocks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        try {
            int rowCount = scanner.nextInt();
            scanner.nextLine();
            int[][] firstArray = new int[rowCount][];
            int[][] secondArray = new int[rowCount][];
            int[][] resultArray = new int[rowCount][];
            for(int i = 0; i < rowCount; i++){
                String[] cols = scanner.nextLine().trim().split("\\s+");
                firstArray[i] = new int[cols.length];
                for(int j = 0; j < cols.length; j++){
                    firstArray[i][j] = Integer.parseInt(cols[j]);
                }
            }

            for(int i = 0; i < rowCount; i++){
                String[] cols = scanner.nextLine().trim().split("\\s+");
                secondArray[i] = new int[cols.length];

                for(int j = 0; j < cols.length; j++){
                    secondArray[i][j] = Integer.parseInt(cols[j]);
                }
            }
            int resultLen = 0;
            if (rowCount > 0){
                resultLen = firstArray[0].length + secondArray[0].length;
            }
            boolean fit = true;
            for(int i = 0; i < rowCount; i++){
                int currentLen = firstArray[i].length + secondArray[i].length;
                if (currentLen != resultLen){
                    resultLen = currentLen;
                    fit = false;
                }
                resultArray[i] = new int[resultLen];
                for (int j = 0; j < firstArray[i].length; j++){
                    resultArray[i][j] = firstArray[i][j];
                }
                int k = firstArray[i].length;
                for(int j = secondArray[i].length - 1; j >= 0; j--){
                    resultArray[i][k] = secondArray[i][j];
                    k++;
                }
            }
            if (fit){
                for(int i = 0; i < rowCount; i++){
                    String sLine = "";
                    for(int j = 0; j < resultArray[i].length; j++){
                        sLine += String.format("%d, ", resultArray[i][j]);
                    }
                    if (sLine.endsWith(", ")){
                        sLine = sLine.substring(0, sLine.length() - 2);
                    }
                    System.out.println(String.format("[%s]", sLine));
                }
            } else {
                int totalCell = 0;
                for(int i = 0; i < rowCount; i++){
                    totalCell += resultArray[i].length;
                }
                System.out.printf("The total number of cells is: %d", totalCell);
            }
        } finally{
            scanner.close();
        }

    }
}
