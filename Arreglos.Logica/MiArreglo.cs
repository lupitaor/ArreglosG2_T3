namespace Arreglos.Logica
{
    public class MiArreglo
    {
        //Atributos o campos

        private int _tope;
        private int[] _arreglo;



        //Constructor
        public MiArreglo(int n)
        {
            N = n;
            _arreglo = new int[N];
            _tope = 0;
        }

        //Propiedades
        public int N { get; }
        public bool EstaVacio => _tope == 0;
        public bool EstaLleno => _tope == N;

        //Métodos
        //Método Llenar con parametros
        public void Llenar(int minimo, int maximo)
        {
            Random oRandom = new Random();

            for (int i = 0; i < N; i++)
            {
                _arreglo[i] = oRandom.Next(minimo, maximo);
            }
            _tope = N;
        }

        //Método Ordenar
        public void Ordenar()
        {
            Ordenar(true);
        }

        //Método Ordenar
        public void Ordenar(bool ascendente)
        {
            for (int i = 0; i < _tope - 1; i++)
            {
                for (int j = i + 1; j < _tope; j++)
                {
                    if (ascendente)
                    {
                        if (_arreglo[i] > _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }

                    }
                    else
                    {
                        if (_arreglo[i] < _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }

                    }



                }
            }
        }

        //Métrodo cambiar
        public void Cambiar(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        //Método Agregar

        public void Agregar(int numero)
        {
            if (EstaLleno)
            {
                throw new Exception("El arreglo está lleno");
            }
            _arreglo[_tope] = numero;
            _tope++;
        }

        //Método insertar

        public void Insertar(int numero, int posicion)
        {
            if (EstaLleno)
            {
                throw new Exception("El arreglo está lleno");
            }

            if (posicion < 0)
            {
                posicion = 0;
            }
            if (posicion > _tope)
            {
                posicion = _tope;
            }

            for (int i = _tope; i > posicion; i--)
            {
                _arreglo[i] = _arreglo[i - 1];
            }
            _arreglo[posicion] = numero;
            _tope++;
        }

        //Método eliminar

        public void Eliminar(int posicion)
        {
            if (EstaVacio)
            {
                throw new Exception("El arreglo esta vacío");
            }
            if (posicion < 0)
            {
                posicion = 0;
            }
            if (posicion > _tope)
            {
                posicion = _tope;
            }

            for (int i = posicion; i <= _tope - 1; i++)
            {
                _arreglo[i] = _arreglo[i + 1];
            }
            _tope--;
        }


        //Método obtener pares
        public MiArreglo ObtenerPares()
        {
            int contandoPares = 0;
            for (int i = 0; i < _tope; i++)
            {
                if (EsPar(_arreglo[i]))
                {
                    contandoPares++;
                }
            }
            var arregloPares = new MiArreglo(contandoPares);

            for (int i = 0; i < _tope; i++)
            {
                if (EsPar(_arreglo[i]))
                {
                    arregloPares.Agregar(_arreglo[i]);
                }
            }
            return arregloPares;
        }

        private bool EsPar(int n)
        {
            if (n % 2 == 0)
            {
                return true;
            }
            return false;
        }


        //Método obtener primos

        public MiArreglo ObtenerPrimos()
        {
            int contandoPrimos = 0;
            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] == 1) { continue; }
                if (EsPrimo(_arreglo[i]))
                {
                    contandoPrimos++;
                }
            }
            var arregloPrimos = new MiArreglo(contandoPrimos);
            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] == 1) { continue; }
                if (EsPrimo(_arreglo[i]))
                {
                    arregloPrimos.Agregar(_arreglo[i]);
                }
            }
            return arregloPrimos;
        }

        private bool EsPrimo(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }

            }
            return true;
        }

        public override string ToString()
        {

            if (EstaVacio)
            {
                return "El arreglo esta vacío";
            }

            string salida = string.Empty;

            int contador = 0;

            for (int i = 0; i < _tope; i++)
            {
                salida += $"{_arreglo[i]}\t";
                contador++;

                if (contador > 9)
                {
                    contador = 0;
                    salida += "\n";
                }
            }
            return salida;
        }
    }
}
