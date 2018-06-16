using System; 
using System.Collections.Generic; 

public class Strings 
{ 
    private int amount; //количество строк вцелом 
    private int length; //длина строк 

    private int x; //для записи возвращаемого значения функцией searchStr() 

    private int varNumber; //номер строки, которую пользователь захочет вывести на экран 
    private int varConcat; //выбор пользователя (объединять строки или нет) 

    //указатели на начало строк, которые будут заполняться пользователем 
    private string strSearch; //для поиска заданной строки 
    private string strConcat; //для записи всех введенных строк в одну строку 

    public Strings(int a, int b) //количество строк и максимальная длина строк 
    { 
        amount = a; //количество 
        length = b+1; //максимальная длина 
    } 
    List<string> str = new List<string>(); 

    public void searchStr() //метод, который определяет наличие в наборе строк заданной строки 
    { 
        int temp = str.IndexOf(str.Find((x) => x == strSearch)) + 1; 
        if (temp == 0) 
            Console.WriteLine("Строка содержащая {0}: {1}", strSearch, temp-1); 
        else 
            Console.WriteLine("Строка содержащая {0}: {1}", strSearch, temp); 
    } 

    public void setString() // задание строки, с заданным номером; 
    { 
        Console.WriteLine("Введите строки."); 
        for (int i = 0; i < amount; i++) 
        { 
            Console.WriteLine("Введите строку №{0} (не более {1}-ти символов): ", i+1, length); 
            string temp = Console.ReadLine(); 
            if(temp.Length+1 <= length) 
                str.Add(temp); 
            else 
                i--; 
        }
        Console.Write("Введите строку, номер которой хотите найти (не более 30-ти символов): "); 
        strSearch = Console.ReadLine(); 
        searchStr(); //присвоим переменной х значение, которое вернет функция searchStr() 
    } 

    public void getString() //вывод строк на экран 
    { 
        Console.WriteLine("Если вы хотите отобразить все строки - введите 0."); 
        Console.WriteLine("Если вы хотите вывести на экран конкретную строку, введите ее номер (1, 2 или 3): "); 
        varNumber = int.Parse(Console.ReadLine()); 
        if (varNumber == 0) 
            foreach (string i in str) 
                Console.WriteLine("Строка {0}: {1}", str.IndexOf(i)+1, i); 
        else //в данном случае если пользователь ввел 0 
            Console.WriteLine("Строка {0}: {1}", varNumber, str[varNumber]); 
    } 

    public void concat() //метод конкатенации (объединения) строк; 
    { 
        Console.WriteLine("Если Вы хотите объединить все строки, нажмите - 1. Если нет, нажмите - 0: "); 
        varConcat = int.Parse(Console.ReadLine()); 
        if (varConcat == 0) 
            Console.WriteLine("Строки не будут объединены!"); 
        else 
        { 
            foreach (string i in str) 
                strConcat += i; 
            Console.Write("Объединенные строки: " + strConcat); 
        } 
    } 

    public void del() //метод очистки памяти по завершении работы программы 
    { 
        strConcat = null; 
        strSearch = null; 
        str.Clear(); 
    } 

    static void Main() 
    { 
        Console.WriteLine("ВВедите кол-во строк:"); 
        int amount = int.Parse(Console.ReadLine()); 
        Console.WriteLine("Введите длину строк: "); 
        int length = int.Parse(Console.ReadLine()); 
        Strings strings = new Strings(amount, length); //создаем объект 
        strings.setString(); //вызываем метод задания строк в котором также вызывается метод сравнения строк 
        strings.getString(); // вывод строк на экран 
        strings.concat(); // метод конкатенации (пользователь выбирает объединять строки или нет) 
        Console.ReadKey(); 
        strings.del(); //чистим память 
    } 
}