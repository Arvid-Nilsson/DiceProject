using System;

namespace diceroller{
    class Dice{
        private int amount;
        private int sides;

        //property for amount, checks so that more than 1 dice is rolld
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
        //property for sides, checks if the dice has at least 2 sides. 1 side whould be imposible
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
        //Constructor for enering sides and ampunt as sepparet intagers
        public Dice(int enterAmount, int enterSides){
            Amount = enterAmount;
            Sides = enterSides;
        }
        //Constructor for entering a string in the format xDx or xTx even though xTx is wrong
        public Dice(string input){
            string inputLower = input.ToLower();
            int dPosition = inputLower.IndexOf("d");
            int length = inputLower.Length;
            
            //adds compatability with the format xTx
            if(dPosition == -1 && inputLower.Contains("t") == true){
                dPosition = inputLower.IndexOf("t");
                Console.WriteLine("Skriv inte in T, det är D men jag kommer tillåta det den här gången\n");
            }

            //Writing the amount and sides to the private amount and sides through their properties
            Amount = int.Parse(inputLower.Substring(0,dPosition));
            Sides = int.Parse(inputLower.Substring(dPosition + 1, length - dPosition - 1)); 
        }

        //Rolls the dice
        public string rollDice(){
            Random rnd = new Random();
            int sum = 0;
            string rollsString = "";

            for(int i = 0; i < amount; i++){
                int roll = rnd.Next(0, sides) + 1;
                sum = sum + roll;

                //Makes the a string of the array of rolls
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
            return $"Du slog {this.amount}D{this.sides} och fick {rollsString} detta blir totalt {sum}";
        }
    }

    class Program{
        public static void Main(string[] args){
            Dice tarning = new Dice("20t6");
            
            Console.WriteLine(tarning.rollDice());
        }
    }
}
