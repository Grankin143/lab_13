using lab_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
    public delegate void Cha(int ab, Lek lek);
    interface Add
    {
        void add();
    }
    public class Lek
    {
        protected string mass;
        protected string name;
        protected int price;
        protected int amount;
        virtual public void read()
        {
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
        }
        public Lek(string mass, string name, int price, int amount)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
            this.amount = amount;
        }
        public Lek()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
        }
        virtual public void display()
        {
            Console.WriteLine("Код лекарства: " + mass);
            Console.WriteLine("Название лекарства: " + name);
            Console.WriteLine("Цена: " + price);
            Console.WriteLine("Колличество: " + amount);
        }
        static public void setAmount(int amount, Lek lek)
        {
            lek.amount = lek.amount + amount;
        }
        public int Amount
        {
            set
            {
                if(value > 0)
                {
                    amount = value;
                }
            }
            get
            {
                return amount;
            }
        }
        static public void setPrice(int price, Lek lek)
        {
            lek.price = price;
        }
        public int Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public string Mass
        {
            get
            {
                return mass;
            }
        }
    }

    class Proizvoditel : Lek, Add, ICloneable
    {
        private int[] date = new int[3];
        private string[] world_naz = new string[10];
        public Proizvoditel()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
            this.date[0] = this.date[1] = this.date[2] = -1;
            world_naz[0] = "-";
        }
        public Proizvoditel(string mass, string name, int price, int amount, int[] release, string[] platforms):base(mass, name, price, amount)
        {
            int i;
            for (i = 0; i < 3; i++)
            {
                this.date[i] = release[i];
            }
            for (i = 0; i < platforms.Length; i++)
            {
                this.world_naz[i] = platforms[i];
            }
        }
        public override void read()
        {
            int d;
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
            Console.WriteLine("Введите дату (00.00.0000), после ввода дня, месяца, года нажмите клавишу Enter: ");
            date[0] = Convert.ToInt32(Console.ReadLine());
            date[1] = Convert.ToInt32(Console.ReadLine());
            date[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите страну производства (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                world_naz[d] = Console.ReadLine();
            } while (world_naz[d] != "");
        }
        public override void display()
        {        
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код лекарства: " + mass + "\n";
            s += "Название лекарства: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Дата: " + date[0] + "." + date[1] + "." + date[2] + "\n";
            s += "Страны: ";
            for (d = 0; d < world_naz.Length; d++)
            {
                s += world_naz[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (world_naz[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите страну производства лекарства: ");
            world_naz[i] = Console.ReadLine();
        }
        public object Clone()
        {
            return new Proizvoditel(mass, name, price, amount, date, world_naz);
        }
    }

    class Naz_world : Lek, Add
    {
        private string[] import = new string[10];
        private string[] export = new string[10];
        public Naz_world()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
            this.import[0] = "-";
            this.export[0] = "-";
        }
        public Naz_world(string mass, string name, int price, int amount, string[] import, string[] export):base(mass, name, price, amount)
        {
            int i;
            for (i = 0; i < import.Length; i++)
            {
                this.import[i] = import[i];
            }
            for (i = 0; i < export.Length; i++)
            {
                this.export[i] = export[i];
            }
        }
        public override void read()
        {
            int d;
            Console.WriteLine("Введите название лекарства: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства: ");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену: ");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
            Console.WriteLine("Введите название страны привоза (чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                import[d] = Console.ReadLine();
            } while (import[d] != "");
            Console.WriteLine("Введите название страны вывоза(чтобы закончить введите пустую строку)");
            d = -1;
            do
            {
                d++;
                export[d] = Console.ReadLine();
            } while (export[d] != "");
        }
        public override void display()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код лекарства: " + mass + "\n";
            s += "Название лекарства: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Страны импорта: ";
            for (d = 0; d < import.Length; d++)
            {
                s += import[d] + ", ";
            }
            s += "Страны экспорта: ";
            for (d = 0; d < export.Length; d++)
            {
                s += export[d] + ", ";
            }
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (import[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите название страны привоза: ");
            import[i] = Console.ReadLine();
        }
    }
    class Array<M> where M : Lek
    {
        private M[] b;
        private int size;
        public Array()
        {
            size = 0;
        }
        public Array(M[] o, int size)
        {
            b = o;
            this.size = size;
        }
        public void display()
        {
            int i;
            for(i = 0; i< size; i++)
            {
                Console.WriteLine("Лекарство: " + i);
                b[i].display();
            }
        }
        public void Add(M o)
        {
            b[size] = o;
            size++;
        }
        public M find(string mass)
        {
            int i;
            i = 0;
            while (i < size)
            {
                if (b[i].Mass == mass)
                {
                    return b[i];
                }
                i++;
            }
            return null;
        }
        public Array<M> sum(Array<M> b2)
        {
            Array<M> b3 = new Array<M>();
            int i;
            b3.b = this.b;
            b3.size = this.size;
            for(i = 0; i < b2.size; i++)
            {
                b3.b[b3.size] = b2.b[i];
                b3.size++;
            }
            return b3;
        }
    }
}
    class Apteka
    {
        private string name;
        private string num;
        private Array<Lek> lek = new Array<Lek>();
        private Array<Proizvoditel> proz = new Array<Proizvoditel>();
        private Array<Naz_world> naz_world = new Array<Naz_world>();
        public void read()
        {
            string f;
            Lek[] lek1 = new Lek[10];
            Proizvoditel[] proz1 = new Proizvoditel[10];
            Naz_world[] naz_world1 = new Naz_world[10];
            int number;
            Console.WriteLine("Введите название аптеки: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите номер аптеки: ");
            num = Console.ReadLine();
            number = 0;
            Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                lek1[number] = new Lek();
                lek1[number].read();
                number++;
                Console.WriteLine("Добавить ещё лекарство ?(1 - да, 0 -нет)");
                f = Console.ReadLine();
            }
            lek = new Array<Lek>(lek1, number);
            number = 0;
            Console.WriteLine("Добавить производителя ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                proz1[number] = new Proizvoditel();
                proz1[number].read();
                number++;
                Console.WriteLine("Добавить ещё производителя ?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            proz = new Array<Proizvoditel>(proz1, number);
            number = 0;
            Console.WriteLine("Добавить страну ?(1 - да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                naz_world1[number] = new Naz_world();
                naz_world1[number].read();
                number++;
                Console.WriteLine("Добавить ещё страну ?(1 - да, 0 - нет)");
                f = Console.ReadLine();
            }
            naz_world = new Array<Naz_world>(naz_world1, number);
        }
        public Apteka(string name, string num, int numOfMeds, Lek[] lek, int numOfProzs, Proizvoditel[] proz, int numOfWorlds, Naz_world[] naz_world)
        {
            this.name = name;
            this.num = num;
            this.lek = new Array<Lek>(lek, numOfMeds);
            this.proz = new Array<Proizvoditel>(proz, numOfProzs);
            this.naz_world = new Array<Naz_world>(naz_world, numOfWorlds);
        }
        public Apteka(string name)
        {
            this.name = name;
            this.num = "-";
        }
        public Apteka()
        {
            this.name = "-";
            this.num = "-";
        }
        public void display()
        {
            Console.WriteLine("Название аптеки: " + name);
            Console.WriteLine("Номер: " + num);
            lek.display();
            proz.display();
            naz_world.display();
        }
        public static Apteka operator ++ (Apteka apteka)
        {
            Apteka newApteka = new Apteka();
            string f;
            newApteka.name = apteka.name;
            newApteka.num = apteka.num;
            newApteka.lek = apteka.lek;
            newApteka.proz = apteka.proz;
            newApteka.naz_world = apteka.naz_world;
            Console.WriteLine("Добавить лекарство - 1, производителя - 2, страну - 3");
            f = Console.ReadLine();
            if (f == "1")
            {
                Lek a = new Lek();
                a.read();
                newApteka.lek.Add(a);
            }
            else if (f == "2")
            {
                Proizvoditel a = new Proizvoditel();
                a.read();
                newApteka.proz.Add(a);
            }
            else
            {
                Naz_world a = new Naz_world();
                a.read();
                newApteka.naz_world.Add(a);
            }
            return newApteka;
        }
        public void Change(string mass, int ab, Cha func)
        {
            Lek lek1;
            lek1 = null;
            Proizvoditel proz1;
            proz1 = null;
            Naz_world naz_world1;
            naz_world1 = null;
            lek1 = lek.find(mass);
            if (lek1 != null)
            {
                func(ab, lek1);
            }
            if (lek1 == null)
            {
                proz1 = proz.find(mass);
                if (proz1 != null)
                {
                    func(ab, proz1);
                }
            }
            if (proz1 == null && lek1 == null)
            {
                naz_world1 = naz_world.find(mass);
                if (naz_world1 != null)
                {
                    func(ab, naz_world1);
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public static Apteka operator + (Apteka apteka1, Apteka apteka2) {
            Apteka newStore = new Apteka();
            newStore.name = apteka1.name;
            newStore.num = apteka1.num;
            newStore.lek = apteka1.lek.sum(apteka2.lek);
            newStore.proz = apteka1.proz.sum(apteka2.proz);
            newStore.naz_world = apteka1.naz_world.sum(apteka2.naz_world);
            return newStore;
        }
        public void add(string mass)
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
    class Program
    {
        static void Main(string[] args)
        {
            Apteka[] apteka1 = new Apteka[10];
            Lek[] lek1 = new Lek[10];
            Proizvoditel[] proz1 = new Proizvoditel[10];
            Naz_world[] naz_world1 = new Naz_world[10];
            int numOfMeds, i, max, n, numOfProzs, numOfWorlds = 0, lekAmount, d, lekPrice, price;
            int[] date = new int[3];
            string f, mass, name, num, lekMass, lekName;
            string[] s1 = new string[10], naz_world = new string[10], import = new string[10];
            Cha func;
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, 2 - init)");
            f = Console.ReadLine();
            if (f == "1")
            {
                apteka1[0] = new Apteka();
                apteka1[0].read();
            }
            else if (f == "2")
            {
                Console.WriteLine("Ввести все параметры - 1, только название - 2, без параметров - 3");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите номер аптеки: ");
                    num = Console.ReadLine();
                    numOfMeds = 0; ;
                    Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название лекарства: ");
                        lekName = Console.ReadLine();
                        Console.WriteLine("Введите код лекарства: ");
                        lekMass = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену: ");
                            try
                            {
                                lekPrice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException){
                                lekPrice = -1;
                            }
                        } while (lekPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество лекарства: ");
                            try
                            {
                                lekAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekAmount = -1;
                            }
                        } while (lekAmount < 0);
                        lek1[numOfMeds] = new Lek(lekName, lekMass, lekPrice, lekAmount);
                        numOfMeds++;
                        Console.WriteLine("Добавить лекарство ?(1 - да, 0 - нет)");
                        f = Console.ReadLine();
                    }
                    numOfProzs = 0;
                    Console.WriteLine("Добавить производителя ?(1 - да, 0 - нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название производителя: ");
                        lekName = Console.ReadLine();
                        Console.WriteLine("Введите код производителя: ");
                        lekMass = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену: ");
                            try
                            {
                                lekPrice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekPrice = -1;
                            }
                        } while (lekPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество лекарства: ");
                            try
                            {
                                lekAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekAmount = -1;
                            }
                        } while (lekAmount < 0);
                        Console.WriteLine("Введите дату (00.00.0000) день, месяц, год после ввода дня, месяца, года нажимайте Enter)");
                        date[0] = Convert.ToInt32(Console.ReadLine());
                        date[1] = Convert.ToInt32(Console.ReadLine());
                        date[2] = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите страну производства (чтобы закончить введите пустую строку)");
                        numOfWorlds = 0;
                        d = -1;
                        do
                        {
                            numOfWorlds++;
                            d++;
                            naz_world[d] = Console.ReadLine();
                        } while (naz_world[d] != "");
                        proz1[numOfProzs] = new Proizvoditel(lekName, lekMass, lekPrice, lekAmount, date, naz_world);
                        numOfProzs++;
                        Console.WriteLine("Добавить ещё производителя ?(1 - да, 0 - нет)");
                        f = Console.ReadLine();
                    }
                    apteka1[0] = new Apteka(name, num, numOfMeds, lek1, numOfProzs, proz1, numOfWorlds, naz_world1);
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    apteka1[0] = new Apteka(name);
                }
                else
                {
                    apteka1[0] = new Apteka();
                }
            }
            i = 0;
            max = 1;
            f = "1";
            while (f != "10")
            {
                Console.WriteLine("Введите номер следующего действия:");
                Console.WriteLine("1 - показать информацию о аптеки");
                Console.WriteLine("2 - добавить новое лекарство");
                Console.WriteLine("3 - изменить цену лекарства");
                Console.WriteLine("4 - добавить аптеку");
                Console.WriteLine("5 - показать все аптеки");
                Console.WriteLine("6 - сменить аптеку");
                Console.WriteLine("7 - сложить аптеки");
                Console.WriteLine("8 - добавить страну");
                Console.WriteLine("9 - копирование");
                Console.WriteLine("10 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    apteka1[i].display();
                }
                else if (f == "2")
                {
                    apteka1[i] = ++apteka1[i];
                }
                else if (f == "3")
                {
                    func = Lek.setPrice;
                    Console.WriteLine("Введите код лекарства: ");
                    mass = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Введите новую цену: ");
                        try
                        {
                            price = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            price = -1;
                        }
                    } while (price < 0);
                    apteka1[i].Change(mass, price, func);
                }
                else if (f == "4")
                {
                    apteka1[max] = new Apteka();
                    apteka1[max].read();
                    i = max;
                    max++;

                }
                else if (f == "5")
                {
                    for (n = 0; n < max; n++)
                    {
                        Console.WriteLine("Аптека: " + apteka1[n].Name);
                    }
                }
                else if (f == "6")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            i = n;
                            n = max;
                        }
                    }
                }
                else if (f == "7")
                {
                    Console.WriteLine("Введите название аптеки: ");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            apteka1[i] = apteka1[i] + apteka1[n];
                            n = max;
                        }
                    }
                }
                else if (f == "8")
                {
                    Console.WriteLine("Введите код лекарства: ");
                    mass = Console.ReadLine();
                    apteka1[i].add(mass);
                }
                else if (f == "9")
                {
                    date[0] = date[1] = date[2] = 1;
                    naz_world[0] = "naz_world";
                    proz1[0] = new Proizvoditel("proz", "proz", 1, 1, date, naz_world);
                    import[0] = "imimim";
                    naz_world[0] = "world";
                    naz_world1[0] = new Naz_world("naz_world", "naz_world", 2, 2, import, naz_world);
                    proz1[1] = (Proizvoditel)proz1[0].Clone();
                    proz1[1].Amount = 2;
                    proz1[0].display();
                    naz_world1[1] = naz_world1[0];
                    naz_world1[1].Amount = 3;
                    naz_world1[0].display();
                }
            }
        }
    }