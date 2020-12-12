using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();
    public int Count => _items.Count;
    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        if (!_items.Contains(item))
        {
            _items.Add(item);
        }
    }
    public T random(int start, int finish)
    {
        System.Random rnd = new System.Random();
        int value = rnd.Next(start, finish - 1);
        return _items[value];
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}

    public class ProcedureGenerate : MonoBehaviour
{
    private string[,] pk;
    void Start()
    {
        pk = new string[25, 24] {{"*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" },
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"}};
        Dictionary<string, int[]> rooms = new Dictionary<string, int[]>(13);

        rooms.Add("1", new int[4] { 1, 1, 0, 0 });
        rooms.Add("2", new int[4] { 1, 0, 1, 0 });
        rooms.Add("3", new int[4] { 1, 0, 0, 1 });
        rooms.Add("4", new int[4] { 0, 1, 1, 0 });
        rooms.Add("5", new int[4] { 0, 1, 0, 1 });
        rooms.Add("6", new int[4] { 0, 0, 1, 1 });
        rooms.Add("7", new int[4] { 1, 1, 1, 0 });
        rooms.Add("8", new int[4] { 1, 1, 0, 1 });
        rooms.Add("9", new int[4] { 1, 0, 1, 1 });
        rooms.Add("e", new int[4] { 0, 1, 1, 1 });
        rooms.Add("f", new int[4] { 1, 1, 1, 1 });

        List<int[]> keys = new List<int[]> {
              new int[4] { 1, 1, 0, 0 }, new int[4] { 1, 0, 1, 0 }, new int[4] { 1, 0, 0, 1 }, new int[4] { 0, 1, 1, 0 }
            , new int[4] { 0, 1, 0, 1 }, new int[4] { 0, 0, 1, 1 }, new int[4] { 1, 1, 1, 0 }, new int[4] { 1, 1, 0, 1 }
            , new int[4] { 1, 0, 1, 1 }, new int[4] { 0, 1, 1, 1 }, new int[4] { 1, 1, 1, 1 }};

        List<string> values = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "e", "f" };


        int random_x = 10;
        int random_y = 10;
        pk[random_y, random_x] = "f";

        int q = 0;
        List<List<int>> room_list = new List<List<int>> { };
        room_list.Add(new List<int> { random_x, random_y });
        while (q < 10)
        {
            Set<List<int>> valid_pos = new Set<List<int>> { };
            for (int i = 0; i < room_list.Count; i++)
            {
                if ((pk[room_list[i][0], room_list[i][1] + 1] == "*") && (pk[room_list[i][0], room_list[i][1]] != "*"))
                {
                    if (rooms[pk[room_list[i][0], room_list[i][1]]][2] == 1)
                    {
                        valid_pos.Add(new List<int> { room_list[i][0], room_list[i][1] + 1 });
                    }
                }
                if (pk[room_list[i][0], room_list[i][1] - 1] == "*" && (pk[room_list[i][0], room_list[i][1]] != "*"))
                {
                    if (rooms[pk[room_list[i][0], room_list[i][1]]][0] == 1)
                    {
                        valid_pos.Add(new List<int> { room_list[i][0], room_list[i][1] - 1 });
                    }
                }
                if (pk[room_list[i][0] + 1, room_list[i][1]] == "*" && (pk[room_list[i][0], room_list[i][1]] != "*"))
                {
                    if (rooms[pk[room_list[i][0], room_list[i][1]]][3] == 1)
                    {
                        valid_pos.Add(new List<int> { room_list[i][0] + 1, room_list[i][1] });
                    }
                }
                if (pk[room_list[i][0] - 1, room_list[i][1]] == "*" && (pk[room_list[i][0], room_list[i][1]] != "*"))
                {
                    if (rooms[pk[room_list[i][0], room_list[i][1]]][1] == 1)
                    {
                        valid_pos.Add(new List<int> { room_list[i][0] - 1, room_list[i][1] });
                    }
                }
            }

            List<int> place = valid_pos.random(0, valid_pos.Count);
            List<int> frees = new List<int> { };
            int[] room = new int[4] { 0, 0, 0, 0 };

            if (pk[place[0] + 1, place[1]] != "*")
            {
                if (rooms[pk[place[0] + 1, place[1]]][1] == 1)
                    room[3] = 1;
            }
            else frees.Add(3);

            if (pk[place[0] - 1, place[1]] != "*")
            {
                if (rooms[pk[place[0] - 1, place[1]]][3] == 1)
                    room[1] = 1;
            }
            else frees.Add(1);

            if (pk[place[0], place[1] + 1] != "*")
            {
                if (rooms[pk[place[0], place[1] + 1]][1] == 1)
                    room[2] = 1;
            }
            else frees.Add(2);

            if (pk[place[0], place[1] - 1] != "*")
            {
                if (rooms[pk[place[0], place[1] - 1]][2] == 1)
                    room[0] = 1;
            }
            else frees.Add(0);


            var rnd = new System.Random(System.DateTime.Now.Millisecond);

            int val = rnd.Next(0, frees.Count);
            room[frees[val]] = 1;
            room_list.Add(new List<int> { place[0], place[1] });
            int value = 0;
            for (int i = 0; i < keys.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (keys[i][j] == room[j])
                    {
                        counter++;
                    }
                }
                if (counter == 4)
                {
                    value = i;
                    break;
                }
            }
            pk[place[0], place[1]] = values[value];
            q += 1;
        }
    }

}
