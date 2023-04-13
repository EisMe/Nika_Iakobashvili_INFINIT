using System;

/*

OOP 2 ( C# )

დავალება 1

ნიკა იაკობაშვილი

*/

namespace Nika_Iakobashvili_INFINIT
{
    internal class INFINIT
    {
        // რიცხვების მასივი, მაქსიმუმ 1000 ელემენტი
        public int[] digits = new int[1000];

        // სიგრძის ცვლადი
        public int length = 0;

        // ნიშანი
        private bool isNegative = false;

        // დეფოლტ კონსტრუქტორი
        public INFINIT()
        {
            for (int i = 0; i < length; i++)
            {
                digits[i] = 0;
            }
        }

        public INFINIT(string number)
        {
            // ვალიდაცია
            if (number.Length > 1000)
            {
                Console.WriteLine("Input is too large");
                return;
            }
            if (number.Length < 1)
            {
                Console.WriteLine("Input is too small");
                return;
            }
            if (number[0] == '-')
            {
                isNegative = true;
                number = number.Remove(0, 1);
            }
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] < '0' || number[i] > '9')
                {
                    Console.WriteLine("Input is not a number");
                    return;
                }
            }
            for (int i = 0; i < number.Length; i++)
            {
                digits[i] = (int)(number[number.Length - i - 1] - 48);
            }
            length = number.Length;
        }

        // კონსოლიდან წაკითხვა
        public void Read()
        {
            string number = Console.ReadLine();
            // ვალიდაცია
            if (number.Length > 1000)
            {
                Console.WriteLine("Input is too large");
                return;
            }
            if (number.Length < 1)
            {
                Console.WriteLine("Input is too small");
                return;
            }
            if (number[0] == '-')
            {
                isNegative = true;
                number = number.Remove(0, 1);
            }
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] < '0' || number[i] > '9')
                {
                    Console.WriteLine("Input is not a number");
                    return;
                }
            }
            for (int i = 0; i < number.Length; i++)
            {
                digits[i] = (int)(number[number.Length - i - 1] - 48);
            }
            length = number.Length;
        }

        // ToStrin-ის გადატვირთვა
        public override string ToString()
        {
            string number = "";
            for (int i = 0; i < length; i++)
            {
                number += (digits[length - i - 1]).ToString();
            }
            if (isNegative)
            {
                number = "-" + number;
            }
            return number;
        }

        // ადარებს ორი ობიექტის მოდულს ( ვიყენებ Plus()-ში )
        public bool CompareModulus(INFINIT b)
        {
            if (length > b.length)
            {
                return true;
            }
            if (length < b.length)
            {
                return false;
            }
            for (int i = length - 1; i >= 0; i--)
            {
                if (digits[i] > b.digits[i])
                {
                    return true;
                }
                if (digits[i] < b.digits[i])
                {
                    return false;
                }
            }
            return false;
        }

        // Plus() მეთოდი ( რადგან მე Minus()-ში გამოვიყენე Plus(),
        // დავამატე არგუმეენტი control რათა გავაკონტროლო რას გამოიტანს ფუნქცია ეკრანზე

        public void Plus(INFINIT b, int control = 0)
        {
            string output = "";
            if (control == 0)
                output += this.ToString() + " + " + b.ToString();
            // თუ ორივე დადებითი ან უარყოფითია
            if (this.isNegative == b.isNegative)
            {
                // ვპოულობ მაქსიმალურ სიგრძეს და ვქმნი ახალ მასივს
                int maxLen = this.length > b.length ? this.length : b.length;
                int[] sum = new int[maxLen + 1];
                // ჯერ ვკრებ თანმიმდევრობით
                for (int i = 0; i < maxLen; i++)
                {
                    sum[i] = this.digits[i] + b.digits[i];
                }
                // შემდეგ თავიდან დავივლი მასივში და თუ რიცხვი > 9 ვაკეთებ საჭირო ოპერაციებს
                for (int i = 0; i < maxLen; i++)
                {
                    if (sum[i] > 9)
                    {
                        sum[i + 1] += sum[i] / 10;
                        sum[i] %= 10;
                    }
                }
                // თუ მათი შეკრებით რიცხვი ერთი ციფრით გაიზარდა, ვითვალისწინებ და ვზრდი
                if (sum[maxLen] > 0)
                {
                    maxLen++;
                }
                // გადამაქვს მასივი
                for (int i = 0; i < maxLen; i++)
                {
                    this.digits[i] = sum[i];
                }
               
                this.length = maxLen;

                output += "= " + this.ToString();

                Console.WriteLine(output);
            }
            else
            {
                // თუ ეს არის ურაყოფითი და მეორე დადებითი
                if (this.isNegative)
                {
                    // თუ ეს მოდულით მეტია 
                    if (this.CompareModulus(b))
                    {
                        // აღარ აღვწერ იგივე კოდს
                        
                        int maxLen = this.length;
                        int[] sum = new int[maxLen];

                        for (int i = 0; i < maxLen; i++)
                        {
                            sum[i] = this.digits[i] - b.digits[i];
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            if (sum[i] < 0)
                            {
                                sum[i + 1] -= 1;
                                sum[i] += 10;
                            }
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            this.digits[i] = sum[i];
                        }

                        this.length = maxLen;
                        // ვაშორებ ზედმეტ ნულებს
                        while (this.digits[this.length - 1] == 0 && this.length > 1)
                        {
                            this.length--;
                        }
                        // თუ საბოლოო პასუხი ნულია მაშინ მოვაშორებ მინუსს
                        if (length == 1 && digits[0] == 0)
                        {
                            isNegative = false;
                        }
                        output += "= " + this.ToString();
                        Console.WriteLine(output);
                    }
                    else
                    {
                        // თუ მეორე რიცხვი მოდულით უფრო დიდია
                        int maxLen = b.length;
                        int[] sum = new int[maxLen];

                        for (int i = 0; i < maxLen; i++)
                        {
                            sum[i] = b.digits[i] - this.digits[i];
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            if (sum[i] < 0)
                            {
                                sum[i + 1] -= 1;
                                sum[i] += 10;
                            }
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            this.digits[i] = sum[i];
                        }

                        this.length = maxLen;
                        this.isNegative = false;
                        
                        while (this.digits[this.length - 1] == 0 && this.length > 1)
                        {
                            this.length--;
                        }
                        if (length == 1 && digits[0] == 0)
                        {
                            isNegative = false;
                        }
                        output += "= " + this.ToString();
                        Console.WriteLine(output);
                    }
                }
                // თუ ეს არის დადებითი და მეროე უარყოფითი
                else
                {
                    if (this.CompareModulus(b))
                    {
                        int maxLen = this.length;
                        int[] sum = new int[maxLen];

                        for (int i = 0; i < maxLen; i++)
                        {
                            sum[i] = this.digits[i] - b.digits[i];
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            if (sum[i] < 0)
                            {
                                sum[i + 1] -= 1;
                                sum[i] += 10;
                            }
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            this.digits[i] = sum[i];
                        }

                        this.length = maxLen;
                        while (this.digits[this.length - 1] == 0 && this.length > 1)
                        {
                            this.length--;
                        }
                        if (length == 1 && digits[0] == 0)
                        {
                            isNegative = false;
                        }
                        output += "= " + this.ToString();
                        Console.WriteLine(output);
                    }
                    else

                    {
                        int maxLen = b.length;
                        int[] sum = new int[maxLen];

                        for (int i = 0; i < maxLen; i++)
                        {
                            sum[i] = b.digits[i] - this.digits[i];
                        }

                        for (int i = 0; i < maxLen; i++)
                        {
                            if (sum[i] < 0)
                            {
                                sum[i + 1] -= 1;
                                sum[i] += 10;
                            }
                        }
                        for (int i = 0; i < maxLen; i++)
                        {
                            this.digits[i] = sum[i];
                        }

                        this.length = maxLen;
                        this.isNegative = true;
                        while (this.digits[this.length - 1] == 0 && this.length > 1)
                        {
                            this.length--;
                        }
                        if (length == 1 && digits[0] == 0)
                        {
                            isNegative = false;
                        }
                        output += "= " + this.ToString();
                        Console.WriteLine(output);
                    }
                }
            }
        }

        public void Minus(INFINIT b)
        {
            // რადგან
            //  a -   b  =  a + (-b)
            // -a -   b  = -a + (-b)
            //  a - (-b) =  a +   b
            // -a - (-b) = -a +   b
            // გადავწყიტე გამომეყენებინა Plus()
            string output = "";
            output += this.ToString() + " - " + b.ToString();
            Console.WriteLine(output);

            b.isNegative = !b.isNegative;
            // გადავცემ დამატებით 1-ს
            this.Plus(b, 1);
            b.isNegative = !b.isNegative;
        }

        public void Times(INFINIT b)
        {
            string output = "";
            output += this.ToString() + " * " + b.ToString();

            int maxLen = this.length + b.length;
            int[] sum = new int[maxLen + 1];

            for (int i = 0; i < this.length; i++)
            {
                for (int j = 0; j < b.length; j++)
                {
                    sum[i + j] += this.digits[i] * b.digits[j];
                }
            }

            for (int i = 0; i < maxLen; i++)
            {
                if (sum[i] > 9)
                {
                    sum[i + 1] += sum[i] / 10;
                    sum[i] %= 10;
                }
            }

            if (sum[maxLen] > 0)
            {
                maxLen++;
            }

            for (int i = 0; i < maxLen; i++)
            {
                this.digits[i] = sum[i];
            }

            this.length = maxLen;
            this.isNegative = this.isNegative != b.isNegative;

            while (this.digits[this.length - 1] == 0 && this.length > 1)
            {
                this.length--;
            }
            if (length == 1 && digits[0] == 0)
            {
                isNegative = false;
            }

            output += " = " + this.ToString();
            Console.WriteLine(output);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new INFINIT();
            var b = new INFINIT();
            a.Read();
            b.Read();
            a.Plus(b);
            a.Minus(b);
            a.Times(b);
        }
    }
}