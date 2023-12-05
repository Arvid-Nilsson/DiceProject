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

        public string rollDice(){
            Random rnd = new Random();
            int sum = 0;
            int[] rolls = new int[amount];
            string rollsString = "";

            for(int i = 0; i < amount; i++){
                int roll = rnd.Next(0, sides) + 1;
                sum = sum + roll;
                rolls[i] = roll;

                if(i == amount - 1){
                    rollsString += $"och {roll}";
                }
                else if(i == amount - 2){
                    rollsString += $"{roll} ";
                }
                else{
                    rollsString += $"{roll}, ";
                }
            } 
            return $"Du slog {this.getamount()}D{this.getsides()} och fick {rollsString} detta blir totalt {sum}";
        }
    }

    class Program{
        public static void Main(string[] args){
            Dice tarning = new Dice(3, 6);
            
            Console.WriteLine(tarning.rollDice());
        }
    }
}
