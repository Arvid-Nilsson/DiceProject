using System;

namespace diceroller{
    class Tarning{
        private int amount;
        private int sides;

        public int Amount{
            get{return Amount;}

            set{
                if(value >= 1){
                    amount = value;
                }
                else{
                    amount = 1;
                }
            }
        }
        public int Sides{
            get{return Amount;}

            set{
                if(value >= 2){
                    sides = value;
                }
                else{
                    amount = 2;
                }
            }
        }

        public Tarning(int enterAmount, int enterSides){
            Amount = enterAmount;
            Sides = enterSides;
        }
        public Tarning(string input){
            string inputLower = input.ToLower();
            int dPosition = inputLower.IndexOf("d");
            int length = inputLower.Length;
            
            if(dPosition == -1 && inputLower.Contains("t") == true){
                dPosition = inputLower.IndexOf("t");
                Console.WriteLine("Skriv inte in T, det är D men jag kommer tillåta det den här gången\n");
            }

            Amount = int.Parse(inputLower.Substring(0,dPosition));
            Sides = int.Parse(inputLower.Substring(dPosition + 1, length - dPosition - 1)); 
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
            Tarning tarning = new Tarning("3D6");
            
            Console.WriteLine(tarning.rollDice());
        }
    }
}
