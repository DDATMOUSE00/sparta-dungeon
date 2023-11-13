internal class Program
{
    private static Character player;
    private static Item item;
    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 값
        player = new Character("르탄", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 값
        item = new Item("낡은 검", 2, false, "무쇠갑옷", 5, false);

        //아이템 착용 여부
    }

    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        //아이템 스탯 관리
        public int ItemAD { get; }
        public int ItemDF { get; }
        public bool Aduse { get; set; }
        public bool Dfuse { get; set; }

        public Item(string sword, int AD, bool ADuse, string shield, int DF, bool DFuse)
        {
            ItemAD = AD;
            ItemDF = DF;
            Aduse = ADuse;
            Dfuse = DFuse;
        }
    }



    static void DisplayGameIntro()
    {
        //시작화면
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 3);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            case 2:
                DisplayInventory();
                break;
            case 3:
                DisplayShop();
                break;
        }
    }

    static void DisplayMyInfo()
    {
        //캐릭터 정보
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        if (item.Aduse == true)
        {
            Console.WriteLine($"공격력 : {player.Atk}(+{item.ItemAD})");
        } else
        {
            Console.WriteLine($"공격력 : {player.Atk}");
        }
        if (item.Dfuse == true)
        {
            Console.WriteLine($"방어력 : {player.Def}(+{item.ItemDF})");
        } else
        {
            Console.WriteLine($"방어력 : {player.Def}");
        }
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");



        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }
    
    
    static void DisplayInventory()
    {
        //인벤토리
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine($"- 낡은 검       | +({item.ItemAD})  | 쉽게 볼 수 있는 낡은 검 입니다.");
        Console.WriteLine($"- 무쇠갑옷      | +({item.ItemDF})  | 무쇠로 만들어져 튼튼한 갑옷입니다.");
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 1:
                DisplayItemuse();
                break;
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayItemuse()
    {
        //아이템 착용 관리
        Console.Clear();

        Console.WriteLine("인벤토리 - 장착 관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine($"- 1 낡은 검       | +({item.ItemAD})  | 쉽게 볼 수 있는 낡은 검 입니다.");
        Console.WriteLine($"- 2 무쇠갑옷      | +({item.ItemDF})  | 무쇠로 만들어져 튼튼한 갑옷입니다.");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 2);
        switch (input)
        {
            case 0:
                DisplayInventory();
                break;
            case 1:
                if (item.Aduse == false)
                {
                    item.Aduse = true;
                } else
                {
                    item.Aduse = false;
                }
                break;
            case 2:
                if (item.Dfuse == false)
                {
                    item.Dfuse = true;
                }
                else
                {
                    item.Dfuse = false;
                }
                break;
        }

    }
    static void DisplayShop()
    {
        //상점
        Console.Clear();

        Console.WriteLine("상점에 오신걸 환영합니다.");

        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}


