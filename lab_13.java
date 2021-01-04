import java.util.Scanner;
import java.util.*;

public class lab_13 {
    public static void main(String[] args) {
        String encoding = System.getProperty("console.encoding", "cp866"), name1, num1, nameLek1, mass1, f;
        String[] naz_world = new String[10], import1 = new String[10], export = new String[10];
        Scanner in = new Scanner(System.in, encoding);
        Apteka[] apteka = new Apteka[10];
        Lek[] lek1 = new Lek[10];
        Proizvoditel[] proz1 = new Proizvoditel[10];
        Naz_world[] naz_world1 = new Naz_world[10];
        Number k = new Number();
        int numOfMeds1, amount1, i, max, n, d, numOfProzs1, numOfWorlds1;
        int[] date = new int[3];
        double price1;
        System.out.println("Ввести данные через read или init(1 - read, 2 - init)");
        f = in.nextLine();
        if(f.equals("1")){
            apteka[0] = new Store();
            apteka[0].read();
        }
        else if (f.equals("2")) {
            System.out.println("Ввести все параметры (1), ввести только название (2), не вводить параметры (3)");
            f = in.nextLine();
            if(f.equals("1")){
                System.out.println("Введите название аптеки: ");
                name1 = in.nextLine();
                System.out.println("Введите номер аптеки: ");
                num1 = in.nextLine();
                System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
                f = in.nextLine();
                i = 0;
                while(f.equals("1")){
                    System.out.println("Введите название лекарства: ");
                    nameItem1 = in.nextLine();
                    System.out.println("Введите код лекарства: ");
                    mass1 = in.nextLine();
                    try{
                        System.out.println("Введите цену: ");
                        price1 = in.nextDouble();
                    }
                    catch(Exception e){
                        price1 = 0;
                        in.nextLine();
                    }
                    try{
                        System.out.println("Введите колличество: ");
                        amount1 = in.nextInt();
                    }
                    catch(Exception e){
                        amount1 = 0;
                    }
                    in.nextLine();
                    lek1[i] = new Lek(mass1, nameLek1, price1, amount1);
                    i++;
                    System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
                    f = in.nextLine();
                }
                numOfMeds1 = i;
                System.out.println("Добавить производителя ?(1 - да, 0 - нет)");
                f = in.nextLine();
                i = 0;
                while(f.equals("1")){
                    System.out.println("Введите название лекарства: ");
                    nameLek1 = in.nextLine();
                    System.out.println("Введите код лекарства: ");
                    mass1 = in.nextLine();
                    try{
                        System.out.println("Введите цену: ");
                        price1 = in.nextDouble();
                    }
                    catch(Exception e){
                        price1 = 0;
                        in.nextLine();
                    }
                    try{
                        System.out.println("Введите колличество: ");
                        amount1 = in.nextInt();
                    }
                    catch(Exception e){
                        amount1 = 0;
                    }
                    System.out.println("Введите дату (00.00.0000), после нажмите Enter)");
                    date[0] = in.nextInt();
                    date[1] = in.nextInt();
                    date[2] = in.nextInt();
                    in.nextLine();
                    System.out.println("Введите страну (чтобы закончить введите пустую строку)");
                    d = -1;
                    do
                    {
                        d++;
                        naz_worlds[d] = in.nextLine();
                    } while (!naz_world[d].equals(""));
                    proz1[i] = new Proizvoditel(mass1, nameLek1, price1, amount1, date, naz_world);
                    i++;
                    System.out.println("Добавить ещё страну ?(1 - да, 0 - нет)");
                    f = in.nextLine();
                }
                numOfProzs1 = i;
                System.out.println("Добавить производителя ?(1 - да, 0 - нет)");
                f = in.nextLine();
                i = 0;
                while(f.equals("1")){
                    System.out.println("Введите страну привоза (чтобы закончить введите пустую строку)");
                    d = -1;
                    do
                    {
                        d++;
                        import1[d] = in.nextLine();
                    } while (!import1[d].equals(""));
                    System.out.println("Введите страну экспорта (чтобы закончить введите пустую строку)");
                    d = -1;
                    do
                    {
                        d++;
						export[d] = in.nextLine();
                    } while (!export[d].equals(""));
                    naz_world11[i] = new Naz_world(mass1, nameLek1, price1, amount1, import1, export);
                    i++;
                    System.out.println("Добавить страну ?(1 - да, 0 - нет)");
                    f = in.nextLine();
                }
                numOfWorlds1 = i;
                apteka[0] = new Apteka(name1, num1, numOfMeds1, lek1, numOfProzs1, proz1, numOfWorlds1, naz_world1);
            }
            else if(f.equals("2")){
                System.out.println("Введите название аптеки: ");
                name1 = in.nextLine();
                apteka[0] = new Apteka(name1);
            }
            else{
                apteka[0] = new Apteka();
            }
        }
        f = "0";
        i = 0;
        max = 1;
        while(f.equals("9") == false){
            System.out.println("Введите номер следующего действия");
            System.out.println("1 - показать информацию о аптеки");
            System.out.println("2 - добавить новое лекарство");
            System.out.println("3 - изменить цену лекарства");
            System.out.println("4 - добавить аптеку");
            System.out.println("5 - показать все аптеки");
            System.out.println("6 - сменить аптеку");
            System.out.println("7 - добавить страну");
            System.out.println("8 - клонирование");
            System.out.println("9 - выйти");
            f = in.nextLine();
            if(f.equals("1")){
                apteka[i].display();
            }
            else if(f.equals("2")){
                apteka[i].add();
            }
            else if(f.equals("3")){
                System.out.println("Введите код лекарства: ");
                mass1 = in.nextLine();
                System.out.println("Введите новую цену: ");
                try{
                    price1 = in.nextDouble();
                }
                catch(Exception e){
                    price1 = 0;
                }
                in.nextLine();
                apteka[i].priceChange(mass1, price1);
            }
            else if(f.equals("4")){
                apteka[max] = new Apteka();
                apteka[max].read();
                i=max;
                max++;
            }
            else if(f.equals("5")){
                for(n = 0;n < max; n++){
                    apteka[n].displayName();
                }
            }
            else if(f.equals("6")){
                System.out.println("Введите название аптеки: ");
                name1 = in.nextLine();
                for(n = 0;n < max;n++){
                    if(store[n].aptekacmp(name1)){
                        i = n;
                        n = max;
                    }
                }
            }
            else if(f.equals("7")){
                System.out.println("Введите код лекарства: ");
                mass1 = in.nextLine();
                apteka[i].add(mass1);
            }
            else if(f.equals("8")){
                date[0] = date[1] = date[2] = 1;
                naz_world[0] = "aaa";
                proz1[0] = new Proizvoditel("proz", "proz", 1, 1, date, naz_world);
                import1[0] = "bbb";
                naz_world[0] = "zzz";
                naz_world1[0] = new Platform("naz_world", "naz_world", 2, 2, import1, naz_world);
                proz1[1] = (Proizvoditel)proz1[0].clone();
                proz1[1].setAmount(2);
                proz1[0].display();
                naz_world1[1] = naz_world1[0];
                naz_world1[1].setAmount(3);
                naz_world1[0].display();
            }
        }    
    }
}