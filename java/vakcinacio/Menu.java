import java.io.*;
import java.util.Scanner;
import java.util.ArrayList;



public class Menu{
    
    private static ArrayList<Patient> people = new ArrayList<Patient>();
    public static Scanner sc; 
    public static BufferedReader br;
    
    public Menu() {}

    public void run(){
        boolean end = false;
        int choice;
        

        while(!end){
            

            try {
                choice = choose();
                switch (choice){
                    case 1:  addOnePatient(); break;
                    case 2:  removeOnePatient(); break;
                    case 3: changeOnePatient(); break;
                    case 4: listEveryPatient(); break;
                    case 5: addPatientFromFile(); break;
                    case 6: listEveryPatientToFile(); break;
                    case 0: end=true; System.out.println("Good bye! Wish you good health!"); break;
                    default:  break; 
                }
            }catch ( IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }
    }

    private int choose(){
        int choice;
        sc = new Scanner(System.in);
        System.out.println("*******************************************************");
        System.out.println("Choose from the menu points here!");
        System.out.println("1: Add a new patient");
        System.out.println("2: Remove a patient");
        System.out.println("3: Change the datas of a patient");
        System.out.println("4: List every patients from database to the screen");
        System.out.println("5: Add patients from file");
        System.out.println("6: List every patients from database to a new file");
        System.out.println("0: Exit");
        System.out.println("*******************************************************");
        System.out.print("Your choice: ");
        if(!sc.hasNextInt()) throw new IllegalArgumentException("You have to enter a number! Try it again!");
        choice=sc.nextInt();
        if(choice < 0 || choice > 6) throw new IllegalArgumentException("You should enter a number between 0 and 6!");
        System.out.println("*******************************************************");
        return choice;
    }


    private void addOnePatient(){
        sc = new Scanner(System.in);
        System.out.print("Datas(in this form->name, year_of_birth, mobile, can_pay_if_necessary): \n"); 
        String str = sc.nextLine();
        String[] line = str.split(", ");
        try{
            if(line.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
            else if(line[3].contains("igen")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], true);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { talalt=true;}
                    else i++;
                }
                if(talalt){ System.out.println("Already a member");}
                else {people.add(newOne); System.out.println("Added!");}
            }
            else if(line[3].contains("nem")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], false);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { talalt=true;}
                    else i++;
                }
                if(talalt){ System.out.println("Already a member");}
                else {people.add(newOne); System.out.println("Added!");}
            }
            else throw new IllegalArgumentException("You gave datas in wrong form!");
        }catch(IllegalArgumentException e){
            System.out.println(e.getMessage());
        }
        
    }

    private void removeOnePatient(){
        sc = new Scanner(System.in);
        System.out.print("Datas of person(in this form->name, year_of_birth, mobile, can_pay_if_necessary): \n");
        String str = sc.nextLine();
        String[] line = str.split(", ");
        try{
            if(line.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
            else if(line[3].contains("igen")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], true);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { people.remove(i); System.out.println("Deleted!"); talalt=true;}
                    else i++;
                }
                if(talalt==false)  {System.out.println("No matches!");}
            }
            else if(line[3].contains("nem")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], false);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { people.remove(i); System.out.println("Deleted!"); talalt=true;}
                    else i++;
                }
                if(talalt==false)  {System.out.println("No matches!");}
            }
            else throw new IllegalArgumentException("You gave datas in wrong form!");
        }catch(IllegalArgumentException e){
            System.out.println(e.getMessage());
        }
        

    }

    private void changeOnePatient(){
        sc = new Scanner(System.in);
        System.out.print("Datas of person(in this form->name, year_of_birth, mobile, can_pay_if_necessary): \n");
        String str = sc.nextLine();
        String[] line = str.split(", ");
        try{
            if(line.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
            else if(line[3].contains("igen")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], true);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) {
                        System.out.print("New datas of person(in this form->name, year_of_birth, mobile, can_pay_if_necessary): \n");
                        String strNew = sc.nextLine();
                        String[] lineNew = strNew.split(", ");
                        if(lineNew.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
                        else if(lineNew[3].contains("igen")){
                            Patient modifiedOne = new Patient(lineNew[0], Integer.parseInt(lineNew[1]), lineNew[2], true);
                            people.set(i,modifiedOne);
                        }else if(lineNew[3].contains("nem")){
                            Patient modifiedOne = new Patient(lineNew[0], Integer.parseInt(lineNew[1]), lineNew[2],false);
                            people.set(i,modifiedOne);
                        }else throw new IllegalArgumentException("You gave new datas in wrong form!");
                        talalt=true;
                    }
                    else i++;
                }
                if(talalt==false)  {System.out.println("No matches!");}
            }else if(line[3].contains("nem")){
                Patient newOne = new Patient(line[0], Integer.parseInt(line[1]), line[2], false);
                boolean talalt=false;
                int i=0;
                while(!talalt && i<people.size()){
                    if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) {
                        System.out.print("New datas of person(in this form->name, year_of_birth, mobile, can_pay_if_necessary): \n");
                        String strNew = sc.nextLine();
                        String[] lineNew = strNew.split(", ");
                        if(lineNew.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
                        else if(lineNew[3].contains("igen")){
                            Patient modifiedOne = new Patient(lineNew[0], Integer.parseInt(lineNew[1]), lineNew[2], true);
                            people.set(i,modifiedOne);
                        }else if(lineNew[3].contains("nem")){
                            Patient modifiedOne = new Patient(lineNew[0], Integer.parseInt(lineNew[1]), lineNew[2],false);
                            people.set(i,modifiedOne);
                        }else throw new IllegalArgumentException("You gave new datas in wrong form!");
                        talalt=true;
                    }
                    else i++;
                }
                if(talalt==false)  {System.out.println("No matches!");}
            } else {throw new IllegalArgumentException("You gave old datas in wrong form!");}
        }catch(IllegalArgumentException e){
            System.out.println(e.getMessage());
        }
        
    }




    
    private void listEveryPatient(){
        if(people.size() == 0) {System.out.println("The database is empty!");}
        else{
            for(Patient e : people){
                System.out.println(e.toString());
            }
        }
        
    }




    
    private void addPatientFromFile(){
        sc = new Scanner(System.in);
        System.out.print("Enter the name of the input file: ");
        String inFileName = sc.nextLine();
        File input = new File(inFileName);
        try{
            BufferedReader br = new BufferedReader(new FileReader(input));
            String line;
            while((line=br.readLine()) != null){
                String parts[] = line.split(", ");
                if(parts.length != 4) {throw new IllegalArgumentException("You gave datas in wrong form! Try again!");}
                else if(parts[3].contains("igen")){
                    Patient newOne = new Patient(parts[0], Integer.parseInt(parts[1]), parts[2], true);
                    boolean talalt=false;
                    int i=0;
                    while(!talalt && i<people.size()){
                        if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { talalt=true;}
                        else i++;
                    }
                    if(!talalt) {people.add(newOne);}
                }
                else if(parts[3].contains("nem")){
                    Patient newOne = new Patient(parts[0], Integer.parseInt(parts[1]), parts[2], false);
                    boolean talalt=false;
                    int i=0;
                    while(!talalt && i<people.size()){
                        if((people.get(i)).equals(newOne.getName(), newOne.getYear(), newOne.getMobile(), newOne.getPaying())) { talalt=true;}
                        else i++;
                    }
                    if(!talalt){ people.add(newOne);}
                }
                else System.out.println("This line is not acceptable: "+line);

            }
            br.close();
        }catch(FileNotFoundException e){
            System.out.println("Unable to access file: "+inFileName);
        }catch(IOException e){
            System.out.println("IO error");
        }catch(IllegalArgumentException e){
            System.out.println(e.getMessage());
        }
        
    }
    
    private void listEveryPatientToFile(){
        sc = new Scanner(System.in);
        System.out.print("Enter the name of the output file: ");
        String outFileName = sc.nextLine();
        File output = new File(outFileName);
        try{
            PrintWriter pw = new PrintWriter(output);
            for(Patient p : people){
                pw.println(p.toString());
            }
            pw.close();
        }catch(IOException e){
            System.out.println("IO error");
        }
    }


}
