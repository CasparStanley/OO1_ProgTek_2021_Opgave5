using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO1_5_TCP_Server_FootballPlayer
{
    class FootballPlayer
    {
        private int _id;
        private string _name;
        private double _price;
        private int _shirtNumber;

        /// <summary>
        /// The unique ID of the Football Player.
        /// </summary>
        public int Id
        {
            get => _id;
            set { _id = value; }
        }

        /// <summary>
        /// The name of the Football Player
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckName(value);

                _name = value;
            }
        }

        /// <summary>
        /// The price the Football Player was last sold for
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", value, "Price should never be less than zero.");
                }

                _price = value;
            }
        }

        /// <summary>
        /// The current number on the Football Player's shirt
        /// </summary>
        public int ShirtNumber
        {
            get => _shirtNumber;
            set
            {
                CheckShirtNumber(value);
                _shirtNumber = value;
            }
        }

        public FootballPlayer() { }

        /// <summary>
        /// This is a football player.
        /// </summary>
        /// <param name="id">The unique ID of the Football Player.</param>
        /// <param name="name">The name of the Football Player</param>
        /// <param name="price">The price the Football Player was last sold for</param>
        /// <param name="shirtNo">The current number on the Football Player's shirt</param>
        public FootballPlayer(int id, string name, double price, int shirtNo)
        {
            Id = id;

            CheckName(name);
            CheckPrice(price);
            CheckShirtNumber(shirtNo);

            Name = name;
            Price = price;
            ShirtNumber = shirtNo;
        }

        private static void CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is null or blank");
            }

            if (name.Length < 4)
            {
                throw new ArgumentOutOfRangeException("name", name, "Name should never be shorter than four characters.");
            }
        }

        private static void CheckPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("price", price, "Price should never be less than zero.");
            }
        }

        private static void CheckShirtNumber(int number)
        {
            if (number < 0 || number > 100)
            {
                throw new ArgumentOutOfRangeException("shirtNumber", number, "Shirt Number should never be less than zero or more than one hundred.");
            }
        }

        /// <summary>
        /// Print all the known data about this Football Player
        /// </summary>
        public override string ToString()
        {
            return String.Format("Football Player\n ID: {0}, Name: {1}, Price: {2}, Shirt Number: {3}", Id, Name, Price, ShirtNumber);
        }
    }
}
