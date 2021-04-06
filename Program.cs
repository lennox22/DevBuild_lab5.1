using System;
using System.Collections.Generic;

namespace RPG
{
    class GameCharacter
    {
        private string pName;
        private int pStrength;
        private int pIntelligence;

        public GameCharacter(string nombre, int strong, int smart)
        {
            pName = nombre;
            pStrength = strong;
            pIntelligence = smart;
        }
        public string name
        {
            get
            {
                return pName;
            }
            set
            {
                pName = value;
            }
        }
        public int Strength
        {
            get
            {
                return pStrength;
            }
            set
            {
                pStrength = value;
            }
        }
        public int Intelligence
        {
            get
            {
                return pIntelligence;
            }
            set
            {
                pIntelligence = value;
            }
        }

        public virtual string Play()
        {
            return $"The player is {pName} with a strength of {pStrength} and intelligence of {pIntelligence}.";
        }
    }

    class Warrior : GameCharacter
    {
        private string pWeaponType;

        public Warrior(string nombre, int strong, int smart, string WeaponType) : base(nombre, strong, smart)
        {
            pWeaponType = WeaponType;
        }
        public string WeaponType
        {
            get
            {
                return pWeaponType;
            }
            set
            {
                pWeaponType = value;
            }
        }

        public override string Play()
        {
            return $"The player is {name} with a strength of {Strength} and intelligence of {Intelligence}.\n{name} uses {pWeaponType}.";
        }
    }

    class MagicUsing : GameCharacter
    {
        private int pMagicEnergy;

        public MagicUsing(string nombre, int strong, int smart, int MagicEnergy) : base(nombre, strong, smart)
        {
            pMagicEnergy = MagicEnergy;
        }

        public int MagicEnergy
        {
            get
            {
                return pMagicEnergy;
            }
            set
            {
                pMagicEnergy = value;
            }
        }

        public override string Play()
        {
            return $"The player is {name} with a strength of {Strength} and intelligence of {Intelligence} and magic energy of {pMagicEnergy}.";
        }
    }

    class Wizard : MagicUsing
    {
        private int pSpellNumber;

        public Wizard(string nombre, int strong, int smart, int MagicEnergy, int SpellNumber) : base(nombre, strong, smart, MagicEnergy)
        {
            pSpellNumber = SpellNumber;
        }

        public int SpellNumber
        {
            get
            {
                return pSpellNumber;
            }
            set
            {
                pSpellNumber = value;
            }
        }

        public override string Play()
        {
            return $"The player is {name} with a strength of {Strength} and intelligence of {Intelligence} and magic energy of {MagicEnergy}.\n{name} has {pSpellNumber} spells.";
        }
    }

    class Program
    {

        public static List<GameCharacter> newCharacter = new List<GameCharacter>();

        static void Main(string[] args)
        {
            bool loop = true;

            do
            {


                BuildCharacters();

                Console.Write("Welcome to the World of Dev.Buildcraft!\n\n");

                DisplayChar();

                loop = ContinueYN();


            } while (loop);

            //foreach (GameCharacter person in newCharacter)
            //{
            //    Console.WriteLine(person.Play());
            //}
        }

        static void InvalidMessages()
        {

            Console.Write($"\n\nThat was not a valid answer.\nPlease enter either y or n: ");


        }

        static bool ContinueYN()
        {
            bool loopAgain = true;

            string input;

            bool notvalid = true;

            do
            {
                Console.Write($"\n\nPlay again? (y/n): ");
                input = Console.ReadLine().ToLower();

                if (input != "y" && input != "n")
                {
                    InvalidMessages();
                }
                else
                {
                    notvalid = false;

                    if (input == "n")
                    {
                        loopAgain = false;
                    }
                }
            } while (notvalid);

            Console.Clear();

            return loopAgain;

        }

        static void DisplayChar()
        {
            for (int i = 0; i < newCharacter.Count; i++)
            {
                Console.WriteLine(newCharacter[i].Play());
                Console.WriteLine();
            }
        }
        static void BuildCharacters()
        {

            //Warrior Berzerk = new Warrior("Berzerk the Calm", 25, 2, "their stupid huge hands");
            //Warrior Brandish = new Warrior("Brandish the Warrior", 18, 4, "Morning Star");
            //Warrior Birkdale = new Warrior("Birkdale the Knight", 17, 14, "Long Sword");
            //Wizard Zipzap = new Wizard("Zipzap the Wise", 9, 18, 20, 16);
            //Wizard Crusible = new Wizard("Crusible the Scorcerer", 10, 17, 16, 25);
            //Wizard Krokro = new Wizard("Krokro the Imperceptible", 5, 20, 35, 100);
            newCharacter.Add(new Wizard("Krokro the Imperceptible", 5, 20, 35, 100));
            newCharacter.Add(new Wizard("Crusible the Scorcerer", 10, 17, 16, 25));
            newCharacter.Add(new Wizard("Zipzap the Wise", 9, 18, 20, 16));
            newCharacter.Add(new Warrior("Birkdale the Knight", 17, 14, "Long Sword"));
            newCharacter.Add(new Warrior("Brandish the Warrior", 18, 4, "Morning Star"));
            newCharacter.Add(new Warrior("Berzerk the Calm", 25, 2, "their stupid huge hands"));

            //Console.WriteLine(Krokro.Play());


        }
    }
}
