using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class TurnTaker
    {   //Parent level Abstract Class

        public PvP_TT PvP_TT;
        public PvAI_TT PvAI_TT;


        public TurnTaker()
        {
            PvP_TT pvp = new PvP_TT();
            PvAI_TT pvpai = new PvAI_TT();
        }

        public void Battle()
        {
            bool isDinosTurn = true;
            while (// Check Score Logic)
            {
                if (isDinosTurn == true)
                {
                    MakeDinoAttack(herd.dinosaurs[0]);
                    isDinosTurn = false;
                }
                else
                {
                    MakeRoboAttack(fleet.robots[0]);
                    isDinosTurn = true;
                }
            }
        }

        public void MakeDinoAttack(Dinosaur dinosaur)
        {
            Console.WriteLine($"Dinosaur {dinosaur.type} is up!");
            ShowOpponents(true);
            int userChoice = Convert.ToInt32(Console.ReadLine());
            dinosaur.Attack(fleet.robots[userChoice]);
            if (fleet.robots[userChoice].health <= 0)
            {
                Console.WriteLine($"{fleet.robots[userChoice].name} has died!\n");
                fleet.robots.RemoveAt(userChoice);
            }
        }

        public void MakeRoboAttack(Robot robot)
        {
            Console.WriteLine($"\nRobot {robot.name} is up!");
            ShowOpponents(false);
            int userChoice = Convert.ToInt32(Console.ReadLine());
            robot.Attack(herd.dinosaurs[userChoice]);
            if (herd.dinosaurs[userChoice].health <= 0)
            {
                Console.WriteLine($"{herd.dinosaurs[userChoice].type} has died!\n");
                herd.dinosaurs.RemoveAt(userChoice);
            }
        }

        public void ShowOpponents(bool isDinosTurn)
        {
            Console.WriteLine("Please select a opponent to attack:");
            if (isDinosTurn)
            {
                for (int i = 0; i < fleet.robots.Count; i++)
                {
                    Console.WriteLine($"{i}) {fleet.robots[i].name}");
                }
            }
            else
            {
                for (int i = 0; i < herd.dinosaurs.Count; i++)
                {
                    Console.WriteLine($"{i}) {herd.dinosaurs[i].type}");
                }
            }

        }

    }
}
