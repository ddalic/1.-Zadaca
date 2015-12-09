using System;
using System.Linq;
namespace IntCollection
{

    class Program
    {
        public class IntegerList : IIntegerList
        {
            private int[] _internalStorage;

            public IntegerList() {
                int[] novi = new int[4];
                _internalStorage = novi;
            }

            public IntegerList(int initialSize) {
                int[] _internalStorage = new int[initialSize];
                this._internalStorage = _internalStorage;
            }

            public int Count
            {
                get
                {
                    int brelemenata = 0;
                    for (int i = 0; i < _internalStorage.Length; i++) {
                        if (_internalStorage[i] != 0) brelemenata++; else break;
                    }

                    return brelemenata;
                }
            }

            public void Add(int item)
            {
                Boolean dodao = false;
                for (int i = 0; i < _internalStorage.Length; i++) {
                    if (_internalStorage[i] == 0)
                    {
                        _internalStorage[i] = item;
                        dodao = true;
                        break;
                    }

                }
                if (dodao == false) {
                    Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
                    for (int i = 0; i < _internalStorage.Length; i++){
                        if (_internalStorage[i] == 0) {
                            _internalStorage[i] = item;
                            break;
                        }
                    }
                }
               
            }

            public void Clear()
            {
                for (int i = 0; i < _internalStorage.Length; i++) {
                    _internalStorage[i] = 0;
                }
            }

            public bool Contains(int item)
            {
                Boolean ima = false;
                for (int i = 0; i < _internalStorage.Length; i++) {
                    if (_internalStorage[i] == item) {
                        ima = true;
                    }
                }
                return ima;
            }

            public int GetElement(int index)
            {
                if (index > _internalStorage.Length) throw new IndexOutOfRangeException();
                return _internalStorage[index];
            }

            public int IndexOf(int item)
            {
                for (int i = 0; i < _internalStorage.Length; i++) {
                    if (_internalStorage[i] == item) return i;
                }

                return -1;
            }

            public bool Remove(int item)
            {
                return RemoveAt(IndexOf(item));
            }

            public bool RemoveAt(int index)
            {
                if(index > _internalStorage.Length || index == -1 || _internalStorage[index] == 0) return false;
                _internalStorage = _internalStorage.Where((_internalStorage, indexer) => indexer != index).ToArray();
                return true;
            }
            public void printaj() {
                for (int i = 0; i < _internalStorage.Length; i++) Console.WriteLine(_internalStorage[i]);
            }
        }

        static void Main(string[] args)
        {
            IntegerList listOfIntegers = new IntegerList();
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            // lista je [1,2,3,4,5]
            // Mičemo prvi element liste.
            listOfIntegers.RemoveAt(0);
            // Lista je [2,3,4,5]
            // Mičemo element liste čija je vrijednost "5".
            listOfIntegers.Remove(5);
            // Lista je [2,3,4]
            Console.WriteLine(listOfIntegers.Count);
            // 3
            Console.WriteLine(listOfIntegers.Remove(100));
            // false, nemamo element u vrijednosti 100
            Console.WriteLine(listOfIntegers.RemoveAt(5));
            // false, nemamo ništa na poziciji 5
            // Brišemo sav sadržaj kolekcije
            listOfIntegers.Clear();
            Console.WriteLine(listOfIntegers.Count);
            // 0
            Console.ReadLine();
        }
    }
}
