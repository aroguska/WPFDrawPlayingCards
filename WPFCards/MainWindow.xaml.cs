using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;


namespace WPFCards
{
    public partial class MainWindow : Window
    {
        Deck cards = new Deck();
        List<Cards> listOfMyCards = new List<Cards>();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Shuffle(object sender, RoutedEventArgs e)
        {
            LeftDeck.Items.Clear();
            cards.Shuffle();
            for (int i = 0; i < cards.Count; i++)
            {
                LeftDeck.Items.Add(cards[i]);
            }
        }

        private void Sort(object sender, RoutedEventArgs e)
        {
            listOfMyCards.Sort();
            RightDeck.Items.Clear();
            for (int i = 0; i < listOfMyCards.Count; i++)
            {
                RightDeck.Items.Add(listOfMyCards[i]);
            }
        }

        private void Place(object sender, RoutedEventArgs e)
        {
            if (listOfMyCards.Count > 0)
            {
                int index = random.Next(0, listOfMyCards.Count);
                cards.Add(listOfMyCards[index]);
                listOfMyCards.RemoveAt(index);
                RightDeck.Items.Clear();

                for (int i = 0; i < listOfMyCards.Count; i++)
                {
                    RightDeck.Items.Add(listOfMyCards[i]);
                }
                LeftDeck.Items.Clear();

                for (int i = 0; i < cards.Count; i++)
                {
                    LeftDeck.Items.Add(cards[i]);
                }
            }
            else
                MessageBox.Show("You don't have any card.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Draw(object sender, RoutedEventArgs e)
        {
            if (cards.Count > 0)
            {
                int index = random.Next(0, cards.Count);
                listOfMyCards.Add(cards[index]);
                cards.RemoveAt(index);

                LeftDeck.Items.Clear();

                for (int i = 0; i < cards.Count; i++)
                {
                    LeftDeck.Items.Add(cards[i]);
                }

                RightDeck.Items.Clear();

                for (int i = 0; i < listOfMyCards.Count; i++)
                {
                    RightDeck.Items.Add(listOfMyCards[i]);
                }
            }
            else
                MessageBox.Show("Deck of cards is empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            LeftDeck.Items.Clear();
            cards.Reset();
            for (int i = 0; i < cards.Count; i++)
            {
                LeftDeck.Items.Add(cards[i]);
            }
            RightDeck.Items.Clear();
            listOfMyCards.Clear();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            if (File.Exists(projectDirectory))
            { 
                File.Delete(projectDirectory);
            }

            using (var vs = new StreamWriter($@"{projectDirectory}\Output\Right_And_Left_Deck.txt"))
            {
                vs.WriteLine("Left Deck");
                vs.WriteLine();
                for (int i = 0; i < cards.Count; i++)
                {
                    vs.WriteLine($"{i+1}. {cards[i].Name}");
                }
                vs.WriteLine();
                vs.WriteLine("Right Deck");
                vs.WriteLine();
                for (int i = 0; i < listOfMyCards.Count; i++)
                {
                    vs.WriteLine($"{i+1}. {listOfMyCards[i].Name}");
                }
            }
        }

    }
}
