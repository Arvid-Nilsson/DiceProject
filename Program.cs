using System;

namespace diceroller{
    class Dice{
        private int amount;
        private int sides;

        public Dice(int enterAmount, int enterSides){
            amount = enterAmount;
            sides = enterSides;
        }

        public int getamount(){
            return amount;
        }
        public int getsides(){
            return sides;
        }

        public Tuple<int, int[]> rollDice(){
            Random rnd = new Random();
            int sum = 0;
            int[] rolls = new int[amount];

            for(int i = 0; i < amount; i++){
                int roll = rnd.Next(0, sides) + 1;
                sum = sum + roll;
                rolls[i] = roll;
            } 
            
            return new Tuple<int, int[]>(sum, rolls);
        }
    }

    class Program{
        public static void Main(string[] args){
            Dice tarning = new Dice(3, 6);
            var dice = tarning.rollDice();
            string dicerolls = "";
            //foreach(int x in dice.Item2){
            //    dicerolls += $"{x}, ";
            //}
            for(int i = 0; i < dice.Item2.Length; i++){
                int x = dice.Item2[i];
                if(i == dice.Item2.Length - 1){
                    dicerolls += $"och {x}";
                }
                else if(i == dice.Item2.Length - 2){
                    dicerolls += $"{x} ";
                }
                else{
                    dicerolls += $"{x}, ";
                }
            }
            Console.WriteLine($"Du slog {tarning.getamount()}D{tarning.getsides()} och fick {dicerolls} detta blir totalt {dice.Item1}");
        }
    }
}