using System.Diagnostics;

namespace p4Concurrencia;

class Program {

    static int sumaTotal = 0;
    static object lockObject = new Object();

    static void CalcularPrimos(object range) {
        
        (int inicio, int final) = ((int, int))range;
        int suma = 0;

        for (int i = inicio; i <= final; i++) {
            
            if (EsPrimo(i)) {
                suma += 1;
            }
        }

        lock(lockObject) {
            sumaTotal += suma;
        }
    }

    static bool EsPrimo(int number) {
        
        if (number < 2) return false;

        for (int i = 2; i*i <= number; i++) {
            if (number % i == 0) return false;
        }
        
        return true;
    }

    static void Concurrencia(int limite, int segmentos) {
        
        int range = limite / segmentos;
        Thread[] hilos = new Thread[segmentos];

        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < segmentos; i++) {
            
            int inicio = i * range + 1;
            int final = (i == segmentos - 1) ? limite : inicio + range - 1;
            hilos[i] = new Thread(CalcularPrimos);
            hilos[i].Start((inicio, final));
        }

        foreach (var hilo in hilos) {
            hilo.Join();
        }

        stopwatch.Stop();
        Console.WriteLine($"Suma total de números primos hasta {limite}: {sumaTotal}");
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
    }

    static void Secuencial(int limite) {

        Stopwatch stopwatch = Stopwatch.StartNew();

        int suma = 0;
        
        for (int i = 1; i <= limite; i++) {
            if (EsPrimo(i)) {
                suma += 1;
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"Suma total de números primos hasta {limite}: {sumaTotal}"); 
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms"); 
    }

    static void Main(string[] args) {

        Console.WriteLine("Ingrese el número limite:");
        int N = int.Parse(Console.ReadLine());
        int M = 4;

        Console.WriteLine("\nFUNCIÓN CONCURRENTE:");
        Concurrencia(N, M);

        Console.WriteLine("-------------------------------------------\n");

        Console.WriteLine("FUNCIÓN SECUENCIAL:");
        Secuencial(N);
    }
}
