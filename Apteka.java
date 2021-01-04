import java.util.Scanner;

public class Apteka {
    String name;
    String num;
    private Array<Lek> lek = new Array<Lek>();
    private Array<Proizvoditel> proz = new Array<Proizvoditel>();
    private Array<Naz_world> naz_world = new Array<Naz_world>();
    void read(){
        int f, number;
        Lek[] lek1 = new Lek[10];
        Proizvoditel[] proz1 = new Proizvoditel[10];
        Naz_world[] naz_world1 = new Naz_world[10];
        String encoding = System.getProperty("console.encoding", "cp866");
        Scanner in = new Scanner(System.in, encoding);
        System.out.println("Введите название аптеки: ");
        name = in.nextLine();
        System.out.println("Введите номер аптеки: ");
        num = in.nextLine();
        System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
        f = in.nextInt();
        number = 0;
        while(f == 1){
            lek1[number] = new Lek();
            lek1[number].read();
            number++;
            System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
            f = in.nextInt();
        }
        lek = new Array<Lek>(lek1, number);
        System.out.println("Добавить производителя ?(1 - да, 0 - нет)");
        f = in.nextInt();
        number = 0;
        while(f == 1){
            proz1[number] = new Proizvoditel();
            proz1[number].read(1);
            number++;
            System.out.println("Добавить производителя ?(1 - да, 0 - нет)");
            f = in.nextInt();
        }
        proz = new Array<Proizvoditel>(proz1, number);
        System.out.println("Добавить страну ?(1 - да, 0 - нет)");
        f = in.nextInt();
        number = 0;
        while(f == 1){
            naz_world1[number] = new Naz_world();
            naz_world1[number].read(1);
            number++;
            System.out.println("Добавить страну ?(1 - да, 0 - нет)");
            f = in.nextInt();
        }
        naz_world = new Array<Naz_world>(naz_world1, number);
    }
    Apteka(String name1, String num1, int numOfMeds1, Lek lek1[], int numOfProzs1, Proizvoditel[] proz1, int numOfWorlds1, Naz_world[] naz_world1){
        name = name1;
        num = num1;
        lek = new Array<Lek>(lek1, numOfMeds1);
        proz = new Array<Proizvoditel>(proz1, numOfProzs1);
        naz_world = new Array<Naz_world>(naz_world1, numOfWorlds1);
    }
    Apteka(String name1){
        name = name1;
        num = "-";
    }
    Apteka(){
        name = "-";
        num = "-";
    }
    void display(){
        int i;
        System.out.println("Название аптеки: " + name);
        System.out.println("Номер аптеки: " + num);
        lek.display();
        proz.display();
        naz_world.display();
    }
    void add(){
        String encoding = System.getProperty("console.encoding", "cp866");
        Scanner in = new Scanner(System.in, encoding);
        int f;
        System.out.println("Добавить лекарство - 1, производителя - 2, страну - 3");
        f = in.nextInt();
        if(f == 1){
            Lek lek1 = new Lek();
            lek1.read();
            lek.Add(lek1);
        }
        else if(f == 2){
            Proizvoditel proz1 = new Proizvoditel();
            proz1.read(1);
            proz.Add(proz1);
        }
        else {
            Naz_world naz_world1 = new Naz_world();
            naz_world1.read(1);
            naz_world.Add(naz_world1);
        }
    }
    void priceChange(String mass, double price){
            Lek lek1;
            lek1 = null;
            Proizvoditel proz1;
            proz1 = null;
            Naz_world naz_world1;
            naz_world1 = null;
            lek1 = lek.find(mass);
            if(lek1 != null)
            {
                lek1.setPrice(price);
            }
            if (lek1 == null)
            {
                proz1 = proz.find(mass);
                if (proz1 != null)
                {
                    proz1.setPrice(price);
                }
            }
            if (proz1 == null && lek1 == null)
            {
                naz_world1 = naz_world.find(mass);
                if (naz_world1 != null)
                {
                    naz_world1.setPrice(price);
                }
            }
        }
    void displayName(){
        System.out.println("Аптека: " + name);
    }
    boolean aptekacmp(String name1){
       if(name.equals(name1)){
           return true;
       }
       else {
           return false;
       }
    }
    void add(String mass)
        {
            Proizvoditel proz1;
            proz1 = null;
            Naz_world naz_world1;
            naz_world1 = null;
            proz1 = proz.find(mass);
            if (proz1 != null)
            {
                proz1.add();
            }
            else
            {
                naz_world1 = naz_world.find(mass);
                if (naz_world1 != null)
                {
                    naz_world1.add();
                }
            }
        }
}


