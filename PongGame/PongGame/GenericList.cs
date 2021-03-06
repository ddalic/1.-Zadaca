﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
        public class GenericList<X> : IGenericList<X>
        {
            private X[] _internalStorage;

            public GenericList()
            {
                X[] novi = new X[4];
                _internalStorage = novi;
            }
            public GenericList(int initialSize)
            {
                X[] novi = new X[initialSize];
                _internalStorage = novi;
            }


            public int Count
            {
                get
                {
                    int brelemenata = 0;
                    for (int i = 0; i < _internalStorage.Length; i++)
                    {
                        if (_internalStorage[i] != null) brelemenata++;
                    }
                    return brelemenata;

                }
            }

            public void Add(X item)
            {
                Boolean dodao = false;
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i] == null)
                    {
                        _internalStorage[i] = item;
                        dodao = true;
                        break;
                    }
                }
                if (dodao == false)
                {
                    Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
                    for (int i = 0; i < _internalStorage.Length; i++)
                    {
                        if (_internalStorage[i] == null)
                        {
                            _internalStorage[i] = item;
                            break;
                        }
                    }
                }
            }

            public void Clear()
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    _internalStorage[i] = default(X);
                }
            }

            public bool Contains(X item)
            {
                Boolean ima = false;
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i].Equals(item)) return true;
                }
                return false;
            }

            public X GetElement(int index)
            {
                if (index > _internalStorage.Length) throw new IndexOutOfRangeException();
                return _internalStorage[index];
            }

            public int IndexOf(X item)
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i].Equals(item)) return i;
                }
                return -1;
            }

            public bool Remove(X item)
            {
                return RemoveAt(IndexOf(item));
            }

            public bool RemoveAt(int index)
            {
                if (index > _internalStorage.Length || index == -1 || _internalStorage[index].Equals(null)) return false;
                _internalStorage = _internalStorage.Where((_internalStorage, indexer) => indexer != index).ToArray();
                return true;
            }
        }
    }
