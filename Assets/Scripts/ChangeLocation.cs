using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeLocation : MonoBehaviour
{
    public GameObject doors_open;
    public GameObject up_doors;
    public GameObject left_doors;
    public GameObject down_doors;
    public GameObject right_doors;
    public GameObject Exit;
    private int TimeForExit = 7;
    public GameObject Fly_Enemy;
    public GameObject Ground_Enemy;
    public Text mytext;
    public Transform[] f_fly;
    public Transform[] f_ground;
    public Transform[] fly_1;
    public Transform[] ground_1;
    public Transform[] fly_2;
    public Transform[] ground_2;
    public Transform[] fly_3;
    public Transform[] ground_3;
    public Transform[] fly_4;
    public Transform[] ground_4;
    public Transform[] fly_5;
    public Transform[] ground_5;
    public Transform[] fly_6;
    public Transform[] ground_6;
    public Transform[] fly_7;
    public Transform[] ground_7;
    public Transform[] fly_8;
    public Transform[] ground_8;
    public Transform[] fly_9;
    public Transform[] ground_9;
    public Transform[] e_fly;
    public Transform[] e_ground;
    int curent_posX = 10;
    int curent_posY = 10;
    public GameObject Player;
    public Transform f0;
    public Transform f1;
    public Transform f2;
    public Transform f3;
    public Transform n10;
    public Transform n11;
    public Transform n20;
    public Transform n22;
    public Transform n30;
    public Transform n33;
    public Transform n41;
    public Transform n42;
    public Transform n51;
    public Transform n53;
    public Transform n62;
    public Transform n63;
    public Transform n70;
    public Transform n71;
    public Transform n72;
    public Transform n80;
    public Transform n81;
    public Transform n83;
    public Transform n90;
    public Transform n92;
    public Transform n93;
    public Transform e1;
    public Transform e2;
    public Transform e3;
    string[,] map;
    Dictionary<string, int[]> rooms = new Dictionary<string, int[]>(13);
    private int lastval = 0;
    public bool CanIGo = true;
    private List<int[]> roomsWhereIwas = new List<int[]>();
    private Enemy[] isAnyoneHere;

    //Dictionary<string, float[]> coord = new Dictionary<string, float[]>(13);
    // Start is called before the first frame update
    void Start()
    {
        map = new string[25, 24] {{"*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" },
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

        List<int[]> keys = new List<int[]>() {
              new int[4] { 1, 1, 0, 0 }, new int[4] { 1, 0, 1, 0 }, new int[4] { 1, 0, 0, 1 }, new int[4] { 0, 1, 1, 0 }
            , new int[4] { 0, 1, 0, 1 }, new int[4] { 0, 0, 1, 1 }, new int[4] { 1, 1, 1, 0 }, new int[4] { 1, 1, 0, 1 }
            , new int[4] { 1, 0, 1, 1 }, new int[4] { 0, 1, 1, 1 }, new int[4] { 1, 1, 1, 1 }};

        List<string> values = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "e", "f" };


        int random_x = 10;
        int random_y = 10;
        map[random_y, random_x] = "f";

        int q = 0;
        List<List<int>> room_list = new List<List<int>> ();
        room_list.Add(new List<int> { random_x, random_y });
        string debug_line = "";
        int lastoffrees = -1;
        while (q < 10)
        {
            List<List<int>> valid_pos = new List<List<int>> ();
            foreach (var i in room_list)
            {
                if (map[i[0], i[1] + 1] == "*")
                {
                    if (rooms[map[i[0], i[1]]][2] == 1)
                    {
                        if (!valid_pos.Contains( new List<int>() {i[0], i[1] + 1}))
                        {
                            Debug.Log("puk");
                            valid_pos.Add(new List<int>() { i[0], i[1] + 1});
                        }
                    }
                }
                if (map[i[0], i[1] - 1] == "*")
                {
                    if (rooms[map[i[0], i[1]]][0] == 1)
                    {
                        if (!valid_pos.Contains(new List<int>() { i[0], i[1] - 1 }))
                        {
                            Debug.Log("puk");
                            valid_pos.Add(new List<int>() { i[0], i[1] - 1 });
                        }
                    }
                }
                if (map[i[0] + 1, i[1]] == "*")
                {
                    if (rooms[map[i[0], i[1]]][3] == 1)
                    {
                        if (!valid_pos.Contains(new List<int>() { i[0] + 1, i[1] }))
                        {
                            Debug.Log("puk");
                            valid_pos.Add(new List<int>() { i[0] + 1, i[1] });
                        }
                    }
                }
                if (map[i[0] - 1, i[1]] == "*")
                {
                    if (rooms[map[i[0], i[1]]][1] == 1)
                    {
                        if (!valid_pos.Contains(new List<int>() { i[0] - 1, i[1] + 1 }))
                        {
                            Debug.Log("puk");
                            valid_pos.Add(new List<int>() { i[0] - 1, i[1]});
                        }
                    }
                }
            }
            for (int i =0; i < valid_pos.Count; i++)
            {
                for (int j =0; j<valid_pos[i].Count; j++)
                {
                    debug_line += valid_pos[i][j].ToString();
                }
                debug_line += "\n";
            }
            bool flag = false;
            
            var rnd = new System.Random();
            int val = rnd.Next(0, valid_pos.Count);
            while (flag == false)
            {
                if (lastval == val)
                {
                    val = rnd.Next(0, valid_pos.Count);
                }
                else
                {
                    flag = true;
                }
            }
            lastval = val;
            List<int> place = valid_pos[val];
            List<int> frees = new List<int>();
            int[] room = new int[4] { 0, 0, 0, 0 };

            if (map[place[0] + 1, place[1]] != "*")
            {
                if (rooms[map[place[0] + 1, place[1]]][1] == 1)
                    room[3] = 1;
            }
            else frees.Add(3);

            if (map[place[0] - 1, place[1]] != "*")
            {
                if (rooms[map[place[0] - 1, place[1]]][3] == 1)
                    room[1] = 1;
            }
            else frees.Add(1);

            if (map[place[0], place[1] + 1] != "*")
            {
                if (rooms[map[place[0], place[1] + 1]][0] == 1)
                    room[2] = 1;
            }
            else frees.Add(2);

            if (map[place[0], place[1] - 1] != "*")
            {
                if (rooms[map[place[0], place[1] - 1]][2] == 1)
                    room[0] = 1;
            }
            else frees.Add(0);
            flag = false;
            val = rnd.Next(0, frees.Count);
            while (flag == false)
            {
                if (lastoffrees == val)
                {
                    val = rnd.Next(0, frees.Count);
                }
                else
                {
                    flag = true;
                }
            }
            lastoffrees = val;
            
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
            map[place[0], place[1]] = values[value];
            q += 1;
        }

        string finalLine = "";
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                finalLine = finalLine + map[i, j];
            }
            finalLine += "\n";
        }
        mytext.text = finalLine;
        //coord.Add("1(0)", new float[2] { 150f, 19f });
        //coord.Add("1(1)", new float[2] { 166f, 33f });
        //coord.Add("2(0)", new float[2] { -73f, 88f });
        //coord.Add("2(2)", new float[2] { -112f, 91f });
        //coord.Add("3(0)", new float[2] { 0f, 89f });
        //coord.Add("3(3)", new float[2] { 16f, 73f });
        //coord.Add("4(1)", new float[2] { 92f, 103f });
        //coord.Add("4(2)", new float[2] { 36f, 91f });
        //coord.Add("5(1)", new float[2] { 166f, 103f });
        //coord.Add("5(3)", new float[2] { 166f, 73f });
        //coord.Add("6(2)", new float[2] { 15f, -72f });
        //coord.Add("6(3)", new float[2] { -188f, 21f });
        //coord.Add("7(0)", new float[2] { -73f, 19f });
        //coord.Add("7(1)", new float[2] { -58f, 33f });
        //coord.Add("7(2)", new float[2] { -112f, 21f });
        //coord.Add("8(0)", new float[2] { 1f, 19f });
        //coord.Add("8(1)", new float[2] { 16f, 33f });
        //coord.Add("8(3)", new float[2] { 16f, 3f });
        //coord.Add("9(0)", new float[2] { 76f, 19f });
        //coord.Add("9(2)", new float[2] { 37f, 22f });
        //coord.Add("9(3)", new float[2] { 92f, 3f });
        //coord.Add("e(1)", new float[2] { -134f, 37f });
        //coord.Add("e(2)", new float[2] { -188f, 49f });
        //coord.Add("e(3)", new float[2] { -135f, 66f });
        //coord.Add("f(0)", new float[2] { -15f, -1f });
        //coord.Add("f(1)", new float[2] { 0f, 14f });
        //coord.Add("f(2)", new float[2] { 15f, -1f });
        //coord.Add("f(3)", new float[2] { 0f, -16f });
    }
    void TeleportAndSpawn(GameObject Player, string what_door)
    {
        if (!roomsWhereIwas.Contains(new int[]{ curent_posX, curent_posY }))
        {
            TimeForExit += 1;
            roomsWhereIwas.Add(new int[] { curent_posX, curent_posY });
        }             
        switch (what_door[0].ToString())
        {
            case "f":
                foreach (var a in f_fly)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in f_ground)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "1":
                foreach (var a in fly_1)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_1)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "2":
                foreach (var a in fly_2)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_2)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "3":
                foreach (var a in fly_3)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_3)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "4":
                foreach (var a in fly_4)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_4)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "5":
                foreach (var a in fly_5)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_5)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "6":
                foreach (var a in fly_6)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_6)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "7":
                foreach (var a in fly_7)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_7)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "8":
                foreach (var a in fly_8)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_8)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "9":
                foreach (var a in fly_9)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in ground_9)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;
            case "e":
                foreach (var a in e_fly)
                {
                    Instantiate(Fly_Enemy, a.position, Quaternion.identity);
                }
                foreach (var a in e_ground)
                {
                    Instantiate(Ground_Enemy, a.position, Quaternion.identity);
                }
                break;

        }
        switch (what_door)
        {
            case "f(0)":
                Player.transform.position = f0.position;
                break;
            case "f(1)":
                Player.transform.position = f1.position;
                break;
            case "f(2)":
                Player.transform.position = f2.position;
                break;
            case "f(3)":
                Player.transform.position = f3.position;
                break;
            case "1(0)":
                Player.transform.position = n10.position;
                break;
            case "1(1)":
                Player.transform.position = n11.position;
                break;
            case "2(0)":
                Player.transform.position = n20.position;
                break;
            case "2(2)":
                Player.transform.position = n22.position;
                break;
            case "3(0)":
                Player.transform.position = n30.position;
                break;
            case "3(3)":
                Player.transform.position = n33.position;
                break;
            case "4(1)":
                Player.transform.position = n41.position;
                break;
            case "4(2)":
                Player.transform.position = n42.position;
                break;
            case "5(1)":
                Player.transform.position = n51.position;
                break;
            case "5(3)":
                Player.transform.position = n53.position;
                break;
            case "6(2)":
                Player.transform.position = n62.position;
                break;
            case "6(3)":
                Player.transform.position = n63.position;
                break;
            case "7(0)":
                Player.transform.position = n70.position;
                break;
            case "7(1)":
                Player.transform.position = n71.position;
                break;
            case "7(2)":
                Player.transform.position = n72.position;
                break;
            case "8(0)":
                Player.transform.position = n80.position;
                break;
            case "8(1)":
                Player.transform.position = n81.position;
                break;
            case "8(3)":
                Player.transform.position = n83.position;
                break;
            case "9(0)":
                Player.transform.position = n90.position;
                break;
            case "9(2)":
                Player.transform.position = n92.position;
                break;
            case "9(3)":
                Player.transform.position = n93.position;
                break;
            case "e(1)":
                Player.transform.position = e1.position;
                break;
            case "e(2)":
                Player.transform.position = e2.position;
                break;
            case "e(3)":
                Player.transform.position = e3.position;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("curent_posX - 1, curent_posY - " + map[curent_posX, curent_posY - 1] + "\n" + "curent_posX + 1, curent_posY - " + map[curent_posX, curent_posY + 1] + "\n" +
                "curent_posX, curent_posY - 1 - " + map[curent_posX + 1, curent_posY] + "\n" + "curent_posX, curent_posY + 1 - " + map[curent_posX - 1, curent_posY] + "\n");
        Debug.Log(curent_posX.ToString() + "<-x  y->" + curent_posY.ToString());

        if (other.tag == "left_door" && map[curent_posX, curent_posY - 1] != "*" && CanIGo)
        {
            
            if (rooms[map[curent_posX, curent_posY - 1]][2] == 1)
            {
                
                //Player.transform.position = new Vector2(coord[map[curent_posX - 1, curent_posY] + "(2)"][0], coord[map[curent_posX - 1, curent_posY] + "(2)"][1]);
                TeleportAndSpawn(Player, map[curent_posX, curent_posY - 1] + "(2)");
                curent_posY -= 1;
            }
        }
        if (other.tag == "up_door" && map[curent_posX - 1, curent_posY] != "*" && CanIGo)
        {
            if (rooms[map[curent_posX - 1, curent_posY]][3] == 1)
            {
                TeleportAndSpawn(Player, map[curent_posX - 1, curent_posY] + "(3)");
                curent_posX -= 1;
                //Player.transform.position = new Vector2(coord[map[curent_posX - 1, curent_posY] + "(3)"][0], coord[map[curent_posX - 1, curent_posY] + "(3)"][1]);
            }
        }
        if (other.tag == "right_door" && map[curent_posX, curent_posY + 1] != "*" && CanIGo)
        {
            if (rooms[map[curent_posX, curent_posY + 1]][0] == 1)
            {
                TeleportAndSpawn(Player, map[curent_posX, curent_posY + 1] + "(0)");
                curent_posY += 1;
                //Player.transform.position = new Vector2(coord[map[curent_posX, curent_posY + 1] + "(0)"][0], coord[map[curent_posX, curent_posY + 1] + "(0)"][1]);
            }
        }
        if (other.tag == "down_door" && map[curent_posX + 1, curent_posY] != "*" && CanIGo)
        {
            if (rooms[map[curent_posX + 1, curent_posY]][1] == 1)
            {
                TeleportAndSpawn(Player, map[curent_posX + 1, curent_posY] + "(1)");
                curent_posX += 1;
                //Player.transform.position = new Vector2(coord[map[curent_posX + 1, curent_posY] + "(1)"][0], coord[map[curent_posX + 1, curent_posY] + "(1)"][1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        isAnyoneHere = FindObjectsOfType<Enemy>();
        if (isAnyoneHere.Length == 0)
        {

            CanIGo = true;
        }
        else
        {
            CanIGo = false;
        }
        if (CanIGo)
        {
            if (map[curent_posX - 1, curent_posY] == "*")
            {
                up_doors.SetActive(true);
            }
            if (map[curent_posX, curent_posY - 1] == "*")
            {
                left_doors.SetActive(true);
            }
            if (map[curent_posX + 1, curent_posY] == "*")
            {
                down_doors.SetActive(true);
            }
            if (map[curent_posX, curent_posY + 1] == "*")
            {
                right_doors.SetActive(true);
            }
            doors_open.SetActive(false);
            if (TimeForExit == 9)
            {
                Instantiate(Exit, transform.position, Quaternion.identity);
                TimeForExit = 0;
            }
        } else
        {
            up_doors.SetActive(false);
            left_doors.SetActive(false);
            down_doors.SetActive(false);
            right_doors.SetActive(false);
            doors_open.SetActive(true);
        }
    }
}
