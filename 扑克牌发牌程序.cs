using System;
using System.Collections.Generic;
using System.Text;
//�˿��Ʒ��Ƴ���
namespace ���Ƴ���
{
    class card
    {
        // Suitָ���ǻ�ɫ��1Ϊ÷����2Ϊ���꣬3Ϊ���ģ�4Ϊ����  
        public byte Suit;
        public byte FaceNum ;   // FaceNum ָ������������ 1--13 
        public card(byte Suit, byte FaceNum )//���캯��
        {
            this.FaceNum  = FaceNum ;
            this.Suit = Suit;
        }
        public int pic_order()//�Ƶ�˳���
        {
            return (Suit - 1) * 13 + FaceNum ;
        }
        public override string ToString()//����ToString()����
        {
            string SuitName;//��ɫ��
            switch (Suit)
            {
                case 1:
                    SuitName = "÷";
                    break;
                case 2:
                    SuitName = "��";
                    break;
                case 3:
                    SuitName = "��";
                    break;
                case 4:
                    SuitName = "��";
                    break;
                default:
                    SuitName = "";
                    break;
            }
            string FaceNumName;//���������
            switch (FaceNum )
            {
                case 1:
                    FaceNumName = "A";
                    break;
                case 11:
                    FaceNumName = "J";
                    break;
                case 12:
                    FaceNumName = "Q";
                    break;
                case 13:
                    FaceNumName = "K";
                    break;
                default:
                    FaceNumName = FaceNum .ToString();
                    break;
            }
            return string.Format("{0}{1}", SuitName, FaceNumName);
        }
    }
    class Poke//һ����
    {   //���б�CardList
        public static List<card> CardList = new List<card>();
        public static Random r = new Random();
        public Poke()
        {
            for (byte i = 1; i <= 4; i++)
            {
                for (byte j = 1; j <= 13; j++)
                {
                    CardList.Add(new card(i, j));
                }
            }
        }
        public card Shuffle()//����
        {
            if (CardList.Count <= 0) return null;
            card c = null;
            int i = (int)(CardList.Count * r.NextDouble());//�������������
            c = CardList[i];//��ȡ������Ϊ�����
            CardList.RemoveAt(i);//���б���ɾ��������
            return c;//���س�ȡ������Ϊ�����
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Poke Poke1 = new Poke();//Pokeʵ��Poke1
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("{0}������:", i);
                for (int j = 1; j <= 13; j++)
                {
                    card card1 = Poke1.Shuffle();//��ȡһ����
                    if (card1 != null)
                    {
                        Console.Write(" {0}", card1.ToString());
                        //Console.Write(":{0}", card1.pic_order());
                    }             
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
