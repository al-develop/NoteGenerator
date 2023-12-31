using System;
using System.Collections.ObjectModel;

namespace NoteGenerator.Tools;

public static class ShuffleExtension
{
    public static void Shuffle<T>(this ObservableCollection<T> collection)
    {
        Random rnd = new Random();
        for(var i=collection.Count; i > 0; i--)
            collection.Swap(0, rnd.Next(0, i));
    }

    public static void Swap<T>(this ObservableCollection<T> collection, int i, int j)
    {
        var temp = collection[i];
        collection[i] = collection[j];
        collection[j] = temp;
    }
}